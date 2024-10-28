using System; // Ensure to include this for Random
using System.Collections.Generic; // For List<T>
using System.Threading; // For Thread.Sleep

namespace MainFinal
{
    internal class Program
    {
        private const int MaxCubes = 10; // Maximum number of cubes allowed
        private const int CubeSpawnThreshold = 5; // Minimum cubes before spawning new ones

        static void Main(string[] args)
        {
            try
            {
                Console.CursorVisible = false; // Hide the cursor
                int spawnX = 0; // Player's initial X position
                int spawnY = 0; // Player's initial Y position on the bottom

                // Get console buffer size
                int consoleWidth = Console.WindowWidth;
                int consoleHeight = Console.WindowHeight - 1; // Reserve bottom row for ground level

                Random random = new Random(); // Random number generator
                List<int> cubeHeights = new List<int>(); // List to store cube heights
                List<int> cubePositions = new List<int>(); // List to store cube positions
                List<int> cubeVerticalDirections = new List<int>(); // List to store vertical movement directions

                // Generate initial random cubes
                GenerateCubes(random, cubeHeights, cubePositions, cubeVerticalDirections, consoleWidth, consoleHeight);

                while (true)
                {
                    // Track movement keys
                    bool moveUp = false;
                    bool moveDown = false;
                    bool moveLeft = false;
                    bool moveRight = false;

                    // Get user input without blocking loop
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo cki = Console.ReadKey(true);
                        if (cki.Key == ConsoleKey.W)
                        {
                            moveUp = true;
                        }
                        else if (cki.Key == ConsoleKey.S)
                        {
                            moveDown = true;
                        }
                        else if (cki.Key == ConsoleKey.A)
                        {
                            moveLeft = true;
                        }
                        else if (cki.Key == ConsoleKey.D)
                        {
                            moveRight = true;
                        }
                    }

                    // Update player position based on key states
                    if (moveUp) spawnY--;
                    if (moveDown) spawnY++;
                    if (moveLeft) spawnX--;
                    if (moveRight) spawnX++;

                    // Ensure player doesn't go out of bounds
                    spawnX = Math.Max(0, Math.Min(spawnX, consoleWidth - 1));
                    spawnY = Math.Max(0, Math.Min(spawnY, consoleHeight));

                    // Update cube positions
                    for (int i = 0; i < cubePositions.Count; i++)
                    {
                        cubePositions[i]--; // Move each cube left

                        // Randomly move cubes up or down
                        if (random.Next(0, 10) < 3) // 30% chance to change direction
                        {
                            cubeVerticalDirections[i] *= -1; // Change direction
                        }

                        // Update cube height based on direction
                        cubeHeights[i] += cubeVerticalDirections[i];

                        // Ensure cube heights stay within bounds
                        if (cubeHeights[i] < 1) cubeHeights[i] = 1; // Minimum height
                        if (cubeHeights[i] > consoleHeight - 1) cubeHeights[i] = consoleHeight - 1; // Maximum height

                        if (cubePositions[i] < 0) // Reset position when it goes off screen
                        {
                            // Remove the cube that went off-screen
                            cubePositions.RemoveAt(i);
                            cubeHeights.RemoveAt(i);
                            cubeVerticalDirections.RemoveAt(i);
                            i--; // Adjust index after removal

                            // Generate new cubes if under the limit and if the current count is below the threshold
                            if (cubePositions.Count < MaxCubes && cubePositions.Count < CubeSpawnThreshold)
                            {
                                GenerateCubes(random, cubeHeights, cubePositions, cubeVerticalDirections, consoleWidth, consoleHeight);
                            }
                        }
                    }

                    // Render character
                    Console.Clear();
                    Console.SetCursorPosition(spawnX, Math.Max(0, Math.Min(spawnY, consoleHeight - 1))); // Ensure spawnY is also within bounds
                    Console.Write("O"); // Player character

                    // Render cubes
                    for (int i = 0; i < cubePositions.Count; i++)
                    {
                        // Ensure cube rendering is within bounds
                        if (consoleHeight - cubeHeights[i] >= 0 && consoleHeight - cubeHeights[i] < consoleHeight)
                        {
                            // Ensure cube positions are within bounds
                            int cubePositionX = Math.Max(0, Math.Min(cubePositions[i], consoleWidth - 1));
                            Console.SetCursorPosition(cubePositionX, consoleHeight - cubeHeights[i]); // Set cursor to cube position
                            Console.Write("[]"); // Cube character
                        }
                    }

                    // Delay for smoother animation
                    Thread.Sleep(1); // Adjust delay for smoother animation
                }
            }
            catch (System.Exception ex) // Catch any exceptions
            {
                Console.Clear();
                Console.WriteLine($"An error occurred: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}"); // Show where the error happened
            }
        }

        // Method to generate cubes
        private static void GenerateCubes(Random random, List<int> cubeHeights, List<int> cubePositions, List<int> cubeVerticalDirections, int consoleWidth, int consoleHeight)
        {
            int numberOfCubes = random.Next(1, 6); // Random number of cubes between 1 and 5
            for (int i = 0; i < numberOfCubes; i++)
            {
                if (cubePositions.Count < MaxCubes) // Check if under the limit
                {
                    cubeHeights.Add(random.Next(1, consoleHeight - 1)); // Random height for each cube
                    cubePositions.Add(consoleWidth - 1 + i * 2); // Position cubes spaced apart
                    cubeVerticalDirections.Add(random.Next(0, 2) == 0 ? 1 : -1); // Randomly assign up (1) or down (-1)
                }
            }
        }
    }
}
