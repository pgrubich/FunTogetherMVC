using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FunTogether.Models;
using FunTogether.Data;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateActivity(ActivityViewModel model)
        {      
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Activity activity = _mapper.Map<Activity>(model);
            await _dbContext.Activities.AddAsync(activity);
            await _dbContext.SaveChangesAsync();

            return View("Create");
        }
    }
}
