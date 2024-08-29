using Microsoft.AspNetCore.Mvc;
using TalaTask.API.src.Infraestrutura.Repositorios.Impl.Memory;
using TalaTask.API.src.Modelo;
using TalaTask.API.src.Negocio;

namespace TalaTask.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmpleadosController : ControllerBase
    {
        private readonly EmpleadoServices _services;
        public EmpleadosController(EmpleadoServices services)
        {
            _services = services;
        }

        /// <summary>
        /// Retorna una lista de empleados.
        /// </summary>
        /// <returns>Una lista de empleados.</returns>
        [HttpGet]
        public List<Empleado> Get()
        {
            return _services.Listar();

        }

        /// <summary>
        /// Crea un nuevo empleado.
        /// </summary>
        /// <param name="request">El empleado a crear.</param>
        /// <returns></returns>
        [HttpPost]
        public void Post(EmpleadoRequestDto request)
        {

            var empleado = new Empleado
            {
                Id = request.Id,
                Nombre = request.Nombre,
                Habilidades = request.Habilidades,
                Disponibilidades = request.Disponibilidades.Select(x => new Disponibilidad { Inicio = x.Inicio, Fin = x.Fin }).ToList()
            };
            _services.Crear(empleado);
        }

        /// <summary>
        /// Elimina un empleado.
        /// </summary>
        /// <param name="id">El id del empleado a eliminar.</param>
        /// <returns></returns> 
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _services.Eliminar(new Empleado { Id = id });
        }
    }
}