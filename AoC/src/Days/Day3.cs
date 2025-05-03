
using Nixill.Collections;
using Nixill.Objects;
using Nixill.Utils.Extensions;

namespace Nixill.AdventOfCode;

public class Day3 : AdventDay
{
  public override void Run(StreamReader input)
  {
    IntVector2 position = new(0, 0);
    Dictionary<IntVector2, int> presents = new Dictionary<IntVector2, int>
    {
      [(0, 0)] = 1
    };
    int maxCount = 1;

    foreach (char c in input.GetEverything())
    {
      position += c switch
      {
        '>' => IntVector2.Right,
        '<' => IntVector2.Left,
        '^' => IntVector2.Up,
        'v' => IntVector2.Down,
        _ => throw new InvalidDataException()
      };
      int count = presents.PlusOrSet(position, 1);
      maxCount = int.Max(maxCount, count);
    }

    Part1Number = presents.Count;
    Part2Number = maxCount; // let's try and be clever and guess it :3
  }
}