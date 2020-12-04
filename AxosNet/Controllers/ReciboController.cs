using AxosNet.Context;
using AxosNet.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AxosNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReciboController : ControllerBase
    {
        private readonly AppDbContext context;
        public ReciboController(AppDbContext context)
        {
            this.context = context;
        }
        // GET: api/<ReciboController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.Tb_Recibos_Bd.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ReciboController>/5
        [HttpGet("{id}", Name = "GetRecibo")]
        public ActionResult Get(int id)
        {
            try
            {
                var recivo = context.Tb_Recibos_Bd.FirstOrDefault(g => g.ID_Proveedor == id);
                return Ok(recivo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ReciboController>
        [HttpPost]
        public ActionResult Post([FromBody] Recibos_Bd recivo)
        {
            try
            {
                context.Tb_Recibos_Bd.Add(recivo);
                context.SaveChanges();
                return CreatedAtRoute("GetRecibo", new { id = recivo.ID_Proveedor }, recivo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ReciboController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Recibos_Bd recivo)
        {
            try
            {
                if (recivo.ID_Proveedor == id)
                {
                    context.Entry(recivo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetRecibo", new { id = recivo.ID_Proveedor }, recivo);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ReciboController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var recivo = context.Tb_Recibos_Bd.FirstOrDefault(g => g.ID_Proveedor == id);
                if (recivo != null)
                {
                    context.Tb_Recibos_Bd.Remove(recivo);
                    context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
