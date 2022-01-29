using System;
using System.IO;
using Domain.Types;

namespace MarsRoversProblem
{
    class Program
    {
        /// <summary>Read input text file and execute commands</summary>
        static void Main(string[] args)
        {
            const string inputFilePath = "input.txt";

            using var streamReader = File.OpenText(inputFilePath);
            var line = streamReader.ReadLine();

            if (line == null) throw new Exception("Input file is empty");
            var plateau = Plateau.Init(line);
            var isDeployRoverLine = true;
            Rover rover = null;

            while ((line = streamReader.ReadLine()) != null) //read all lines
            {
                if (isDeployRoverLine) //deploy rover
                {
                    rover = Rover.DeployRover(line, plateau);
                }
                else //execute commands and write output to console
                {
                    if (rover == null)
                        throw new Exception("Invalid input line. Rover is not deployed");
                    rover.ExecuteCommands(line);
                    Console.WriteLine(rover.GetCurrentPosition());
                }

                isDeployRoverLine = !isDeployRoverLine;
            }
        }
    }
}