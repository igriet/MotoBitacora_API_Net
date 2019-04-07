using Bitacora_API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bitacora_API.Controllers
{
    public class BitacoraController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Registros> Get()
        {
            using (var db = new BitacoraEntities())
            {
                return db.Registros.ToList();
            }
        }

        // GET api/<controller>/5
        public Registros Get(string id)
        {
            using (var db = new BitacoraEntities())
            {
                return db.Registros.FirstOrDefault(x => x.id.Equals(id));
            }
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody]Registros item)
        {
            try
            {
                using (var db = new BitacoraEntities())
                {
                    item.id = Guid.NewGuid().ToString();
                    item.fechaRegistro = DateTime.Now.Date;
                    db.Registros.Add(item);
                    db.SaveChanges();
                }
                return Ok(item);
            }
            catch(Exception ex)
            {
                return BadRequest("Error al guardar el registro en la bitacora");
            }
        }

        // PUT api/<controller>/5
        public void Put(string id, [FromBody]Registros item)
        {
            using (var db = new BitacoraEntities())
            {
                Registros oldValue = db.Registros.FirstOrDefault(x => x.id.Equals(id));
                oldValue = item;
                db.SaveChanges();
            }
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            using (var db = new BitacoraEntities())
            {
                Registros oldValue = db.Registros.FirstOrDefault(x => x.id.Equals(id));
                db.Registros.Remove(oldValue);
                db.SaveChanges();
            }
        }
    }
}