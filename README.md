```
Why dictionaries have a section for each letter?
{
    Every word is mapped to its first letter
}

HashSetSolver vs DictionarySolver
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
|     Method | Size |    Mean |    Error |   StdDev |
|----------- |----- |--------:|---------:|---------:|
| Dictionary | Maxi | 2.372 s | 0.0832 s | 0.0550 s |
|    HashSet | Maxi | 3.001 s | 0.0604 s | 0.0399 s |
| Dictionary | Midi | 2.340 s | 0.0659 s | 0.0436 s |
|    HashSet | Midi | 2.580 s | 0.0941 s | 0.0622 s |
| Dictionary | Mini | 2.294 s | 0.0329 s | 0.0218 s |
|    HashSet | Mini | 2.323 s | 0.0867 s | 0.0574 s |
```
Result?
{
    A fine performance improvement !!
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
[`Next()`](https://github.com/tafo/BoggleSolver/tree/TrieSolver)
