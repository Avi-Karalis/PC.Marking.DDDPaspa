using Application;
using Application.giannisDF;
using Application.giannisDF.ApiDto;
using Domain.DTO;
using Domain.Exceptions;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using RepoInterfaces;
using System.Net;

namespace API.Controllers 
{
    // Set the route prefix for the controller and indicate that it is an API controller
    [Route("api/[controller]")]
    [ApiController]
    public class ExamAutoMarkingController : ControllerBase 
    {
        // Declare private fields to hold the injected dependencies
        private Marking _marking;
        private ExamService _examService;
        private IServiceProvider _serviceProvider;

        // Inject the dependencies using constructor injection
        public ExamAutoMarkingController(Marking marking, ExamService examService, IServiceProvider serviceProvider)
        {
            // ask from the UoW to supply an implementation that exists for IExamRepository and is of type ExamRepository
            //ApplyImplementation(serviceProvider, ExamRepositoryImplementations.ExamRepository);
            _marking = marking;
            _examService = examService;
            _serviceProvider = serviceProvider;
        }

        //private void ApplyImplementation(IServiceProvider serviceProvider, ExamRepositoryImplementations implementation)
        //{
        //    var examRepos = serviceProvider.GetServices<IExamRepository>();
        //    foreach (var repo in examRepos.ToList())
        //    {
        //        if (repo.Implementation == implementation)
        //        {
        //            _examRepo = repo;
        //        }
        //    }
        //}

        // Define an HTTP GET action to retrieve all exams
        [HttpGet("all")]
        public async Task<IActionResult> ShowExams()
        {
            _examService.ApplyImplementation(ExamRepositoryImplementations.ExamRepository2);
            // Call the GetAll() method of the injected exam repository to retrieve all exams
            var response = _examService.examRepository.GetAll();    
            //var response = await _examRepo.GetAll();
            // Return an HTTP 200 OK response with the retrieved exams as the response body
            return Ok(response);
        }

        // Define an HTTP POST action to mark an exam automatically
        [HttpPost("Auto")]
        // Set the response type for a successful request to an integer representing the exam score
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        // Set the response type for an error response to a custom response type representing the error
        [ProducesErrorResponseType(typeof(float))]
        public async Task<IActionResult> MarkExamAuto([FromBody]ExamGetDto examGetDto)
        {
          Console.WriteLine(_serviceProvider.GetServices<IExamRepository>().FirstOrDefault(k => k.GetType()== typeof(ExamRepository)));
            try
            {
                // Call the MarkingService() method of the injected Marking service to mark the exam and retrieve the score
                _marking.getExamDto = examGetDto;
                var score = await _marking.MarkingService();
                // Return an HTTP 200 OK response with the exam score as the response body
                //return StatusCode((int)HttpStatusCode.OK, score);
                return Ok(score);
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
