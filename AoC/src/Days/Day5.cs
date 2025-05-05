using System.Text.RegularExpressions;

namespace Nixill.AdventOfCode;

public class Day5 : AdventDay
{
  // Part 1 requirements
  Regex Vowels = new(@"[aeiou]");
  Regex DoubleLetter = new(@"(.)\1");
  Regex BadGroups = new(@"(ab|cd|pq|xy)");

  // Part 2 requirements
  Regex DoublePair = new(@"(..).*\1");
  Regex SinglePair = new(@"(.).\1");

  public override void Run(StreamReader input)
  {
    string[] list = input.GetAllLines();
    Part1Number = list.Count(l => Vowels.Matches(l).Count >= 3 && DoubleLetter.IsMatch(l) && !BadGroups.IsMatch(l));
    Part2Number = list.Count(l => DoublePair.IsMatch(l) && SinglePair.IsMatch(l));
  }
}