```
2 (x + y) = ?
```
[Trie@Wikipedia](https://en.wikipedia.org/wiki/Trie)
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
    No  => Next()
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
    No  => Next()
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
    Yes
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

Level5.ChainCounter =>  6,991,853
Level6.ChainCounter => 56,219,570
And
{
    Level5 found 22 words in 00:00:05.9038080
    Level6 found 22 words in 00:00:40.6983284
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
So?
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
    Yes
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
[`Next()`](https://github.com/tafo/boggle-solver)
