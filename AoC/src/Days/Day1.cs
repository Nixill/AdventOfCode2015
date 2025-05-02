namespace Nixill.AdventOfCode;

public class Day1 : AdventDay
{
  public override void Run(StreamReader input)
  {
    string dirs = input.GetEverything();

    int chars = 0;

    foreach (char c in dirs)
    {
      chars++;
      if (c == '(') Part1Number += 1;
      if (c == ')') Part1Number -= 1;
      if (Part1Number == -1 && Part2Number == 0) Part2Number = chars;
    }
  }
}