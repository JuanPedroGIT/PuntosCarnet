using System.ComponentModel.DataAnnotations;

namespace API.DTO
{
    public class VehiculoDTO
    {
       [Required] 
        public string Matricula { get; set; }
       [Required] 
        public string  Marca { get; set; }
       [Required] 
        public string Modelo { get; set; }
       [Required] 
        public string Dni { get; set; }
    }
}