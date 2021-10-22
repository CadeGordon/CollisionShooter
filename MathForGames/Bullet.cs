using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    class Bullet : Actor

    {
        private Vector2 _velocity;
        private float _speed;

        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        public Vector2 Velocity
        {
            get { return _velocity; }
            set { _velocity = value; }
        }

        public Bullet(char icon, float x, float y, float velocityX, float velocityY, float speed, Color color, string name = "Actor")
            : base(icon, x, y, color, name)
        {
            _speed = speed;
            _velocity.X = velocityX;
            _velocity.Y = velocityY;
        }

        public override void Update(float deltaTime, Scene currentScene)
        {
            

            //Create a vector that stores the move input
            Vector2 moveDirection = new Vector2(_velocity.X, _velocity.Y );

            Velocity = moveDirection.Normalized * Speed * deltaTime;

            Postion += Velocity;

            base.Update(deltaTime, currentScene);

        }

        public override void OnCollision(Actor actor)
        {
            if (actor is Enemy)
                Engine.CloseApplication();
        }
    }
}
