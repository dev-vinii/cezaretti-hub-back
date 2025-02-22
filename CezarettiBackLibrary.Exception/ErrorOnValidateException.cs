using System.Net;

namespace CezarettiBackException;

public class ErrorOnValidateException : CezarettiBackLibraryException
{
    private readonly List<string> _errors;

    public ErrorOnValidateException(List<string> errorMessages)
    {
        _errors = errorMessages;
    }

    public override List<string> GetErrorMessages() => _errors;

    public override HttpStatusCode GetStatusCode() => HttpStatusCode.BadRequest;
}