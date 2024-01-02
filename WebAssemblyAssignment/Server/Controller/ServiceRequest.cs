using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebAssemblyAssignment.Server;
using WebAssemblyAssignment.Shared;

namespace WebAssemblyAssignment.Server.Controllers
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

        [HttpPut("{id}")]
        public IActionResult EditServiceRequest(int id, [FromBody] ServiceRequest updatedServiceRequest)
        {
            var existingServiceRequest = _context.ServiceRequests.Find(id);
            if (existingServiceRequest == null)
            {
                return NotFound("Service request not found");
            }

            existingServiceRequest.Title = updatedServiceRequest.Title;
            existingServiceRequest.Description = updatedServiceRequest.Description;
            // Update other properties as needed

            _context.SaveChanges();

            return Ok("Service request updated successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveServiceRequest(int id)
        {
            var existingServiceRequest = _context.ServiceRequests.Find(id);
            if (existingServiceRequest == null)
            {
                return NotFound("Service request not found");
            }

            _context.ServiceRequests.Remove(existingServiceRequest);
            _context.SaveChanges();

            return Ok("Service request removed successfully");
        }
    }
}
