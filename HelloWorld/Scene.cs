using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;

namespace HelloWorld
{
    internal class Scene
    {
        private Actor[] _actors;

        /// <summary>
        /// Initializes map and sets all characters to be empty spaces.
        /// </summary>
        public Scene()
        {
            _actors = new Actor[2];
        }

        public void Start()
        {
            Sprite playerGraphic = new Sprite("Images/player.png");
            Sprite enemyGraphic = new Sprite("Images/enemy.png");

            Player player;
            Enemy enemy;

            player = new Player("Trey", playerGraphic, 0, 1);
            enemy = new Enemy("Blue", enemyGraphic, 300, 300, player);

            player.Target = enemy;
            
            _actors[0] = player;
            _actors[1] = enemy;

            //Calls start for each actor in the scene.
            for (int i = 0; i < _actors.Length; i++)
            {
                _actors[i].Start();
            }
        }

        public void Update(float deltaTime)
        {
            //Calls update for each actor in the scene.
            for (int i = 0; i < _actors.Length; i++)
            {
                if (!_actors[i].IsActive)
                {
                    continue;
                }

                 _actors[i].Update(deltaTime);

                //Skips collision check if there isn't a collider attached to this actor.
                if (_actors[i].CollisionVolume == null)
                    continue;

                //Check to see if this actor collided with any other actor.
                for (int j = 0; j < _actors.Length; j++)
                {
                    //Skips collision check if there isn't a collider attached to this actor.
                    if (_actors[i].CollisionVolume == null)
                    {
                        continue;
                    }

                    if (_actors[i].CheckCollision(_actors[j]))
                    {
                        _actors[i].OnCollision(_actors[j]);
                    }
                }
            }    
        }

        public void Draw()
        {
            for (int i = 0; i < _actors.Length; i++)
            {
                if(!_actors[i].IsActive)
                {
                    continue;
                }

                _actors[i].Draw();
            }   
        }

        public void End()
        {
            //Calls end for each actor in the scene.
            for (int i = 0; i < _actors.Length; i++)
            {
                _actors[i].End();
            }
        }
    }
}
