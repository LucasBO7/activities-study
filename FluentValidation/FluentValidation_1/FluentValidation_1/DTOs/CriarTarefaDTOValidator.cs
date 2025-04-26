using FluentValidation;

namespace FluentValidation_1.DTOs;

public class CriarTarefaDTOValidator : AbstractValidator<CriarTarefaDTO>
{
    public CriarTarefaDTOValidator()
    {
        RuleFor(prop => prop.Titulo)
            .NotEmpty()
            .NotNull()
            .MinimumLength(5).WithMessage("O Titulo deve conter no mínimo 5 caracteres.")
            .MaximumLength(100).WithMessage("O título deve conter no máximo 100 caracteres.");

        RuleFor(prop => prop.Descricao)
            .NotEmpty()
            .NotNull()
            .MinimumLength(10).WithMessage("A descrição deve conter no mínimo 10 caracteres.")
            .MaximumLength(1200).WithMessage("A descrição deve conter no máximo 1200 caracteres.");

        RuleFor(prop => prop.DataLimite)
            .GreaterThanOrEqualTo(DateTime.Now).WithMessage("A data limite deve ser posterior ou igual ao dia de hoje.");
    }
}