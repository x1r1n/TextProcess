
using TextAnalysis.Interfaces;

namespace TextAnalysis
{
    public class FrequencyAnalysis : IFrequencyAnalysis
	{
        public Dictionary<string, string>? GetMostFrequentWords(List<List<string>>? text)
        {
            if (text is null || text.Count == 0)
            {
                throw new ArgumentNullException(nameof(text));
            }

            var words = new Dictionary<string, string>();
            var bigrams = FindMostFrequentGrams(GetGrams(text, 2));
            var trigrams = FindMostFrequentGrams(GetGrams(text, 3));

            words = words
                .Concat(bigrams)
                .Concat(trigrams)
                .ToDictionary(pair => pair.Key, pair => pair.Value);

            return words;
        }

        private Dictionary<string, Dictionary<string, int>> GetGrams
            (List<List<string>> text,
            int lengthGram)
        {
            return text
                .Where(sentence => sentence.Count >= lengthGram)
                .SelectMany(sentence =>
                {
                    var maxIndex = sentence.Count - lengthGram + 1;

                    return Enumerable.Range(0, maxIndex)
                    .Select(i =>
                    {
                        var currentKey = string.Join(" ", sentence.Skip(i).Take(lengthGram - 1));
                        var nextWord = sentence[i + lengthGram - 1];

                        return new { CurrentKey = currentKey, NextWord = nextWord };
                    });
                })
                .GroupBy(pair => pair.CurrentKey)
                .ToDictionary(
                group => group.Key,
                group => group.GroupBy(pair => pair.NextWord)
                .ToDictionary(pairGroup => pairGroup.Key, pairGroup => pairGroup.Count()));
        }

        private Dictionary<string, string> FindMostFrequentGrams
            (Dictionary<string, Dictionary<string, int>> grams)
        {
            return grams.ToDictionary(
                mainKey => mainKey.Key,
                mainKey => mainKey.Value
                .OrderByDescending(subKey => subKey.Value)
                .ThenBy(subKey => subKey.Key, StringComparer.Ordinal)
                .FirstOrDefault()
                .Key ?? string.Empty);
        }
    }
}