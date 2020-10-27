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
        public CodeEspecePoisson Get(int id)
        {
            CodeEspecePoissonDAL allpoissons = new CodeEspecePoissonDAL();
            return allpoissons.GetAllPoisson().FirstOrDefault(p => p.Code_Taxon == id);
        }

        // POST: api/CodeEspecePoisson
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/CodeEspecePoisson/5 
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CodeEspecePoisson/5
        public void Delete(int id)
        {
        }
    }
}
