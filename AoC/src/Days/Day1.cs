
namespace Nixill.AdventOfCode;

public class Day1 : AdventDay
{
  public override void Run(StreamReader input)
  {
    string dirs = input.GetEverything();

    long lefts = 0;
    long rights = 0;

    foreach (char c in dirs)
    {
      if (c == '(') lefts += 1;
      if (c == ')') rights += 1;
    }

    Part1Number = lefts - rights;
    Part2Number = lefts * rights; // just as a guess :3
  }
}