## BOGGLE
```
A game that is played using a grid of letters

Players attempt to find words in sequences of adjacent letters
```
```
Players can start with any letter

Previously used letters can not be used again

Words must be at least 3 characters

Words must be at most MxN characters
{
    M = The number of rows
    N = The number of columns
}

Points are calculated according to the following table
```
Word Length | Points
--| --
3 | 1
4 | 1
5 | 2
6 | 3
7 | 5
8+| 11
```
Sample 3x3 Grid
{
    A B C 
    K E M
    X Y Z 
}

Sample Dictionary
{ 
    "ABE", "ABY", "ABLE", "BAK", "KEY"
}

All Valid Words
{
    "ABE", "BAK", "KEY"
}
```
## BOGGLE SOLVER
```
Finds all possible words in the given grid
```
```
A boggle solver was implemented by DFS(DepthFirstSearch) approach
```

[`CLICK TO SEE PREVIOUS VERSIONS AND BENCHMARKS`](https://github.com/tafo/BoggleSolver/tree/SlowSolver)
```
IndexSolver vs Trie(3 letter chain)
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
| Method | Size |       Mean |     Error |    StdDev |
|------- |----- |-----------:|----------:|----------:|
|   Trie | Maxi | 1,734.1 ms |   9.18 ms |   6.07 ms |
|  Index | Maxi | 1,504.1 ms | 477.62 ms | 315.91 ms |
|   Trie | Midi | 1,539.7 ms |  16.16 ms |  10.69 ms |
|  Index | Midi | 1,284.4 ms |   5.44 ms |   3.60 ms |
|   Trie | Mini |   902.5 ms |   6.49 ms |   4.29 ms |
|  Index | Mini |   762.1 ms |   5.84 ms |   3.86 ms |
```
Result?
{
    Check 4 letter chain
}
```
```
IndexSolver vs Trie(4 letter chain)
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
| Method | Size |       Mean |    Error |   StdDev |
|------- |----- |-----------:|---------:|---------:|
|   Trie | Maxi |   539.6 ms |  3.50 ms |  2.32 ms |
|  Index | Maxi | 1,416.1 ms | 10.95 ms |  7.24 ms |
|   Trie | Midi |   408.8 ms |  1.59 ms |  1.05 ms |
|  Index | Midi | 1,313.7 ms | 10.41 ms |  6.88 ms |
|   Trie | Mini |   148.1 ms |  7.37 ms |  4.87 ms |
|  Index | Mini |   778.1 ms | 17.72 ms | 11.72 ms |
```
Result?
{
    IndexSolver is retired!
}
```
