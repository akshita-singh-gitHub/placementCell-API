using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace JwtWebApiDotNet7
{
   
    public class UserDb
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }

        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;




    }
    public class CompanyList
    {

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string? Industry { get; set; } = string.Empty;
        public string? About { get; set; } = string.Empty;
        public string? FormAvailability { get; set; } = string.Empty;
        public int? UserId { get; set; }
      

    }
    public class StudentList
    {

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string ContactNo { get; set; } = string.Empty;
        public string Year { get; set; } = string.Empty;
        public string Branch { get; set; } = string.Empty;
        public string TenthPercent { get; set; } = string.Empty;
        public string TwelfthPercent { get; set; } = string.Empty;
        public int? UserId { get; set; }
    }

  //  [Keyless]
  public class StudPlacementList
    {

      public int Id { get; set; }
        public string? RollNo { get; set; } = string.Empty;
        public string? Name { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string? Contact { get; set; } = string.Empty;
        public string? Branch { get; set; } = string.Empty;
        public string? Company { get; set; } = string.Empty;
        public string? Status { get; set; } = string.Empty;
        public string? ImageUrl { get; set; } = string.Empty;
        public DateTime? Date { get; set; }
        public string? Package { get; set; } = string.Empty;

    }

    public class AppliedStudent
    {

        public int Id { get; set; }
     //   public string RollNo { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string CGPA { get; set; } = string.Empty;
        public string Availabilty { get; set; } = string.Empty;
        public string Results { get; set; } = string.Empty;


    }

}
