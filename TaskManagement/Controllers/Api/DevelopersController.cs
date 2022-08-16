using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using TaskManagement.Dtos;
using TaskManagement.Models;
using TaskManagement.Models.Application;

namespace TaskManagement.Controllers.Api
{
    public class DevelopersController : ApiController
    {
        private readonly IApplicationDbContext context;

        public DevelopersController(IApplicationDbContext context)
        {
            this.context = context;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            context.Dispose();
        }

        // GET /api/developers
        public IHttpActionResult GetDevelopers(string query = null)
        {
            var developersQuery = !string.IsNullOrEmpty(query) ?
                context.Developers.Where(t => t.Name.Contains(query)) :
                context.Developers;

            var developers = developersQuery
                .Include(t => t.Tasks)
                .Select(Mapper.Map<Developer, DeveloperDto>)
                .ToList();

            return Ok(developers);
        }
    }
}
