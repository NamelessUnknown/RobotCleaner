namespace RobotCleaner
{
    public static class RobotCleaner
    {
        public static int CalculateCleanedSurface(Input input)
        {
            List<Coordinates> cleanedSurfaces = new List<Coordinates>()
            {
                input.StartingCoordinates
            };

            var actualCoordinates = new Coordinates(input.StartingCoordinates.X, input.StartingCoordinates.Y);

            for (int i = 0; i < input.NumberOfCommands; i++)
            {
                foreach (var move in input.Moves)
                {
                    switch (move.Direction)
                    {
                        case "E":
                            cleanedSurfaces.AddRange(CleanedSurfacesInGivenDirection(actualCoordinates.X, actualCoordinates.Y, "E", move.NumberOfSteps));
                            actualCoordinates.X -= move.NumberOfSteps;

                            break;
                        case "W":
                            cleanedSurfaces.AddRange(CleanedSurfacesInGivenDirection(actualCoordinates.X, actualCoordinates.Y, "W", move.NumberOfSteps));
                            actualCoordinates.X += move.NumberOfSteps;

                            break;
                        case "S":
                            cleanedSurfaces.AddRange(CleanedSurfacesInGivenDirection(actualCoordinates.X, actualCoordinates.Y, "S", move.NumberOfSteps));
                            actualCoordinates.Y -= move.NumberOfSteps;

                            break;
                        case "N":
                            cleanedSurfaces.AddRange(CleanedSurfacesInGivenDirection(actualCoordinates.X, actualCoordinates.Y, "N", move.NumberOfSteps));
                            actualCoordinates.Y += move.NumberOfSteps;
                            break;
                    }
                }
            }

            foreach (var coords in cleanedSurfaces)
            {
                Console.WriteLine("X coordinates: " + coords.X + " Y coordinates: " + coords.Y);
            }

            var distinctAreas = cleanedSurfaces.GroupBy(area => new { area.X, area.Y }).Select(g => g.First()).Count();

            Console.WriteLine($"=> Cleaned: {distinctAreas}");
            return distinctAreas;
        }

        public static IEnumerable<Coordinates> CleanedSurfacesInGivenDirection(int x, int y, string direction, int steps)
        {
            var currentCoordinates = new Coordinates(x, y);
            for (int i = 0; i < steps; i++)
            {
                switch (direction)
                {
                    case "E":
                        --currentCoordinates.X;
                        break;
                    case "W":
                        ++currentCoordinates.X;
                        break;
                    case "S":
                        --currentCoordinates.Y;
                        break;
                    case "N":
                        ++currentCoordinates.Y;
                        break;
                }
                yield return new Coordinates(currentCoordinates.X, currentCoordinates.Y);
            }
        }
    }
}
