using TalaTask.API.src.Infraestrutura.Repositorios.Interfaces;
using TalaTask.API.src.Modelo;
using System.Linq;

namespace TalaTask.API.src.Infraestrutura.Repositorios.Impl.Memory
{
    public class TareaRepository : ITareaRepository
    {
        private List<Tarea> _tareas = new List<Tarea>();
        public void Crear(Tarea item)
        {
            _tareas.Add(item);
        }

        public void Editar(Tarea item)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(Tarea item)
        {
            throw new NotImplementedException();
        }

        public Tarea? GetById(int id)
        {
            return _tareas.FirstOrDefault(x => x.Id == id);
        }

        public List<Tarea> GetByIds(List<int> ids)
        {
            return _tareas.Where(x => ids.Contains(x.Id)).ToList();
        }

        public Tarea? GetByTitulo(string titulo)
        {
            return _tareas.FirstOrDefault(x => x.Titulo == titulo);
        }

        public List<Tarea> Listar()
        {
            return _tareas;
        }
    }

    public class AsignacionRepository : IAsignacionRepository
    {
        private List<Asignacion> _asignaciones = new List<Asignacion>();
        public void Crear(Asignacion item)
        {
            _asignaciones.Add(item);
        }

        public void Editar(Asignacion item)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(Asignacion item)
        {
            throw new NotImplementedException();
        }

        public List<Asignacion> Listar()
        {
            return _asignaciones;
        }
    }
}
