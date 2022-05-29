using RobotCleaner;

List<Move> exampleMovesSet = new List<Move>()
{
    new Move()
    {
        Direction = "E",
        NumberOfSteps = 2
    },
    new Move()
    {
        Direction = "N",
        NumberOfSteps = 3
    },
    new Move()
    {
        Direction = "W",
        NumberOfSteps = 4
    },
    new Move()
    {
        Direction = "S",
        NumberOfSteps = 5
    },
    new Move()
    {
        Direction = "E",
        NumberOfSteps = 5
    },
    new Move()
    {
        Direction = "W",
        NumberOfSteps = 6
    }
};
Input input = new Input(1, new Coordinates(0, 0) , exampleMovesSet);

RobotCleaner.RobotCleaner.CalculateCleanedSurface(input);