using TalaTask.API.src.Infraestrutura.Repositorios.Interfaces;
using TalaTask.API.src.Modelo;
using System.Linq;

namespace TalaTask.API.src.Infraestrutura.Repositorios.Impl.Memory
{
    public class EmpleadoRepository : IEmpleadoRepository
    {

        private List<Empleado> _empleados = new List<Empleado>();
        public void Crear(Empleado item)
        {
            _empleados.Add(item);
        }

        public void Editar(Empleado item)
        {
            _empleados.RemoveAll(x => x.Id == item.Id);
            _empleados.Add(item);
        }

        public void Eliminar(Empleado item)
        {
            _empleados.RemoveAll(x => x.Id == item.Id);
        }

        public Empleado? GetById(int id)
        {
            return _empleados.FirstOrDefault(x => x.Id == id);
        }

        public Empleado? GetByName(int id)
        {
            return _empleados.FirstOrDefault(x => x.Id == id);
        }

        public List<Empleado> Listar()
        {
            return _empleados;
        }

        public List<Empleado> ObtieneEmpleadosConHabilidades(List<string> habilidades)
        {
            return _empleados
                .Where(x => habilidades.All(habilidad => x.Habilidades.Contains(habilidad)))
                .ToList();
        }
    }
}
