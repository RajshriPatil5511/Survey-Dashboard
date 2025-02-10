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
    public class SurveyFormsController : Controller
    {
        private readonly VRS3LOGIN_AUTHENTICATIONDbContext _context;

        public SurveyFormsController(VRS3LOGIN_AUTHENTICATIONDbContext context)
        {
            _context = context;
        }


        // GET: SurveyForms
        public IActionResult Index()
        {
            var ListOfSurveys = _context.surveyForms.ToList();
            return View(ListOfSurveys);
        }

        // GET: SurveyForms/Details/5
        public IActionResult Details(int? id)
        {

            var surveyForms = _context.surveyForms.Find(id);

            return View(surveyForms);
        }


        // GET: SurveyForms/Create
        public IActionResult Create()
        {
            return View();
        }


        // create action view 
        /*  public ActionResult createform() {
  *//*
              ViewBag.Messsage = "Welcome to my Demo!";
              CompositeModel mymodel =new CompositeModel();
              mymodel.SurveyForms = GetSurveyForms();
              mymod*//*el.SurwayQuetions = GetSurwayQuetions();
              return View(mymodel);   
              }*/





        // POST: SurveyForms/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,SurveyName,Category,SubCategory,FormName,Section,SectionWeightage,SurveyRantingtype")] SurveyFormsModel surveyForms)
        {

            if (ModelState.IsValid)
            {
                _context.Add(surveyForms);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(surveyForms);
        }

        // GET: SurveyForms/Edit/5
public async Task<IActionResult> Edit(int? id)
{
    if (id == null || _context.surveyForms == null)
    {
        return NotFound();
    }
    var surveyForms = await _context.surveyForms.FindAsync(id);
    if (surveyForms == null)
    {
        return NotFound();
    }
    return View(surveyForms);
}

        // POST: SurveyForms/Edit/5       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,SurveyName,Category,SubCategory,FormName,Section,SectionWeightage,SurveyRantingtype")] SurveyFormsModel surveyForms)
        {
            if (id != surveyForms.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(surveyForms);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SurveyFormsExists(surveyForms.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_SurveyFormAllPartial", _context.surveyForms.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Edit", surveyForms) });
        }


        /*// GET: SurveyForms/Delete/5
          [HttpGet]
          public IActionResult Delete(int? id)
          {
              var surveyForm = _context.surveyForms.Find(id);

              return View( surveyForm);
          }*/

        // POST: SurveyForms/Delete/5
        // POST: SurveyForms/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.surveyForms == null)
            {
                return Problem("Entity set 'VRS3LOGIN_AUTHENTICATIONDbContext.surveyForms'  is null.");
            }
            var surveyForms = await _context.surveyForms.FindAsync(id);
            if (surveyForms != null)
            {
                _context.surveyForms.Remove(surveyForms);
            }

            await _context.SaveChangesAsync();
            return Json(new {  html = Helper.RenderRazorViewToString(this, "_SurveyFormAllPartial", _context.surveyForms.ToList())});
        }

        private bool SurveyFormsExists(int id)
        {
            return (_context.surveyForms?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
