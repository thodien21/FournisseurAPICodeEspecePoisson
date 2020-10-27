using APIServiceProposions.DAL;
using APIServiceProposions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIServiceProposions.Controllers
{
    public class CodeEspecePoissonController : ApiController
    {
        // GET: api/CodeEspecePoisson
        public IEnumerable<CodeEspecePoisson> Get()
        {
            CodeEspecePoissonDAL allpoissons = new CodeEspecePoissonDAL();
            return allpoissons.GetAllPoisson();
        }

        // GET: api/CodeEspecePoisson/5
        public HttpResponseMessage Get(int id)
        {
            CodeEspecePoissonDAL allpoissons = new CodeEspecePoissonDAL();
            var poissonDB = allpoissons.GetAllPoisson().Where(p => p.Code_Taxon == id);
            if (poissonDB == null || poissonDB.Count() == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Poisson avec code taxon " + id + " non trouvé");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, poissonDB);
            }
        }

        // POST: api/CodeEspecePoisson
        public IEnumerable<CodeEspecePoisson> Post([FromBody]CodeEspecePoisson poisson)
        {
            CodeEspecePoissonDAL allpoissons = new CodeEspecePoissonDAL();
            allpoissons.InsertPoisson(poisson);
            return allpoissons.GetAllPoisson();
        }

        // PUT: api/CodeEspecePoisson/5 
        public HttpResponseMessage Put(int id, [FromBody]CodeEspecePoisson poisson)
        {
            CodeEspecePoissonDAL allpoissons = new CodeEspecePoissonDAL();
            var poissonDB = allpoissons.GetAllPoisson().Where(p => p.Code_Taxon == id);
            if (poissonDB == null || poissonDB.Count() == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Poisson avec code taxon " + id + " non trouvé");
            }
            else
            {
                allpoissons.UpdatePoissons(id, poisson);
                return Request.CreateResponse(HttpStatusCode.OK, poisson);
            }
        }

        // DELETE: api/CodeEspecePoisson/5
        public HttpResponseMessage Delete(int id)
        {
            CodeEspecePoissonDAL allpoissons = new CodeEspecePoissonDAL();
            var poissonDB = allpoissons.GetAllPoisson().Where(p => p.Code_Taxon == id);
            if (poissonDB == null || poissonDB.Count() == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Poisson avec code taxon " + id + " non trouvé");
            }
            else
            {
                allpoissons.DeletePoisson(id);
                return Request.CreateResponse(HttpStatusCode.OK, poissonDB.Count() + " poisson(s) avec code taxon " + id + " supprimé(s)");
            }
        }
    }
}
