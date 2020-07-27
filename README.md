## INDEXING & SEARCHING
```
How do we search a word in a dictionary?
```
[Trie@Wikipedia](https://en.wikipedia.org/wiki/Trie)
```
What is Trie?

It is actually a reusability method.

Check the following words
{
    ACE
    ACT
    ADD
}

Is there any repeating letter?
{
    Yes!
    {
        "A"
    }
}

Is there any way to write these words without repeating same char again and again?
{
    Yes!
    {
        A(CE, CT, ADD)
        {
            Actually, we all know this method
            It is Math!            
            3 * (2x + 3y + z) = 6x + 9y + 3z
        }
    }
}

Finally!!!
{
    TrieSolver was implemented !
}

```
[`TrieSolver`](https://github.com/tafo/BoggleSolver/blob/TrieSolver/BoggleSolver.Library/TrieSolver.cs)
[`LetterTrie`](https://github.com/tafo/BoggleSolver/blob/TrieSolver/BoggleSolver.Library/LetterTrie.cs)
```
IndexSolver vs TrieSolver
{
    Windows 10.0.18362.959 (1903/May2019Update/19H1)
    Intel Core i7-4720HQ CPU 2.60GHz (Haswell), 1 CPU, 8 logical and 4 physical cores

    Dict
    {
        Maxi    = 281,279 Words
        Midi    = 129,552 Words
        Mini    =  39,096 Words    
    }

    Boggle
    {
        [
            [ "T", "M", "C", "F" ],
            [ "W", "O", "V", "I" ],
            [ "A", "H", "X", "E" ],
            [ "S", "Y", "L", "R" ]
        ]
    }
}
```
| Method | Size |       Mean |       Error |    StdDev |
|------- |----- |-----------:|------------:|----------:|
|   Trie | Maxi | 2,956.4 ms |    43.13 ms |  28.53 ms |
|  Index | Maxi | 1,373.8 ms |    11.45 ms |   7.57 ms |
|   Trie | Midi | 2,929.3 ms |    38.43 ms |  25.42 ms |
|  Index | Midi | 1,273.4 ms |    15.85 ms |  10.48 ms |
|   Trie | Mini | 3,151.5 ms | 1,116.59 ms | 738.55 ms |
|  Index | Mini |   753.7 ms |     6.94 ms |   4.59 ms |
```
Result?
{
    There is no performance improvement!
    {
        But!
        Current the depth(level) of current TrieSolver is 1
        {
            Remember the previous reusability method
            A(CE, CT, ADD) = ACE, ACT, ADD

            Is there any repeating letter inside the paranthesis?
            {
                Yes!
                {
                    A(CE, CT, ADD) => A(C(E,T),DD)
                }                
            }
        }
    }
}
```

```
Not satisfied?

So?
```

[`continue`](https://github.com/tafo/BoggleSolver)