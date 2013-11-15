// Copyright © 2007 by Initial Force AS.  All rights reserved.
// https://github.com/InitialForce/UnitsNet
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

namespace UnitsNet
{
    [AttributeUsage(AttributeTargets.Field)]
    public class LengthAttribute : UnitAttribute
    {
        public LengthAttribute(double ratio, string pluralName = null) : base(pluralName, ratio)
        {
        }
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class MassAttribute : UnitAttribute
    {
        public MassAttribute(double ratio, string pluralName = null) : base(pluralName, ratio)
        {
        }
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class AngleAttribute : UnitAttribute
    {
        public AngleAttribute(double ratio, string pluralName = null) : base(pluralName, ratio)
        {
        }
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class AreaAttribute : UnitAttribute
    {
        public AreaAttribute(double ratio, string pluralName = null) : base(pluralName, ratio)
        {
        }
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class ElectricPotentialAttribute : UnitAttribute
    {
        public ElectricPotentialAttribute(double ratio, string pluralName = null) : base(pluralName, ratio)
        {
        }
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class FlowAttribute : UnitAttribute
    {
        public FlowAttribute(double ratio, string pluralName = null) : base(pluralName, ratio)
        {
        }
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class ForceAttribute : UnitAttribute
    {
        public ForceAttribute(double ratio, string pluralName = null) : base(pluralName, ratio)
        {
        }
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class PressureAttribute : UnitAttribute
    {
        public PressureAttribute(double ratio, string pluralName = null) : base(pluralName, ratio)
        {
        }
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class RotationalSpeedAttribute : UnitAttribute
    {
        public RotationalSpeedAttribute(double ratio, string pluralName = null) : base(pluralName, ratio)
        {
        }
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class TorqueAttribute : UnitAttribute
    {
        public TorqueAttribute(double ratio, string pluralName = null) : base(pluralName, ratio)
        {
        }
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class VolumeAttribute : UnitAttribute
    {
        public VolumeAttribute(double ratio, string pluralName = null) : base(pluralName, ratio)
        {
        }
    } 

    [AttributeUsage(AttributeTargets.Field)]
    public class UnitAttribute : Attribute
    {
        /// <summary>
        /// Ratio of unit to base unit. For example, <see cref="Unit.Kilometer"/> is 1000:1 of the base unit <see cref="Unit.Meter"/>.
        /// </summary>
        public readonly double Ratio;

        /// <summary>
        /// Name of unit in plural form. Will be used as property name such as Force.FromNewtonmeters().
        /// </summary>
        public readonly string PluralName;

        ///// <summary>
        ///// Name of unit in singular form. Will be used as ???.
        ///// </summary>
        //public string SingularName { get; set; }

        public UnitAttribute(string pluralName, double ratio)
        {
            Ratio = ratio;
            PluralName = pluralName;
            //SingularName = null;
        }
    }
}