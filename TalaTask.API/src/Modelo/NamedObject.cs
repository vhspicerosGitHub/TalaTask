namespace TalaTask.API.src.Modelo
{
    public abstract class NamedObject : IdentificableObject
    {
        public string Nombre { get; set; } = string.Empty;
    }
}
