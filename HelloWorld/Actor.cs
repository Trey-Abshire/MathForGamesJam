using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace HelloWorld
{
    internal class Actor
    {
        /// <summary>
        /// Make it to where actors move and scale using the transform matrix 
        /// instead of the variables we have now.
        /// </summary>
        private Matrix3 _transform = new Matrix3();
        private string _name;
        private Collider _collisionVolume;
        private Sprite _graphic;
        private bool _isActive = true;
        
        public Vector2 Position
        {
            get 
            {
                Vector2 position = new Vector2(_transform.M20, _transform.M21);
                return position;  
            }
            set 
            {
                _transform.M20 = value.X;
                _transform.M21 = value.Y;      
            }
        }

        public Sprite Graphic
        {
            get { return _graphic; }
            set { _graphic = value; } 
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public Collider CollisionVolume
        {
            get {return _collisionVolume;}
            set { _collisionVolume = value;}    
        }

        public Vector2 Scale
        {
            get 
            {
                Vector2 scale = new Vector2(_transform.M00, _transform.M01);
                return scale; 
            }
            set 
            {
                    _transform.M10 = value.X;
                    _transform.M11 = value.Y;
            }
        }

        public Matrix3 Transform
        {
            get { return _transform; }
        }

        public void SetScale(Vector2 scale) { }
        
        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }

        public Actor (string name, Sprite sprite)
        {
            _name = name;
            _graphic = sprite;
        }

        public Actor(string name, Sprite sprite, int positionX, int positionY)
        {
            _name = name;
            _graphic = sprite;
            Position = new Vector2(positionX, positionY);
            
        }

        public Actor(string name, Sprite sprite, Vector2 position)
        {
            _name = name;
            _graphic = sprite;
            Position = position;
            
        }

        public Actor(string name, Sprite sprite, Vector2 position, Vector2 scale)
        {
            _name = name;
            _graphic = sprite;
            Position = position;
            //SetScale(new Vector2(,scale, scale));
        }

        public void Translate(float x, float y)
        {
           Position += new Vector2(x, y);
        }

        public void Translate(Vector2 direction)
        {
            //new way with operator overloading
            Position += direction;
        }

        /// <summary>
        /// Checks to see if the collision volume attached to this actor overlapped another.
        /// </summary>
        /// <param name="other">The other actor to check collision against. </param>
        /// <returns> Whether or not these actors are overlapping.</returns>
        public bool CheckCollision(Actor other)
        {
            return _collisionVolume.CheckCollision(other);
        }

        public virtual void OnCollision(Actor other) { }
       
        public virtual void Start() 
        {
            _transform.M00 = 50;
            _transform.M11 = 50;
        }
        
        public virtual void Update(float deltaTime) { }
       
        public virtual void Draw()
        {
            if (_graphic != null)
            {
                _graphic.Draw(_transform); 
            }
        }

        public virtual void End() { }
    }
}