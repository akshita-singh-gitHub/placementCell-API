  using JwtWebApiDotNet7.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace JwtWebApiDotNet7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlacedStudController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly DataContext _context;

        public PlacedStudController(IConfiguration configuration, DataContext context)
        {
            _configuration = configuration;
            _context = context;

        }

        [HttpGet]
        public async Task<ActionResult<List<StudPlacementList>>> getplacedstudList()
        {
            return Ok(await _context.StudPlacementList.ToListAsync());
        }

        [HttpGet("[action]/{name}")]

        public async Task<ActionResult<StudPlacementList>> GetStudByName(string name)
        {

            var dbPlaceStud = _context.StudPlacementList.Where(x => x.Name == name).ToList();


            return Ok(dbPlaceStud);
        } 
        
        [HttpGet("[action]/{company}")]

        public async Task<ActionResult<StudPlacementList>> GetCompByName(string company)
        {

            var dbPlaceStud = _context.StudPlacementList.Where(x => x.Company == company).ToList();


            return Ok(dbPlaceStud);
        }

        [HttpPost("AddPlacedStud")]

        public async Task<ActionResult<List<StudPlacementList>>> AddPlacedStud(StudPlacementList details)
        {
            StudPlacementList placed = new StudPlacementList();

            DateTime datetime = DateTime.Now;
            placed.Date = datetime;
            _context.StudPlacementList.Add(details);
            _context.SaveChanges();

            return _context.StudPlacementList.ToList();
        }
    }
}