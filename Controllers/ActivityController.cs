using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FunTogether.Models;
using FunTogether.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FunTogether.Controllers
{
    public class ActivityController : Controller
    {
        private FunTogetherContext _dbContext;
        private readonly IMapper _mapper;

        public ActivityController(FunTogetherContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var activities = await _dbContext.Activities.ToListAsync();
            var modelItems = _mapper.Map<IList<Activity>, IList<ActivitiesIndexViewModel>>(activities);
            return View(modelItems);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activity = await _dbContext.Activities
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (activity == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<ActivityViewModel>(activity);
            return View(model);
        }

        public IActionResult Create()
        {
            var model = new ActivityViewModel
            {
                AgeGroups = _dbContext.Filters.Where(f => f.Category == Filter.FilterCategory.AgeGroup).ToList(),
                Genders = _dbContext.Filters.Where(f => f.Category == Filter.FilterCategory.Gender).ToList()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ActivityViewModel model)
        {      
            if (!ModelState.IsValid)
            {
                model.AgeGroups = _dbContext.Filters.Where(f => f.Category == Filter.FilterCategory.AgeGroup).ToList();
                model.Genders = _dbContext.Filters.Where(f => f.Category == Filter.FilterCategory.Gender).ToList();
                return View(model);
            }

            Activity activity = _mapper.Map<Activity>(model);
            await _dbContext.Activities.AddAsync(activity);

            // Create age group filters for activity
            await CreateActivityFilters(model.AgeGroups, activity);

            // Create gender filters for activity
            await CreateActivityFilters(model.Genders, activity);

            // Create activity type filter for activity
            Filter filter = _dbContext.Filters.FirstOrDefault(f => f.Id == model.ActivityTypeId);
            if (filter != null)
            {
                ActivityFilter activityFilter = new ActivityFilter
                {
                    Activity = activity,
                    Filter = filter
                };
                await _dbContext.ActivityFilters.AddAsync(activityFilter);
            }

            await _dbContext.SaveChangesAsync();
            return View("Details", model);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activity = await _dbContext.Activities.FindAsync(id);
            if (activity == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<ActivityViewModel>(activity);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromRoute] int id, ActivityViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var activity = await _dbContext.Activities.FindAsync(id);
            if (activity == null)
            {
                return NotFound();
            }

            _mapper.Map(model, activity);
            _dbContext.Update(activity);
            await _dbContext.SaveChangesAsync();

            return View("Details", model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var activity = await _dbContext.Activities.FindAsync(id);
            if (activity == null)
            {
                return NotFound();
            }

            _dbContext.Activities.Remove(activity);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        private async Task CreateActivityFilters(List<Filter> filters, Activity activity)
        {
            // Exit if all filters are checked
            if (!filters.Any(f => f.Selected == false)) return;

            foreach (var filter in filters)
            {
                if (filter.Selected)
                {
                    Filter f = _dbContext.Filters.FirstOrDefault(f => f.Id == filter.Id);
                    ActivityFilter activityFilter = new ActivityFilter
                    {
                        Activity = activity,
                        Filter = f
                    };
                    await _dbContext.ActivityFilters.AddAsync(activityFilter);
                }
            }
        }


    }
}
