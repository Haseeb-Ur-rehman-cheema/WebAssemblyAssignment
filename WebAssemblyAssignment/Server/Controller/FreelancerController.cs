using Microsoft.AspNetCore.Mvc;
using System;
using WebAssemblyAssignment.Server;
using WebAssemblyAssignment.Shared;

[ApiController]
[Route("api/[controller]")]
public class FreelancersController : ControllerBase
{
    private readonly ApplicationDbContext _context; // Corrected variable name

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
}
