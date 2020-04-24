using System;
using UnitsNet.Units;

namespace UnitsNet
{
    public partial struct Molarity
    {
        /// <summary>
        ///     Construct from <see cref="Density"/> divided by <see cref="Mass"/>.
        /// </summary>
        /// <seealso cref="MassConcentration.op_Division(MassConcentration,MolarMass)"/>
        [Obsolete("This constructor will be removed in favor of operator overload MassConcentration.op_Division(MassConcentration,MolarMass).")]
        public Molarity(Density density, Mass molecularWeight)
            : this()
        {
            _value = density.KilogramsPerCubicMeter / molecularWeight.Kilograms;
            _unit = MolarityUnit.MolesPerCubicMeter;
        }

        /// <summary>
        ///     Get a <see cref="Density"/> from this <see cref="Molarity"/>.
        /// </summary>
        /// <param name="molecularWeight"></param>
        /// <seealso cref="ToMassConcentration(MolarMass)"/>
        [Obsolete("This method will be removed in favor of ToMassConcentration(MolarMass)")]
        public Density ToDensity(Mass molecularWeight)
        {
            return Density.FromKilogramsPerCubicMeter(MolesPerCubicMeter * molecularWeight.Kilograms);
        }

        /// <summary>
        ///     Get a <see cref="MassConcentration"/> from this <see cref="Molarity"/>.
        /// </summary>
        /// <param name="molecularWeight"></param>
        public MassConcentration ToMassConcentration(MolarMass molecularWeight) 
        {
            return this * molecularWeight; 
        }

        /// <summary>
        ///     Get a <see cref="MassConcentration"/> from this <see cref="Molarity"/>.
        /// </summary>
        /// <param name="componentDensity"></param>
        /// <param name="componentMass"></param>
        public VolumeConcentration ToVolumeConcentration(Density componentDensity, MolarMass componentMass)
        {
            return this * componentMass / componentDensity;
        }

        #region Static Methods

        /// <summary>
        ///     Get <see cref="Molarity"/> from <see cref="Density"/>.
        /// </summary>
        /// <param name="density"></param>
        /// <param name="molecularWeight"></param>
        [Obsolete("Use MassConcentration / MolarMass operator overload instead.")]
        public static Molarity FromDensity(Density density, Mass molecularWeight)
        {
            return density / molecularWeight;
        }

        /// <summary>
        ///  Get <see cref="Molarity"/> from <see cref="VolumeConcentration"/> and known component <see cref="Density"/> and <see cref="MolarMass"/>.
        /// </summary>
        /// <param name="volumeConcentration"></param>
        /// <param name="componentDensity"></param>
        /// <param name="componentMass"></param>
        /// <returns></returns>
        public static Molarity FromVolumeConcentration(VolumeConcentration volumeConcentration, Density componentDensity, MolarMass componentMass)
        {
            return volumeConcentration * componentDensity / componentMass;
        }

        #endregion

        #region Operators

        /// <summary>Get <see cref="MassConcentration" /> from <see cref="Molarity" /> times the <see cref="MolarMass" />.</summary>
        public static MassConcentration operator *(Molarity molarity, MolarMass componentMass)
        {
            return MassConcentration.FromGramsPerCubicMeter(molarity.MolesPerCubicMeter * componentMass.GramsPerMole);
        }

        /// <summary>Get <see cref="MassConcentration" /> from <see cref="MolarMass" /> times the <see cref="Molarity" />.</summary>
        public static MassConcentration operator *(MolarMass componentMass, Molarity molarity)
        {
            return MassConcentration.FromGramsPerCubicMeter(molarity.MolesPerCubicMeter * componentMass.GramsPerMole);
        }

        /// <summary>Get <see cref="Molarity" /> from diluting the current <see cref="Molarity" /> by the given <see cref="VolumeConcentration" />.</summary>
        public static Molarity operator *(Molarity molarity, VolumeConcentration volumeConcentration)
        {
            return new Molarity(molarity.MolesPerCubicMeter * volumeConcentration.DecimalFractions, MolarityUnit.MolesPerCubicMeter);
        }

        /// <summary>Get <see cref="Molarity" /> from diluting the current <see cref="Molarity" /> by the given <see cref="VolumeConcentration" />.</summary>
        public static Molarity operator *(VolumeConcentration volumeConcentration, Molarity molarity)
        {
            return new Molarity(molarity.MolesPerCubicMeter * volumeConcentration.DecimalFractions, MolarityUnit.MolesPerCubicMeter);
        }

        #endregion

    }
}
