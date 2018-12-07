# robot-application

This application reads in a set of instructions describing an arena and collection of robots.

The first line of input determines the upper-right co-ordinates of the arena ("n n" where n is an integer value).

The next line will signify the start position of a robot ("n n E" where n is an integer signifying the start co-ordinates and E is one of the four compass points).

Each robot line is followed by a line of instructions for the robot to follow (using characters L, R and M to mean turn left, turn right, and move forward one space). This is then repeated for as many robots as required.

If any of the input instructions do not conform to these rules, an error message will be output.

The input instructions should be saved in a text file "instructions.txt" in the same folder as the executable RobotApplication.exe. The output (showing the final location of each robot in the arena) will be automatically saved in "output.txt".

Simply run the executable file [RobotApplication/bin/Release] to update the output.
