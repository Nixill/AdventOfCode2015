This is a free-to-use template for Advent of Code programs! All I ask is that you leave the LICENSE file intact (though you may rename it and apply your own license to the resulting repository).

The template is set up so that you can jump straight into coding the solutions without worrying about the boilerplate to run it. There is a little bit of fine print to that, though.

# Usage
For each day:

1. All input data goes in the folder `AoC/data/dayX`, where `X` is the number of the day (without leading zeroes).
   1. Examples should be files named `example*.txt`, where `*` can be replaced with anything. These example files should contain the expected answer for part 1 on the first line, part 2 on the second line, and then the actual input starts with the third line. Either line can also be set to `\SKIP` to set the `SkipPart1` or `SkipPart2` flags in your code, if needed. (If the expected answer starts with a backslash, write two backslashes at the start. Don't escape backslashes in the expected answer otherwise.)
   2. The actual puzzle input should be in a file named `input.txt`. It does *NOT* have the leading "expected answer" lines - you can (and should) directly save the "get your puzzle input" file to the expected path.
2. For each day, you will need to create a public class named `DayX`, where `X` is the number of the day (without leading zeroes). This class must derive from `AdventDay`, and contain a `Run` method that takes a single `StreamReader`.
   1. This `StreamReader` is set to the start of the puzzle or example input. For examples, it will be positioned past the expected answers, at the start of the third line.
   2. Within the `Run` method, set the `Part1String` or `Part1Number` to the answer your code comes up with. Same for `Part2`.
3. Run the program.
   1. Using "Latest" will run the highest-numbered available day; "Main" will prompt you to input a day.
   2. The runner will run your code against all example inputs first.
   3. If an expected answer is specified, and the given answer doesn't match it, you'll be told what the actually-given answer was, and the program will exit upon the conclusion of all example tests (*without* running on your input data!).
   4. If all examples' given answers match the expected answers, then the program will run your code on the actual input data, and give you those answers as well.

# REPL Usage
Another thing you can do, new to this version of my AoC template, is to run the code as part of a Read-Eval-Print Loop. If you're doing this, I recommend using [CSharpREPL](https://github.com/waf/CSharpRepl). You can then run your code for a given day, for example day 1, as follows (relative paths assume you opened the csharprepl at the root of this repository):

```cs
#r "AoC/AoC.csproj"
using Nixill.AdventOfCode;
Day1 day1example1 = Program.RunDay<Day1>("AoC/data/day1/example1.txt");
```

Once you've done so, you are free to inspect any public members of the output at your leisure.

# AdventDay Class
The `AdventDay` class contains the following accessible members:

- string `InputFilename` (get): The input filename for a given iteration of the code. Ideally not used, but some puzzles do have slightly different rules between examples and actual input.
- bool `SkipPart1` and `SkipPart2`: Usually `false`; if `true`, a given example has indicated that one part or the other should be skipped on that input. Mostly usable for part 1 examples that aren't designed to carry into part 2. Always `false` for real puzzle input.
- bool `Part1Complete` and `Part2Complete` (get): Whether or not an answer has been provided by your code for a given part.
- string `Part1Answer` and `Part2Answer` (get): The answer provided by your code, if any. Throws an exception if that part is not complete. Cannot be directly set, use the following properties instead.
- string `Part1String` and `Part2String`: The answer provided by your code, as a string. When set, that part is marked as complete.
- long `Part1Number` and `Part2Number`: The answer provided by your code, as a number. When set, that part is marked as complete.

Access notes:

- `SkipPart1` and `SkipPart2` are internally, but not publicly, settable.
- `Part1String`, `Part2String`, `Part1Number`, and `Part2Number` are protected, not publicly accessible.

# AdventExtensions Class
The `AdventExtensions` static class contains the following extension methods on `StreamReader`:

- IEnumerable&lt;string&gt; `StreamReader.GetLines()`: Gets an enumerator over the lines of the input.
- string[] `StreamReader.GetAllLines()`: Gets an array of all the lines of the input.
- string `StreamReader.GetEverything()`: Gets the entire input.
- IEnumerable&lt;string&gt; `StreamReader.GetLinesOfChunk()`: Gets an enumerator over the lines of the next chunk of the input.
- IEnumerable&lt;IEnumerable&lt;string&gt;&gt; `StreamReader.GetChunksByLine()`: Gets an enumerator over all the chunks of the input.
- IEnumerable&lt;string&gt; `StreamReader.GetWholeChunks()`: Gets an enumerator over whole chunks.
- Grid&lt;char&gt; `StreamReader.CharacterGrid()`: Returns the entire input as a single grid of characters.
- Grid&lt;char&gt; `StreamReader.CharacterGridChunk()`: Returns the next chunk of input as a single grid of characters.
- Grid&lt;T&gt; `StreamReader.Grid(Func<char, T>)`: Returns the entire input as a single grid. The parameter maps a character to something else.
- Grid&lt;T&gt; `StreamReader.GridChunk(Func<char, T>)`: Returns the next chunk of input as a single grid of characters. The parameter maps a character to something else.

With the following notes/caveats:
- If the input file ends with a blank line, this line is ignored.
- One chunk is one or more non-empty lines, broken by empty lines. The empty lines separating chunks are not returned.
- All of those methods run from the current position within the input.

And the following other extension methods:
- T `T.AssignTo(out T)`: Assigns a value to a variable inline, returning it.
- void `IGrid<char>.PrintGrid()`: Prints a character grid to the console.

# Other notes
Note that the folder `AoC/data` is `.gitignore`d. This is intentional, as Advent of Code [requests](https://adventofcode.com/about#faq_copying) that puzzle inputs not be shared. You can remove that if you're committing to a private repository; otherwise, if you need to version-control your input data, you should look into submodules.

If you've used either of my [previous](https://github.com/Nixill/AdventOfCodeTemplate) [templates](https://github.com/Nixill/AdventOfCodeTemplate3), this new format is *mostly* incompatible with both. However, the data folder structure remains the same as it did in Template3.

Template2 doesn't exist. Don't ask. ☺