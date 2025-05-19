
using Nixill.Utils.Extensions;

namespace Nixill.AdventOfCode;

public class Day8 : AdventDay
{
  public override void Run(StreamReader input)
  {
    string[] lines = input.GetAllLines();

    Part1Number = lines.Select(l => l.Length - Parse(l).Length).Sum();
    Part2Number = lines.Select(l => Unparse(l).Length - l.Length).Sum();
  }

  private string Parse(string input)
    => new string(ParseEnum(input).ToArray());

  private IEnumerable<char> ParseEnum(string input)
  {
    List<char> chars = input.Skip(1).SkipLast(1).ToList();

    while (chars.Count > 0)
    {
      char c = chars.Pop();

      if (c != '\\')
      {
        yield return c;
        continue;
      }

      char c2 = chars.Pop();
      if (c2 == '\\')
      {
        yield return '\\';
      }
      else if (c2 == '"')
      {
        yield return '"';
      }
      else if (c2 == 'x')
      {
        char c3 = chars.Pop();
        char c4 = chars.Pop();
        yield return (char)Convert.ToInt32(new string([c3, c4]), 16);
      }
    }
  }

  private string Unparse(string input)
    => new string(UnparseEnum(input).ToArray());

  private IEnumerable<char> UnparseEnum(string input)
  {
    foreach (char c in input)
    {
      if (c == '"')
      {
        yield return '\\';
        yield return '"';
      }
      else if (c == '\\')
      {
        yield return '\\';
        yield return '\\';
      }
      else yield return c;
    }
  }
}