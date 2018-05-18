using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MedHair.ClassLibrary.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }
        public ApplicationDbContext(string connectionString) : base(connectionString)
        {
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.ProxyCreationEnabled = true;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
        public DbSet<HairSizeSettings> HairSizeSettings { set; get; }
        public DbSet<Document> Documents { set; get; }
        public DbSet<Contact> Contacts { set; get; }
        public DbSet<User>  Users { set; get; }
        public DbSet<Patient> Patients { set; get; }
        public DbSet<CommentOnTheVisit> CommentOnTheVisits { set; get; }
        public DbSet<Visit> Visits { set; get; }
        public DbSet<Research> Researches { set; get; }
        public DbSet<Diagnostic> Diagnostics { set; get; }
        public DbSet<Lens> Lenses { set; get; }
        public DbSet<Setting> Settings { set; get; }
        public DbSet<StatisticalSettings> StatisticalSettings { set; get; }
        public DbSet<Image> Images { set; get; }
        public DbSet<Hair> Hairs { set; get; }
        public DbSet<ReportField> ReportFields { set; get; }
        public DbSet<FieldOption> FieldOptions { set; get; }
        public DbSet<Picture> Pictures { set; get; }
        public DbSet<ReportTemplate> ReportTemplates { set; get; }
        public DbSet<C_FieldType> C_FieldTypes { set; get; }
    }
}
