using TalaTask.API.src.Infraestrutura.Repositorios.Impl.Memory;
using TalaTask.API.src.Infraestrutura.Repositorios.Interfaces;
using TalaTask.API.src.Modelo;
using TalaTask.API.src.Negocio;
using TalaTask.API.src.Utils;

namespace TalaTask.Tests
{
    public class SplitAsignacionTEST
    {
        private IAsignacionRepository _asignacionRepository;
        private ITareaRepository _tareaRepository;
        private IEmpleadoRepository _empleadoRepository;
        private AsignacionesServices asignacionesServices;

        [SetUp]
        public void Setup()
        {
            _asignacionRepository = new AsignacionRepository();
            _tareaRepository = new TareaRepository();
            _empleadoRepository = new EmpleadoRepository();
            asignacionesServices = new AsignacionesServices(_asignacionRepository, _tareaRepository, _empleadoRepository);
        }

        [Test]
        public void TestNoencuentraHabilidad()
        {
            var empleado = new Empleado { Nombre = "Pedro", Id = 1, Habilidades = new List<string> { "Javascript", "C#" } };
            empleado.Disponibilidades.Add(new Disponibilidad { Inicio = new DateTime(2024, 01, 01, 10, 00, 00), Fin = new DateTime(2024, 01, 01, 20, 00, 00), });

            var tarea = new Tarea { Id = 1, Titulo = "Tarea 1", Habilidades = new List<string> { "Javascript" }, DuracionEstimada = 2, FechaDeadLine = new DateTime(2024, 01, 01, 13, 00, 00) };
            _tareaRepository.Crear(tarea);

            empleado = asignacionesServices.SplitDisponibilidad(empleado, tarea);
            Assert.AreEqual(2, empleado.Disponibilidades.Count);
        }
    }
}