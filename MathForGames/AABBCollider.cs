﻿using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    class AABBCollider : Collider
    {
        private float _width;
        private float _height;

        /// <summary>
        /// The size of this collider on the x axis
        /// </summary>
        public float Width
        {
            get { return _width; }
            set { _width = value; }
        }

        /// <summary>
        /// the size of this collider on the y axis
        /// </summary>
        public float Height
        {
            get { return _height; }
            set { _height = value; }
        }

        /// <summary>
        /// the farthest on the left x posiotion of this collider
        /// </summary>
        public float Left
        {
            get
            {
                return Owner.Postion.X - Width / 2;
            }
        }

        /// <summary>
        /// the farthest on the right x position of this colldier
        /// </summary>
        public float Right
        {
            get
            {
                return Owner.Postion.X + Width / 2;
            }
        }

        /// <summary>
        /// the farthest y position upwards
        /// </summary>
        public float Top
        {
            get
            {
                return Owner.Postion.Y - Height / 2;
            }
        }

        /// <summary>
        /// the farthest y posistion downwards
        /// </summary>
        public float Bottom
        {
            get
            {
                return Owner.Postion.Y + Height / 2;
            }
        }

        public AABBCollider(float width, float height, Actor owner) : base(owner, ColliderType.AABB)
        {
            _width = width;
            _height = height;
        }

        public override bool CheckCollisionAABB(AABBCollider other)
        {
            //Return false if this owner is checking for a collision againts itself
            if (other.Owner == Owner)
                return false;

            //Return true if there is an overlap between boxes
            if(other.Left <= Right &&
               other.Top <= Bottom &&
               Left <= other.Right &&
               Top <= other.Bottom)
            {
                return true;
            }

            //Return false if there is no overlap
            return false;
        }

        public override bool CheckCollisionCircle(CircleCollider other)
        {
            return other.CheckCollisionAABB(this);
        }

        public override void Draw()
        {
            Raylib.DrawRectangleLines((int)Left, (int)Top, (int)Width, (int)Height, Color.RED);
        }
    }
}
