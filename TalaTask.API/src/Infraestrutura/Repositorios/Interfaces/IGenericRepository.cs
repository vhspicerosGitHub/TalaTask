using System.ComponentModel.Design;

namespace TalaTask.API.src.Infraestrutura.Repositorios.Interfaces
{
    public interface IGenericRepository<T>
    {
        void Crear(T item);
        void Eliminar(T item);
        void Editar(T item);
        List<T> Listar();
    }
}
