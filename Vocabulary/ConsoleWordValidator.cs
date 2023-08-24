using FluentValidation;

namespace Vocabulary;

public class ConsoleWordValidator : AbstractValidator<ConsoleWordAddDto>
{
    public ConsoleWordValidator()
    {
        RuleFor(x => x.English).NotEmpty();
        RuleFor(x => x.Russian).NotEmpty();
        
    }

}