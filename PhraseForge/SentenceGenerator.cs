using PhraseForge.Interfaces;

namespace PhraseForge
{
    public class SentenceGenerator : ISentenceGenerator
	{
        public string ContinuePhrase
            (Dictionary<string, string> generationWords,
            string phraseBeginning,
            int wordsCount)
        {
            if (generationWords is null || generationWords.Count == 0)
            {
                throw new ArgumentNullException(nameof(generationWords));
            }
            else if (wordsCount <= 0)
            {
				return phraseBeginning;
			}

            phraseBeginning = phraseBeginning.ToLower();

            while (--wordsCount >= 0)
            {
                var wordsBeginning = phraseBeginning.Split(' ');
                var lastWord = wordsBeginning.Last();

                if (wordsBeginning.Length >= 2)
                {
                    var lastSeveralWords = string
                        .Join(" ", wordsBeginning.Skip(wordsBeginning.Length - 2));

                    if (generationWords.TryGetValue(lastSeveralWords, out var nextWord))
                    {
                        phraseBeginning += " " + nextWord;
                    }
                    else
                    {
                        if (generationWords.TryGetValue(lastWord, out nextWord))
                            phraseBeginning += " " + nextWord;
                        else
                            return phraseBeginning;
                    }
                }
                else
                {
                    if (generationWords.TryGetValue(lastWord, out var nextWord))
                    {
						phraseBeginning += " " + nextWord;
					}
                    else
                    {
						return phraseBeginning;
					}
				}
            }
            return phraseBeginning;
        }
    }
}