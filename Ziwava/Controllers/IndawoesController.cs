using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Spatial;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Ziwava.Models;

namespace Ziwava.Controllers
{
    public class IndawoesController : ApiController
    {
        private ZiwavaContext db = new ZiwavaContext();

        // GET: api/Indawoes
        public List<Indawo> GetIndawoes(string userLocation, string distance)
        {
            var lon = userLocation.Split(',')[0];
            var lat = userLocation.Split(',')[1];

            var listOfIndawoes = Helper.GetNearByLocations(lat, lon,Convert.ToInt32(distance), db); // TODO: Use distance to narrow search
            //var listOfIndawoes = LoadJson(@"C:\Users\sibongisenib\Documents\ImportantRecentProjects\listOfIndawoes.json");

            foreach (var item in listOfIndawoes)
                item.images = db.Images.Where(x => x.indawoId == item.id).ToList();
            return listOfIndawoes;
        }


        public List<Indawo> LoadJson(string path)
        {
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                List<Indawo> items = JsonConvert.DeserializeObject<List<Indawo>>(json);
                return items;
            }
        }

        // GET: api/Indawoes/5
        [ResponseType(typeof(Indawo))]
        public IHttpActionResult GetIndawo(int id)
        {
            //Indawo indawo = db.Indawoes.Find(id);
            Indawo indawo = LoadJson(@"C:\Users\sibongisenib\Documents\ImportantRecentProjects\listOfIndawoes.json").First(x => x.id == id);
            if (indawo == null)
            {
                return NotFound();
            }

            return Ok(indawo);
        }

        // PUT: api/Indawoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutIndawo(int id, Indawo indawo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != indawo.id)
            {
                return BadRequest();
            }

            db.Entry(indawo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IndawoExists(id))
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

        // POST: api/Indawoes
        [ResponseType(typeof(Indawo))]
        public List<Indawo> PostIndawo(string userLocation, string distance)
        {
            var format = new NumberFormatInfo();
            format.NegativeSign = "-";
            format.NumberDecimalSeparator = ".";
            var lon = userLocation.Split(',')[0];
            var lat = userLocation.Split(',')[1];

            var listOfIndawo = Helper.GetNearByLocations(lat, lon, Convert.ToInt32(distance), db);

            return listOfIndawo;
        }

        private List<Indawo> getPlacesWithInDistance(string userLocation, List<Indawo> listOfIndawo, string distance)
        {
            throw new NotImplementedException();
        }
        private List<Indawo> getIndawoWithIn50k(string userLocation)
        {
            //Using only userLocation return a list of places with in 50K of location
            throw new NotImplementedException();
        }

        // DELETE: api/Indawoes/5
        [ResponseType(typeof(Indawo))]
        public IHttpActionResult DeleteIndawo(int id)
        {
            Indawo indawo = db.Indawoes.Find(id);
            if (indawo == null)
            {
                return NotFound();
            }

            db.Indawoes.Remove(indawo);
            db.SaveChanges();

            return Ok(indawo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IndawoExists(int id)
        {
            return db.Indawoes.Count(e => e.id == id) > 0;
        }
    }
}