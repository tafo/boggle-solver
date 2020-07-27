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

[`continue`](https://github.com/tafo/BoggleSolver/tree/SlowSolver)
```
IndexSolver vs Trie(3 letter chain)
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

