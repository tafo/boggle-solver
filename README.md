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
Check the following evolution steps of TheSolver
```
***
**SlowSolver**
```
FindChainMethod  => DepthFirstSearch

CheckChainMethod => Scanning
```
[`Source Code`](https://github.com/tafo/BoggleSolver/tree/SlowSolver)
```
Not optimized
{
    The start point of the evolution steps
}

Called SlowSolver
{    
    Very slow for a 4x4 boggle
}
```
```
Satisfied(?)
{
    Yes => !!!
    No  => Next()
}
```
***
**BinarySolver**
```
FindChainMethod  => DepthFirstSearch

CheckChainMethod => Binary Search
{
    Dictionaries are already sorted!
}
```
[`Source Code`](https://github.com/tafo/BoggleSolver/tree/BinarySolver)
```
SlowSolver vs BinarySolver
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
            [ "W", "O", "R" ],
            [ "C", "D", "L" ],
            [ "K", "A", "M" ]
        ]
    }
}
```
| Solver | Dict |          Mean |       Error |      StdDev |
|--------|----- |--------------:|------------:|------------:|
| Slow   | Mini |  2,245.407 ms |  31.4585 ms |  20.8078 ms |
| Binary | Mini |     18.564 ms |    1.222 ms |   0.8081 ms |
| Slow   | Midi |  7,669.591 ms | 263.0141 ms | 173.9676 ms |
| Binary | Midi |     29.315 ms |   2.102 ms  |   1.3902 ms |
| Slow   | Maxi | 16,611.425 ms | 385.2566 ms | 254.8234 ms |
| Binary | Maxi |     61.492 ms |   3.7198 ms |   2.4604 ms |
```
Result?
{
    Significant improvement !!!
    Retire SlowSolver !!!
}
```
```
Satisfied(?)
{
    Yes => !!
    No  => Next()
}

```
***
**HashSetSolver**
```
A set contains unique elements 
{
    Every word is unique!
}

FindChainMethod  => DepthFirstSearch

CheckChainMethod => ?
{
    I am open to any kind of requests
}
```
[`Source Code`](https://github.com/tafo/BoggleSolver/tree/HashSetSolver)
```
BinarySearchSolver vs HashSetSolver
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
            [ "W", "O", "R" ],
            [ "C", "D", "L" ],
            [ "K", "A", "M" ]
        ]
    }
}
```
| Solver       | Dict |      Mean |    Error |    StdDev |
|------------- |----- |----------:|---------:|----------:|
| BinarySearch | Maxi | 44.999 ms | 1.233 ms | 0.8154 ms |
|      HashSet | Maxi | 62.794 ms | 6.370 ms | 4.2133 ms |
| BinarySearch | Midi | 28.731 ms | 2.844 ms | 1.8813 ms |
|      HashSet | Midi | 30.020 ms | 5.479 ms | 3.6239 ms |
| BinarySearch | Mini | 18.634 ms | 4.394 ms | 2.9062 ms |
|      HashSet | Mini |  8.243 ms | 1.143 ms | 0.7558 ms |
```
Result?
{ 
    HashSet is slower for larger dictionaries
    {
        Initialization
        {
            From a dictionary file to HashSet<string>
        }
    }

    The minimum observed iteration time is 7.3236 ms which is very small!
    So?
    It is the time to use a 4x4 Boggle
}
```
```
BinarySearchSolver vs HashSetSolver
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
|       Method | Dict |     Mean |    Error |   StdDev |
|------------- |----- |---------:|---------:|---------:|
| BinarySearch | Maxi | 17.306 s | 0.2815 s | 0.1862 s |
|      HashSet | Maxi |  3.199 s | 0.0983 s | 0.0650 s |
| BinarySearch | Midi | 16.205 s | 0.0914 s | 0.0605 s |
|      HashSet | Midi |  2.726 s | 0.0753 s | 0.0498 s |
| BinarySearch | Mini | 14.523 s | 0.1291 s | 0.0854 s |
|      HashSet | Mini |  2.433 s | 0.0593 s | 0.0392 s |
```
Result?
{ 
    Significant improvement !!!
    Retire BinarySearchSolver !!
}
```
```
Satisfied(?)
{
    Yes => !
    No  => Next()
}
```
***
**TrieSolver**
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
