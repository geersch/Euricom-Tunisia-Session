using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Euricom.Web.UI.Infrastructure;
using Euricom.Web.UI.Models;
using MongoDB.Bson;
using MongoDB.Driver.Builders;

namespace Euricom.Web.UI.Controllers.Api
{
    public class TimesheetsController : ApiController
    {
        readonly IMongoContext _mongoContext;

        public TimesheetsController(IMongoContext mongoContext)
        {
            _mongoContext = mongoContext;
        }

        // GET /api/timesheets
        public HttpResponseMessage Get()
        {
            var respository = _mongoContext.GetCollection<Timesheet>();
            var timesheets = respository.FindAll().ToList();

            var response = Request.CreateResponse(HttpStatusCode.OK, timesheets);

            // Where are the timesheets?
            string uri = Url.Route(null, null);
            response.Headers.Location = new Uri(Request.RequestUri, uri);

            return response;
        }

        // GET /api/timesheets/4fd63a86f65e0a0e84e510de
        [HttpGet]
        public Timesheet Get(string id)
        {
            var repository = _mongoContext.GetCollection<Timesheet>();
            var query = Query.EQ("_id", new ObjectId(id));
            return repository.Find(query).Single();
        }

        // POST /api/timesheets
        [HttpPost]
        public HttpResponseMessage Post(Timesheet timesheet)
        {
            var repository = _mongoContext.GetCollection<Timesheet>();
            repository.Insert(timesheet);

            // Where is the new timesheet?
            string uri = Url.Route(null, new { id = timesheet.Id });
            var response = Request.CreateResponse(HttpStatusCode.Created, timesheet);
            response.Headers.Location = new Uri(Request.RequestUri, uri);
            return response;
        }

        // PUT /api/timesheets
        [HttpPut]
        public HttpResponseMessage Put(Timesheet timesheet)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK, timesheet);

            var repository = _mongoContext.GetCollection<Timesheet>();
            repository.Save(timesheet);                       

            // Where is the modified timesheet?
            string uri = Url.Route(null, new { id = timesheet.Id });
            response.Headers.Location = new Uri(Request.RequestUri, uri);

            return response;
        }

        // DELETE /api/timesheets/4fd63a86f65e0a0e84e510de
        public HttpResponseMessage Delete(params string[] ids)
        {
            var repository = _mongoContext.GetCollection<Timesheet>();
            foreach(var id in ids)
            {
                repository.Remove(Query.EQ("_id", new ObjectId(id)));
            }

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }
    }
}
