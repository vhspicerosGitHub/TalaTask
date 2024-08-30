using TalaTask.API.src.Infraestrutura.Repositorios.Interfaces;
using TalaTask.API.src.Modelo;
using TalaTask.API.src.Utils;

namespace TalaTask.API.src.Negocio
{
    public class TareaServices
    {
        private readonly ITareaRepository _repository;
        public TareaServices(ITareaRepository empleadoRepository)
        {
            _repository = empleadoRepository;
        }

        public List<Tarea> Listar()
        {
            return _repository.Listar();
        }

        public void Crear(Tarea tarea)
        {
            if (tarea.DuracionEstimada < 1)
                throw new AppException("La duracion debe ser mayor a 0.");
            if (_repository.GetById(tarea.Id) != null)
                throw new AppException("Ya existe una tarea con ese id.");
            if (_repository.GetByTitulo(tarea.Titulo) != null)
                throw new AppException("Ya existe una tarea con ese titulo.");

            _repository.Crear(tarea);
        }

        public void Editar(Tarea tarea)
        {
            if (_repository.GetById(tarea.Id) == null)
                throw new AppException(400, "No existe una tarea con ese id.");
            _repository.Editar(tarea);
        }

        public void Eliminar(Tarea tarea)
        {
            if (_repository.GetById(tarea.Id) == null)
                throw new AppException(400, "No existe una tarea con ese id.");
            _repository.Eliminar(tarea);
        }
    }
}
