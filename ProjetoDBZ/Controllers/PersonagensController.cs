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
    public async Task<IActionResult> AddPersonagem([FromBody] Personagem personagem)
    {
        if (!ModelState.IsValid) 
            return BadRequest(ModelState);
        
        _context.Dbz.Add(personagem);
        await _context.SaveChangesAsync();
        
        return Created("", personagem);
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
            return NotFound("Personagem não encontrado!");
        
        return Ok(personagem);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdatePersonagem(int id, [FromBody] Personagem personagemAtualizado)
    {
        var personagemExistente = await _context.Dbz.FindAsync(id);
        
        if (personagemExistente is null) 
            return NotFound("Personagem não encontrado!");
        
        _context.Entry(personagemExistente).CurrentValues.SetValues(personagemAtualizado);
        await _context.SaveChangesAsync();
        
        return Ok(personagemExistente);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeletePersonagem(int id)
    {
        var personagem = await _context.Dbz.FindAsync(id);
        
        if (personagem is null)
            return NotFound("Personagem não encontrado!");
        
        _context.Dbz.Remove(personagem);
        await _context.SaveChangesAsync();
        
        return NoContent();
    }
}