using System.Collections.Generic;

namespace BoggleSolver.Library
{
    public class LetterTrie
    {
        public static int Level = 1;
        public char Letter { get; set; }
        public bool IsLastLetter { get; set; }
        public List<LetterTrie> Children { get; set; }
        public HashSet<string> Words { get; set; }

        public LetterTrie(char letter = '#')
        {
            Letter = letter;
            Children = new List<LetterTrie>(26);
            Words = new HashSet<string>();
        }

        public LetterTrie this[char letter]
        {
            get
            {
                var find = Children.Find(x => x.Letter == letter);
                if (find != null) return find;
                find = new LetterTrie(letter);
                Children.Add(find);
                return find;
            }
        }
    }
}