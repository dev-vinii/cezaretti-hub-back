using CezarettiBackCommunication.Requests;
using FluentValidation;

namespace CezarettiBack.Api.UseCases.Users.Register;

public class RegisterUserValidator : AbstractValidator<RequestUserJson>
{
    public RegisterUserValidator()
    {
        RuleFor(req => req.Name).NotEmpty().WithMessage("O nome é obrigatório.");
        RuleFor(req => req.Email).EmailAddress().WithMessage("O e-mail não é válido.");
        RuleFor(req => req.Password).NotEmpty().WithMessage("A Senha é obrigatória.");
        When(req => string.IsNullOrEmpty(req.Password) == false, () =>
        {
            RuleFor(req => req.Password).MinimumLength(6).WithMessage("A senha deve ter no mínimo 6 caracteres.");
        });
    }
}