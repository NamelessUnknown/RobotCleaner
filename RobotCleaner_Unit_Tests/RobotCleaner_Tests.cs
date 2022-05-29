using RobotCleaner;

namespace RobotCleaner_Unit_Tests
{
    public class RobotCleaner_Tests
    {
        [Fact]
        public void RobotCleaner_RouteTest_OneDirection()
        {
            List<Move> moves = new()
            {
                new Move()
                {
                    Direction = "W",
                    NumberOfSteps = 2
                }
            };
            Input input = new Input(1, new Coordinates(0, 0), moves);

            var result = RobotCleaner.RobotCleaner.CalculateCleanedSurface(input);
            Assert.Equal(3, result);
        }
        [Fact]
        public void RobotCleaner_RouteTest_TwoDirections()
        {
            List<Move> moves = new()
            {
                new Move()
                {
                    Direction = "W",
                    NumberOfSteps = 2
                },
                new Move()
                {
                    Direction = "N",
                    NumberOfSteps = 2
                }
            };
            Input input = new Input(1, new Coordinates(0, 0), moves);

            var result = RobotCleaner.RobotCleaner.CalculateCleanedSurface(input);
            Assert.Equal(5, result);
        }

        [Fact]
        public void RobotCleaner_RouteTest_OneDirection_BackAndForth()
        {
            List<Move> moves = new()
            {
                new Move()
                {
                    Direction = "W",
                    NumberOfSteps = 2
                },
                new Move()
                {
                    Direction = "E",
                    NumberOfSteps = 2
                }
            };
            Input input = new Input(1, new Coordinates(0, 0), moves);

            var result = RobotCleaner.RobotCleaner.CalculateCleanedSurface(input);
            Assert.Equal(3, result);
        }

        [Fact]
        public void RobotCleaner_RouteTest_TwoDirections_BackAndForth()
        {
            List<Move> moves = new()
            {
                new Move()
                {
                    Direction = "W",
                    NumberOfSteps = 2
                },
                new Move()
                {
                    Direction = "N",
                    NumberOfSteps = 2
                },
                new Move()
                {
                    Direction = "S",
                    NumberOfSteps = 2
                },
                new Move()
                {
                    Direction = "E",
                    NumberOfSteps = 2
                }
            };
            Input input = new Input(1, new Coordinates(0, 0), moves);

            var result = RobotCleaner.RobotCleaner.CalculateCleanedSurface(input);
            Assert.Equal(5, result);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(3)]
        [InlineData(99999)]
        public void RobotCleaner_CleanedSurfacesInGivenDirection_Test_AmountOfReturnedSurfaces(int expectedAmountOfMoves)
        {
            var result = RobotCleaner.RobotCleaner.CleanedSurfacesInGivenDirection(0, 0, "E", expectedAmountOfMoves);
            Assert.Equal(expectedAmountOfMoves, result.Count());
        }
    }
}