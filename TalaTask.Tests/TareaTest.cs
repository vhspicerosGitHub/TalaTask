using TalaTask.API.src.Infraestrutura.Repositorios.Impl.Memory;
using TalaTask.API.src.Infraestrutura.Repositorios.Interfaces;
using TalaTask.API.src.Modelo;
using TalaTask.API.src.Negocio;
using TalaTask.API.src.Utils;

public class TareaTest
{

    private ITareaRepository _tareaRepository;
    private TareaServices _tareaServices;

    [SetUp]
    public void Setup()
    {

        _tareaRepository = new TareaRepository();
        _tareaServices = new TareaServices(_tareaRepository);


    }

    [Test]
    public void TareaDuplicada()
    {
        var tarea = new Tarea { Id = 1, Titulo = "Tarea 1", Habilidades = new List<string> { "PHP" }, DuracionEstimada = 2, FechaDeadLine = DateTime.Now.AddHours(10) };

        _tareaServices.Crear(tarea);
        var ex = Assert.Throws<AppException>(code: () => _tareaServices.Crear(tarea));
    }
}