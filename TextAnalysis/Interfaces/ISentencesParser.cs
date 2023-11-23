using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalysis.Interfaces
{
	public interface ISentencesParser
	{
		List<List<string>>? ParseSentences(string text);
	}
}
