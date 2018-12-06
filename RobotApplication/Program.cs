using System;
using System.IO;
using System.Collections.Generic;

namespace RobotApplication
{
       
    class Program
    {
              
        static void Main()
        {

            //Setup input and output files
            string[] instructions = File.ReadAllLines(@AppDomain.CurrentDomain.BaseDirectory + "instructions.txt");
            StreamWriter writer = new StreamWriter(@AppDomain.CurrentDomain.BaseDirectory + "output.txt");
            
            //Variables used for file validation
            int i = 0;
            int x = 0;
            int y = 0;
            bool xnum;
            bool ynum;
            bool error = false;

            List<String> inputRobot = new List<String>();            
            List<String> inputInstructions = new List<String>();

            foreach (string readLine in instructions) 
            {
                //Arena line
                if (i == 0)
                {
                    string arenaSize = readLine;
                    arenaSize = arenaSize.Trim();
                    string[] sizes = arenaSize.Split(' ');

                    //Check fr two integer parameters
                    if (sizes.Length != 2)
                    {
                        writer.WriteLine("Invalid Number of Arguments");
                        error = true;
                    };

                    xnum = Int32.TryParse(sizes[0], out x);
                    ynum = Int32.TryParse(sizes[1], out y);

                    if (xnum == false || ynum == false) 
                    { 
                        writer.WriteLine("Invalid Arena Size");
                        error = true;
                    };

                    //Move to first robot line
                    i = 1;
                }

                    //Robot line
                else if (i == 1) 
                    { 
                        inputRobot.Add(readLine.Trim()); 
                        //Move to instruction line
                        i = 2; 
                    }

                    //Instruction line
                else 
                    { 
                        inputInstructions.Add(readLine.Trim()); 
                        //Move to next robot line
                        i = 1; 
                    };

               
                
            }

            if (inputRobot.Count != inputInstructions.Count)
            {
                writer.WriteLine("Robot missing instructions.");
                error = true;
            };

            if (!error)
            {

                Arena newArena = new Arena();
                newArena.SetArena(x, y);

                int z = -1;
                Robot robotOne = new Robot();

                foreach (string robot in inputRobot)
                {

                    z++;

                    string robotParameters = robot.Trim();
                    string[] robotSplit = robotParameters.Split(' ');

                    //Validate robot parameters
                    if (robotSplit.Length != 3)
                    {
                        writer.WriteLine("Invalid Robot Parameters");
                        error = true;
                        break;
                    };

                    xnum = Int32.TryParse(robotSplit[0], out x);
                    ynum = Int32.TryParse(robotSplit[1], out y);
                    string direction = robotSplit[2];


                    if (xnum == false || ynum == false || (direction != "N" && direction != "E" && direction != "S" && direction != "W"))
                    {
                        writer.WriteLine("Invalid Robot Parameters");
                        error = true;
                        break;
                    };

                    //Validate instructions
                    foreach (char c in inputInstructions[z])
                    {
                        if (c != 'L' && c != 'R' && c!= 'M')
                        {
                        writer.WriteLine("Invalid Instruction Parameters");
                        error = true;
                        break;
                        }
                    }

                    if (!error)
                    {
                        robotOne.SetRobot(x, y, direction.ToCharArray()[0], inputInstructions[z]);
                        robotOne.SetArena(newArena);
                        robotOne.runInstructions();
                        writer.WriteLine(robotOne.GetRobot());
                    }
                };
            }
            
            if (error) { writer.WriteLine("Error in instructions file, could not proceed."); };

            writer.Close();
            
        }
    }
}
