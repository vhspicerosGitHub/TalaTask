namespace TalaTask.API.src.Modelo
{

    public class Empleado : NamedObject
    {
        public List<string> Habilidades { get; set; } = new List<string>();
        public List<Disponibilidad> Disponibilidades { get; set; } = new List<Disponibilidad>();

        public void AsignarTarea(Tarea tarea)
        {


            // a este metodo llega asumiendo  que algunas pre condiciones,
            // por ejemplo que las habilidades cuadren, y que existe una ventana para realizar la tarea

            var disponibilidades = Disponibilidades.OrderBy(x => x.Inicio).ToList();
            var disponibilidadParaRealizarTarea = disponibilidades.FirstOrDefault(x => x.Disponible && x.CantidadHoras >= tarea.DuracionEstimada);

            // se remueve la disponibilidad a usar (usa la fecha de inicio y termino)
            disponibilidades = disponibilidades.FindAll(x => x.Inicio != disponibilidadParaRealizarTarea.Inicio && x.Fin != disponibilidadParaRealizarTarea.Fin);

            // Se hace un split y se deja una disponbilidad disponible con el tiempo restante
            var (usar, disponible) = disponibilidadParaRealizarTarea.Split(disponibilidadParaRealizarTarea.Inicio.AddHours(tarea.DuracionEstimada));
            usar.Disponible = false;
            disponible.Disponible = true;
            disponibilidades.AddRange(new List<Disponibilidad> { usar, disponible });
            disponibilidades.OrderBy(x => x.Inicio);
            Disponibilidades = disponibilidades;
        }
    }
}