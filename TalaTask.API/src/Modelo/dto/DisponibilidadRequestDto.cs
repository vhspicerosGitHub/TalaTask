namespace TalaTask.API.src.Modelo
{
    public class DisponibilidadRequestDto
    {
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }

        public bool Disponible { get; set; } = true;

        public double CantidadHoras
        {
            get
            {
                return (Fin - Inicio).TotalHours;
            }
        }
    }
}