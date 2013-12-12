using System.Collections.Generic;
using System.Web.Http;
using WebApiArcgisApiDemo.Models; 

namespace WebApiArcgisApiDemo.Controllers
{
    public class DB1ServicesController : ApiController
    {
        private readonly IDAO _db1DAO;

        public DB1ServicesController(IDAO db1DAO)
        {
            _db1DAO = db1DAO;
        }

        public List<object> GetServices()
        {
            return _db1DAO.GetTable("getservices", null);
        }
    }
}
