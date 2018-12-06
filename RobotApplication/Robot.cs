using System;

namespace RobotApplication
{
    class Robot
    {
        //Associate compass directions with degrees
        public enum Direction { N = 0, E = 90, S = 180, W = 270};
        
        int xPos;
        int yPos;
        Direction compass;
        String instructions;
        Arena assignedArena;
        

        public void SetRobot(int x, int y, char face, string commands)
        {
            xPos = x;
            yPos = y;
            instructions = commands;

            if (face == 'N') compass = Direction.N;
            if (face == 'E') compass = Direction.E;
            if (face == 'S') compass = Direction.S;
            if (face == 'W') compass = Direction.W;
        }

        public void SetArena(Arena a)
        {
            assignedArena = a;
        }

        public String GetRobot()
        {
            return xPos.ToString() + ' ' + yPos.ToString() + ' ' + (Direction)compass;
        }

        public void TurnRight()
        {
            //Turn 90 degrees clockwise
            compass = compass + 90;

            if ((int)compass >= 360)
            {
                compass = compass - 360;
            }
        }

        public void TurnLeft()
        {
            //Turn 90 degrees anti-clockwise
            compass = compass - 90;
            int x = (int)compass;

            if ((int)compass < 0)
            {
                compass = compass + 360;
            }            
        }

        public void MoveForward()
        {

            switch (compass)
            {
                //For each direction, if robot hasn't hit wall, move forwards.

                case Direction.N:
                    if (yPos != assignedArena.maxY)
                    yPos++;
                    break;
                case Direction.E:
                    if (xPos != assignedArena.maxX)
                    xPos++;
                    break;
                case Direction.S:
                    if (yPos != 0)
                    yPos--;
                    break;
                case Direction.W:
                    if (xPos != 0)
                    xPos--;
                    break;
            }

        }

        public void runInstructions()
        {
            foreach (char command in instructions)
            {

                if (command == 'L') { TurnLeft(); }
                else if (command == 'R') { TurnRight(); }
                else if (command == 'M') { MoveForward(); }
                else Console.WriteLine("Unknown Command: " + command);
                
            }
        }
    }

    
}
