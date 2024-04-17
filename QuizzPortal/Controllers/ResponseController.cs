using AutoMapper;
using BusinessLogicLayer;
using Microsoft.AspNetCore.Mvc;
using QuizzPortal.Models;
using System;
using System.Collections.Generic;

namespace QuizzPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponseController : ControllerBase
    {
        private readonly BLLibrary _bLLibrary;
        private readonly IMapper _mapper;

        public ResponseController(BLLibrary bLLibrary, IMapper mapper)
        {
            _bLLibrary = bLLibrary;
            _mapper = mapper;
        }

        // POST api/response
        [HttpPost]
        public IActionResult CreateResponse(ResponseModel responseModel)
        {
            try
            {
                var responseBLL = _mapper.Map<ResponseBLL>(responseModel);
                var createdResponse = _bLLibrary.CreateResponse(responseBLL);
                var createdResponseModel = _mapper.Map<ResponseModel>(createdResponse);
                return Ok(new { message = "Response created successfully", response = createdResponseModel });
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as appropriate
                return StatusCode(500, "An error occurred while creating the response.");
            }
        }

        // GET api/response/{id}
        [HttpGet("{id}")]
        public IActionResult GetResponse(int id)
        {
            try
            {
                var responseBLL = _bLLibrary.GetResponse(id);
                var responseModel = _mapper.Map<ResponseModel>(responseBLL);
                return Ok(responseModel);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as appropriate
                return StatusCode(500, "An error occurred while retrieving the response.");
            }
        }

        // GET api/response
        [HttpGet]
        public IActionResult GetAllResponses()
        {
            try
            {
                var responseBLLs = _bLLibrary.GetAllResponses();
                var responseModels = _mapper.Map<IEnumerable<ResponseModel>>(responseBLLs);
                return Ok(responseModels);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as appropriate
                return StatusCode(500, "An error occurred while retrieving all responses.");
            }
        }

        // PUT api/response/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateResponse(int id, ResponseModel responseModel)
        {
            try
            {
                if (id != responseModel.Id)
                {
                    return BadRequest();
                }

                var responseBLL = _mapper.Map<ResponseBLL>(responseModel);
                _bLLibrary.UpdateResponse(responseBLL);

                return Ok(new { message = "Response updated successfully" });
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as appropriate
                return StatusCode(500, "An error occurred while updating the response.");
            }
        }

        // DELETE api/response/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteResponse(int id)
        {
            try
            {
                _bLLibrary.DeleteResponse(id);
                return Ok(new { message = "Response deleted successfully" });
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as appropriate
                return StatusCode(500, "An error occurred while deleting the response.");
            }
        }
    }
}
