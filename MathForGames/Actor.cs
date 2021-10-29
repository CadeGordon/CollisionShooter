using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    
    class Actor
    {
        private string _name;
        private bool _started;
        private Vector2 _forward = new Vector2(1,0);
        private Collider _collider;
        private Matrix3 _transform = Matrix3.Identity;
        private Matrix3 _translation = Matrix3.Identity;
        private Matrix3 _rotation = Matrix3.Identity;
        private Matrix3 _scale = Matrix3.Identity;
        private Sprite _sprite;

        /// <summary>
        /// True if the start function has been called for this actor
        /// </summary>
        public bool Started
        {
            get { return _started; }
        }

        public Vector2 Postion
        {
            get { return new Vector2(_transform.M02, _transform.M12); }
            set 
            {
                _transform.M02 = value.X;
                _transform.M12 = value.Y;
            }
        }

        

        public Actor( float x, float y, string name = "Actor", string path = "" ) :
            this( new Vector2 { X = x, Y = y }, name, path)
        { }
        
        
        
        


        public Actor( Vector2 position, string name = "Actor" , string path = "")

        {
            Postion = position;
            _name = name;

            if (path != "")
                _sprite = new Sprite(path);
        }

        public Vector2 Forward
        {
            get { return _forward; }
            set { _forward = value; }
        }

        public Sprite Sprite
        {
            get { return _sprite; }
            set { _sprite = value; }
        }

        public Collider Collider
        {
            get { return _collider; }
            set { _collider = value; }
        }

        public virtual void Start()
        {
            _started = true;
        }

        public virtual void Update(float deltaTime, Scene currentScene)
        {
            _transform = _translation * _rotation * _scale;
            Console.WriteLine(_name + ": " + Postion.X + ", " + Postion.Y);

        }

        public virtual void Draw()
        {
            if (_sprite != null)
                _sprite.Draw(_transform);
        }

        public void End()
        {

        }

        public virtual void OnCollision(Actor actor, Scene currentScene)
        {

        }

        /// <summary>
        /// Check if this actor collided with another actor
        /// </summary>
        /// <param name="other">Thea ctor to check for a collision</param>
        /// <returns>True if the distance bewteen  the actors is less than the radii of the two combined</returns>
        public virtual bool CheckForCollision(Actor other)
        {
            //Retunr false if either actor doesnt have a collider attached
            if (Collider == null || other.Collider == null)
                return false;

            return Collider.CheckCollision(other);
        }

        /// <summary>
        /// Sets the position of the actor
        /// </summary>
        /// <param name="translationX">the new x position</param>
        /// <param name="translationY">The new y position</param>
        public void SetTranslation(float translationX, float translationY)
        {
            _translation = Matrix3.CreateTranslation(translationX, translationY);
        }

        /// <summary>
        /// Changes the position of the actor by the given values
        /// </summary>
        /// <param name="translationX">the amount to move on x</param>
        /// <param name="translationY">the amount to move on y</param>
        public void Translate(float translationX, float translationY)
        {
            _translation = Matrix3.CreateTranslation(translationX, translationY);
        }

        /// <summary>
        /// Set the rotation of the actor
        /// </summary>
        /// <param name="radians">the angle of the new rotation in radians</param>
        public void SetRotation(float radians)
        {
            _rotation = Matrix3.CreateRotation(radians);
        }

        /// <summary>
        /// Adds a rotation to the current transformation rotations
        /// </summary>
        /// <param name="radians">the angle in radians to tunr</param>
        public void Rotate(float radians)
        {
            _rotation = Matrix3.CreateRotation(radians);
        }

        /// <summary>
        /// Sets the scale of the actor
        /// </summary>
        /// <param name="x">The value to scale on the x axis</param>
        /// <param name="y">The value to scale on the x axis</param>
        public void SetScale(float x, float y)
        {
            _transform.M00 = x;
            _transform.M11 = y;
        }

        /// <summary>
        /// Scales the actor by the given amount
        /// </summary>
        /// <param name="x">The value to scale on the x axis</param>
        /// <param name="y">The value to scale on the y axis</param>
        public void Scale(float x, float y)
        {
            _scale = Matrix3.CreateScale(x, y);
        }
    }
}
