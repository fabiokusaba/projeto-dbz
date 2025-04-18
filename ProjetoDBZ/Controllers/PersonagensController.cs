using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Personagem>>> GetPersonagens()
    {
        var personagens = await _context.Dbz.ToListAsync();
        return Ok(personagens);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetPersonagem(int id)
    {
        var personagem = await _context.Dbz.FindAsync(id);
        if (personagem is null)
        {
            return NotFound("Personagem não encontrado!");
        }
        return Ok(personagem);
    }
}