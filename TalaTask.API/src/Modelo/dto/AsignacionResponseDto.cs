using TalaTask.API.src.Modelo;

public class AsignacionResponseDto
{
    public AsignacionResponseDto(Asignacion asignacion)
    {
        TareaId = asignacion.Tarea.Id;
        if (asignacion.Empleado != null)
            EmpleadoId = asignacion.Empleado.Id;
        Comentario = asignacion.Comentario;
        FechaAsignacion = asignacion.FechaAsignacion;
    }

    public int TareaId { get; set; }
    public int EmpleadoId { get; set; }
    public string Comentario { get; set; } = string.Empty;
    public DateTime? FechaAsignacion { get; set; }
}