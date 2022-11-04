using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;

namespace HelloWorld
{
    abstract class Collider
    {
        private Actor _owner;

        /// <summary>
        /// The actor that this collider is attached to.
        /// </summary>
        public Actor Owner
        {
            get { return _owner; }
        }

        /// <param name="owner">The actor that this collider will be attached to.</param>
        public Collider(Actor owner)
        {
            _owner = owner;
        }

        /// <summary>
        /// Checks to see if this collider is overlapping another.
        /// </summary>
        /// <param name="other">The actor that the other collider is attached to.</param>
        /// <returns>Whether or not the colliders are overlapping </returns>
        public bool CheckCollision(Actor other)
        {
            return CheckCollisionCircle((CircleCollider)other.CollisionVolume);
        }

        public virtual bool CheckCollisionCircle(CircleCollider collider)
        {
            return false;
        }

        public virtual void Draw() { }

    }
}
