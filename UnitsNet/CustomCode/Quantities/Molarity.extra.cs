using System;
using UnitsNet.Units;

namespace UnitsNet
{
    public partial struct Molarity<T>
    {
        /// <summary>
        ///     Construct from <see cref="Density{T}"/> divided by <see cref="Mass{T}"/>.
        /// </summary>
        /// <seealso cref="MassConcentration{T}.op_Division(MassConcentration{T}, MolarMass{T})"/>
        [Obsolete("This constructor will be removed in favor of operator overload MassConcentration.op_Division(MassConcentration,MolarMass).")]
        public Molarity(Density<T> density, Mass<T> molecularWeight )
            : this()
        {
            _value = density.KilogramsPerCubicMeter / molecularWeight.Kilograms;
            _unit = MolarityUnit.MolesPerCubicMeter;
        }

        /// <summary>
        ///     Get a <see cref="Density{T}"/> from this <see cref="Molarity{T}"/>.
        /// </summary>
        /// <param name="molecularWeight"></param>
        /// <seealso cref="ToMassConcentration(MolarMass{T})"/>
        [Obsolete("This method will be removed in favor of ToMassConcentration(MolarMass)")]
        public Density<T> ToDensity(Mass<T> molecularWeight )
        {
            return Density<T>.FromKilogramsPerCubicMeter(MolesPerCubicMeter * molecularWeight.Kilograms);
        }

        /// <summary>
        ///     Get a <see cref="MassConcentration{T}"/> from this <see cref="Molarity{T}"/>.
        /// </summary>
        /// <param name="molecularWeight"></param>
        public MassConcentration<T> ToMassConcentration(MolarMass<T> molecularWeight ) 
        {
            return this * molecularWeight; 
        }

        /// <summary>
        ///     Get a <see cref="MassConcentration{T}"/> from this <see cref="Molarity{T}"/>.
        /// </summary>
        /// <param name="componentDensity"></param>
        /// <param name="componentMass"></param>
        public VolumeConcentration<T> ToVolumeConcentration(Density<T> componentDensity, MolarMass<T> componentMass )
        {
            return this * componentMass / componentDensity;
        }

        #region Static Methods

        /// <summary>
        ///     Get <see cref="Molarity{T}"/> from <see cref="Density{T}"/>.
        /// </summary>
        /// <param name="density"></param>
        /// <param name="molecularWeight"></param>
        [Obsolete("Use MassConcentration / MolarMass operator overload instead.")]
        public static Molarity<T> FromDensity(Density<T> density, Mass<T> molecularWeight )
        {
            return density / molecularWeight;
        }

        /// <summary>
        ///  Get <see cref="Molarity{T}"/> from <see cref="VolumeConcentration{T}"/> and known component <see cref="Density{T}"/> and <see cref="MolarMass{T}"/>.
        /// </summary>
        /// <param name="volumeConcentration"></param>
        /// <param name="componentDensity"></param>
        /// <param name="componentMass"></param>
        /// <returns></returns>
        public static Molarity<T> FromVolumeConcentration(VolumeConcentration<T> volumeConcentration, Density<T> componentDensity, MolarMass<T> componentMass )
        {
            return volumeConcentration * componentDensity / componentMass;
        }

        #endregion

        #region Operators

        /// <summary>Get <see cref="MassConcentration{T}" /> from <see cref="Molarity{T}" /> times the <see cref="MolarMass{T}" />.</summary>
        public static MassConcentration<T> operator *(Molarity<T> molarity, MolarMass<T> componentMass )
        {
            return MassConcentration<T>.FromGramsPerCubicMeter(molarity.MolesPerCubicMeter * componentMass.GramsPerMole);
        }

        /// <summary>Get <see cref="MassConcentration{T}" /> from <see cref="MolarMass{T}" /> times the <see cref="Molarity{T}" />.</summary>
        public static MassConcentration<T> operator *(MolarMass<T> componentMass, Molarity<T> molarity )
        {
            return MassConcentration<T>.FromGramsPerCubicMeter(molarity.MolesPerCubicMeter * componentMass.GramsPerMole);
        }

        /// <summary>Get <see cref="Molarity{T}" /> from diluting the current <see cref="Molarity{T}" /> by the given <see cref="VolumeConcentration{T}" />.</summary>
        public static Molarity<T> operator *(Molarity<T> molarity, VolumeConcentration<T> volumeConcentration )
        {
            return new Molarity<T>( molarity.MolesPerCubicMeter * volumeConcentration.DecimalFractions, MolarityUnit.MolesPerCubicMeter);
        }

        /// <summary>Get <see cref="Molarity{T}" /> from diluting the current <see cref="Molarity{T}" /> by the given <see cref="VolumeConcentration{T}" />.</summary>
        public static Molarity<T> operator *(VolumeConcentration<T> volumeConcentration, Molarity<T> molarity )
        {
            return new Molarity<T>( molarity.MolesPerCubicMeter * volumeConcentration.DecimalFractions, MolarityUnit.MolesPerCubicMeter);
        }

        #endregion

    }
}
