using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VRS3LOGIN_AUTHENTICATION.Models;
using VRS3LOGIN_AUTHENTICATION.Areas.Identity.Data;

namespace VRS3LOGIN_AUTHENTICATION.Controllers
{
    public class LaunchNewSurveyController : Controller
    {
        private readonly VRS3LOGIN_AUTHENTICATIONDbContext _context;

        public LaunchNewSurveyController(VRS3LOGIN_AUTHENTICATIONDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.surveyName = new SelectList(_context.surveyForms, "id", "SurveyName");
            ViewBag.SurveyQuetions = new SelectList(_context.SurveyQuetions, "Quetionsid", "Quetions");
            return View();
        }

        [HttpPost]
        public IActionResult Index(List<SurveyManagerModel> dataItems)
        {
            if (dataItems != null && dataItems.Count > 0)
            {
                try
                {
                    _context.SurveyManager.AddRange(dataItems);
                    _context.SaveChanges();

                    return Ok("Data saved successfully");
                }
                catch (Exception ex)
                {
                    return BadRequest($"Error saving data: {ex.Message}");
                }
            }

            return BadRequest("Data is empty or invalid");
        }
    }
}
