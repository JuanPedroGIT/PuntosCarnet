using System.ComponentModel.DataAnnotations;

namespace API.DTO
{
    public class RegistroInfraccionDTO
    {
       [Required] 
       public string Dni { get; set; }
       [Required] 
        public string Matricula { get; set; }
       [Required] 
        public string NombreInfraccion { get; set; }
    }
}