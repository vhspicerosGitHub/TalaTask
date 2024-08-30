namespace TalaTask.API.src.Modelo
{

    public class Empleado : NamedObject
    {
        public List<string> Habilidades { get; set; } = new List<string>();
        public List<Disponibilidad> Disponibilidades { get; set; } = new List<Disponibilidad>();

    }
}