namespace Vocabulary;

public class WordsService
{
    private HashSet<Word> _words = new();

    public WordsService() { }
    public WordsService(IEnumerable<Word> words) : this()
    {
        foreach (var word in words)
        {
            _words.Add(word);
        }

    }

    public IEnumerable<Word> Words => _words;

    public void AddWord(Word word)
    {
        _words.Add(word);
    }

    public Word RemoveWord(string partialId)
    {
        Word word = FindById(partialId);
        _words.Remove(word);
        return word;
    }

    public bool SortBy(string? byWhat)
    {
        bool result = true;

        switch (byWhat?.ToLower())
        {
            case "english":
                _words = _words.OrderBy(w => w.English).ToHashSet();
                break;

            case "russian":
                _words = _words.OrderBy(w => w.Russian).ToHashSet();
                break;

            case "id":
                _words = _words.OrderBy(w => w.Id).ToHashSet();
                break;

            default: 
                result = false; 
                break;
        }

        return result;
    }

    public Word FindById(Guid id)
    {
        return _words.First(w => w.Id == id);
    }

    public Word FindById(string partialId)
    {
        var wordIds = _words.Where(w => w.Id.ToString().Replace("-", string.Empty).StartsWith(partialId)).Select(w => w.Id);

        if (wordIds.Count() > 1)
        {
            throw new InvalidOperationException("Partial id is too short");
        }

        return FindById(wordIds.First());
    }
}
