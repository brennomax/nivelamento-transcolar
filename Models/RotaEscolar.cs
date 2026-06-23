namespace NivelamentoTranscolar.Models;

public class RotaEscolar
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Tipo { get; set; } = string.Empty;
    public decimal DistanciaKm { get; set; }
    public string Descricao  { get; set; } = string.Empty;
    public TimeOnly Horario { get; set; } 
    public bool Ativa  { get; set; }

    public List<Aluno> Alunos { get; set; } = new();

}