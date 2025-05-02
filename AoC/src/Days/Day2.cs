namespace Nixill.AdventOfCode;

public class Day2 : AdventDay
{
  public override void Run(StreamReader input)
  {
    var dimsLists = input.GetAllLines().Select(l => l.Split('x').Select(int.Parse).Order().ToArray());
    Part1Number = dimsLists.Select(a => 3 * a[0] * a[1] + 2 * a[0] * a[2] + 2 * a[1] * a[2]).Sum();
    Part2Number = dimsLists.Select(a => 2 * (a[0] + a[1]) + a[0] * a[1] * a[2]).Sum();
  }
}