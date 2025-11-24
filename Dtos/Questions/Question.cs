namespace Weatherly.Api.Dtos.Questions
{
    /// <summary>
    /// Incoming Question
    /// Implemented as record in case question is quite long
    /// </summary>
    /// <param name="Text"></param>
    /// <param name="Chat_history"></param>
    public record QuestionDto(string Text, List<string> Chat_history);
}
