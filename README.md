## INDEXING & SEARCHING
```
How do we search a subject(word) in a book?
How do we search on the NET?
How do we search ...?
```
[Index@Wikipedia](https://en.wikipedia.org/wiki/Index)
[SubjectIndexing@Wikipedia](https://en.wikipedia.org/wiki/Subject_indexing)
```
Content(Subject Indexing)
{
    Subject indexing is the act of describing or classifying a document by index terms or other symbols 
    in order to indicate what the document is about, to summarize its content or to increase its findability.
}

Dictionaries use letter indexing like DictinarySolver

But!
Is there any word that starts with "GGG", "RRR", "WXQ", ... ?
{
    Remember the rule "Words must be at least 3 characters"

    Boggle
    {
        W X Q
        A B C
        X Y Z
    }

    Even if there is no word that starts with WXQ
    {
        DictionarySolver continues to find chains that start with WXQ and checks them
            WXQC and WXQCs
            WXQB and WXQBs
        
        So?
    }
}
```
[`IndexSolver`](https://github.com/tafo/BoggleSolver/blob/IndexSolver/BoggleSolver.Library/IndexSolver.cs)
```
DictionarySolver vs IndexSolver
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
|     Method | Size |       Mean |    Error |   StdDev |
|----------- |----- |-----------:|---------:|---------:|
| Dictionary | Maxi | 2,448.6 ms | 39.79 ms | 26.32 ms |
|      Index | Maxi | 1,363.7 ms | 13.92 ms |  9.21 ms |
| Dictionary | Midi | 2,347.6 ms | 10.59 ms |  7.01 ms |
|      Index | Midi | 1,246.6 ms |  9.38 ms |  6.21 ms |
| Dictionary | Mini | 2,356.2 ms |  9.87 ms |  6.53 ms |
|      Index | Mini |   734.5 ms |  2.77 ms |  1.83 ms |

```
Result?
{
    A significant performance improvement !!
    {
        No surprise!
        {
            Check ChainCounter
            {
                For Test Dictionary
                {
                    DictionarySolver.ChainCounter = 12,029,640
                         IndexSolver.ChainCounter =  1,144,998
                }      
                For Mini Dictionary
                {
                    DictionarySolver.ChainCounter = 12,029,640
                         IndexSolver.ChainCounter =  2,841,041
                }
                For Midi Dictionary
                {
                    DictionarySolver.ChainCounter = 12,029,640
                         IndexSolver.ChainCounter =  4,775,792
                }
                For Maxi Dictionary
                {
                    DictionarySolver.ChainCounter = 12,029,640
                         IndexSolver.ChainCounter =  5,203,342
                }
            }
        }
    }
}
```

```
But, not satisfied!

So?
```

[`continue`](https://github.com/tafo/BoggleSolver)