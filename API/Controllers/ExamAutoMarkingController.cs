using Application;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepoInterfaces;

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

        [HttpGet("all"]
        public async Task<IActionResult> ShowExams()
        {
            var response = await _examRepo.GetAll();
            return Ok(response);
        }

        [HttpPost("Auto")]
        public async Task<IActionResult> MarkExamAuto([FromBody]Exam exam)
        {
            var score = await _marking.MarkingService(exam);
            return Ok(score);
        }


    }
}
