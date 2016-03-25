using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Levelup.Data.Core;
using Levelup.DAL.Abstract;
using Levelup.WebService.Results;

namespace Levelup.WebService.Controllers
{
    [Authorize]
    public class QuestionTypeController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public QuestionTypeController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var entities = await _unitOfWork.QuestionTypes.GetAllAsync();
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

        public async Task<IHttpActionResult> Get(int id)
        {
            try
            {
                var item = await _unitOfWork.QuestionTypes.GetByIdAsync(id);
                return Json(item);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Authorize(Roles = "Admin")]
        public async Task<IHttpActionResult> Post(QuestionType item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var resultAdding = await _unitOfWork.QuestionTypes.AddAsync(item);
                if (!resultAdding)
                    return BadRequest("Some error in adding entity");
                var resultSaving = await _unitOfWork.SaveAsync();
                if (!resultSaving)
                    return BadRequest("Some error in saving entity");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        public async Task<IHttpActionResult> Put(QuestionType item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var resultUpdating = await _unitOfWork.QuestionTypes.UpdateAsync(item);
                if (!resultUpdating)
                    return BadRequest("Some error in updating entity");
                var resultSaving = await _unitOfWork.SaveAsync();
                if (!resultSaving)
                    return BadRequest("Some error in saving entity");
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                var resultDeleting = await _unitOfWork.QuestionTypes.DeleteAsync(id);
                if (!resultDeleting)
                    return BadRequest("Some error in updating entity");
                var resultSaving = await _unitOfWork.SaveAsync();
                if (!resultSaving)
                    return BadRequest("Some error in saving entity");
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            return Ok();
        }
    }
}
