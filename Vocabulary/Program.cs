using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Vocabulary;

public class Program
{
    public static void Main()
    {
        var words = new List<Word>()
        {
            new Word(){ English = "phone", Russian = "телефон", Description = ""},
            new Word(){ English = "joke", Russian = "шутка", Description = "не умеешь не надо"},
            new Word(){ English = "penis", Russian = "пенис", Description = "мужской половой орган"},
            new Word(){ English = "aboba", Russian = "абобус", Description = "АМОГУС"}
        };
        WordsService wordsSrv = new(words);
        IWordsVisualizerService visualizerSrv = new ConsoleWordsVisualizerService();
        ConsoleReaderService consoleReaderService = new ConsoleReaderService();
        

        while(true)
        {
            string? currentInput = Console.ReadLine();
            switch (currentInput)
            {
                case "/disp":
                    visualizerSrv.Display(wordsSrv.Words);
                    break;

                case "/add":
                    try
                    {
                        Word word = consoleReaderService.ReadWord();
                        wordsSrv.AddWord(word);
                        Console.WriteLine(word);
                        
                    }
                    catch (ValidationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case "/remove":
                    string? partialId = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(partialId))
                    {
                        Console.WriteLine("Partial id is empty");
                        break;
                    }
                    try
                    {
                        var word = wordsSrv.RemoveWord(partialId);
                        Console.WriteLine($"Word with id: {word.Id} was deleted");
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    
                    break;

                case "/help":
                    Console.WriteLine("For display table enter: /disp \n For add word enter: /add \n For remove word enter: /remove \n For clear console enter: /clr \n For order table enter: /order \n For close console enter: /close");
                    break;

                case "/clr":
                    Console.Clear();
                    break;

                case "/order":
                    Console.Write("Which column sort (id/english/russian): ");
                    string? column = Console.ReadLine();

                    var wasSorted = wordsSrv.SortBy(column);

                    if (!wasSorted)
                    {
                        Console.WriteLine("This column not exist");
                    }

                    break;

                case "/close":
                    Console.WriteLine("Are you sure (y/n)");
                    if (Console.ReadLine() == "y")
                    {
                        Environment.Exit(0);
                    }
                    break;

                default:
                    Console.WriteLine("Not correct input, enter /help");
                    break;
            }
            Console.WriteLine();

        }
    }
}
