﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Levelup.Data.Core;
using Levelup.DAL.Abstract;
using Levelup.WebService.Results;
using System.Threading.Tasks;

namespace Levelup.WebService.Controllers
{
    [Authorize]
    public class DepartmentController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var entities = await _unitOfWork.Departments.GetAllAsync();
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
                var item = await _unitOfWork.Departments.GetByIdAsync(id);
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
        public async Task<IHttpActionResult> Post(Department item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var resultAdding = await _unitOfWork.Departments.AddAsync(item);
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
        public async Task<IHttpActionResult> Put(Department item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var resultUpdating = await _unitOfWork.Departments.UpdateAsync(item);
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
                var resultDeleting = await _unitOfWork.Departments.DeleteAsync(id);
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
