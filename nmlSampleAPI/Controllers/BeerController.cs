using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using nmlSampleAPI.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;


namespace nmlSampleAPI.Controllers
{
    public class BeerController : ApiController
    {
        // GET: api/Beer
        [Route("api/beer/")]
        public List<Beer> Get()
        {
            BeerData bd = new Controllers.BeerData();

            return bd.GetAll();
        }

        // GET: api/Beer/5
        [Route("api/beer/{id:int}")]
        public List<Beer> GetById(int id)
        {
            List<Beer> beerinfo = new List<Beer>();

            string Baseurl = "http://api.punkapi.com"; /*add to config*/

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(Baseurl);

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                client.DefaultRequestHeaders.Clear();


                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = client.GetAsync($"/v2/beers/{id}").Result;

                if (Res.IsSuccessStatusCode)
                {

                    var beerResponse = Res.Content.ReadAsStringAsync().Result;


                    beerinfo = JsonConvert.DeserializeObject<List<Beer>>(beerResponse);

                }

                return beerinfo;

            }
        }
        [Route("api/beer/{name}")]
        public List<Beer> GetByName(string name)
        {
            List<Beer> beerinfo = new List<Beer>();

            string Baseurl = "http://api.punkapi.com"; /*add to config*/

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(Baseurl);

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                client.DefaultRequestHeaders.Clear();


                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = client.GetAsync($"/v2/beers?beer_name={name}").Result;

                if (Res.IsSuccessStatusCode)
                {

                    var beerResponse = Res.Content.ReadAsStringAsync().Result;


                    beerinfo = JsonConvert.DeserializeObject<List<Beer>>(beerResponse);

                }

                return beerinfo;

            }
        }

    }

    public class BeerData
    {
        public List<Beer> GetAll()
        {
            List<Beer> beerinfo = new List<Beer>();

            string Baseurl = "http://api.punkapi.com"; /*add to config*/

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(Baseurl);

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                client.DefaultRequestHeaders.Clear();


                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = client.GetAsync("/v2/beers").Result;

                if (Res.IsSuccessStatusCode)
                {

                    var beerResponse = Res.Content.ReadAsStringAsync().Result;


                    beerinfo = JsonConvert.DeserializeObject<List<Beer>>(beerResponse);

                }

                return beerinfo;

            }

        }
    }
}
