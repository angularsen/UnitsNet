// Copyright © 2007 by Initial Force AS.  All rights reserved.
// https://github.com/InitialForce/SIUnits
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

using System;

// ReSharper disable once CheckNamespace
namespace UnitsNet
{
    /// <summary>
    /// Area is a quantity that expresses the extent of a two-dimensional surface or shape, or planar lamina, in the plane. Area can be understood as the amount of material with a given thickness that would be necessary to fashion a model of the shape, or the amount of paint necessary to cover the surface with a single coat.[1] It is the two-dimensional analog of the length of a curve (a one-dimensional concept) or the volume of a solid (a three-dimensional concept).
    /// </summary>
    public partial struct Area : IComparable, IComparable<Area>
    {
        /// <summary>
        /// Base unit of Area.
        /// </summary>
        public readonly double SquareMeters;

        public Area(double squaremeters) : this()
        {
            SquareMeters = squaremeters;
        }

        #region Unit Properties

        public double SquareCentimeters
        {
            get { return SquareMeters/0.0001; }
        }

        public double SquareDecimeters
        {
            get { return SquareMeters/0.01; }
        }

        public double SquareFeet
        {
            get { return SquareMeters/0.092903; }
        }

        public double SquareInches
        {
            get { return SquareMeters/0.00064516; }
        }

        public double SquareKilometers
        {
            get { return SquareMeters/1000000; }
        }

        public double SquareMiles
        {
            get { return SquareMeters/2590000; }
        }

        public double SquareMillimeters
        {
            get { return SquareMeters/1E-06; }
        }

        public double SquareYards
        {
            get { return SquareMeters/0.836127; }
        }

        #endregion

        #region Static 

        public static Area Zero
        {
            get { return new Area(); }
        }
        
        public static Area FromSquareCentimeters(double squarecentimeters)
        {
            return new Area(squarecentimeters*0.0001);
        }

        public static Area FromSquareDecimeters(double squaredecimeters)
        {
            return new Area(squaredecimeters*0.01);
        }

        public static Area FromSquareFeet(double squarefeet)
        {
            return new Area(squarefeet*0.092903);
        }

        public static Area FromSquareInches(double squareinches)
        {
            return new Area(squareinches*0.00064516);
        }

        public static Area FromSquareKilometers(double squarekilometers)
        {
            return new Area(squarekilometers*1000000);
        }

        public static Area FromSquareMeters(double squaremeters)
        {
            return new Area(squaremeters*1);
        }

        public static Area FromSquareMiles(double squaremiles)
        {
            return new Area(squaremiles*2590000);
        }

        public static Area FromSquareMillimeters(double squaremillimeters)
        {
            return new Area(squaremillimeters*1E-06);
        }

        public static Area FromSquareYards(double squareyards)
        {
            return new Area(squareyards*0.836127);
        }

        #endregion

        #region Arithmetic Operators

        public static Area operator -(Area right)
        {
            return new Area(-right.SquareMeters);
        }

        public static Area operator +(Area left, Area right)
        {
            return new Area(left.SquareMeters + right.SquareMeters);
        }

        public static Area operator -(Area left, Area right)
        {
            return new Area(left.SquareMeters - right.SquareMeters);
        }

        public static Area operator *(double left, Area right)
        {
            return new Area(left*right.SquareMeters);
        }

        public static Area operator *(Area left, double right)
        {
            return new Area(left.SquareMeters*right);
        }

        public static Area operator /(Area left, double right)
        {
            return new Area(left.SquareMeters/right);
        }

        public static double operator /(Area left, Area right)
        {
            return left.SquareMeters/right.SquareMeters;
        }

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is Area)) throw new ArgumentException("Expected type Area.", "obj");
            return CompareTo((Area) obj);
        }

        public int CompareTo(Area other)
        {
            return SquareMeters.CompareTo(other.SquareMeters);
        }

        public static bool operator <=(Area left, Area right)
        {
            return left.SquareMeters <= right.SquareMeters;
        }

        public static bool operator >=(Area left, Area right)
        {
            return left.SquareMeters >= right.SquareMeters;
        }

        public static bool operator <(Area left, Area right)
        {
            return left.SquareMeters < right.SquareMeters;
        }

        public static bool operator >(Area left, Area right)
        {
            return left.SquareMeters > right.SquareMeters;
        }

        public static bool operator ==(Area left, Area right)
        {
            return left.SquareMeters == right.SquareMeters;
        }

        public static bool operator !=(Area left, Area right)
        {
            return left.SquareMeters != right.SquareMeters;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return SquareMeters.Equals(((Area) obj).SquareMeters);
        }

        public override int GetHashCode()
        {
            return SquareMeters.GetHashCode();
        }

        #endregion

        public override string ToString()
        {
            return string.Format("{0:0.##} {1}", SquareMeters, UnitSystem.Create().GetDefaultAbbreviation(Unit.SquareMeter));
        }
    }
} 
