using CezarettiBackCommunication.Requests;
using CezarettiBackCommunication.Response;
using CezarettiBackException;

namespace CezarettiBack.Api.UseCases.Users.Register;

public class RegisterUserUseCase
{
    public ResponseRegisteredUserJson Execute(RequestUserJson req)
    {
        var validator = new RegisterUserValidator();
        
        var result = validator.Validate(req);
        
        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

            throw new ErrorOnValidateException(errorMessages);
        }   
        
        return new ResponseRegisteredUserJson();
    }
}