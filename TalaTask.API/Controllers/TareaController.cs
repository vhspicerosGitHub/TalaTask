using Microsoft.AspNetCore.Mvc;
using TalaTask.API.src.Modelo;
using TalaTask.API.src.Negocio;

namespace TalaTask.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TareaController : ControllerBase
    {
        private readonly TareaServices _services;
        public TareaController(TareaServices services)
        {
            _services = services;
        }

        /// <summary>
        /// Retorna una lista de Tareas 
        /// </summary>
        /// <returns>Una lista de Tareas</returns>
        [HttpGet]
        public List<Tarea> Get()
        {
            return _services.Listar();

        }

        /// <summary>
        /// Crea una nueva tarea
        /// </summary>
        /// <param name="request">La tarea a crear.</param>
        /// <returns></returns>
        [HttpPost]
        public void Post(Tarea request)
        {
            _services.Crear(request);
        }

        /// <summary>
        /// Elimina una tarea por su id
        /// </summary>
        /// <param name="id">El id de la tarea a eliminar</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _services.Eliminar(new Tarea { Id = id });
        }
    }
}
