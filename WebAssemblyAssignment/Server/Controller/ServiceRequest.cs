using Microsoft.AspNetCore.Mvc;
using WebAssemblyAssignment.Shared;

namespace WebAssemblyAssignment.Server.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceRequestsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ServiceRequestsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddServiceRequest([FromBody] ServiceRequest serviceRequest)
        {
            _context.ServiceRequests.Add(serviceRequest);
            _context.SaveChanges();

            return Ok("Service request added successfully");
        }

        [HttpGet]
        public IActionResult GetServiceRequests()
        {
            var serviceRequests = _context.ServiceRequests.ToList();
            return Ok(serviceRequests);
        }
    }

}
