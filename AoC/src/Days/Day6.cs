using System.Text.RegularExpressions;
using Nixill.Collections;
using Nixill.Objects;

namespace Nixill.AdventOfCode;

public class Day6 : AdventDay
{
  static Regex Instruction = new(@"(toggle|turn (?:on|off)) (\d+),(\d+) through (\d+),(\d+)");

  public override void Run(StreamReader input)
  {
    Grid<bool> lights1 = new Grid<bool>(1000, 1000, false);
    Grid<int> lights2 = new Grid<int>(1000, 1000, 0);
    int count1 = 0;
    int count2 = 0;

    D6Instruction[] instructions = input.GetLines()
      .Select(l => Instruction.Match(l))
      .Select(m => (m.Groups[1].Value, int.Parse(m.Groups[2].Value), int.Parse(m.Groups[3].Value),
        int.Parse(m.Groups[4].Value), int.Parse(m.Groups[5].Value)))
      .Select(g => new D6Instruction
      {
        Mode = g.Item1 switch
        {
          "toggle" => D6ToggleMode.Toggle,
          "turn off" => D6ToggleMode.TurnOff,
          "turn on" => D6ToggleMode.TurnOn,
          _ => throw new InvalidDataException()
        },
        TopLeft = (int.Min(g.Item2, g.Item4), int.Min(g.Item3, g.Item5)),
        BotRight = (int.Max(g.Item2, g.Item4), int.Max(g.Item3, g.Item5))
      }).ToArray();

    foreach (var inst in instructions)
    {
      for (int x = inst.TopLeft.X; x <= inst.BotRight.X; x++)
      {
        for (int y = inst.TopLeft.Y; y <= inst.BotRight.Y; y++)
        {
          if (lights1[(x, y)]) count1--;
          lights1[(x, y)] = inst.Mode switch
          {
            D6ToggleMode.TurnOff => false,
            D6ToggleMode.Toggle => !lights1[(x, y)],
            D6ToggleMode.TurnOn => true,
            _ => lights1[(x, y)]
          };
          if (lights1[(x, y)]) count1++;

          int val = lights2[(x, y)];
          count2 -= val;
          val = inst.Mode switch
          {
            D6ToggleMode.TurnOff => int.Max(0, val - 1),
            D6ToggleMode.Toggle => val + 2,
            D6ToggleMode.TurnOn => val + 1,
            _ => val
          };
          count2 += (lights2[(x, y)] = val);
        }
      }
    }

    Part1Number = count1;
    Part2Number = count2;
  }
}

public enum D6ToggleMode
{
  TurnOff = -1,
  Toggle = 0,
  TurnOn = 1
}

public readonly struct D6Instruction
{
  public D6ToggleMode Mode { get; init; }
  public IntVector2 TopLeft { get; init; }
  public IntVector2 BotRight { get; init; }
}