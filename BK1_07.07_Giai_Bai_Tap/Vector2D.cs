using System;

namespace BK1_07._07 {
    public class Vector2D {
        float x;
        float y;
        public Vector2D (float x, float y) {
            this.x = x;
            this.y = y;
        }

        //=====================//
        // All Method
        //====================//
        public void Add (Vector2D other) {
            this.x += other.X;
            this.y += other.Y;
        }

        public void Div (Vector2D other) {
            this.x /= other.X;
            this.y /= other.Y;
        }

        public float Distance (Vector2D other) {
            double pow2X = Math.Pow (other.X - this.x, 2);
            double pow2Y = Math.Pow (other.Y - this.y, 2);
            return (float) Math.Sqrt (pow2X + pow2Y);
        }

        public void Swap (Vector2D other) {
            float tempX = this.x;
            float tempY = this.y;

            this.x = other.X;
            this.y = other.Y;

            other.X = tempX;
            other.Y = tempY;
        }

        public Vector2D Clone () {
            return new Vector2D (this.x, this.y);
        }

        public string ConvertToString () {
            return "Vector2D(x: " + this.x + ", y: " + this.y + ")";
        }

        //========================//
        // End All Method
        //========================//

        //========================//
        // Getter or Setter Mothod
        //========================//
        public float X {
            get {
                return this.x;
            }
            set {
                this.x = value;
            }
        }

        public float Y {
            get {
                return this.y;
            }
            set {
                this.y = value;
            }
        }

        //========================//
        // End Getter or Setter Mothod
        //========================//

        //==========================//
        // implement the Operator Overloading for Vector2D
        //==========================//        
        public static Vector2D operator + (Vector2D a, Vector2D b) {
            Vector2D vector = new Vector2D (0, 0);
            vector.X = a.X + b.X;
            vector.Y = a.Y + b.Y;
            return vector;
        }

        public static Vector2D operator - (Vector2D a, Vector2D b) {
            Vector2D vector = new Vector2D (0, 0);
            vector.X = a.X - b.X;
            vector.Y = a.Y - b.Y;
            return vector;
        }

        public static Vector2D operator * (Vector2D a, Vector2D b) {
            Vector2D vector = new Vector2D (0, 0);
            vector.X = a.X * b.X;
            vector.Y = a.Y * b.Y;
            return vector;
        }

        public static Vector2D operator / (Vector2D a, Vector2D b) {
            Vector2D vector = new Vector2D (0, 0);
            vector.X = a.X / b.X;
            vector.Y = a.Y / b.Y;
            return vector;
        }
        //==========================//
        // End the Operator Overloading
        //==========================//
    }

}