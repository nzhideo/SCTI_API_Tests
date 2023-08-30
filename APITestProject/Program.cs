using System;
using System.Diagnostics;

namespace MyConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Specify the path to the NUnit Console Runner executable
            string nunitConsoleRunner = "nunit3-console.exe";

            string testAssemblyPath = "C:/SCTI_API_Tests/APITestProject/bin/Debug/net6.0/APITestProject.dll";

            // Create a ProcessStartInfo to run the NUnit Console Runner
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = nunitConsoleRunner,
                Arguments = testAssemblyPath,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            // Start the NUnit Console Runner process
            Process process = new Process { StartInfo = psi };
            process.Start();

            // Read and display the output of the NUnit Console Runner
            string output = process.StandardOutput.ReadToEnd();
            Console.WriteLine(output);

            // Wait for the process to complete
            process.WaitForExit();

            // Get the exit code of the process
            int exitCode = process.ExitCode;

            // Close the process
            process.Close();

            // Optionally, handle the exit code as needed
            if (exitCode != 0)
            {
                Console.WriteLine("Tests failed.");
            }
            else
            {
                Console.WriteLine("Tests passed.");
            }
        }
    }
}
