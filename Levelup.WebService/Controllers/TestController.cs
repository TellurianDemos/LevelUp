using Levelup.DAL.Abstract;
using Levelup.Data.Core;
using Levelup.WebService.Results;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Levelup.WebService.Controllers
{
    [Authorize]
    public class TestController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public TestController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var entities = await _unitOfWork.Tests.GetAllAsync(x => x.CategoriesInTest, x => x.Department, x => x.SkillLevel);
                //var res = entities.ToList();
                return Json(entities);
            }
            catch (ApplicationException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
