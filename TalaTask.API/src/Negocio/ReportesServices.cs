using System.Data;
using TalaTask.API.src.Infraestrutura.Repositorios.Interfaces;
using TalaTask.API.src.Modelo;
using TalaTask.API.src.Utils;

public class ReportesServices
{

    private readonly IEmpleadoRepository _empleadoRepository;
    private readonly ITareaRepository _tareaRepository;
    private readonly IAsignacionRepository _asignacionRepository;

    public ReportesServices(IEmpleadoRepository empleadoRepository, ITareaRepository tareaRepository, IAsignacionRepository asignacionRepository)
    {
        _empleadoRepository = empleadoRepository;
        _tareaRepository = tareaRepository;
        _asignacionRepository = asignacionRepository;
    }

    public Empleado ReportePorEmpleado(int empleadoId)
    {
        var empleado = _empleadoRepository.GetById(empleadoId);
        if (empleado == null)
            throw new AppException(StatusCodes.Status404NotFound, "No existe un empleado con ese id");
        return empleado;
    }

    public List<Disponibilidad>? ReportePorEmpleadoLibre(int empleadoId)
    {
        return _empleadoRepository.GetDisponibilidades(empleadoId, true);
    }

    public List<Disponibilidad>? ReportePorEmpleadoOcupado(int empleadoId)
    {
        return _empleadoRepository.GetDisponibilidades(empleadoId, false);
    }

    internal Empleado EmpleadoConMasTareasAsignadas()
    {
        return _empleadoRepository.EmpleadoConMasTareasAsignadas();
    }
}