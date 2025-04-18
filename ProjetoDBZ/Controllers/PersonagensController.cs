using Microsoft.AspNetCore.Mvc;
using ProjetoDBZ.Data;
using ProjetoDBZ.Models;

namespace ProjetoDBZ.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonagensController(AppDbContext context) : ControllerBase
{
    private readonly AppDbContext _context = context;

    [HttpPost]
    public async Task<IActionResult> AddPersonagem(Personagem personagem)
    {
        _context.Dbz.Add(personagem);
        await _context.SaveChangesAsync();
        return Ok(personagem);
    }
}