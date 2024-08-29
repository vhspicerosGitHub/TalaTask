namespace TalaTask.API.src.Modelo
{

    public class EmpleadoRequestDto : NamedObject
    {
        public List<string> Habilidades { get; set; } = new List<string>();
        public List<DisponibilidadRequestDto> Disponibilidades { get; set; } = new List<DisponibilidadRequestDto>();
    }
}