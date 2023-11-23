using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalysis.Interfaces
{
	public interface ISentenceGenerator
	{
		string ContinuePhrase(Dictionary<string, string>? _generationWords, string phraseBeginning, int wordsCount);
	}
}
