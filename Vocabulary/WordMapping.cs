namespace Vocabulary;

public static class WordMapping
{
    public static Word ToWord(this ConsoleWordAddDto wordAdd)
    {
        return new Word()
        {
            English = wordAdd.English!,
            Russian = wordAdd.Russian!,
            Description = wordAdd.Description
        };
    }
}
