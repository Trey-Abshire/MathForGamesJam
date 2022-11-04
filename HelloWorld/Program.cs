using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a new instance of a Game
            Engine game = new Engine();
            //Run the Game
            game.Run();
            //Wait before closing
            Console.ReadKey();

           
        }
    }
}
