namespace Infrastructure.Crosscutting.Validations;

public class CustomValidationException: Exception
{
    public int ErrorsFound { get; set; }
    public List<string> Errors { get; } = new List<string>();

    public CustomValidationException(string error)
    {
        this.ErrorsFound = 1;
        this.Errors.Add(error);
    }

    public CustomValidationException(List<string> errors)
    {
        this.ErrorsFound = errors.Count;
        this.Errors = errors;
    }
}