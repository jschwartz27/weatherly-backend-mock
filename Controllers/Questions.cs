using LanguageExt;
using Microsoft.AspNetCore.Mvc;
using Weatherly.Api.Dtos;
using Microsoft.AspNetCore.Http.HttpResults;
using Weatherly.Api.Dtos.Questions;

namespace Weatherly.Api.Controllers;

[ApiController]
[Route("api/v1/questions")]
public class QuestionsController : ControllerBase
{
    private readonly ILogger<QuestionsController> _logger;

    public QuestionsController(ILogger<QuestionsController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Get Existing Questions
    /// </summary>
    /// <param name="questionCount"></param>
    [HttpGet("{questionCount}")]
    [Produces("application/json")]
    public IEnumerable<ExistingQuestionDto> GetExistingQuestions([FromRoute] byte questionCount)
    {
        // for frontend testing
        return questionCount % 2 == 0
            ? new List<ExistingQuestionDto>()
            : Enumerable
                .Range(1, questionCount)
                .Select(
                    index =>
                        new ExistingQuestionDto(
                            Id: index,
                            Text: $"This is question number {index}?"
                        )
                );
    }

    /// <summary>
    /// Ask Question
    /// </summary>
    /// <param name="question"></param>
    /// <returns></returns>
    [HttpPost]
    [Produces("application/json")]
    public string AskQuestion([FromBody] QuestionDto question)
    {
        return @$"The Answer To Your Question: {question.Text}! Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin magna turpis, auctor accumsan justo sit amet, faucibus efficitur magna. Vestibulum sed risus non lacus porta commodo. Sed posuere sit amet lorem ac lacinia. Fusce mattis sodales nulla, facilisis sodales nunc pretium id. Nunc sit amet justo vitae odio feugiat luctus in et magna. Ut semper vitae turpis vel rutrum. Etiam eros sapien, posuere id sagittis eget, venenatis vitae enim. Vestibulum nec condimentum erat, eu maximus augue. Proin tempus dui vel mauris porttitor ultricies. Duis id velit nec lacus vehicula accumsan sed eu velit. Donec metus purus, rutrum eget lectus sed, laoreet facilisis ipsum. Donec ut lectus ut nulla ornare consectetur tempus non justo. Cras euismod mauris eu lorem imperdiet sodales.";
    }

    /// <summary>
    /// Delete Existing Question
    /// For testing: fails on questions with odd Id
    /// </summary>
    /// <param name="questionId"></param>
    /// <returns></returns>
    [HttpDelete("{questionId}")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(string), 200)]
    [ProducesResponseType(typeof(BadRequest), 400)]
    public IActionResult DeleteQuestion([FromRoute] uint questionId)
    {
        return questionId % 2 == 0
            ? Ok($"Question Id: {questionId}, succesfully deleted!")
            : BadRequest($"[Bad Request] Question Id: {questionId}, not found!");
    }
}
