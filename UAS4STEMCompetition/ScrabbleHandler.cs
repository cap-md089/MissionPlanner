using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;

namespace MissionPlanner.UAS4STEMCompetition {
	class ScrabbleHandler {
		private static IEnumerable<string> GetDictionary () {
			var path = 
				Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) +
				Path.DirectorySeparatorChar +
				"UAS4STEMCompetition" +
				Path.DirectorySeparatorChar +
				"dictionary.txt";

			var ret = new List<string>();
			ret.AddRange(File.ReadAllLines(path));

			return ret;
		}

		private static IEnumerable<string> GetWordsForLetters (IEnumerable<char> letters, IEnumerable<string> dictionary) {
			if (letters.Count() == 0) {
				return new List<string>();
			}

			var wordsOfRightLength =
				from word in dictionary
				where word.Length == letters.Count()
				select word;

			var rx = new Regex($"[{new string(letters.ToArray())}]{{5}}", RegexOptions.IgnoreCase);

			var wordsWithRightLetters =
				from word in wordsOfRightLength
				where rx.IsMatch(word)
				select word;

			return wordsWithRightLetters;
		}

		public static IEnumerable<string> GetWordsForTargets(IEnumerable<Target> targets) {
			var dictionary = GetDictionary();

			var letters =
				from target in targets
				where target is LetterTarget
				select ((LetterTarget)target).letter;

			var words = GetWordsForLetters(letters, dictionary);

			return words;
		}
	}
}
