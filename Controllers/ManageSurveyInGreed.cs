using Microsoft.AspNetCore.Mvc;
using VRS3LOGIN_AUTHENTICATION.Areas.Identity.Data;

public class ManageSurveyInGreedController : Controller
{
    private readonly VRS3LOGIN_AUTHENTICATIONDbContext _context;

    public ManageSurveyInGreedController(VRS3LOGIN_AUTHENTICATIONDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        // Retrieve all records initially
        var surveys = _context.SurveyManager.ToList();
        ViewBag.Selected = "0"; // Initialize to "0" to display all records initially
        ViewBag.SurveyNames = GetSurveyNames(); // Populate the survey names
        return View(surveys);
    }

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

    // You can add Create, Edit, Details, and Delete actions as needed
}
