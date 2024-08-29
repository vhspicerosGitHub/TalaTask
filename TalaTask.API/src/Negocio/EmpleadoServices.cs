using TalaTask.API.src.Infraestrutura.Repositorios.Interfaces;
using TalaTask.API.src.Modelo;
using TalaTask.API.src.Utils;

namespace TalaTask.API.src.Negocio
{
    public class EmpleadoServices
    {
        private readonly IEmpleadoRepository _empleadoRepository;
        public EmpleadoServices(IEmpleadoRepository empleadoRepository)
        {
            _empleadoRepository = empleadoRepository;
        }

        public List<Empleado> Listar()
        {
            return _empleadoRepository.Listar();
        }

        public void Crear(Empleado empleado)
        {
            if (_empleadoRepository.GetById(empleado.Id) != null)
                throw new AppException("Ya existe un empleado con ese id");

            if (_empleadoRepository.GetByName(empleado.Id) != null)
                throw new AppException("Ya existe un empleado con ese nombre");

            _empleadoRepository.Crear(empleado);
        }

        public void Editar(Empleado empleado)
        {
            if (_empleadoRepository.GetById(empleado.Id) == null)
                throw new AppException(404, "No existe un empleado con ese id");

            _empleadoRepository.Editar(empleado);
        }

        public void Eliminar(Empleado empleado)
        {
            if (_empleadoRepository.GetById(empleado.Id) == null)
                throw new AppException(404, "No existe un empleado con ese id");

            _empleadoRepository.Editar(empleado);
        }
    }
}
