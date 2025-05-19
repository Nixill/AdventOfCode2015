
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using Nixill.Attributes;
using Nixill.Utils.Extensions;

namespace Nixill.AdventOfCode;

public class Day7 : AdventDay
{
  public override void Run(StreamReader input)
  {
    List<D7Instruction> Instructions = input.GetAllLines().Select(s => new D7Instruction(s)).ToList();
    Dictionary<string, ushort> Values = [];

    while (Instructions.Count > 0)
    {
      D7Instruction inst = Instructions.Pop();

      if ((inst.LeftSide != null && !Values.ContainsKey(inst.LeftSide))
        || (inst.RightSide != null && !Values.ContainsKey(inst.RightSide)))
      {
        Instructions.Add(inst);
        continue;
      }

      ushort left = (inst.LeftSide != null) ? Values[inst.LeftSide] : (ushort)0;
      ushort right = (inst.RightSide != null) ? Values[inst.RightSide] : (ushort)0;
      ushort value = inst.Value;

      value = (inst.Operator) switch
      {
        D7Operator.AndGate => (ushort)(left & right),
        D7Operator.OrGate => (ushort)(left | right),
        D7Operator.NotGate => (ushort)(~left),
        D7Operator.LShiftGate => (ushort)(left << value),
        D7Operator.RShiftGate => (ushort)(left >> value),
        D7Operator.PassThru => left,
        _ => value // handles the Literal case too!
      };

      Values[inst.Output] = value;
    }

    Part1Number = Values["a"];
  }
}

public enum D7Operator
{
  [RegexTest(@"^(?<l>[a-z]+) AND (?<r>[a-z]+) -> (?<out>[a-z]+)$")] AndGate = 1,
  [RegexTest(@"^(?<l>[a-z]+) OR (?<r>[a-z]+) -> (?<out>[a-z]+)$")] OrGate = 2,
  [RegexTest(@"^NOT (?<r>[a-z]+) -> (?<out>[a-z]+)$")] NotGate = 3,
  [RegexTest(@"^(?<l>[a-z]+) LSHIFT (?<val>\d+) -> (?<out>[a-z]+)$")] LShiftGate = 4,
  [RegexTest(@"^(?<l>[a-z]+) RSHIFT (?<val>\d+) -> (?<out>[a-z]+)$")] RShiftGate = 5,
  [RegexTest(@"^(?<l>[a-z]+) -> (?<out>[a-z]+)$")] PassThru = 6,
  [RegexTest(@"^(?<val>\d+) -> (?<out>[a-z]+)$")] Literal = 7,
  Invalid = 0
}

public readonly struct D7Instruction
{
  public required string? LeftSide { get; init; }
  public required string? RightSide { get; init; }
  public required D7Operator Operator { get; init; }
  public required ushort Value { get; init; }
  public required string Output { get; init; }

  [SetsRequiredMembers]
  public D7Instruction(string input)
  {
    Operator = RegexTestAttribute.TestAgainst<D7Operator>(input, out Match match);
    LeftSide = null;
    RightSide = null;
    Value = 0;
    Output = match.Groups["out"].Value;

    switch (Operator)
    {
      case D7Operator.AndGate or D7Operator.OrGate:
        LeftSide = match.Groups["l"].Value;
        RightSide = match.Groups["r"].Value;
        break;
      case D7Operator.NotGate or D7Operator.PassThru:
        LeftSide = match.Groups["l"].Value;
        break;
      case D7Operator.LShiftGate or D7Operator.RShiftGate:
        LeftSide = match.Groups["l"].Value;
        Value = ushort.Parse(match.Groups["val"].Value);
        break;
      case D7Operator.Literal:
        Value = ushort.Parse(match.Groups["val"].Value);
        break;
    }
  }
}
