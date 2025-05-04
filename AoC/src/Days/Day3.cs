
using Nixill.Collections;
using Nixill.Objects;
using Nixill.Utils.Extensions;

namespace Nixill.AdventOfCode;

public class Day3 : AdventDay
{
  public override void Run(StreamReader input)
  {
    string directions = input.GetEverything();
    IntVector2 positionP1 = (0, 0);
    HashSet<IntVector2> presents1 = [(0, 0)];
    IntVector2 santaP2 = (0, 0);
    IntVector2 roboSantaP2 = (0, 0);
    HashSet<IntVector2> presents2 = [(0, 0)];

    foreach (char[] c in directions.Chunk(2))
    {
      IntVector2 move = c[0] switch
      {
        '>' => IntVector2.Right,
        '<' => IntVector2.Left,
        '^' => IntVector2.Up,
        'v' => IntVector2.Down,
        _ => throw new InvalidDataException()
      };
      positionP1 += move;
      presents1.Add(positionP1);
      santaP2 += move;
      presents2.Add(santaP2);

      if (c.Length == 2)
      {
        move = c[1] switch
        {
          '>' => IntVector2.Right,
          '<' => IntVector2.Left,
          '^' => IntVector2.Up,
          'v' => IntVector2.Down,
          _ => throw new InvalidDataException()
        };
        positionP1 += move;
        presents1.Add(positionP1);
        roboSantaP2 += move;
        presents2.Add(roboSantaP2);
      }
    }

    Part1Number = presents1.Count;
    Part2Number = presents2.Count;
  }
}