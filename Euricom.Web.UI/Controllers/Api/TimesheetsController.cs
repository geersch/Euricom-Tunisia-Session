using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Euricom.Web.UI.Models;

namespace Euricom.Web.UI.Controllers.Api
{
    public class TimesheetsController : ApiController
    {
        // GET /api/timesheets
        public HttpResponseMessage Get()
        {
            var timesheets = GetTimesheets();
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
            var timesheet = (from t in GetTimesheets()
                             where t.Id == new Guid(id)
                             select t).Single();

            return timesheet;
        }

        // POST /api/timesheets
        [HttpPost]
        public HttpResponseMessage Post(Timesheet timesheet)
        {
            var response = Request.CreateResponse(HttpStatusCode.Created, timesheet);

            // Where is the new timesheet?
            string uri = Url.Route(null, new { id = timesheet.Id });
            response.Headers.Location = new Uri(Request.RequestUri, uri);

            UpdateTimesheets(timesheet);

            return response;
        }

        // PUT /api/timesheets
        [HttpPut]
        public HttpResponseMessage Put(Timesheet timesheet)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK, timesheet);

            // Where is the modified timesheet?
            string uri = Url.Route(null, new { id = timesheet.Id });
            response.Headers.Location = new Uri(Request.RequestUri, uri);

            UpdateTimesheets(timesheet);

            return response;
        }

        // DELETE /api/timesheets/4fd63a86f65e0a0e84e510de
        public HttpResponseMessage Delete(params Guid[] ids)
        {
            var timesheets = GetTimesheets();
            foreach(var id in ids)
            {
                var timesheet = (from t in GetTimesheets()
                                 where t.Id == id
                                 select t).SingleOrDefault();
                if (timesheet == null)
                    continue;

                timesheets.Remove(timesheet);
            }

            HttpContext.Current.Cache.Remove("timesheets");
            HttpContext.Current.Cache.Insert("timesheets", timesheets);

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        private IList<Timesheet> GetTimesheets()
        {
            var timesheets = HttpContext.Current.Cache["timesheets"] as List<Timesheet>;
            if (timesheets == null)
            {
                timesheets = new List<Timesheet>
                {
                //    new Timesheet { Id = Guid.NewGuid(), FirstName = "Christophe", LastName = "Geers", Year = 2012, Month = 1 },
                //    new Timesheet { Id = Guid.NewGuid(), FirstName = "Christophe", LastName = "Geers", Year = 2012, Month = 2 },
                //    new Timesheet { Id = Guid.NewGuid(), FirstName = "Christophe", LastName = "Geers", Year = 2012, Month = 3 },
                //    new Timesheet { Id = Guid.NewGuid(), FirstName = "Christophe", LastName = "Geers", Year = 2012, Month = 4 },
                //    new Timesheet { Id = Guid.NewGuid(), FirstName = "Christophe", LastName = "Geers", Year = 2012, Month = 5 },
                //    new Timesheet { Id = Guid.NewGuid(), FirstName = "Christophe", LastName = "Geers", Year = 2012, Month = 6 },
                //    new Timesheet { Id = Guid.NewGuid(), FirstName = "Christophe", LastName = "Geers", Year = 2012, Month = 7 },
                //    new Timesheet { Id = Guid.NewGuid(), FirstName = "Christophe", LastName = "Geers", Year = 2012, Month = 8 }
                };

                HttpContext.Current.Cache.Insert("timesheets", timesheets);
            }

            return timesheets;
        }

        private void UpdateTimesheets(Timesheet timesheet)
        {
            var timesheets = GetTimesheets();

            var oldTimesheet = (from t in GetTimesheets()
                                where t.Id == timesheet.Id
                                select t).SingleOrDefault();

            if (oldTimesheet == null)
            {
                timesheets.Add(timesheet);
            }
            else
            {
                oldTimesheet.FirstName = timesheet.FirstName;
                oldTimesheet.LastName = timesheet.LastName;
                oldTimesheet.Month = timesheet.Month;
                oldTimesheet.Year = timesheet.Year;
            }

            HttpContext.Current.Cache.Remove("timesheets");
            HttpContext.Current.Cache.Insert("timesheets", timesheets);
        }
    }
}
