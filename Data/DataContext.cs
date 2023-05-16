using JwtWebApiDotNet7;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;

namespace JwtWebApiDotNet7.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
       
        public DbSet<UserDb> UserList => Set<UserDb>();
        public DbSet<CompanyList> CompanyList => Set<CompanyList>();
        public DbSet<StudentList> StudentList => Set<StudentList>();
     //   public DbSet<PlacementList> PlacementList  => Set<PlacementList>();
      //  public DbQuery<PlacementList> PlacementList { get; set; }
        public DbSet<AppliedStudent> AppliedStudent => Set<AppliedStudent>();



      

         /*   protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
            modelBuilder.Entity<PlacementList>(
                eb =>
                {
                    eb.HasNoKey();
                    eb.ToView("PlacementList");

                });
                    
            }*/
      //  public DbSet<PlacementList> PlacementList { get; set; }
        //public DbSet<PlacementList> PlacementList { get; set; }

           public DbSet<StudPlacementList> StudPlacementList => Set<StudPlacementList>();



    }

}
