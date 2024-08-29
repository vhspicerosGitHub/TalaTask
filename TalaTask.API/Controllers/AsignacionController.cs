using Microsoft.AspNetCore.Mvc;
using TalaTask.API.src.Modelo;
using TalaTask.API.src.Negocio;

namespace TalaTask.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AsignacionController
    {
        private readonly AsignacionesServices _asignacionesServices;
        public AsignacionController(AsignacionesServices asignacionesServices)
        {
            _asignacionesServices = asignacionesServices;
        }

        /// <summary>
        /// Asigna una tarea a un empleado.
        /// </summary>
        /// <param name="tareaId">El id de la tarea a asignar.</param>
        /// <remarks>
        /// La tarea se asignará a un empleado disponible con las mismas habilidades
        /// </remarks>
        [HttpPost("{tareaId}")]
        public void Post(Int32 tareaId)
        {
            _asignacionesServices.Crear(tareaId);
        }


        [HttpPost]
        public List<AsignacionResponseDto> Post([FromBody] List<Int32> tareaIds)
        {
            return _asignacionesServices.CrearTareas(tareaIds);
        }
    }
}