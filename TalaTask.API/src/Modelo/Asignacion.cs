namespace TalaTask.API.src.Modelo
{
    public class Asignacion : IdentificableObject
    {
        public Empleado? Empleado { get; set; }
        public Tarea Tarea { get; set; } = new Tarea();
        public DateTime? FechaAsignacion { get; set; }
        public string Comentario { get; set; } = string.Empty;
    }
}
