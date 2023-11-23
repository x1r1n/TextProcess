using TextAnalysis.Interfaces;

namespace TextAnalysis
{
    public class SentencesParser : ISentencesParser
	{
        public List<List<string>>? ParseSentences(string text)
        {
            if (String.IsNullOrEmpty(text))
            {
				throw new ArgumentNullException("text");
			}

            return text
                .ToLower()
                .Split(".!?;:()".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(sentence => sentence
                .Aggregate(new List<string>(), (words, symbol) =>
                {
                    if (char.IsLetter(symbol) || symbol.Equals('\''))
                    {
                        if (words.Count > 0)
                        {
							words[words.Count - 1] += symbol;
						}
					}
                    else
                    {
                        words.Add(String.Empty);
                    }
                    return words;
                })
                .Where(word => !String.IsNullOrEmpty(word))
                .ToList())
                .Where(sentence => sentence.Count > 0)
                .ToList();
        }
    }
}