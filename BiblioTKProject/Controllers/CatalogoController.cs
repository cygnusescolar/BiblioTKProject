using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using BiblioTKProject.Models;

namespace BiblioTKProject.Controllers
{
    public class CatalogoController : ApiController
    {
       // private CygnusBiblioTKv2Entities db = new CygnusBiblioTKv2Entities();



        //// GET: api/Catalogo
        public async Task<IEnumerable<CatalogoViewModel>> GetCatalogo()
        {
            //var listaCatalogo = await db.tbl_BiblioTK_Catalogo.Select(x => new { Titulo = x.cat_Titulo, Anio = x.cat_Año}).ToList();
            //return listaCatalogo;

            var listaCatalogo = from c in db.tbl_BiblioTK_Catalogo
                        orderby c.catalogo_uid ascending
                        select  new CatalogoViewModel { cat_Titulo = c.cat_Titulo, cat_Año = c.cat_Año };
            return await listaCatalogo.ToListAsync();
        }
 
        // GET: api/Catalogo/5
        //[ResponseType(typeof(tbl_BiblioTK_Catalogo))]
        public async Task<IHttpActionResult> GetCatalogo(Guid id)
        {
            tbl_BiblioTK_Catalogo tbl_BiblioTK_Catalogo = await db.tbl_BiblioTK_Catalogo.FindAsync(id);
            if (tbl_BiblioTK_Catalogo == null)
            {
                return NotFound();
            }

            return Ok(tbl_BiblioTK_Catalogo);
        }

        // PUT: api/Catalogo/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCatalogo(Guid id, tbl_BiblioTK_Catalogo tbl_BiblioTK_Catalogo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_BiblioTK_Catalogo.catalogo_uid)
            {
                return BadRequest();
            }

            db.Entry(tbl_BiblioTK_Catalogo).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatalogoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Catalogo
        [ResponseType(typeof(tbl_BiblioTK_Catalogo))]
        public async Task<IHttpActionResult> PostCatalogo(tbl_BiblioTK_Catalogo tbl_BiblioTK_Catalogo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_BiblioTK_Catalogo.Add(tbl_BiblioTK_Catalogo);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CatalogoExists(tbl_BiblioTK_Catalogo.catalogo_uid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tbl_BiblioTK_Catalogo.catalogo_uid }, tbl_BiblioTK_Catalogo);
        }

        // DELETE: api/Catalogo/5
        [ResponseType(typeof(tbl_BiblioTK_Catalogo))]
        public async Task<IHttpActionResult> DeleteCatalogo(Guid id)
        {
            tbl_BiblioTK_Catalogo tbl_BiblioTK_Catalogo = await db.tbl_BiblioTK_Catalogo.FindAsync(id);
            if (tbl_BiblioTK_Catalogo == null)
            {
                return NotFound();
            }

            db.tbl_BiblioTK_Catalogo.Remove(tbl_BiblioTK_Catalogo);
            await db.SaveChangesAsync();

            return Ok(tbl_BiblioTK_Catalogo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CatalogoExists(Guid id)
        {
            return db.tbl_BiblioTK_Catalogo.Count(e => e.catalogo_uid == id) > 0;
        }
    }
}