using JwtWebApiDotNet7.Data;
using JwtWebApiDotNet7.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace JwtWebApiDotNet7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly DataContext _context;

        public CompanyController(IConfiguration configuration, DataContext context)
        {
            _configuration = configuration;
            _context = context;

        }
        [HttpGet]
        public async Task<ActionResult<List<CompanyList>>> getCompanyList()
        {
            return Ok(await _context.CompanyList.ToListAsync());
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<CompanyList>> GetCompById(int id)
        {

            var dbcomp = _context.CompanyList.Where(x => x.Id == id).ToList();


            return Ok(dbcomp);
        }   
        
        [HttpGet("[action]/{userId}")]

        public async Task<ActionResult<CompanyList>> GetCompByUserId(int userId)
        {

            var dbcomp = _context.CompanyList.Where(x => x.UserId == userId).ToList();


            return Ok(dbcomp);
        }

        [HttpPost("RegisterCompany")]

        public async Task<ActionResult<List<CompanyList>>> RegisterCompany(CompanyList details)
        {
            CompanyList dbstud = new CompanyList();
            UserDb NewLoginUser = new UserDb();

            NewLoginUser = _context.UserList.SingleOrDefault(x => x.Email == details.Email && x.Name == details.Name);

            dbstud.UserId = NewLoginUser.Id;
            dbstud.Name = details.Name;
            dbstud.Email = details.Email;
            dbstud.Address = details.Address;
            dbstud.Industry = details.Industry;
            dbstud.About = details.About;

            _context.CompanyList.Add(dbstud);
            _context.SaveChanges();

            return _context.CompanyList.ToList();
        }


        [HttpGet("[action]/{company}")]

        public async Task<ActionResult<CompanyList>> GetCompByName(string company)
        {

            var dbComp = _context.CompanyList.Where(x => x.Name == company).ToList();


            return Ok(dbComp);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<StudentList>>> UpdateCompany(CompanyList details, int id)
        {

            var dbstud = _context.CompanyList.SingleOrDefault(x => x.Id == id);
            if (dbstud != null)
            {

                dbstud.Name = details.Name;
                dbstud.Email = details.Email;
                dbstud.Address = details.Address;
                dbstud.Industry = details.Industry;
                dbstud.About = details.About;
            }
            _context.SaveChanges();


            return Ok(_context.CompanyList.ToList());


        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<UserDb>> DeleteCompAccount(int userId)
        {
            var dbcomp = _context.CompanyList.SingleOrDefault(x => x.UserId == userId);
            _context.CompanyList.Remove(dbcomp);

            await _context.SaveChangesAsync();
            /* return Ok(await _context.Listresto.ToListAsync());*/

            return Ok();
        }  
        
        [HttpPut("[action]/{id}")]

        public async Task<ActionResult<CompanyList>> SetCompFormAvailability(int id)
        {
            List<CompanyList> dbcomp = new List<CompanyList>();


            var comp = _context.CompanyList.Where(x => x.Id == id).ToList();

            if (comp[0].FormAvailability == "true")
                comp[0].FormAvailability = "false";
            else comp[0].FormAvailability = "true";
             _context.SaveChanges();


            return Ok(_context.CompanyList.ToList());
        }

    }
}
