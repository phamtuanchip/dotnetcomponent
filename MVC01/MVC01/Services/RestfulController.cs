using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using MVC01.Models;
namespace MVC01.Services
{
    public class RestfulController : ApiController
    {
        MusicStoreEntities db = new MusicStoreEntities();
        // GET: api/Restful
         
        public JsonResult<List<Album>> Get()
        {
            
            return Json(db.Albums.ToList());
        }

        // GET: api/Restful/5
        public JsonResult<Album> Get(int id)
        {
            return Json(db.Albums.Find(id));
        }

        // GET: api/Restful/Search?key=
        // Need to update WebApiConfig

        [HttpGet]
        public JsonResult<List<Album>> Search(String key)
        {
            var result = db.Albums.Where(x => x.Title.ToLower().StartsWith(key.ToLower())).ToList();
            return Json(result);
        }

        // POST: api/Restful
        public HttpResponseMessage Post([FromBody]string value)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, value);
            return response;
        }

        // PUT: api/Restful/5
        public HttpResponseMessage Put(int id, [FromBody]string value)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, value);
            return response;

        }

        // DELETE: api/Restful/5
        public void Delete(int id)
        {
        }
    }
}
