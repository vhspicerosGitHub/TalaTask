using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using TalaTask.API.src.Modelo;
using TalaTask.API.src.Negocio;

namespace TalaTask.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CargaInicialController : ControllerBase
    {

        private readonly EmpleadoServices _empleadoServices;
        private readonly TareaServices _tareaServices;

        public CargaInicialController(EmpleadoServices empleadoServices, TareaServices tareaServices)
        {
            _empleadoServices = empleadoServices;
            _tareaServices = tareaServices;
        }

        /// <summary>
        /// Carga inicial de datos para pruebas.
        /// </summary>
        /// <returns></returns> 
        [HttpPost]
        public void Post()
        {
            var empleado = new Empleado { Nombre = "Pedro", Id = 1, Habilidades = new List<string> { "Javascript", "C#" } };
            empleado.Disponibilidades.Add(new Disponibilidad { Inicio = new DateTime(2024, 01, 01, 10, 00, 00), Fin = new DateTime(2024, 01, 01, 20, 00, 00), });
            _empleadoServices.Crear(empleado);

            empleado = new Empleado { Nombre = "Victor Hugo", Id = 2, Habilidades = new List<string> { "Python", "Go", "C#" } };
            empleado.Disponibilidades.Add(new Disponibilidad { Inicio = new DateTime(2024, 01, 01, 10, 00, 00), Fin = new DateTime(2024, 01, 01, 20, 00, 00), });
            _empleadoServices.Crear(empleado);

            empleado = new Empleado { Nombre = "Juan", Id = 3, Habilidades = new List<string> { "Python", "Go" } };
            empleado.Disponibilidades.Add(new Disponibilidad { Inicio = new DateTime(2024, 01, 01, 10, 00, 00), Fin = new DateTime(2024, 01, 01, 20, 00, 00), });
            _empleadoServices.Crear(empleado);

            empleado = new Empleado { Nombre = "Diego ", Id = 4, Habilidades = new List<string> { "Python", "Go" } };
            empleado.Disponibilidades.Add(new Disponibilidad { Inicio = new DateTime(2024, 01, 01, 10, 00, 00), Fin = new DateTime(2024, 01, 01, 20, 00, 00), });
            _empleadoServices.Crear(empleado);



            var tarea = new Tarea { Id = 1, Titulo = "Tarea 1", Habilidades = new List<string> { "Javascript", "C#" }, DuracionEstimada = 2, FechaDeadLine = new DateTime(2024, 01, 01, 13, 00, 00) };
            _tareaServices.Crear(tarea);

            tarea = new Tarea { Id = 2, Titulo = "Desarrollar modulo en Cobol 1", Habilidades = new List<string> { "Cobol" }, DuracionEstimada = 5, FechaDeadLine = new DateTime(2026, 01, 2, 20, 00, 00) };
            _tareaServices.Crear(tarea);

            tarea = new Tarea { Id = 3, Titulo = "Desarrollar API de empleados", Habilidades = new List<string> { "C#" }, DuracionEstimada = 6, FechaDeadLine = new DateTime(2026, 01, 01, 20, 00, 00) };
            _tareaServices.Crear(tarea);

            tarea = new Tarea { Id = 4, Titulo = "Desarrollar admin de usuarios con Django", Habilidades = new List<string> { "Python" }, DuracionEstimada = 4, FechaDeadLine = new DateTime(2026, 01, 16, 13, 00, 00) };
            _tareaServices.Crear(tarea);

        }
    }
}