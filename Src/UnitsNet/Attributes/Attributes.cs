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

namespace UnitsNet.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class AngleAttribute : UnitAttribute
    {
        public Unit BaseUnit { get { return Unit.Degree; } }

        public override string XmlDocSummary { get { return "In geometry, an angle is the figure formed by two rays, called the sides of the angle, sharing a common endpoint, called the vertex of the angle."; } } 
        public AngleAttribute(double slope, string pluralName = (string)null) : base(pluralName, slope, offset: 0)
        {
        }
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class AreaAttribute : UnitAttribute
    {
        public Unit BaseUnit { get { return Unit.SquareMeter; } }
        public override string XmlDocSummary { get { return "Area is a quantity that expresses the extent of a two-dimensional surface or shape, or planar lamina, in the plane. Area can be understood as the amount of material with a given thickness that would be necessary to fashion a model of the shape, or the amount of paint necessary to cover the surface with a single coat.[1] It is the two-dimensional analog of the length of a curve (a one-dimensional concept) or the volume of a solid (a three-dimensional concept)."; } }
        public AreaAttribute(double slope, string pluralName = (string)null) : base(pluralName, slope, offset: 0)
        {
        }
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class ElectricPotentialAttribute : UnitAttribute
    {
        public Unit BaseUnit { get { return Unit.Volt; } }
        public override string XmlDocSummary { get { return "In classical electromagnetism, the electric potential (a scalar quantity denoted by Φ, ΦE or V and also called the electric field potential or the electrostatic potential) at a point is the amount of electric potential energy that a unitary point charge would have when located at that point."; } }
        public ElectricPotentialAttribute(double slope, string pluralName = (string)null) : base(pluralName, slope, offset: 0)
        {
        }
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class FlowAttribute : UnitAttribute
    {
        public Unit BaseUnit { get { return Unit.CubicMeterPerSecond; } }
        public override string XmlDocSummary { get { return "In physics and engineering, in particular fluid dynamics and hydrometry, the volumetric flow rate, (also known as volume flow rate, rate of fluid flow or volume velocity) is the volume of fluid which passes through a given surface per unit time. The SI unit is m3·s−1 (cubic meters per second). In US Customary Units and British Imperial Units, volumetric flow rate is often expressed as ft3/s (cubic feet per second). It is usually represented by the symbol Q."; } }
        public FlowAttribute(double slope, string pluralName = (string)null) : base(pluralName, slope, offset: 0)
        {
        }
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class ForceAttribute : UnitAttribute
    {
        public Unit BaseUnit { get { return Unit.Newton; } }
        public override string XmlDocSummary { get { return "In physics, a force is any influence that causes an object to undergo a certain change, either concerning its movement, direction, or geometrical construction. In other words, a force can cause an object with mass to change its velocity (which includes to begin moving from a state of rest), i.e., to accelerate, or a flexible object to deform, or both. Force can also be described by intuitive concepts such as a push or a pull. A force has both magnitude and direction, making it a vector quantity. It is measured in the SI unit of newtons and represented by the symbol F."; } }
        public ForceAttribute(double slope, string pluralName = (string)null) : base(pluralName, slope, offset: 0)
        {
        }
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class LengthAttribute : UnitAttribute, IUnitAttribute<LengthUnit>
    {
        public LengthUnit BaseUnit { get { return LengthUnit.Meter; } }
        public override string XmlDocSummary { get { return "Many different units of length have been used around the world. The main units in modern use are U.S. customary units in the United States and the Metric system elsewhere. British Imperial units are still used for some purposes in the United Kingdom and some other countries. The metric system is sub-divided into SI and non-SI units."; } }
        public LengthAttribute(double slope, string pluralName = (string)null) : base(pluralName, slope, offset: 0)
        {
        }
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class MassAttribute : UnitAttribute, IUnitAttribute<MassUnit>
    {
        public MassUnit BaseUnit { get { return MassUnit.Kilogram; } }
        public override string XmlDocSummary { get { return "In physics, mass (from Greek μᾶζα \"barley cake, lump [of dough]\") is a property of a physical system or body, giving rise to the phenomena of the body's resistance to being accelerated by a force and the strength of its mutual gravitational attraction with other bodies. Instruments such as mass balances or scales use those phenomena to measure mass. The SI unit of mass is the kilogram (kg)."; } }
        public MassAttribute(double slope, string pluralName = (string)null) : base(pluralName, slope, offset: 0)
        {
        }
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class PressureAttribute : UnitAttribute
    {
        public Unit BaseUnit { get { return Unit.Pascal; } }
        public override string XmlDocSummary { get { return "Pressure (symbol: P or p) is the ratio of force to the area over which that force is distributed. Pressure is force per unit area applied in a direction perpendicular to the surface of an object. Gauge pressure (also spelled gage pressure)[a] is the pressure relative to the local atmospheric or ambient pressure. Pressure is measured in any unit of force divided by any unit of area. The SI unit of pressure is the newton per square metre, which is called the pascal (Pa) after the seventeenth-century philosopher and scientist Blaise Pascal. A pressure of 1 Pa is small; it approximately equals the pressure exerted by a dollar bill resting flat on a table. Everyday pressures are often stated in kilopascals (1 kPa = 1000 Pa)."; } }
        public PressureAttribute(double slope, string pluralName = (string)null) : base(pluralName, slope, offset: 0)
        {
        }
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class RotationalSpeedAttribute : UnitAttribute
    {
        public Unit BaseUnit { get { return Unit.RevolutionPerSecond; } }
        public override string XmlDocSummary { get { return "Rotational speed (sometimes called speed of revolution) is the number of complete rotations, revolutions, cycles, or turns per time unit. Rotational speed is a cyclic frequency, measured in radians per second or in hertz in the SI System by scientists, or in revolutions per minute (rpm or min-1) or revolutions per second in everyday life. The symbol for rotational speed is ω (the Greek lowercase letter \"omega\")."; } }
        public RotationalSpeedAttribute(double slope, string pluralName = (string)null)
            : base(pluralName, slope, offset: 0)
        {
        }
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class SpeedAttribute : UnitAttribute
    {
        public Unit BaseUnit { get { return Unit.MeterPerSecond; } }
        public override string XmlDocSummary { get { return "In everyday use and in kinematics, the speed of an object is the magnitude of its velocity (the rate of change of its position); it is thus a scalar quantity.[1] The average speed of an object in an interval of time is the distance travelled by the object divided by the duration of the interval;[2] the instantaneous speed is the limit of the average speed as the duration of the time interval approaches zero."; } }
        public SpeedAttribute(double slope, string pluralName = (string)null)
            : base(pluralName, slope, offset: 0)
        {
        }
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class TemperatureAttribute : UnitAttribute
    {
        public Unit BaseUnit { get { return Unit.Kelvin; } }
        public override string XmlDocSummary { get { return "A temperature is a numerical measure of hot or cold. Its measurement is by detection of heat radiation or particle velocity or kinetic energy, or by the bulk behavior of a thermometric material. It may be calibrated in any of various temperature scales, Celsius, Fahrenheit, Kelvin, etc. The fundamental physical definition of temperature is provided by thermodynamics."; } }

        /// <summary>
        /// Define a temperature unit by a linear mapping function to the base unit Kelvin.
        /// Example: Celsius is defined as C = K - 273.15. To define this as a function to the base unit,
        /// we invert it and get K = C + 273.15. From the function y = ax + b
        /// we find the slope 'a' as 1 and 'b' as 273.15.
        /// </summary>
        /// <param name="slope">Slope 'a' of function y = ax + b.</param>
        /// <param name="offset">Y-intercept 'b' of function y = ax + b.</param>
        /// <param name="pluralName">Name of unit in plural form. Used in methods and properties of unit class, such as FromMeters() method and Meters property in Length class.</param>
        public TemperatureAttribute(double slope, double offset = 0, string pluralName = (string)null) : base(pluralName, slope, offset)
        {
        }
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class TorqueAttribute : UnitAttribute
    {
        public Unit BaseUnit { get { return Unit.Newtonmeter; } }
        public override string XmlDocSummary { get { return "Torque, moment or moment of force (see the terminology below), is the tendency of a force to rotate an object about an axis,[1] fulcrum, or pivot. Just as a force is a push or a pull, a torque can be thought of as a twist to an object. Mathematically, torque is defined as the cross product of the lever-arm distance and force, which tends to produce rotation. Loosely speaking, torque is a measure of the turning force on an object such as a bolt or a flywheel. For example, pushing or pulling the handle of a wrench connected to a nut or bolt produces a torque (turning force) that loosens or tightens the nut or bolt."; } }
        public TorqueAttribute(double slope, string pluralName = (string)null) : base(pluralName, slope, offset: 0)
        {
        }
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class VolumeAttribute : UnitAttribute
    {
        public Unit BaseUnit { get { return Unit.CubicMeter; } }
        public override string XmlDocSummary { get { return "Volume is the quantity of three-dimensional space enclosed by some closed boundary, for example, the space that a substance (solid, liquid, gas, or plasma) or shape occupies or contains.[1] Volume is often quantified numerically using the SI derived unit, the cubic metre. The volume of a container is generally understood to be the capacity of the container, i. e. the amount of fluid (gas or liquid) that the container could hold, rather than the amount of space the container itself displaces."; } }
        public VolumeAttribute(double slope, string pluralName = (string)null) : base(pluralName, slope, offset: 0)
        {
        }
    }
}