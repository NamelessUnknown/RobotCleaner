using RobotCleaner;

Console.WriteLine("Insert starting coordinates(e.g. '-2 -2')");
var startingCoordinates = Console.ReadLine().ToString();

Console.WriteLine("Insert number of sequences (e.g. '2')");
var numberOfSequences = int.Parse(Console.ReadLine().ToString());

Console.WriteLine("Insert move directions and number of surfaces to be cleaned (e.g. 'E2 W4')");
var collectedMoveDirections = Console.ReadLine().ToString();

var moveDirections = !string.IsNullOrEmpty(collectedMoveDirections)? collectedMoveDirections.Split(" ") : null;

List<Move> createdMoveSet = new List<Move>();

foreach (var moveDir in moveDirections)
{
    createdMoveSet.Add(new Move()
    {
        Direction = moveDir[0].ToString(),
        NumberOfSteps = int.Parse(moveDir.ToString().Substring(1))
    });
}

Coordinates startCoords = new(int.Parse(startingCoordinates[0].ToString()), int.Parse(startingCoordinates[2].ToString()));

Input input = new Input(numberOfSequences, startCoords, createdMoveSet);

RobotCleaner.RobotCleaner.CalculateCleanedSurface(input);