using TalaTask.API.src.Modelo;

namespace TalaTask.API.src.Infraestrutura.Repositorios.Interfaces
{
    public interface ITareaRepository : IGenericRepository<Tarea>
    {
        Tarea? GetById(int id);
        List<Tarea> GetByIds(List<Int32> ids);
        Tarea? GetByTitulo(string titulo);
    }
}