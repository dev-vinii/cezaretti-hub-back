using CezarettiBack.Api.UseCases.Users.Register;
using CezarettiBackCommunication.Requests;
using CezarettiBackCommunication.Response;
using CezarettiBackException;
using Microsoft.AspNetCore.Mvc;

namespace CezarettiBack.Api.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status201Created)]
    public IActionResult Create(RequestUserJson req)
    {
        try
        {
            var useCase = new RegisterUserUseCase();
            var response = useCase.Execute(req);
            return Created(string.Empty, response);
        }
        catch (CezarettiBackLibraryException e)
        {
            return BadRequest(new ResposeErrorMessagesJson { Errors = e.GetErrorMessages() });
        } catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new ResposeErrorMessagesJson { Errors = ["Erro desconhecido"] });
        }
    }
    
    [HttpGet]
    public IActionResult Get()
    {
        return Ok();
    }
}