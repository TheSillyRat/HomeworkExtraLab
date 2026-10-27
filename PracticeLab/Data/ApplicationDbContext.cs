using Microsoft.EntityFrameworkCore;
using PracticeLab.Entities;

namespace PracticeLab.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
: base(options)
        {

        }

        public DbSet<Product> Products => Set<Product>();
        public DbSet<Inspector> Inspectors => Set<Inspector>();
        public DbSet<DefectCategory> DefectCategories => Set<DefectCategory>();
        public DbSet<InspectionReport> InspectionReports => Set<InspectionReport>();
        
        
        
    }
}
