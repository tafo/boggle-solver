**Object Oriented Coding**
```
Playing With Objects
{
    Extensible?

    Closer to Real?

    ...
}
```
```
Simply!
{
    Run() calls Chain() 
    Chain() calls itself again and again
    {
        Chain method calculates the indexes of available adjacent cells again and again
        {
            Using calculated indexes
            {
                Implement a BoggleCell class
                &
                MapBoggleCells()
            }
        }
    }
}
```
```
TrieSolver vs CellSolver
{
    Windows 10.0.18362.959 (1903/May2019Update/19H1)
    Intel Core i7-4720HQ CPU 2.60GHz (Haswell), 1 CPU, 8 logical and 4 physical cores

    Dictionaries
    {
        Maxi    = 281,279 Words
        Midi    = 129,552 Words
        Mini    =  39,096 Words    
    }

    Solved Boggles
    {
        "Mini": [
            [ "S", "E", "R", "S" ],
            [ "P", "A", "T", "G" ],
            [ "L", "I", "N", "E" ],
            [ "S", "E", "R", "S" ]
        ]

        "Midi": [
            [ "R", "S", "C", "L", "S" ],
            [ "D", "E", "I", "A", "E" ],
            [ "G", "N", "T", "R", "P" ],
            [ "I", "A", "E", "S", "O" ],
            [ "L", "M", "I", "D", "C" ]
        ]

        "Maxi": [
            [ "D", "S", "R", "O", "D", "G" ],
            [ "T", "E", "M", "E", "N", "S" ],
            [ "R", "A", "S", "I", "T", "O" ],
            [ "D", "G", "N", "T", "R", "P" ],
            [ "R", "E", "I", "A", "E", "S" ],
            [ "T", "S", "C", "L", "P", "D" ]

        "Mino": [
            [ "D", "S", "R", "O", "D", "G", "T" ],
            [ "T", "E", "M", "E", "N", "S", "A" ],
            [ "R", "A", "S", "I", "T", "O", "F" ],
            [ "D", "G", "N", "T", "R", "P", "O" ],
            [ "R", "E", "I", "A", "E", "S", "F" ],
            [ "T", "S", "C", "L", "P", "D", "A" ],
            [ "T", "A", "F", "O", "F", "A", "T" ]
    }

    Run Strategy
    {
        Throughput (Perfect for microbenchmarking)
    }
}
```
|     Method | DictionarySize |      Mean |    Error |   StdDev |
|----------- |--------------- |----------:|---------:|---------:|
| TrieSolver |           Maxi | 114.36 ms | 0.335 ms | 0.280 ms |
| CellSolver |           Maxi | 121.06 ms | 0.823 ms | 0.769 ms |
| TrieSolver |           Midi |  76.30 ms | 0.444 ms | 0.370 ms |
| CellSolver |           Midi |  83.75 ms | 0.829 ms | 0.776 ms |
| TrieSolver |           Mini |  34.35 ms | 0.276 ms | 0.230 ms |
| CellSolver |           Mini |  38.51 ms | 0.395 ms | 0.350 ms |
```
Result?
{
    Even if CellSolver is a more elegant solution than TrieSolver, it is not faster
    {
        Why?
        {
            continue
        }
    }
}
```
```
Checked
{
    MapCells().Cost
    {
        A few ticks
    }
}

A Micro Improvement
{
    Delete BoggleCell.AvailableAdjacentCells, BoggleCell.RowIndex, BoggleCell.ColIndex
    
    Refactor LetterTrie

    ...
}
```
|     Method | DictionarySize |      Mean |    Error |   StdDev |
|----------- |--------------- |----------:|---------:|---------:|
| TrieSolver |           Maxi | 116.76 ms | 1.121 ms | 1.049 ms |
| CellSolver |           Maxi | 115.63 ms | 1.767 ms | 1.476 ms |
| TrieSolver |           Midi |  76.69 ms | 0.639 ms | 0.598 ms |
| CellSolver |           Midi |  78.58 ms | 0.258 ms | 0.229 ms |
| TrieSolver |           Mini |  35.15 ms | 0.238 ms | 0.223 ms |
| CellSolver |           Mini |  35.74 ms | 0.293 ms | 0.260 ms |
```
Result?
{
    Because of CellSolver is a more elegant solution, 
    {
        Retire TrieSolver
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
            No  => Next()
        }
    }
    No  => Next()
}
```
[`Next()`](https://github.com/tafo/boggle-solver)
