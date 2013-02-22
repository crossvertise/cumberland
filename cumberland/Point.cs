// Point.cs
//
// Copyright (c) 2008 Scott Ellington and Authors
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//
//

using System;

namespace Cumberland
{
    public class Point : Feature, IEquatable<Point>
    {
        private double x, y;
        
#region properties
		
		public double X	{

			get
			{
				return x;
			}
			set
			{
				x = value;
			}
		}
		
		
		public double Y	{

			get
			{
				return y;
			}
			set
			{
				y = value;
			}
		}
				
#endregion
		
#region ctors
		
		public Point() : this(0,0)  {}
		
        public Point(double tx, double ty)
        {
            X = tx;
            Y = ty;
        }

#endregion
		
#region operator overrides
		
		public static bool operator == (Point p1, Point p2)
		{
			if (object.ReferenceEquals(p1, null))
			{
				return object.ReferenceEquals(p2, null);
			}
			
			return !object.ReferenceEquals(p2, null) && p1.X == p2.X && p1.Y == p2.Y;
		}
		   
		public static bool operator != (Point p1, Point p2)
		{
			return !(p1 == p2);
		}

#endregion
		
#region overrides
		
		public override int GetHashCode()
		{
			return X.GetHashCode() ^ Y.GetHashCode();
		}


		public override bool Equals(object obj)
		{
			Point p = obj as Point;
			
			return this == p;

		}

		public override string ToString ()
		{
			return string.Format("{{x:{0} y:{1}}}", x, y);
		}
		
		public override Rectangle CalculateBounds ()
		{
			return new Rectangle(X, Y, X, Y);
		}

		
#endregion

#region Methods
		
		/// <summary>
		/// Creates a deep copy
		/// </summary>
		/// <returns>
		/// A <see cref="Point"/>
		/// </returns>
		public virtual Point Clone()
		{
			return new Point(x, y);
		}

		public virtual bool Equals(Point p)
		{
			return this == p;
		}
		
#endregion
		
		public double Distance(Point p)
		{
			return Math.Sqrt(Math.Pow(this.X-p.X, 2) +
			                 Math.Pow(this.Y-p.Y, 2));
		}
		
		public double Distance(Point p1, Point p2)
		{
			double d = p1.Distance(p2);
			
			if (d == 0) return this.Distance(p2);
			
			return Math.Abs((p2.X-p1.X) * (p1.Y-this.Y) - (p1.X-this.X) * (p2.Y-p1.Y)) / d;
		}		
    }
}
