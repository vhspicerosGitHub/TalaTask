namespace TalaTask.API.src.Modelo
{
    public class Tarea : IdentificableObject
    {
        public string Titulo { get; set; } = string.Empty;
        public double DuracionEstimada { get; set; }
        public DateTime FechaDeadLine { get; set; }
        public List<string> Habilidades { get; set; } = new List<string>();
    }
}
