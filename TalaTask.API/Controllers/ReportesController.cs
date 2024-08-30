using System.Data;
using Microsoft.AspNetCore.Mvc;
using TalaTask.API.src.Modelo;

namespace TalaTask.API.Controllers;
[ApiController]
[Route("[controller]")]

public class ReportesController : ControllerBase
{
    private readonly ReportesServices _services;

    public ReportesController(ReportesServices services)
    {
        _services = services;
    }

    [HttpGet("empleado/{empleadoId}")]
    public Empleado ReportePorEmpleado(Int32 empleadoId)
    {
        return _services.ReportePorEmpleado(empleadoId);
    }

    [HttpGet("empleado/{empleadoId}/libre")]
    public List<Disponibilidad>? ReportePorEmpleadoLibre(Int32 empleadoId)
    {
        return _services.ReportePorEmpleadoLibre(empleadoId);
    }

    [HttpGet("empleado/{empleadoId}/ocupado")]
    public List<Disponibilidad>? ReportePorEmpleadoOcupado(Int32 empleadoId)
    {
        return _services.ReportePorEmpleadoOcupado(empleadoId);
    }

    [HttpGet("empleado/masAsignado")]
    public Empleado ReporteMasAsignado()
    {
        return _services.EmpleadoConMasTareasAsignadas();
    }



}
