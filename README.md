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
