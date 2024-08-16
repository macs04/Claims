using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;

namespace WebApplicationMVC.Models
{
  public class Persona
  {
    public int id { get; set; }
    public string compania { get; set; }
    [RegularExpression(@"[a-zA-Z ]+", ErrorMessage = "Solo puede tener letras")]
    public string contacto { get; set; }
    [EmailAddress]
    public string correo { get; set; }
    [Range(1000000000, 9999999999, ErrorMessage = "Debe tener 10 digitos")]
    public long telefono { get; set; }
  }
}
