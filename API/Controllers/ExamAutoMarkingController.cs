using Application;
using Domain;
using Domain.DTO;
using Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepoInterfaces;
using System.Net;

namespace API.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamAutoMarkingController : ControllerBase 
    {
        private IExamRepository _examRepo;
        private Marking _marking;

        public ExamAutoMarkingController(IExamRepository examRepo, Marking marking)
        {
            _examRepo = examRepo;
            _marking = marking;
        }

        [HttpGet("all")]
        public async Task<IActionResult> ShowExams()
        {
            var response = await _examRepo.GetAll();
            return Ok(response);
        }

        [HttpPost("Auto")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesErrorResponseType(typeof(float))]
        public async Task<IActionResult> MarkExamAuto([FromBody]Exam exam)
        {
            try
            {
                var score = await _marking.MarkingService(exam);
                return StatusCode((int)HttpStatusCode.OK, score);
            }
            catch (InvalidRequestBodyException ex)
            {
                return BadRequest(new BaseResponseDTO
                {
                    IsSuccess = false,
                    Errors = ex.Errors
                });
            }
        }


    }
}
