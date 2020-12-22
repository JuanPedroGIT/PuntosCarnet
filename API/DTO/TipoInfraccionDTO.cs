using System.ComponentModel.DataAnnotations;

namespace API.DTO
{
    public class TipoInfraccionDTO
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public int PuntosAdescontar { get; set; }
    }
}