using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using VRS3LOGIN_AUTHENTICATION.Models;

namespace VRS3LOGIN_AUTHENTICATION.Areas.Identity.Data;

public class VRS3LOGIN_AUTHENTICATIONDbContext : IdentityDbContext<ApplicationUser>
{

    public VRS3LOGIN_AUTHENTICATIONDbContext(DbContextOptions<VRS3LOGIN_AUTHENTICATIONDbContext> options)
        : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

    }

    public DbSet<SurveyFormsModel> surveyForms { get; set; }
    public DbSet<SurveyQuetionsModels> SurveyQuetions { get; set; }
    public DbSet<SurveyManagerModel> SurveyManager { get; set; }

}
 