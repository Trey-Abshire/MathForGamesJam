using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;
using Raylib_cs;

namespace HelloWorld
{
    internal class Player : Actor
    {
        private float _speed = 75;
        private Color _defaultColor;
        private Enemy _target;
        
        public Enemy Target
        {
            get { return _target; }
            set { _target = value; }
        }

        public Player(string name, Sprite sprite, int positionX, int positionY) : 
            base(name, sprite, positionX, positionY)
        { 
            _defaultColor = Graphic.SpriteColor;
            CollisionVolume = new CircleCollider(this, 100);
        }

        private bool CheckIfPlayerCollision()
        {
            Vector2 direction = (Position - Target.Position).Normalized;
            float dot = Vector2.GetDotProduct(Target.Facing, direction);

            float distance = Vector2.GetDistance(Position, Target.Position);

            return dot <= 0.9f && distance <= 75;
        }

        public override void OnCollision(Actor other)
        {
            base.OnCollision(other);
        }

        public override void Update(float deltaTime)
        {
            //If a player collides or is in range with an enemy...
            if (CheckIfPlayerCollision())
            {
                //...change their icon colors to a color that isn't their default color.
                Graphic.SpriteColor = Color.RED;
                Graphic.EnemyColor = Color.BLUE;
            }
            //otherwise... 
            else
            { 
                //...set their icon colors to their default state.
                Graphic.SpriteColor = _defaultColor; 
                Graphic.EnemyColor = Color.SKYBLUE;
            }
            
            Vector2 direction = Input.GetMoveInput();

            Vector2 velocity = direction * _speed * deltaTime;

            Console.WriteLine(velocity.Magnitude);

            Translate(velocity);
        }

        public override void Draw()
        {
            base.Draw();
            CollisionVolume.Draw();
        }
    }
}
