using TalaTask.API.src.Modelo;

namespace TalaTask.API.src.Infraestrutura.Repositorios.Interfaces
{
    public interface IEmpleadoRepository : IGenericRepository<Empleado>
    {
        Empleado? GetById(int id);
        Empleado? GetByName(int id);
        List<Empleado> ObtieneEmpleadosConHabilidades(List<string> habilidades);
    }
}