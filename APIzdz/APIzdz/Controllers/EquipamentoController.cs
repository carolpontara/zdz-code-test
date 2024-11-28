using APIzdz.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace APIzdz.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class EquipamentoController : ControllerBase
  {
    private readonly EFDBContext _dbContext;

    public EquipamentoController(EFDBContext dbContext)
    {
      _dbContext = dbContext;
    }

    // Método POST: Adicionar equipamento
    [HttpPost]
    public IActionResult Post([FromBody] Equipamento equipamento)
    {
      if (equipamento == null)
      {
        return BadRequest("Equipamento inválido.");
      }

      _dbContext.Equipamento.Add(equipamento);
      _dbContext.SaveChanges();
      return CreatedAtAction(nameof(GetById), new { id = equipamento.Id }, equipamento);
    }

    // Método GET: Obter todos os equipamentos
    [HttpGet]
    public ActionResult<IEnumerable<Equipamento>> Get()
    {
      var equipamentos = _dbContext.Equipamento.ToList();
      return Ok(equipamentos);
    }

    // Método GET por ID: Obter um equipamento específico
    [HttpGet("{id}")]
    public ActionResult<Equipamento> GetById(int id)
    {
      var equipamento = _dbContext.Equipamento.Find(id);
      if (equipamento == null)
      {
        return NotFound("Equipamento não encontrado.");
      }

      return Ok(equipamento);
    }
  }
}
