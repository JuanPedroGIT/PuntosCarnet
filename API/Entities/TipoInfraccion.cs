namespace API.Entities
{
    public class TipoInfraccion: BaseEntity
    {
        public TipoInfraccion()
        {
        }

        public TipoInfraccion(string nombre, string descripcion, int puntosAdescontar)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            PuntosAdescontar = puntosAdescontar;
        }

        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int PuntosAdescontar { get; set; }
    }
}