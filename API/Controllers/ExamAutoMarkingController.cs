using Application;
using Application.Commands.AutoMarkingCommand;
using Application.Queries.GetAllExamsQuery;
using Domain;
using Domain.DTO;
using Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepoInterfaces;
using System.Net;

namespace API.Controllers 
{
    // Set the route prefix for the controller and indicate that it is an API controller
    [Route("api/Auto")]
    [ApiController]
    public sealed class ExamAutoMarkingController : ApiController 
    {
        // Declare private fields to hold the injected dependencies
        private IExamRepository _examRepo;
        private Marking _marking;

        // Inject the dependencies using constructor injection
        public ExamAutoMarkingController(IExamRepository examRepo, Marking marking, ISender sender)
            : base(sender)
        {
            _examRepo = examRepo;
            _marking = marking;
        }

        // Define an HTTP GET action to retrieve all exams
        [HttpGet("ShowAll")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesErrorResponseType(typeof(GetAllExamsResponse))]
        public async Task<IActionResult> ShowExams(CancellationToken cancelationToken)
        {
            var query = new GetAllExamsQuery();
            var result = await Sender.Send(query, cancelationToken);

            // Call the GetAll() method of the injected exam repository to retrieve all exams
            //var response = await _examRepo.GetAll();
            // Return an HTTP 200 OK response with the retrieved exams as the response body
            return result.Success ? Ok(result.Data) : BadRequest(result.ErrorMessage);
        }

        // Define an HTTP POST action to mark an exam automatically
        [HttpPost("Marking")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesErrorResponseType(typeof(float))]
        public async Task<IActionResult> MarkExamAuto([FromBody]Exam exam, CancellationToken cancelationToken)
        {
            try
            {
                var command = new AutoMarkingCommand(exam);
                var result = await Sender.Send(command, cancelationToken); 

                return result.Success ? Ok(result.Data.OverallExamScore) : BadRequest(result.ErrorMessage);
                
                // Call the MarkingService() method of the injected Marking service to mark the exam and retrieve the score
                //var score = await _marking.MarkingService(exam);
                // Return an HTTP 200 OK response with the exam score as the response body
                //return StatusCode((int)HttpStatusCode.OK, command.exam.OverallExamScore);
            }
            catch (InvalidRequestBodyException ex)
            {
                // If there is an exception due to an invalid request body, return an HTTP 400 Bad Request response with an error message
                return BadRequest(new BaseResponseDTO
                {
                    IsSuccess = false,
                    Errors = ex.Errors
                });
            }
        }


    }
}
