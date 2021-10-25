using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    class Player : Actor
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

        public Player(char icon, float x, float y, float speed, Color color, string name = "Actor") 
            : base(icon, x, y, color, name)
        {
            _speed = speed;
        }

        public override void Update(float deltaTime, Scene currentScene)
        {
            int xDirection = -Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_A))
                + Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_D));
            
            int yDirection = -Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_W))
                + Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_S));

            if (Convert.ToBoolean(Raylib.IsKeyPressed(KeyboardKey.KEY_UP)))
            {
                Bullet bullet = new Bullet('^', Postion.X, Postion.Y, 0, -1, 100, Color.WHITE, "Bullet");
                currentScene.AddActor(bullet);
                CircleCollider bulletCircleCollider = new CircleCollider(5, bullet);
                AABBCollider bulletBoxCollider = new AABBCollider(10, 10, bullet);
                bullet.Collider = bulletBoxCollider;

            }

            if (Convert.ToBoolean(Raylib.IsKeyPressed(KeyboardKey.KEY_DOWN)))
            {
                Bullet bullet = new Bullet('v', Postion.X, Postion.Y, 0, 1, 100, Color.WHITE, "Bullet");
                currentScene.AddActor(bullet);
                CircleCollider bulletCircleCollider = new CircleCollider(5, bullet);
                AABBCollider bulletBoxCollider = new AABBCollider(10, 10, bullet);
                bullet.Collider = bulletBoxCollider;

            }

            if (Convert.ToBoolean(Raylib.IsKeyPressed(KeyboardKey.KEY_LEFT)))
            {
                Bullet bullet = new Bullet('<', Postion.X, Postion.Y, -1, 0, 100, Color.WHITE, "Bullet");
                currentScene.AddActor(bullet);
                CircleCollider bulletCircleCollider = new CircleCollider(5, bullet);
                AABBCollider bulletBoxCollider = new AABBCollider(10, 10, bullet);
                bullet.Collider = bulletBoxCollider;

            }

            if (Convert.ToBoolean(Raylib.IsKeyPressed(KeyboardKey.KEY_RIGHT)))
            {
                Bullet bullet = new Bullet('>', Postion.X, Postion.Y, 1, 0, 100, Color.WHITE, "Bullet");
                currentScene.AddActor(bullet);
                CircleCollider bulletCircleCollider = new CircleCollider(5, bullet);
                AABBCollider bulletBoxCollider = new AABBCollider(10, 10, bullet);
                bullet.Collider = bulletBoxCollider;

            }








            //Create a vector that stores the move input
            Vector2 moveDirection = new Vector2(xDirection, yDirection);

            Velocity = moveDirection.Normalized * Speed * deltaTime;

            Postion += Velocity;

            base.Update(deltaTime, currentScene);
            
        }

        public override void OnCollision(Actor actor, Scene currentScene)
        {
            if (actor is Enemy)
                Engine.CloseApplication();
        }

        public override void Draw()
        {
            base.Draw();
            Collider.Draw();
        }

    }
}
