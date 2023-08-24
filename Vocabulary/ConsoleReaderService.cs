using FluentValidation;

namespace Vocabulary;

public class ConsoleReaderService
{
    private readonly ConsoleWordValidator _validator = new();
    public Word ReadWord()
    {

        Console.Write("Eng word: ");
        string? engWord = Console.ReadLine();
        Console.Write("Rus word: ");
        string? rusWord = Console.ReadLine();
        Console.Write("Description: ");
        string? description = Console.ReadLine();

        ConsoleWordAddDto consoleWord = new()
        {
            English = engWord,
            Russian = rusWord,
            Description = description
        };
        var result = _validator.Validate(consoleWord);

        if(!result.IsValid)
        {
            throw new ValidationException(result.Errors);
        }

        return consoleWord.ToWord();
    }
}
