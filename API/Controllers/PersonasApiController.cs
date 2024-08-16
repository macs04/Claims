//https://learn.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-8.0&tabs=visual-studio
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplicationMVC.Models;

namespace WebApplicationMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasApiController : ControllerBase
    {
        private static List<Persona> personas = new List<Persona>();

        [HttpPost]
        public IActionResult Post(Persona persona)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            personas.Add(persona);
            return Ok(persona);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(personas);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var person = personas.FirstOrDefault(p => p.id == id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Persona newPersona)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var persona = personas.FirstOrDefault(p => p.id == id);
            if (persona == null)
            {
                return NotFound();
            }
            persona.compania = newPersona.compania;
            persona.contacto = newPersona.contacto;
            persona.correo = newPersona.correo;
            persona.telefono = newPersona.telefono;
            return Ok(persona);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var persona = personas.FirstOrDefault(p => p.id == id);
            if (persona == null)
            {
                return NotFound();
            }

            personas.Remove(persona);
            return Ok();
        }
    }
}
