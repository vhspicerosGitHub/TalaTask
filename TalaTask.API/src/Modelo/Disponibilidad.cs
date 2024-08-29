namespace TalaTask.API.src.Modelo
{
    public class Disponibilidad
    {
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }

        public bool Disponible { get; set; } = true;
        public Int32 TareaId { get; set; }
        public DateTime? FechaAsignacion { get; set; }

        public double CantidadHoras
        {
            get
            {
                return (Fin - Inicio).TotalHours;
            }
        }

        public (Disponibilidad, Disponibilidad) Split(DateTime fechaCorte)
        {
            var disini = new Disponibilidad { Inicio = Inicio, Fin = fechaCorte };
            var disfin = new Disponibilidad { Inicio = fechaCorte, Fin = Fin };
            return (disini, disfin);
        }
    }
}