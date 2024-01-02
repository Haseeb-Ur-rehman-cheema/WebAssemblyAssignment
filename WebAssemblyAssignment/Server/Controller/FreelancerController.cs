using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebAssemblyAssignment.Server;
using WebAssemblyAssignment.Shared;

[ApiController]
[Route("api/[controller]")]
public class FreelancersController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public FreelancersController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult AddFreelancer([FromBody] Freelancer freelancer)
    {
        _context.Freelancers.Add(freelancer);
        _context.SaveChanges();

        return Ok("Freelancer added successfully");
    }

    [HttpGet]
    public IActionResult GetFreelancers()
    {
        var freelancers = _context.Freelancers.ToList();
        return Ok(freelancers);
    }

    [HttpPut("{id}")]
    public IActionResult EditFreelancer(int id, [FromBody] Freelancer updatedFreelancer)
    {
        var existingFreelancer = _context.Freelancers.Find(id);
        if (existingFreelancer == null)
        {
            return NotFound("Freelancer not found");
        }

        existingFreelancer.FirstName = updatedFreelancer.FirstName;
        existingFreelancer.LastName = updatedFreelancer.LastName;
        // Update other properties as needed

        _context.SaveChanges();

        return Ok("Freelancer updated successfully");
    }

    [HttpDelete("{id}")]
    public IActionResult RemoveFreelancer(int id)
    {
        var existingFreelancer = _context.Freelancers.Find(id);
        if (existingFreelancer == null)
        {
            return NotFound("Freelancer not found");
        }

        _context.Freelancers.Remove(existingFreelancer);
        _context.SaveChanges();

        return Ok("Freelancer removed successfully");
    }
}
