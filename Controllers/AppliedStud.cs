using JwtWebApiDotNet7.Data;
using Microsoft.AspNetCore.Mvc;

namespace JwtWebApiDotNet7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppliedStud : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly DataContext _context;


        public AppliedStud(IConfiguration configuration, DataContext context)
        {
            _configuration = configuration;
            _context = context;

        }


        [HttpPost]

        public async Task<ActionResult<List<AppliedStudent>>> AddAppliedStudent(AppliedStudent details)
        {
            _context.AppliedStudent.Add(details);
            _context.SaveChanges();

            return _context.AppliedStudent.ToList();
        }
    }

    }
