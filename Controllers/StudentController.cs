using JwtWebApiDotNet7.Data;
using JwtWebApiDotNet7.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JwtWebApiDotNet7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly DataContext _context;


        public StudentController(IConfiguration configuration, DataContext context)
        {
            _configuration = configuration;
            _context = context;

        }


        [HttpGet]
        public async Task<ActionResult<List<StudentList>>> getplacedstudList()
        {
            return Ok(await _context.StudentList.ToListAsync());
        }

        [HttpPost("RegisterStudent")]

        public async Task<ActionResult<List<StudentList>>> RegisterStudent(StudentList details)
        {
            StudentList dbstud = new StudentList();
            UserDb NewLoginUser = new UserDb();

            NewLoginUser = _context.UserList.SingleOrDefault(x => x.Email == details.Email && x.Name == details.Name);

            dbstud.UserId = NewLoginUser.Id;
            dbstud.Name = details.Name;
            dbstud.Email = details.Email;
            dbstud.Address = details.Address;
            dbstud.ContactNo = details.ContactNo;
            dbstud.Year = details.Year;
            dbstud.Branch = details.Branch;

            _context.StudentList.Add(dbstud);
            _context.SaveChanges();

            return _context.StudentList.ToList();
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<StudentList>> GetStudById(int id)
        {

            var dbstud = _context.StudentList.Where(x => x.UserId == id).ToList();


            return Ok(dbstud);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<StudentList>>> UpdateStudentList(StudentList details, int id)
        {

            var dbstud = _context.StudentList.SingleOrDefault(x => x.UserId == id);
            if (dbstud != null)
            {

                dbstud.Name = details.Name;
                dbstud.Email = details.Email;
                dbstud.Address = details.Address;
                dbstud.ContactNo = details.ContactNo;
                dbstud.Year = details.Year;
                dbstud.Branch = details.Branch;
            }
            _context.SaveChanges();


            return _context.StudentList.ToList();

        }





       [HttpDelete("{id}")]

        public async Task<ActionResult<UserDb>> DeleteStudAccount(int userId)
        {
            var dbstud = _context.StudentList.SingleOrDefault(x => x.UserId == userId);
            _context.StudentList.Remove(dbstud);

            await _context.SaveChangesAsync();
            /* return Ok(await _context.Listresto.ToListAsync());*/

            return Ok();
        }
    }
}
