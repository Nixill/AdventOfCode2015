using Nixill.Utils;

namespace Nixill.AdventOfCode;

public class Day4 : AdventDay
{
  public override void Run(StreamReader input)
  {
    string code = input.GetEverything();
    Part1Number = Enumerable.Range(0, int.MaxValue).First(i => TextUtils.MD5HexHash($"{code}{i}").StartsWith("00000"));
    if (!SkipPart2) Part2Number = Enumerable.Range((int)Part1Number, int.MaxValue - (int)Part1Number).First(i => TextUtils.MD5HexHash($"{code}{i}").StartsWith("000000"));
  }
}