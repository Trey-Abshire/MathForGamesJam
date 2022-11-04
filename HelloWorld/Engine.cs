using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using System.Diagnostics;

namespace HelloWorld
{
    class Engine
    {
        private const int SCREEN_WIDTH = 800;
        private const int SCREEN_HEIGHT = 450;
        private Scene _testScene;
        private Stopwatch _stopwatch;

        /// <summary>
        /// Called to begin the application
        /// </summary>
        public void Run()
        {
            Start();

            //Start a new stopwatch to keep track of the time that's passed.
            _stopwatch = new Stopwatch();
            _stopwatch.Start();

            //Initialize default variables for calculating delta time.
            float currentTime = 0;
            float lastTime = 0;
            float deltaTime = 0;

            //Loop until the application is told to close.
            while (!Raylib.WindowShouldClose())
            {
                //Store the current time that has passed since the game started in seconds.
                currentTime = _stopwatch.ElapsedMilliseconds / 1000.0f;

                //Subtract last time from current time to find delta time.
                deltaTime = currentTime - lastTime;

                //Update the current scene.
                Update(deltaTime);
                //Draw the current scene.
                Draw();
                
                //Store the current time for the next delta time calculation.
                lastTime = currentTime;
            }

            End();
        }

        //Performed once when the game begins
        private void Start()
        {
            Raylib.InitWindow(SCREEN_WIDTH, SCREEN_HEIGHT, "MathForGames");
            Raylib.SetTargetFPS(0);

            _testScene = new Scene();
            _testScene.Start();
        }

        //Repeated until the game ends
        private void Update(float deltaTime)
        {
            _testScene.Update(deltaTime);   
        }

        //Updates visuals every game loop
        private void Draw()
        {
            Raylib.BeginDrawing();

            Raylib.ClearBackground(Color.BLACK);

            _testScene.Draw(); 

            Raylib.EndDrawing();
        }

        //Performed once when the game ends
        private void End()
        {
            _testScene.End();
            Raylib.CloseWindow();
        }    
    }
}
