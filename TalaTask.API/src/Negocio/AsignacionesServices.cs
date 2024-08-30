using System.Runtime.InteropServices;
using TalaTask.API.src.Infraestrutura.Repositorios.Interfaces;
using TalaTask.API.src.Modelo;
using TalaTask.API.src.Utils;

namespace TalaTask.API.src.Negocio
{
    public class AsignacionesServices
    {
        private readonly IAsignacionRepository _repository;
        private readonly ITareaRepository _tareaRepository;
        private readonly IEmpleadoRepository _empleadoRepository;

        public AsignacionesServices(IAsignacionRepository repository, ITareaRepository tareaRepository, IEmpleadoRepository empleadoRepository)
        {
            _repository = repository;
            _tareaRepository = tareaRepository;
            _empleadoRepository = empleadoRepository;
        }

        public List<AsignacionResponseDto> CrearTareas(List<Int32> tareasId)
        {
            var tareas = _tareaRepository.GetByIds(tareasId);
            var asignaciones = new List<AsignacionResponseDto>();
            foreach (var tarea in tareas)
            {

                var comentario = string.Empty;
                var empleado = AsignarTarea(tarea);

                if (empleado != null)
                    _empleadoRepository.Editar(empleado); // Se actualiza el estado del empleado.

                var asignacion = new Asignacion
                {
                    Comentario = comentario,
                    Tarea = tarea,
                    Empleado = empleado ?? null
                };

                asignacion.Comentario = empleado == null ? "No se pudo asignar la tarea" : string.Empty;
                asignacion.FechaAsignacion = empleado == null ? null : DateTime.Now;
                _repository.Crear(asignacion);

                var asignacionResponseDto = new AsignacionResponseDto(asignacion);
                asignaciones.Add(asignacionResponseDto);
            }

            return asignaciones;
        }

        public List<AsignacionResponseDto> Crear(Int32 tareaId)
        {
            var tareas = new List<Int32>() { tareaId };
            return CrearTareas(tareas);
        }

        public Empleado? AsignarTarea(Tarea tarea)
        {
            // Metodo principal para buscar la mejor asignacion
            // 1. buscar todos los empleados que tengan la mismas habilidades y tengan tiempo disponible antes del deadline.
            var empleados = _empleadoRepository.ObtieneEmpleadosConHabilidades(tarea.Habilidades);
            empleados = empleados.FindAll(x => x.Disponibilidades.Any(y => y.Inicio <= tarea.FechaDeadLine.AddHours(-tarea.DuracionEstimada) && y.CantidadHoras >= tarea.DuracionEstimada));
            empleados.Sort((x, y) => x.Disponibilidades[0].Inicio.CompareTo(y.Disponibilidades[0].Inicio));

            var empleado = empleados.FirstOrDefault();
            if (empleado != null)
                return SplitDisponibilidad(empleado, tarea);

            return null;
        }

        public Empleado SplitDisponibilidad(Empleado empleado, Tarea tarea)
        {
            // a este metodo llega asumiendo  que algunas pre condiciones,
            // por ejemplo que las habilidades cuadren, y que existe una ventana para realizar la tarea

            var disponibilidades = empleado.Disponibilidades.OrderBy(x => x.Inicio).ToList();
            var disponibilidadParaRealizarTarea = disponibilidades.FirstOrDefault(x => x.CantidadHoras >= tarea.DuracionEstimada);
            // se remueve la disponibilidad a usar 
            disponibilidades = disponibilidades.FindAll(x => x.Inicio != disponibilidadParaRealizarTarea.Inicio && x.Fin != disponibilidadParaRealizarTarea.Fin);
            // Se hace un split y se deja una disponbilidad disponible con el tiempo restante
            var (usar, disponible) = disponibilidadParaRealizarTarea.Split(disponibilidadParaRealizarTarea.Inicio.AddHours(tarea.DuracionEstimada));
            usar.Disponible = false;
            usar.TareaId = tarea.Id;
            disponible.Disponible = true;
            disponibilidades.AddRange(new List<Disponibilidad> { usar, disponible });
            disponibilidades.OrderBy(x => x.Inicio);
            empleado.Disponibilidades = disponibilidades;
            return empleado;
        }


        public List<Asignacion> Listar()
        {
            return _repository.Listar();
        }

    }
}
