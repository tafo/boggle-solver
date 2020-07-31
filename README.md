```
2 (x + y) = ?
```
[`SourceCode`](https://github.com/tafo/BoggleSolver/tree/TrieSolver)
```
Trie?
{
    {[(REUSABILITY)]}
}

Check the following words
{
    ACE
    ACT
    ADD
}

Is there any repeating letter?
{
    Yes
    {
        "A"
    }
}

Is there any way to write the words without repeating same "A" again and again?
{
    Yes
    {
        A(CE, CT, ADD)
        {
            Actually, we all know this method
            {
                It is Math!
                {
                    3 * (2x + 3y + z) = 6x + 9y + 3z
                }                           
            }
        }
    }
}
```
```
TrieSolver
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
| Method | Size | Level |    Mean |    Error |   StdDev |
|------- |----- |------ |--------:|---------:|---------:|
|   Trie | Maxi |     1 | 3.061 s | 0.0474 s | 0.0313 s |
|   Trie | Midi |     1 | 2.970 s | 0.0540 s | 0.0357 s |
|   Trie | Mini |     1 | 2.907 s | 0.0428 s | 0.0283 s |
```
Result?
{
    Symbols => "[", "(", ")", "]", ...

    #TrieCost
    If(Searching("ACEACTADD").Cost > Searching("ACETDD").Cost + Adding(Symbols))
    {
        Use Trie !!!
    }

    Elegant Solution!
    {
        Very extensible!
    }
}
```
```
Satisfied(?)
{
    Yes => (:
    {
        Impressed(?)
        {
            Yes => (:
            No  => continue
        }
    }
    No  => continue
}
```
**Math**
```
ACE, ACT, ADD =>
{
    #Level1
    A(CE, CT, ADD) >>> Dictionary["A"] = {"CE", "CT", "ADD"}
    {      
        #Level2
        A[C(E,T),DD]
        {
            So?
            {
                GoTo #TrieCost
            }
        }
    }
}
```
```
TrieSolver Level1 vs Level2 vs Level3
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
| Method | Size | Level |       Mean |       Error |    StdDev |
|------- |----- |------ |-----------:|------------:|----------:|
|   Trie | Maxi |     1 | 2,993.7 ms |    31.42 ms |  20.79 ms |
|   Trie | Maxi |     2 | 3,147.5 ms |    90.04 ms |  59.56 ms |
|   Trie | Maxi |     3 | 1,664.1 ms |    24.86 ms |  16.45 ms |
|   Trie | Midi |     1 | 2,957.7 ms |   119.92 ms |  79.32 ms |
|   Trie | Midi |     2 | 2,964.4 ms |    73.87 ms |  48.86 ms |
|   Trie | Midi |     3 | 1,544.9 ms |    49.80 ms |  32.94 ms |
|   Trie | Mini |     1 | 3,321.5 ms | 1,076.45 ms | 712.00 ms |
|   Trie | Mini |     2 | 1,844.6 ms |    41.60 ms |  27.52 ms |
|   Trie | Mini |     3 |   895.7 ms |    57.74 ms |  38.19 ms |
```
Result?
{
    Level1.ChainCounter@Maxi = 12,029,640
    Level2.ChainCounter@Maxi = 10,667,703
    Level3.ChainCounter@Maxi =  5,203,342

    Level1.ChainCounter@Midi = 12,029,640
    Level2.ChainCounter@Midi = 10,335,609
    Level3.ChainCounter@Midi =  4,775,792

    Level1.ChainCounter@Mini = 12,029,640
    Level2.ChainCounter@Mini =  6,625,611
    Level3.ChainCounter@Mini =  2,841,041

    So?
    {
        As   >>> Words.Every.Take(1).Unique();
        ABs  >>> Words.Every.Take(2).Unique();
        ABCs >>> Words.Every.Take(3).Unique();
        
        Maxi.As.Count == Midi.As.Count == Mini.As.Count

        But!

        Maxi.ABs.Count > Midi.ABs.Count > Mini.ABs.Count !
        
        And!

        Maxi.ABCs.Count >>> Midi.ABCs.Count >>> Mini.ABCs.Count !!!
    }
}
```
```
Satisfied(?)
{
    Yes => (:
    {
        Impressed(?)
        {
            Yes => (:
            No  => continue
        }
    }
    No  => continue
}
```
***
**ABCs & ABCDs**
```
Remember the rule
{
    "Words must be at least 3 characters"
    So?
    {
        Retire Level1 & Level2
        Check Level4
    }    
}
```
```
TrieSolver Level3 vs Level4
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
| Method | Size | Level |       Mean |     Error |    StdDev |
|------- |----- |------ |-----------:|----------:|----------:|
|   Trie | Maxi |     3 | 1,620.3 ms | 116.70 ms |  77.19 ms |
|   Trie | Maxi |     4 |   506.4 ms |  14.42 ms |   9.54 ms |
|   Trie | Midi |     3 | 1,760.8 ms | 799.05 ms | 528.52 ms |
|   Trie | Midi |     4 |   381.1 ms |   2.44 ms |   1.61 ms |
|   Trie | Mini |     3 |   821.4 ms |  42.82 ms |  28.32 ms |
|   Trie | Mini |     4 |   137.8 ms |   8.73 ms |   5.78 ms |
```
Result?
{
    Level3.ChainCounter@Maxi =  5,203,342
    Level4.ChainCounter@Maxi =  1,481,753

    Level3.ChainCounter@Midi =  4,775,792
    Level4.ChainCounter@Midi =  1,149,665

    Level3.ChainCounter@Mini =  2,841,041
    Level4.ChainCounter@Mini =    439,258

    39,096 words vs 439,258 chains for Mini!
    So?
    {
        Check Level5   
    }
}
```
```
Satisfied(?)
{
    Yes => (:
    {
        Impressed(?)
        {
            Yes => (:
            No  => continue
        }
    }
    No  => continue
}
```
***
**ABCDs & ABCDEs**
```
TrieSolver Level4 vs Level5
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
| Method | Size | Level |       Mean |    Error |   StdDev |
|------- |----- |------ |-----------:|---------:|---------:|
|   Trie | Maxi |     4 | 525.565 ms | 8.685 ms | 5.745 ms |
|   Trie | Maxi |     5 |  54.322 ms | 9.538 ms | 6.309 ms |
|   Trie | Midi |     4 | 402.362 ms | 5.710 ms | 3.776 ms |
|   Trie | Midi |     5 |  35.127 ms | 7.934 ms | 5.248 ms |
|   Trie | Mini |     4 | 145.967 ms | 8.766 ms | 5.798 ms |
|   Trie | Mini |     5 |   9.568 ms | 2.198 ms | 1.454 ms |
```
Result?
{
    Level4.ChainCounter@Maxi =  1,481,753
    Level5.ChainCounter@Maxi =    136,400

    Level4.ChainCounter@Midi =  1,149,665
    Level5.ChainCounter@Midi =     86,507

    Level4.ChainCounter@Mini =    439,258
    Level5.ChainCounter@Mini =     24,725

    39,096 words vs 24,725 chains for Mini!

    AND!!!

    Warnings
    {
        The minimum observed iteration time is 51.6903 ms which is very small,
        The minimum observed iteration time is 32.9073 ms which is very small, 
        The minimum observed iteration time is  8.7689 ms which is very small,
        ...
    }

    So?
    {
        It is the time to use a 5x5 boggle
    }
}
```
```
TrieSolver Level5 vs Level6
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
            [ "U", "N", "T", "N", "O" ],
            [ "N", "F", "A", "C", "O" ],
            [ "R", "I", "V", "H", "H" ],
            [ "E", "H", "Y", "E", "K" ],
            [ "A", "E", "O", "S", "T" ]
        ]
    }
}

Level6.ChainCounter =>  6,991,853
Level5.ChainCounter => 56,219,570
And
{
    Level6 found 22 words in 00:00:05.9038080
    Level5 found 22 words in 00:00:40.6983284
}
Why?
{
    Example =>
    Solver chained "F","A","C" and "T"
    {
        FACT is a word?
        {
            Yes
            {
                Continue
                {
                    But!
                    {
                        Is FACTN (FACT + "N") a word?
                        {
                            FACTNs?
                            !!!
                        }
                    }
                }
            }
            No
            {
                Stop!
            }
        }
    }
}
Result?
{
    Clearly!
    ChainCounter should be equal to the number of words in the given boggle
    {
        56,219,570 vs 22 !!!
        {
            I can not be satisfied !!!
        }
    }
}
```
```
Satisfied(?)
{
    Yes => (:
    {
        Impressed(?)
        {
            Yes => (:
            No  => continue
        }
    }
    No  => continue
}
```
**LetterLake vs LetterSea**
```
TrieSolver
{
    Windows 10.0.18362.959 (1903/May2019Update/19H1)
    Intel Core i7-4720HQ CPU 2.60GHz (Haswell), 1 CPU, 8 logical and 4 physical cores

    Dict
    {
        Maxi    = 281,279 Words
        Midi    = 129,552 Words
        Mini    =  39,096 Words    
    }

    Level = MaxWordLength
    {
        58@Maxi
        {
            LLANFAIRPWLLGWYNGYLLGOGERYCHWYRNDROBWLLLLANTYSILIOGOGOGOCH
        }
        45@Midi
        {
            PNEUMONOULTRAMICROSCOPICSILICOVOLCANOCONIOSIS
        }
        18@Mini
        {
            CHARACTERISTICALLY
            INSTITUTIONALIZING
            MISREPRESENTATIONS
            OVERSIMPLIFICATION
            TELECOMMUNICATIONS
        }
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
| Size |     Mean |    Error |    StdDev |
|----- |---------:|---------:|----------:|
| Mini | 468.5 us | 143.7 us |  95.04 us |
| Midi | 719.2 us | 165.5 us | 109.48 us |
| Maxi | 901.9 us | 224.0 us | 148.16 us |

```
Result?
{
    1 us : 1 Microsecond (0.000001 sec)
    
    Warnings
    {
        The minimum observed iteration time is 764.3000 us which is very small
        The minimum observed iteration time is 617.0000 us which is very small
        The minimum observed iteration time is 409.1000 us which is very small. 
        ...
    
        MinIterationTime
        {
            It's recommended to increase it to at least 100.0000 ms using more operations
        }
    }

    So?
    {
        I am satisfied (:
        {
            It is the time to do more operations
        }
    }
}
```
```
I checked the Net and found this page
{
    http://ai.stanford.edu/~chuongdo/boggle/ (Chuong (Tom) Do)
    Says
    {
        S E R S
        P A T G
        L I N E
        S E R S

        124  3-letter words ( 124 points)
        281  4-letter words ( 281 points)
        363  5-letter words ( 726 points)
        304  6-letter words ( 912 points)
        213  7-letter words (1065 points)
        097  8-letter words (1067 points)
        028  9-letter words ( 308 points)
        004 10-letter words (  44 points)

        1414 total words
        But!
        {
            Found 1508 words @ Maxi
        }
        4527 total points

        - - -

        R S C L S
        D E I A E
        G N T R P
        I A E S O
        L M I D C

        195  3-letter words ( 195 points)
        442  4-letter words ( 442 points)
        661  5-letter words (1322 points)
        668  6-letter words (2004 points)
        533  7-letter words (2665 points)
        342  8-letter words (3762 points)
        189  9-letter words (2079 points)
        071 10-letter words ( 781 points)
        018 11-letter words ( 198 points)
        001 12-letter words (  11 points)

        3120 total words
        But!
        {
            Found 3335 words @Maxi
        }
        13459 total points

        - - -

        D S R O D G
        T E M E N S
        R A S I T O
        D G N T R P
        R E I A E S
        T S C L P D

        0232 03-letter words (0232 points)
        0610 04-letter words (0610 points)
        0907 05-letter words (1814 points)
        1087 06-letter words (3261 points)
        0980 07-letter words (4900 points)
        0749 08-letter words (8239 points)
        0429 09-letter words (4719 points)
        0184 10-letter words (2024 points)
        0047 11-letter words (0517 points)
        0013 12-letter words (0143 points)
        0005 13-letter words (0055 points)

        5243 total words
        But!
        {
            Found 5448 words @ Maxi        
        }
        26514 total points
    }
}
```
```
TrieSolver
{
    Windows 10.0.18362.959 (1903/May2019Update/19H1)
    Intel Core i7-4720HQ CPU 2.60GHz (Haswell), 1 CPU, 8 logical and 4 physical cores

    Dict
    {
        Maxi    = 281,279 Words
        Midi    = 129,552 Words
        Mini    =  39,096 Words    
    }

    Level = MaxWordLength
    {
        58@Maxi
        {
            LLANFAIRPWLLGWYNGYLLGOGERYCHWYRNDROBWLLLLANTYSILIOGOGOGOCH
        }
        45@Midi
        {
            PNEUMONOULTRAMICROSCOPICSILICOVOLCANOCONIOSIS
        }
        18@Mini
        {
            CHARACTERISTICALLY
            ...
        }
    }

    Boggle
    {
        [
            [ "S", "E", "R", "S" ],
            [ "P", "A", "T", "G" ],
            [ "L", "I", "N", "E" ],
            [ "S", "E", "R", "S" ]
        ]
    }
}
```
| Method | Size |     Mean |     Error |    StdDev |
|------- |----- |---------:|----------:|----------:|
|   Trie | Maxi | 5.566 ms | 1.0236 ms | 0.6771 ms |
|   Trie | Midi | 4.042 ms | 0.7819 ms | 0.5172 ms |
|   Trie | Mini | 2.084 ms | 0.6342 ms | 0.4195 ms |
```
Result?
{
    Warnings (:
    {
        The minimum observed iteration time is 5.0015 ms which is very small (Maxi)  
        The minimum observed iteration time is 3.5437 ms which is very small (Midi)
        The minimum observed iteration time is 1.7848 ms which is very small (Mini)
        ...
    }

    MinIterationTime
    {
        It's recommended to increase it to at least 100.0000 ms using more operations
    }

    So?
    {
        continue
    }
}
```
```
TrieSolver
{
    Windows 10.0.18362.959 (1903/May2019Update/19H1)
    Intel Core i7-4720HQ CPU 2.60GHz (Haswell), 1 CPU, 8 logical and 4 physical cores

    Dict
    {
        Maxi    = 281,279 Words
        Midi    = 129,552 Words
        Mini    =  39,096 Words    
    }

    Level = MaxWordLength
    {
        58@Maxi
        {
            LLANFAIRPWLLGWYNGYLLGOGERYCHWYRNDROBWLLLLANTYSILIOGOGOGOCH
        }
        45@Midi
        {
            PNEUMONOULTRAMICROSCOPICSILICOVOLCANOCONIOSIS
        }
        18@Mini
        {
            CHARACTERISTICALLY
            ...
        }
    }

    Boggle
    {
        [
            [ "R", "S", "C", "L", "S" ],
            [ "D", "E", "I", "A", "E" ],
            [ "G", "N", "T", "R", "P" ],
            [ "I", "A", "E", "S", "O" ],
            [ "L", "M", "I", "D", "C" ]
        ]
    }
}
```
| Method | Size |      Mean |    Error |    StdDev |
|------- |----- |----------:|---------:|----------:|
|   Trie | Maxi | 19.299 ms | 5.829 ms | 3.8553 ms |
|   Trie | Midi | 14.861 ms | 9.367 ms | 6.1958 ms |
|   Trie | Mini |  5.909 ms | 1.137 ms | 0.7522 ms |
```
Result?
{
    Warnings (:
    {
        The minimum observed iteration time is 17.2487 ms which is very small (Maxi)  
        The minimum observed iteration time is 11.7630 ms which is very small (Midi)
        The minimum observed iteration time is  5.3904 ms which is very small (Mini)
        ...
    }

    MinIterationTime
    {
        It's recommended to increase it to at least 100.0000 ms using more operations
    }

    So?
    {
        continue
    }
}
```
```
TrieSolver
{
    Windows 10.0.18362.959 (1903/May2019Update/19H1)
    Intel Core i7-4720HQ CPU 2.60GHz (Haswell), 1 CPU, 8 logical and 4 physical cores

    Dict
    {
        Maxi    = 281,279 Words
        Midi    = 129,552 Words
        Mini    =  39,096 Words    
    }

    Level = MaxWordLength
    {
        58@Maxi
        {
            LLANFAIRPWLLGWYNGYLLGOGERYCHWYRNDROBWLLLLANTYSILIOGOGOGOCH
        }
        45@Midi
        {
            PNEUMONOULTRAMICROSCOPICSILICOVOLCANOCONIOSIS
        }
        18@Mini
        {
            CHARACTERISTICALLY
            ...
        }
    }

    Boggle
    {
        [
            [ "D", "S", "R", "O", "D", "G" ],
            [ "T", "E", "M", "E", "N", "S" ],
            [ "R", "A", "S", "I", "T", "O" ],
            [ "D", "G", "N", "T", "R", "P" ],
            [ "R", "E", "I", "A", "E", "S" ],
            [ "T", "S", "C", "L", "P", "D" ]
        ]
    }
}
```
| Method | Size |     Mean |    Error |   StdDev |
|------- |----- |---------:|---------:|---------:|
|   Trie | Maxi | 37.95 ms | 3.194 ms | 2.113 ms |
|   Trie | Midi | 25.57 ms | 2.577 ms | 1.704 ms |
|   Trie | Mini | 11.96 ms | 1.932 ms | 1.278 ms |

```
Result?
{
    Warnings (:
    {
        The minimum observed iteration time is 37.1669 ms which is very small (@Maxi)
        The minimum observed iteration time is 24.8757 ms which is very small (@Midi)
        The minimum observed iteration time is 11.3260 ms which is very small (@Mini)
        ...
    }

    MinIterationTime
    {
        It's recommended to increase it to at least 100.0000 ms using more operations
    }

    So?
    {
        continue
    }
}
```
```
TrieSolver
{
    Windows 10.0.18362.959 (1903/May2019Update/19H1)
    Intel Core i7-4720HQ CPU 2.60GHz (Haswell), 1 CPU, 8 logical and 4 physical cores

    Dict
    {
        Maxi    = 281,279 Words
        Midi    = 129,552 Words
        Mini    =  39,096 Words    
    }

    Level = MaxWordLength
    {
        58@Maxi
        {
            LLANFAIRPWLLGWYNGYLLGOGERYCHWYRNDROBWLLLLANTYSILIOGOGOGOCH
        }
        45@Midi
        {
            PNEUMONOULTRAMICROSCOPICSILICOVOLCANOCONIOSIS
        }
        18@Mini
        {
            CHARACTERISTICALLY
            ...
        }
    }

    Boggle
    {
        [
            [ "D", "S", "R", "O", "D", "G" ],
            [ "T", "E", "M", "E", "N", "S" ],
            [ "R", "A", "S", "I", "T", "O" ],
            [ "D", "G", "N", "T", "R", "P" ],
            [ "R", "E", "I", "A", "E", "S" ],
            [ "T", "S", "C", "L", "P", "D" ]
        ]
    }

    Run Strategy
    {
        Throughput (Perfect for microbenchmarking)
    }
}
```
| Method | Size |     Mean |    Error |   StdDev |
|------- |----- |---------:|---------:|---------:|
|   Trie | Maxi | 37.23 ms | 0.169 ms | 0.141 ms |
|   Trie | Midi | 25.11 ms | 0.162 ms | 0.144 ms |
|   Trie | Mini | 11.55 ms | 0.028 ms | 0.025 ms |
```
Result?
{
    It is the time to do micro optimizations
}
```
```
Satisfied(?)
{
    Yes => (:
    {
        Impressed(?)
        {
            Yes => (:
            No  => Next()
        }
    }
    No  => Next()
}
```
[`Next()`](https://github.com/tafo/BoggleSolver/tree/CellSolver)
