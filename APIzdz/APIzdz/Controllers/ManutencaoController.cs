using APIzdz.Models;
using Microsoft.AspNetCore.Mvc;


namespace APIzdz.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ManutencaoController : ControllerBase
  {
    private readonly EFDBContext _dbContext;

    public ManutencaoController(EFDBContext dbContext)
    {
      _dbContext = dbContext;
    }

    // Método POST: Adicionar Manutencao
    [HttpPost]
    public IActionResult Post([FromBody] Manutencao manutencao)
    {
      if (manutencao == null)
      {
        return BadRequest("Manutencao inválido.");
      }

      _dbContext.Manutencao.Add(manutencao);
      _dbContext.SaveChanges();
      return CreatedAtAction(nameof(GetById), new { id = manutencao.Id }, manutencao);
    }

    // Método GET: Obter todos as Manutencaos
    [HttpGet]
    public ActionResult<IEnumerable<Manutencao>> Get()
    {
      var Manutencoes = _dbContext.Manutencao.ToList();
      return Ok(Manutencoes);
    }

    // Método GET por ID: Obter uma Manutencao específica
    [HttpGet("{id}")]
    public ActionResult<Manutencao> GetById(int id)
    {
      var Manutencao = _dbContext.Manutencao.Find(id);
      if (Manutencao == null)
      {
        return NotFound("Manutencao não encontrado.");
      }

      return Ok(Manutencao);
    }
  }
}
