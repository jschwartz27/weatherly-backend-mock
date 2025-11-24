namespace Weatherly.Api.Dtos
{
    /// <summary>
    /// Question id and question string
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="Text"></param>
    public record ExistingQuestionDto(int Id, string Text);
}
