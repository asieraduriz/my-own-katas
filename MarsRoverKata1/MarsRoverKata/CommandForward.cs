using System.CodeDom;

namespace MarsRoverKata
{
    public class CommandForward : ICommand
    {
        private MarsRover marsRover;

        public CommandForward(MarsRover marsRover)
        {
            this.marsRover = marsRover;
        }
        public void Execute()
        {
            if (marsRover.FacingDirection == Direction.S)
            {
                marsRover.Y--;
            }

            if (FacingDirection == Direction.E)
            {
                X++;
            }

            if (FacingDirection == Direction.W)
            {
                X--;
            }

            if (FacingDirection == Direction.N)
            {
                Y++;
            }
        }
    }
}
