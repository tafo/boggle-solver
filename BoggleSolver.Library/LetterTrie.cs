using System.Collections.Generic;

namespace BoggleSolver.Library
{
    public class LetterTrie
    {
        public static bool IsReadOnly { get; set; }
        public static int Level = 3;
        public char Letter { get; set; }
        public List<LetterTrie> Children { get; set; }
        public HashSet<string> Words { get; set; }

        public LetterTrie(char letter = '#')
        {
            Letter = letter;
            Children = new List<LetterTrie>();
            Words = new HashSet<string>();
        }

        public LetterTrie this[char letter]
        {
            get
            {
                var find = Children.Find(x => x.Letter == letter);
                if (IsReadOnly) return find;
                if (find != null) return find;
                find = new LetterTrie(letter);
                Children.Add(find);
                return find;
            }
        }
    }
}