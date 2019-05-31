using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ziwava.Models;

namespace Ziwava.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
            
        }

        // GET api/values/5
        public string Get(string str)
        {
            return str;
        }

        // POST api/values
        public List<Indawo> Post(string userLocation,string distance)
        {
            var format = new NumberFormatInfo();
            format.NegativeSign = "-";
            format.NumberDecimalSeparator = ".";   
            var l1      = userLocation.Split(',')[0];
            var l2      = userLocation.Split(',')[0];
            var long1   = Double.Parse(l1, format);
            var lat1    = Double.Parse(l2, format);

            List<Indawo> listOfIndawo   = getIndawoWithIn50k(userLocation); // Reqires implementation
            List<Indawo> finalList      = getPlacesWithInDistance(userLocation,listOfIndawo,distance);// Reqires implementation
            return listOfIndawo;
        }
        private List<Indawo> getPlacesWithInDistance(string userLocation,List<Indawo> listOfIndawo, string distance){
            throw new NotImplementedException();
        }
        private List<Indawo> getIndawoWithIn50k(string userLocation){
            //Using only userLocation return a list of places with in 50K of location
            throw new NotImplementedException();
        }
        public double DistanceTo(double lat1, double lon1, double lat2, double lon2, char unit = 'K')
        {
            double rlat1    = Math.PI * lat1 / 180;
            double rlat2    = Math.PI * lat2 / 180;
            double theta    = lon1 - lon2;
            double rtheta   = Math.PI * theta / 180;
            double dist     =
                Math.Sin(rlat1) * Math.Sin(rlat2) + Math.Cos(rlat1) *
                Math.Cos(rlat2) * Math.Cos(rtheta);
            dist = Math.Acos(dist);
            dist = dist * 180 / Math.PI;
            dist = dist * 60 * 1.1515;

            switch (unit)
            {
                case 'K': //Kilometers -> default
                    return dist * 1.609344;
                case 'N': //Nautical Miles 
                    return dist * 0.8684;
                case 'M': //Miles
                    return dist;
            }

            return dist;
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
