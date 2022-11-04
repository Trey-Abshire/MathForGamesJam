using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;
using Raylib_cs;

namespace HelloWorld
{
    internal class Enemy : Actor
    {
        private float _speed = 60;
        private Actor _target;
        private Vector2 _facing;
        private Color _defaultColor;

        public Vector2 Facing
        {
            get { return _facing; }
        }

        public Color DefaultColor
        {
            get { return _defaultColor; }
            set { _defaultColor = value; }
        }

        public Enemy(string name, Sprite sprite, int positionX, int positionY, Actor target) :
            base(name, sprite, positionX, positionY)
        {
            _defaultColor = Graphic.EnemyColor;
            _target = target;
            _facing = new Vector2(1, 0);
        }
        /// <summary>
        /// Gets the direction the enemy's target is in.
        /// </summary>
        /// <returns>A normalized vector that represents the targets direction</returns>
        public Vector2 GetDirectionToTarget()
        {
            Vector2 direction = (_target.Position - Position).Normalized;
            return direction;
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);

            //To Do: Make the enemy chase it's target.
            Vector2 direction = GetDirectionToTarget();
            Vector2 velocity = direction * _speed * deltaTime;

            Translate(velocity);
        }
    }
}
