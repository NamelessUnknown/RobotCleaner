namespace RobotCleaner
{
    public class Input
    {
        public int NumberOfCommands { get; set; }
        public Coordinates StartingCoordinates { get; set; } = new Coordinates(0, 0);
        public List<Move> Moves { get; set; }
        public Input(int numberOfCommands, Coordinates startingCoordinates, List<Move> moves)
        {
            NumberOfCommands = numberOfCommands;
            StartingCoordinates = startingCoordinates;
            Moves = moves;
        }
    }
}
