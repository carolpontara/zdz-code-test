namespace APIzdz.Models
{
  public class Manutencao
  {
    public int Id { get; set; }
    public int EquipamentoId { get; set; }
    public int TecnicoId { get; set; }
    public DateTime Data { get; set; }
    public string Descricao { get; set; }
    public decimal Custo { get; set; }
    public string Status { get; set; }

  }
}
