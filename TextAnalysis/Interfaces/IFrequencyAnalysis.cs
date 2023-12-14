using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhraseForge.Interfaces
{
	public interface IFrequencyAnalysis
	{
		Dictionary<string, string> GetMostFrequentWords(List<List<string>>? text);
	}
}
