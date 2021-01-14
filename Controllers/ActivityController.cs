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
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ActivityViewModel model)
        {      
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Activity activity = _mapper.Map<Activity>(model);
            await _dbContext.Activities.AddAsync(activity);
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
    }
}
