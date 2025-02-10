using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VRS3LOGIN_AUTHENTICATION.Areas.Identity.Data;
using VRS3LOGIN_AUTHENTICATION.Migrations;
using VRS3LOGIN_AUTHENTICATION.Models;


namespace VRS3LOGIN_AUTHENTICATION.Controllers
{
    public class SurveyManagerController : Controller
    {
       
        private readonly VRS3LOGIN_AUTHENTICATIONDbContext _context;
        public List<SurveyManagerModel> SurveyManager { get; set; }
        public List<SurveyFormsModel> surveyForms { get; set; }


        public SurveyManagerController(VRS3LOGIN_AUTHENTICATIONDbContext context)
        {
            _context = context;
        }

        /* public IActionResult Index( )
        {
            var surveys = _context.SurveyManager.ToList();
            ViewBag.SurveyNames = GetSurveyNames();
            ViewBag.surveyName = new SelectList(_context.surveyForms, "id", "SurveyName");
            ViewBag.Selected = "select";
            ViewBag.SurveyQuetions = new SelectList(_context.SurveyQuetions, "Quetionsid", "Quetions");
            return View(surveys);
        }*/


        public IActionResult Index()
        {
            var surveys = _context.SurveyManager.ToList();
            ViewBag.SurveyNames = GetSurveyNames();
            ViewBag.SurveyFormNames = GetSurveyFormNames();
            ViewBag.SurveyQuestionNames = GetSurveyQuestionNames();
            ViewBag.Selected = "select";
            return View(surveys);
        }
  
        
/*  
       [HttpPost]
  public IActionResult FilteredIndex(string surveyName)
      {
          if (surveyName != "0")
          {
              // Filter records based on the selected surveyName
              var filteredSurveys = _context.SurveyManager
                  .Where(x => x.surveyName == surveyName)
                  .ToList();
              ViewBag.Selected = surveyName; // Set the selected value
              ViewBag.SurveyNames = GetSurveyNames(); // Populate the survey names
              return View("Index", filteredSurveys);
          }
          // If no selection is made, return to the main Index
          return RedirectToAction("Index");
      }
*/

        [HttpPost]
        public IActionResult FilteredIndex(string surveyName)
        {
            ViewBag.SurveyNames = GetSurveyNames();
            ViewBag.SurveyFormNames = GetSurveyFormNames();
            ViewBag.SurveyQuestionNames = GetSurveyQuestionNames();
            ViewBag.Selected = "select";

            if (surveyName != "0")
            {
                // Filter records based on the selected surveyName
                var filteredSurveys = _context.SurveyManager
                    .Where(x => x.surveyName == surveyName)
                    .ToList();
                ViewBag.Selected = surveyName; // Set the selected value
                ViewBag.SurveyNames = GetSurveyNames(); // Populate the survey names
                return View("Index", filteredSurveys);
            }
            else
                {
                    ModelState.AddModelError(string.Empty, "No survey questions with this survey form.");
                    ViewBag.SurveyFormNames = GetSurveyFormNames(); // Populate the survey form names
                 
                    return View();
                }
            

            // If no selection is made, return to the main Index
            return RedirectToAction("Index");
        }


        [NonAction]
        private List<string> GetSurveyNames()
        {
            // Use Entity Framework to query the database instead of ADO.NET
            var surveyNames = _context.SurveyManager
                .Select(x => x.surveyName)
                .Distinct()
                .ToList();

            return surveyNames;
        }

        private List<SelectListItem> GetSurveyFormNames()
        {
            var surveyFormNames = _context.surveyForms
                .Select(x => new SelectListItem { Value = x.SurveyName, Text = x.SurveyName })
                .ToList();

            return surveyFormNames;
        }

        private List<SelectListItem> GetSurveyQuestionNames()
        {
            var surveyQuestionNames = _context.SurveyQuetions
                .Select(x => new SelectListItem { Value = x.Quetions, Text = x.Quetions })
                .ToList();

            return surveyQuestionNames;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int ManageID)
        {
            if ( _context.surveyForms == null )
            {
                return Problem("Entity set 'VRS3LOGIN_AUTHENTICATIONDbContext.surveyForms'  is null.");
            }
            // Find the record to delete by its ID
            var itemToDelete = await _context.SurveyManager.FindAsync(ManageID);

            if (itemToDelete != null)
            {
                _context.SurveyManager.Remove(itemToDelete);
            }

            await _context.SaveChangesAsync();

            return Json(new { html = Helper.RenderRazorViewToString(this, "FilteredIndex", _context.SurveyManager.ToList()) });
        }

        /* public IActionResult Index()
         {
             var surveyNames = _context.surveyForms.Select(s => s.SurveyName).ToList();
             ViewBag.SurveyNames = new SelectList(surveyNames);
             ViewBag.Selected = "select";
             ViewBag.SurveyQuetions = new SelectList(_context.SurveyQuetions, "Quetionsid", "Quetions");
             return View();
         }*/

        /* public IActionResult Index( )
         {
             var surveys = _context.SurveyManager.ToList();
             ViewBag.SurveyNames = GetSurveyNames();
             ViewBag.surveyName = new SelectList(_context.surveyForms, "id", "SurveyName");
             ViewBag.Selected = "select";
             ViewBag.SurveyQuetions = new SelectList(_context.SurveyQuetions, "Quetionsid", "Quetions");
             return View(surveys);
         }*/


        /*
                [HttpPost]
                public IActionResult FilteredIndex(string surveyName)
                {
                    if (surveyName != "0")
                    {
                        // Filter records based on the selected surveyName
                        var filteredSurveys = _context.SurveyManager
                            .Where(x => x.surveyName == surveyName)
                            .ToList();
                        ViewBag.Selected = surveyName; // Set the selected value
                        ViewBag.SurveyNames = GetSurveyNames(); // Populate the survey names
                        return View("Index", filteredSurveys);
                    }

                    // If no selection is made, return to the main Index
                    return RedirectToAction("Index");
                }


                [NonAction]
                private List<string> GetSurveyNames()
                {
                    // Use Entity Framework to query the database instead of ADO.NET
                    var surveyNames = _context.SurveyManager
                        .Select(x => x.surveyName)
                        .Distinct()
                        .ToList();

                    return surveyNames;
                }
        */

        [HttpPost]
        public IActionResult Index([FromBody] List<SurveyManagerModel> dataItems)
        {
            if (dataItems != null && dataItems.Count > 0)
            {
                try
                {
                    foreach (var item in dataItems)
                    {
                        // Check if a record with the same values already exists in the database
                        var existingRecord = _context.SurveyManager
                            .FirstOrDefault(x => x.surveyName == item.surveyName && x.Quetions == item.Quetions);

                        if (existingRecord == null)
                        {
                            _context.SurveyManager.Add(item);
                        }
                    }

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


        /*  if (viewModel is null)
        {
            throw new ArgumentNullException(nameof(viewModel));
        }

        viewModel.surveyForms = new List<SelectListItem>();
        var data = _context.surveyForms.ToList();

        viewModel.Quetions = new List<SelectListItem>();
        var data1 = _context.SurveyQuetions.ToList();

        viewModel.surveyForms.Add(new SelectListItem
        {
            Text = "Select Survey form",
            Value = ""
        });

        viewModel.Quetions.Add(new SelectListItem
        {
            Text = "Select Question",
            Value = ""
        });

        foreach (var item in data)
        {
            viewModel.surveyForms.Add(new SelectListItem
            {
                Text = item.SurveyName,
                Value = Convert.ToString(item.id)
            });
        }

        foreach (var item in data1)
        {
            viewModel.Quetions.Add(new SelectListItem
            {
                Text = item.Quetions,
                Value = Convert.ToString(item.Quetionsid)
            });
        }

        // Set ViewBag values outside of the loop
        ViewBag.Value = viewModel.SurveyId;
        ViewBag.Text = viewModel.surveyForms.FirstOrDefault(m => m.Value == viewModel.SurveyId.ToString())?.Text;

        ViewBag.Value = viewModel.QuetionsID;
        ViewBag.Text = viewModel.Quetions.FirstOrDefault(m => m.Value == viewModel.QuetionsID.ToString())?.Text;

        // Move the return statement outside of the loop
        return View(viewModel);*/


    [HttpGet]
        public async Task<IActionResult> liveSurvey() {
                return _context.SurveyManager != null ?
                 View(await _context.SurveyManager.ToListAsync()) :
                 Problem("There is no record ");

            var surveyData = _context.SurveyManager
           .FromSqlRaw("SELECT [surveyName], [Quetions] FROM [Surveydashbord_db].[dbo].[SurveyManager] WHERE [surveyName] = 'Mental health survey'")
           .ToList();

            ViewBag.SurveyData = surveyData; // Store the data in ViewBag

        }
    }
}



