using System;
using System.Collections.Generic;

namespace MarsRoverKata
{
    public class MarsRover
    {
        private readonly List<string> PERMITTED_DIRECTIONS = new List<string>()
        {
            "N",
            "E",
            "S",
            "W"
        };

        public int X { get; private set; }
        public int Y { get; private set; }
        public string D { get; private set; }

        public MarsRover(int x, int y, string direction)
        {
            SetStartingCoordinates(x, y);
            SetStartingDirection(direction);
        }

        public void SetStartingCoordinates(int x, int y)
        {
            if (x < 0 || y < 0)
            {
                throw new ArgumentException("Starting X and/or Y coords are invalid");
            }

            X = x;
            Y = y;
        }

        private void SetStartingDirection(string direction)
        {
            if (PERMITTED_DIRECTIONS.Contains(direction))
            {
                this.D = direction;
            }
            else
            {
                throw new ArgumentException("Invalid starting direction");
            }
        }

        public void Move(string[] commands)
        {
            foreach (string command in commands)
            {
                if (IsCommandValid(command))
                {
                    switch (D)
                    {
                        case "N":
                            Y += (command.Equals("F")) ? 1 : -1;
                            break;
                        case "E":
                            X += command.Equals("F") ? 1 : -1;
                            break;
                        case "S":
                            Y -= command.Equals("F") ? 1 : -1;
                            break;
                        case "W":
                            X -= command.Equals("F") ? 1 : -1;
                            break;

                    }
                }
            }
        }

        private bool IsCommandValid(string command)
        {
            return command.Equals("F") || command.Equals("B");
        }
    }
}
