using System;

namespace BK1_07._07 {
    public class Vector2D {
        float x;
        float y;
        public Vector2D (float x, float y) {
            this.x = x;
            this.y = y;
        }

        public override string ToString () {
            return "Vector2D(x: " + this.x + ", y: " + this.y + ")";
        }

        //=====================//
        // All Static Method
        //====================//
        public static Vector2D Add (Vector2D a, Vector2D b) {
            float x = a.X + b.X;
            float y = a.Y + b.Y;
            return new Vector2D (x, y);
        }

        public static Vector2D Div (Vector2D a, Vector2D b) {
            float x = a.X / b.X;
            float y = a.Y / b.Y;
            return new Vector2D (x, y);
        }

        public static float Distance (Vector2D a, Vector2D b) {
            double pow2X = Math.Pow (b.X - a.X, 2);
            double pow2Y = Math.Pow (b.Y - a.Y, 2);
            return (float) Math.Sqrt (pow2X + pow2Y);
        }

        public static void Swap (Vector2D a, Vector2D b) {
            a.X = a.X + b.X;
            b.X = a.X - b.X;
            a.X = a.X - b.X;

            a.Y = a.Y + b.Y;
            b.Y = a.Y - b.Y;
            a.Y = a.Y - b.Y;
        }

        public static Vector2D Clone (Vector2D a) {
            return new Vector2D (a.X, b.Y);
        }

        //========================//
        // End All Static Method
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