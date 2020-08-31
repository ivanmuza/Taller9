using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndProyecto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEndProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectoController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public ProyectoController(AplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<ProyectoController>
        [HttpGet]

        public ActionResult<List<Proyecto>> Get()
        {
            try
            {
                var listComentario = _context.Proyecto.ToList();
                return Ok(listComentario);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ProyectoController>/5
        [HttpGet("{id}")]
        public ActionResult<Proyecto> Get(int id)
        {
            try
            {
                var comentario = _context.Proyecto.Find(id);
                if(comentario == null)
                {
                    return NotFound();
                }
                return Ok(comentario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ProyectoController>
        [HttpPost]
        public ActionResult Post([FromBody] Proyecto comentario)
        {
            try
            {
                comentario.FechaCreacion = DateTime.Now;
                _context.Add(comentario);
                _context.SaveChanges();

                return Ok(comentario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ProyectoController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Proyecto comentario)
        {
            try
            {
                if(id != comentario.Id)
                {
                    return BadRequest();
                }
                _context.Entry(comentario).State = EntityState.Modified;
                _context.Update(comentario);
                _context.SaveChanges();

                return Ok(comentario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ProyectoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var comentario = _context.Proyecto.Find(id);
                if(comentario == null)
                {
                    return NotFound();
                }
                _context.Remove(comentario);
                _context.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
