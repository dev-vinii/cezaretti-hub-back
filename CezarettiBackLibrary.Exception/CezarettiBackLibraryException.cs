using System.Net;

namespace CezarettiBackException;

public abstract class CezarettiBackLibraryException : SystemException
{
    public abstract List<string> GetErrorMessages();
    public abstract HttpStatusCode GetStatusCode();
}