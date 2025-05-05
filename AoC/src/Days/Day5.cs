using System.Text.RegularExpressions;

namespace Nixill.AdventOfCode;

public class Day5 : AdventDay
{
  Regex Vowels = new(@"[aeiou]");
  Regex DoubleLetter = new(@"(.)\1");
  Regex BadGroups = new(@"(ab|cd|pq|xy)");

  public override void Run(StreamReader input)
  {
    string[] list = input.GetAllLines();
    Part1Number = list.Count(l => Vowels.Matches(l).Count >= 3 && DoubleLetter.IsMatch(l) && !BadGroups.IsMatch(l));
  }
}