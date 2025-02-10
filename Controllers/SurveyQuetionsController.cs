using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VRS3LOGIN_AUTHENTICATION.Areas.Identity.Data;
using VRS3LOGIN_AUTHENTICATION.Models;

namespace VRS3LOGIN_AUTHENTICATION.Controllers
{
    public class SurveyQuetionsController : Controller
    {
        private readonly VRS3LOGIN_AUTHENTICATIONDbContext _context;

        public SurveyQuetionsController(VRS3LOGIN_AUTHENTICATIONDbContext context)
        {
            _context = context;
        }

        // GET: SurveyQuetions
        public async Task<IActionResult> Index()
        {
              return _context.SurveyQuetions != null ? 
                          View(await _context.SurveyQuetions.ToListAsync()) :
                          Problem("Entity set 'VRS3LOGIN_AUTHENTICATIONDbContext.SurveyQuetions'  is null.");
        }

        // GET: SurveyQuetions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SurveyQuetions == null)
            {
                return NotFound();
            }

            var surveyQuetionsModel = await _context.SurveyQuetions
                .FirstOrDefaultAsync(m => m.Quetionsid == id);
            if (surveyQuetionsModel == null)
            {
                return NotFound();
            }

            return View(surveyQuetionsModel);
        }

        // GET: SurveyQuetions/AddOrEdit

      
        public async Task<IActionResult> AddOrEdit( int id=0)
        {
            if (id == 0)
                return View( new SurveyQuetionsModels());

            else {
                var surveyQuetionsModel = await _context.SurveyQuetions.FindAsync(id);
                if (surveyQuetionsModel == null)
                {
                    return NotFound();
                }
                return View(surveyQuetionsModel);


            }
        }

       
   
        // POST: SurveyQuetions/AddOrEdit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
       
        public async Task<IActionResult> AddOrEdit(int id, [Bind("Quetionsid,Quetions,QuetionsWeightage,Factor")] SurveyQuetionsModels surveyQuetionsModel)
        {
          
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    _context.Add(surveyQuetionsModel);
                    await _context.SaveChangesAsync();

                } 
                else {
                    try
                    {
                        _context.Update(surveyQuetionsModel);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!SurveyQuetionsModelExists(surveyQuetionsModel.Quetionsid))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }

                }


                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_SQAllPartial", _context.SurveyQuetions.ToList())});
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", surveyQuetionsModel)});
        }

      

        // POST: SurveyQuetions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SurveyQuetions == null)
            {
                return Problem("There is no value with this record !");
            }
            var surveyQuetionsModel = await _context.SurveyQuetions.FindAsync(id);
            if (surveyQuetionsModel != null)
            {
                _context.SurveyQuetions.Remove(surveyQuetionsModel);
            }
            
            await _context.SaveChangesAsync();

            return Json(new {  html = Helper.RenderRazorViewToString(this, "_SQAllPartial", _context.SurveyQuetions.ToList()) });
        }

        private bool SurveyQuetionsModelExists(int id)
        {
          return (_context.SurveyQuetions?.Any(e => e.Quetionsid == id)).GetValueOrDefault();
        }
    }
}
 