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
    public class ResponseAnswerController : ControllerBase
    {
        private readonly BLLibrary _bLLibrary;
        private readonly IMapper _mapper;

        public ResponseAnswerController(BLLibrary bLLibrary, IMapper mapper)
        {
            _bLLibrary = bLLibrary;
            _mapper = mapper;
        }

        // POST api/responseanswer
        [HttpPost]
        public IActionResult CreateResponseAnswer(ResponseAnswerModel responseAnswerModel)
        {
            try
            {
                var responseAnswerBLL = _mapper.Map<ResponseAnswerBLL>(responseAnswerModel);
                var createdResponseAnswer = _bLLibrary.CreateResponseAnswer(responseAnswerBLL);
                var createdResponseAnswerModel = _mapper.Map<ResponseAnswerModel>(createdResponseAnswer);
                return Ok(new { message = "Response answer created successfully", responseAnswer = createdResponseAnswerModel });
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as appropriate
                return StatusCode(500, "An error occurred while creating the response answer.");
            }
        }

        // GET api/responseanswer/{id}
        [HttpGet("{id}")]
        public IActionResult GetResponseAnswer(int id)
        {
            try
            {
                var responseAnswerBLL = _bLLibrary.GetResponseAnswer(id);
                var responseAnswerModel = _mapper.Map<ResponseAnswerModel>(responseAnswerBLL);
                return Ok(responseAnswerModel);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as appropriate
                return StatusCode(500, "An error occurred while retrieving the response answer.");
            }
        }

        // GET api/responseanswer
        [HttpGet]
        public IActionResult GetAllResponseAnswers()
        {
            try
            {
                var responseAnswerBLLs = _bLLibrary.GetAllResponseAnswers();
                var responseAnswerModels = _mapper.Map<IEnumerable<ResponseAnswerModel>>(responseAnswerBLLs);
                return Ok(responseAnswerModels);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as appropriate
                return StatusCode(500, "An error occurred while retrieving all response answers.");
            }
        }

        // PUT api/responseanswer/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateResponseAnswer(int id, ResponseAnswerModel responseAnswerModel)
        {
            try
            {
                if (id != responseAnswerModel.ResponseId)
                {
                    return BadRequest();
                }

                var responseAnswerBLL = _mapper.Map<ResponseAnswerBLL>(responseAnswerModel);
                _bLLibrary.UpdateResponseAnswer(responseAnswerBLL);

                return Ok(new { message = "Response answer updated successfully" });
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as appropriate
                return StatusCode(500, "An error occurred while updating the response answer.");
            }
        }

        // DELETE api/responseanswer/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteResponseAnswer(int id)
        {
            try
            {
                _bLLibrary.DeleteResponseAnswer(id);
                return Ok(new { message = "Response answer deleted successfully" });
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as appropriate
                return StatusCode(500, "An error occurred while deleting the response answer.");
            }
        }

        // GET api/responseanswer/responseswithanswers
        [HttpGet("responseswithanswers")]
        public IActionResult GetResponsesWithAnswers()
        {
            try
            {
                var responsesWithAnswers = _bLLibrary.GetResponsesWithAnswers(); // Call the BLL method
                var responseDTOs = _mapper.Map<IEnumerable<ResponseWithAnswersDTO>>(responsesWithAnswers); // Map to DTO

                return Ok(responseDTOs); // Return mapped response
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as appropriate
                return StatusCode(500, "An error occurred while retrieving responses with answers.");
            }
        }
    }
}
