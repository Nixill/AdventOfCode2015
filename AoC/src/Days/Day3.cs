
using Nixill.Collections;
using Nixill.Objects;
using Nixill.Utils.Extensions;

namespace Nixill.AdventOfCode;

public class Day3 : AdventDay
{
  public override void Run(StreamReader input)
  {
    string directions = input.GetEverything();
    IntVector2 position = (0, 0);
    HashSet<IntVector2> presents = [(0, 0)];

    foreach (char c in directions)
    {
      position += c switch
      {
        '>' => IntVector2.Right,
        '<' => IntVector2.Left,
        '^' => IntVector2.Up,
        'v' => IntVector2.Down,
        _ => throw new InvalidDataException()
      };
      presents.Add(position);
    }

    Part1Number = presents.Count;

    position = (0, 0);
    presents = [(0, 0)];
    IntVector2 roboPosition = (0, 0);

    foreach (char[] c in directions.Chunk(2))
    {
      position += c[0] switch
      {
        '>' => IntVector2.Right,
        '<' => IntVector2.Left,
        '^' => IntVector2.Up,
        'v' => IntVector2.Down,
        _ => throw new InvalidDataException()
      };
      if (c.Length == 2)
        roboPosition += c[1] switch
        {
          '>' => IntVector2.Right,
          '<' => IntVector2.Left,
          '^' => IntVector2.Up,
          'v' => IntVector2.Down,
          _ => throw new InvalidDataException()
        };
      presents.Add(position);
      presents.Add(roboPosition);
    }

    Part2Number = presents.Count;
  }
}