using APIzdz.Models;
using Microsoft.AspNetCore.Mvc;


namespace APIzdz.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class TecnicoController : ControllerBase
  {
    private readonly EFDBContext _dbContext;

    public TecnicoController(EFDBContext dbContext)
    {
      _dbContext = dbContext;
    }

    // Método POST: Adicionar Tecnico
    [HttpPost]
    public IActionResult Post([FromBody] Tecnico tecnico)
    {
      if (tecnico == null)
      {
        return BadRequest("Tecnico inválido.");
      }

      _dbContext.Tecnico.Add(tecnico);
      _dbContext.SaveChanges();
      return CreatedAtAction(nameof(GetById), new { id = tecnico.Id }, tecnico);
    }

    // Método GET: Obter todos os Tecnicos
    [HttpGet]
    public ActionResult<IEnumerable<Tecnico>> Get()
    {
      var Tecnicos = _dbContext.Tecnico.ToList();
      return Ok(Tecnicos);
    }

    // Método GET por ID: Obter um Tecnico específico
    [HttpGet("{id}")]
    public ActionResult<Tecnico> GetById(int id)
    {
      var Tecnico = _dbContext.Tecnico.Find(id);
      if (Tecnico == null)
      {
        return NotFound("Tecnico não encontrado.");
      }

      return Ok(Tecnico);
    }
  }
}
