using TalaTask.API.src.Infraestrutura.Repositorios.Impl.Memory;
using TalaTask.API.src.Infraestrutura.Repositorios.Interfaces;
using TalaTask.API.src.Modelo;
using TalaTask.API.src.Negocio;

namespace TalaTask.Tests
{
    public class AsignacionesttTest
    {
        private IAsignacionRepository _asignacionRepository;
        private ITareaRepository _tareaRepository;
        private IEmpleadoRepository _empleadoRepository;
        private  AsignacionesServices asignacionesServices;

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
            empleado.Disponibilidades.Add(new Disponibilidad { Inicio = DateTime.Now, Fin = DateTime.Now.AddHours(3), });
            _empleadoRepository.Crear(empleado);
            empleado = new Empleado { Nombre = "Juan", Id = 2, Habilidades = new List<string> { "Go", "C#" } };
            empleado.Disponibilidades.Add(new Disponibilidad { Inicio = DateTime.Now.AddHours(1), Fin = DateTime.Now.AddHours(2), });

            _empleadoRepository.Crear(empleado);
            empleado = new Empleado { Nombre = "DiegoD", Id = 3, Habilidades = new List<string> { "Python", "C#" } };
            empleado.Disponibilidades.Add(new Disponibilidad { Inicio = DateTime.Now.AddHours(2), Fin = DateTime.Now.AddHours(2), });

            _empleadoRepository.Crear(empleado);


            var tarea = new Tarea { Id = 1, Titulo = "Tarea 1", Habilidades = new List<string> { "PHP" }, DuracionEstimada = 2, FechaDeadLine = DateTime.Now.AddHours(10) };
            _tareaRepository.Crear(tarea);

            var empleadoMejorAsignacion = asignacionesServices.AsignarTarea(tarea);
            Assert.IsNull(empleadoMejorAsignacion);
        }

        [Test]
        public void TestSinEmpleados()
        {
            var tarea = new Tarea { Id = 1, Titulo = "Tarea 1", Habilidades = new List<string> { "PHP" }, DuracionEstimada = 2, FechaDeadLine = DateTime.Now.AddHours(10) };
            _tareaRepository.Crear(tarea);

            var empleadoMejorAsignacion = asignacionesServices.AsignarTarea(tarea);
            Assert.IsNull(empleadoMejorAsignacion);
        }

        [Test]
        public void Test1()
        {
            var empleado = new Empleado { Nombre = "Pedro", Id = 1, Habilidades = new List<string> { "Javascript", "C#" } };
            empleado.Disponibilidades.Add(new Disponibilidad { Inicio = DateTime.Now, Fin = DateTime.Now.AddHours(3), });
            _empleadoRepository.Crear(empleado);
            empleado = new Empleado { Nombre = "Juan", Id = 2, Habilidades = new List<string> { "Go", "C#" } };
            empleado.Disponibilidades.Add(new Disponibilidad { Inicio = DateTime.Now.AddHours(1), Fin = DateTime.Now.AddHours(2), });

            _empleadoRepository.Crear(empleado);
            empleado = new Empleado { Nombre = "DiegoD", Id = 3, Habilidades = new List<string> { "Python", "C#" } };
            empleado.Disponibilidades.Add(new Disponibilidad { Inicio = DateTime.Now.AddHours(2), Fin = DateTime.Now.AddHours(2), });

            _empleadoRepository.Crear(empleado);


            var tarea = new Tarea { Id = 1, Titulo = "Tarea 1", Habilidades = new List<string> { "C#" }, DuracionEstimada = 2, FechaDeadLine = DateTime.Now.AddHours(10) };
            _tareaRepository.Crear(tarea);

            var empleadoMejorAsignacion = asignacionesServices.AsignarTarea(tarea);

            Assert.NotNull(empleadoMejorAsignacion);
            Assert.AreEqual(1, empleadoMejorAsignacion.Id);
        }

     
    }
}
