namespace MarsRoverKata
{
    public class MarsRover
    {

        public MarsRover(int x, int y, Direction facingDirection)
        {
            X = x;
            Y = y;
            FacingDirection = facingDirection;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public Direction FacingDirection { get; set; }

        public void Move(Movement command)
        {
            if (command.Equals(Movement.Forward))
            {
                MoveForward();
            }
            else
            {
                MoveBackward();
            }
        }

        private void MoveBackward()
        {
            if (FacingDirection == Direction.S)
            {
                Y++;
            }

            if (FacingDirection == Direction.E)
            {
                X--;
            }

            if (FacingDirection == Direction.W)
            {
                X++;
            }

            if (FacingDirection == Direction.N)
            {
                Y--;
            }
        }

        private void MoveForward()
        {

        }

        public void Commands(char[] commands)
        {
            foreach (var cmd in commands )
            {
                ICommand command;
                if (cmd.Equals('f'))
                {
                    command = new CommandForward(this);
                }

                if (cmd.Equals('b'))
                {
                    command = new CommandBackwards(this);
                }

                if (cmd.Equals('l'))
                {
                    command = new CommandLeft(this);
                }

                if (cmd.Equals('r'))
                {
                    command = new CommandRight(this);
                }

                command.Execute();
            }
        }

        public void Spin(SpinCommand command)
        {
            int spinValue = 0;
            if (command == SpinCommand.LEFT)
            {
                spinValue = (int) FacingDirection - 1 == -1 ? 3 : (int) FacingDirection - 1;
            }

            if (command == SpinCommand.RIGHT)
            {
                spinValue = (int)FacingDirection + 1 == 4 ? 0 : (int)FacingDirection + 1;
            }
            FacingDirection = (Direction)spinValue;
        }
    }

    public class CommandBackwards : ICommand
    {
        private MarsRover marsRover_;
        public CommandBackwards(MarsRover marsRover)
        {
            marsRover_ = marsRover;
        }

        public void Execute()
        {
            throw new System.NotImplementedException();
        }
    }

    public enum SpinCommand
    {
        LEFT,
        RIGHT
    }
}