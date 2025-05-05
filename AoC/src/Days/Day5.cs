using System.Text.RegularExpressions;

namespace Nixill.AdventOfCode;

public class Day5 : AdventDay
{
  // Part 1 requirements
  static Regex Vowels = new(@"[aeiou]");
  static Regex DoubleLetter = new(@"(.)\1");
  static Regex BadGroups = new(@"(ab|cd|pq|xy)");

  // Part 2 requirements
  static Regex DoublePair = new(@"(..).*\1");
  static Regex SinglePair = new(@"(.).\1");

  public override void Run(StreamReader input)
  {
    string[] list = input.GetAllLines();
    Part1Number = list.Count(l => Vowels.Matches(l).Count >= 3 && DoubleLetter.IsMatch(l) && !BadGroups.IsMatch(l));
    Part2Number = list.Count(l => DoublePair.IsMatch(l) && SinglePair.IsMatch(l));
  }
}