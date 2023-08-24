using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vocabulary;

public interface IWordsVisualizerService
{
    void Display(IEnumerable<Word> words);
}

internal class ConsoleWordsVisualizerService : IWordsVisualizerService
{
    public void Display(IEnumerable<Word> words)
    {
        Console.WriteLine($"{nameof(Word.Id)} \t\t\t\t\t{nameof(Word.English)} \t{nameof(Word.Russian)} \t{nameof(Word.Description)}");

        foreach (Word word in words)
        {
            Console.WriteLine($"{word.Id} \t{word.English} \t\t{word.Russian} \t\t{word.Description}");

        }
        Console.WriteLine();
    }
}
