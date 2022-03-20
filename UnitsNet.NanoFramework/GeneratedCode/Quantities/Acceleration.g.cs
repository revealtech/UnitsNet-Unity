//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by \generate-code.bat.
//
//     Changes to this file will be lost when the code is regenerated.
//     The build server regenerates the code before each build and a pre-build
//     step will regenerate the code on each local build.
//
//     See https://github.com/angularsen/UnitsNet/wiki/Adding-a-New-Unit for how to add or edit units.
//
//     Add CustomCode\Quantities\MyQuantity.extra.cs files to add code to generated quantities.
//     Add UnitDefinitions\MyQuantity.json and run generate-code.bat to generate new units or quantities.
//
// </auto-generated>
//------------------------------------------------------------------------------

// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using UnitsNet.Units;

namespace UnitsNet
{
    /// <inheritdoc />
    /// <summary>
    ///     Acceleration, in physics, is the rate at which the velocity of an object changes over time. An object's acceleration is the net result of any and all forces acting on the object, as described by Newton's Second Law. The SI unit for acceleration is the Meter per second squared (m/s²). Accelerations are vector quantities (they have magnitude and direction) and add according to the parallelogram law. As a vector, the calculated net force is equal to the product of the object's mass (a scalar quantity) and the acceleration.
    /// </summary>
    public struct  Acceleration
    {
        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        private readonly double _value;

        /// <summary>
        ///     The unit this quantity was constructed with.
        /// </summary>
        private readonly AccelerationUnit _unit;

        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        public double Value => _value;

        /// <inheritdoc />
        public AccelerationUnit Unit => _unit;

        /// <summary>
        ///     Creates the quantity with the given numeric value and unit.
        /// </summary>
        /// <param name="value">The numeric value to construct this quantity with.</param>
        /// <param name="unit">The unit representation to construct this quantity with.</param>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public Acceleration(double value, AccelerationUnit unit)
        {
            _value = value;
            _unit = unit;
        }

        /// <summary>
        ///     The base unit of Duration, which is Second. All conversions go via this value.
        /// </summary>
        public static AccelerationUnit BaseUnit { get; } = AccelerationUnit.MeterPerSecondSquared;

        /// <summary>
        /// Represents the largest possible value of Duration
        /// </summary>
        public static Acceleration MaxValue { get; } = new Acceleration(double.MaxValue, BaseUnit);

        /// <summary>
        /// Represents the smallest possible value of Duration
        /// </summary>
        public static Acceleration MinValue { get; } = new Acceleration(double.MinValue, BaseUnit);

        /// <summary>
        ///     Gets an instance of this quantity with a value of 0 in the base unit Second.
        /// </summary>
        public static Acceleration Zero { get; } = new Acceleration(0, BaseUnit);
        #region Conversion Properties

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="AccelerationUnit.CentimeterPerSecondSquared"/>
        /// </summary>
        public double CentimetersPerSecondSquared => As(AccelerationUnit.CentimeterPerSecondSquared);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="AccelerationUnit.DecimeterPerSecondSquared"/>
        /// </summary>
        public double DecimetersPerSecondSquared => As(AccelerationUnit.DecimeterPerSecondSquared);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="AccelerationUnit.FootPerSecondSquared"/>
        /// </summary>
        public double FeetPerSecondSquared => As(AccelerationUnit.FootPerSecondSquared);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="AccelerationUnit.InchPerSecondSquared"/>
        /// </summary>
        public double InchesPerSecondSquared => As(AccelerationUnit.InchPerSecondSquared);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="AccelerationUnit.KilometerPerSecondSquared"/>
        /// </summary>
        public double KilometersPerSecondSquared => As(AccelerationUnit.KilometerPerSecondSquared);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="AccelerationUnit.KnotPerHour"/>
        /// </summary>
        public double KnotsPerHour => As(AccelerationUnit.KnotPerHour);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="AccelerationUnit.KnotPerMinute"/>
        /// </summary>
        public double KnotsPerMinute => As(AccelerationUnit.KnotPerMinute);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="AccelerationUnit.KnotPerSecond"/>
        /// </summary>
        public double KnotsPerSecond => As(AccelerationUnit.KnotPerSecond);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="AccelerationUnit.MeterPerSecondSquared"/>
        /// </summary>
        public double MetersPerSecondSquared => As(AccelerationUnit.MeterPerSecondSquared);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="AccelerationUnit.MicrometerPerSecondSquared"/>
        /// </summary>
        public double MicrometersPerSecondSquared => As(AccelerationUnit.MicrometerPerSecondSquared);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="AccelerationUnit.MillimeterPerSecondSquared"/>
        /// </summary>
        public double MillimetersPerSecondSquared => As(AccelerationUnit.MillimeterPerSecondSquared);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="AccelerationUnit.MillistandardGravity"/>
        /// </summary>
        public double MillistandardGravity => As(AccelerationUnit.MillistandardGravity);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="AccelerationUnit.NanometerPerSecondSquared"/>
        /// </summary>
        public double NanometersPerSecondSquared => As(AccelerationUnit.NanometerPerSecondSquared);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="AccelerationUnit.StandardGravity"/>
        /// </summary>
        public double StandardGravity => As(AccelerationUnit.StandardGravity);

        #endregion

        #region Static Factory Methods

        /// <summary>
        ///     Creates a <see cref="Acceleration"/> from <see cref="AccelerationUnit.CentimeterPerSecondSquared"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Acceleration FromCentimetersPerSecondSquared(double centimeterspersecondsquared) => new Acceleration(centimeterspersecondsquared, AccelerationUnit.CentimeterPerSecondSquared);

        /// <summary>
        ///     Creates a <see cref="Acceleration"/> from <see cref="AccelerationUnit.DecimeterPerSecondSquared"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Acceleration FromDecimetersPerSecondSquared(double decimeterspersecondsquared) => new Acceleration(decimeterspersecondsquared, AccelerationUnit.DecimeterPerSecondSquared);

        /// <summary>
        ///     Creates a <see cref="Acceleration"/> from <see cref="AccelerationUnit.FootPerSecondSquared"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Acceleration FromFeetPerSecondSquared(double feetpersecondsquared) => new Acceleration(feetpersecondsquared, AccelerationUnit.FootPerSecondSquared);

        /// <summary>
        ///     Creates a <see cref="Acceleration"/> from <see cref="AccelerationUnit.InchPerSecondSquared"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Acceleration FromInchesPerSecondSquared(double inchespersecondsquared) => new Acceleration(inchespersecondsquared, AccelerationUnit.InchPerSecondSquared);

        /// <summary>
        ///     Creates a <see cref="Acceleration"/> from <see cref="AccelerationUnit.KilometerPerSecondSquared"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Acceleration FromKilometersPerSecondSquared(double kilometerspersecondsquared) => new Acceleration(kilometerspersecondsquared, AccelerationUnit.KilometerPerSecondSquared);

        /// <summary>
        ///     Creates a <see cref="Acceleration"/> from <see cref="AccelerationUnit.KnotPerHour"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Acceleration FromKnotsPerHour(double knotsperhour) => new Acceleration(knotsperhour, AccelerationUnit.KnotPerHour);

        /// <summary>
        ///     Creates a <see cref="Acceleration"/> from <see cref="AccelerationUnit.KnotPerMinute"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Acceleration FromKnotsPerMinute(double knotsperminute) => new Acceleration(knotsperminute, AccelerationUnit.KnotPerMinute);

        /// <summary>
        ///     Creates a <see cref="Acceleration"/> from <see cref="AccelerationUnit.KnotPerSecond"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Acceleration FromKnotsPerSecond(double knotspersecond) => new Acceleration(knotspersecond, AccelerationUnit.KnotPerSecond);

        /// <summary>
        ///     Creates a <see cref="Acceleration"/> from <see cref="AccelerationUnit.MeterPerSecondSquared"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Acceleration FromMetersPerSecondSquared(double meterspersecondsquared) => new Acceleration(meterspersecondsquared, AccelerationUnit.MeterPerSecondSquared);

        /// <summary>
        ///     Creates a <see cref="Acceleration"/> from <see cref="AccelerationUnit.MicrometerPerSecondSquared"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Acceleration FromMicrometersPerSecondSquared(double micrometerspersecondsquared) => new Acceleration(micrometerspersecondsquared, AccelerationUnit.MicrometerPerSecondSquared);

        /// <summary>
        ///     Creates a <see cref="Acceleration"/> from <see cref="AccelerationUnit.MillimeterPerSecondSquared"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Acceleration FromMillimetersPerSecondSquared(double millimeterspersecondsquared) => new Acceleration(millimeterspersecondsquared, AccelerationUnit.MillimeterPerSecondSquared);

        /// <summary>
        ///     Creates a <see cref="Acceleration"/> from <see cref="AccelerationUnit.MillistandardGravity"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Acceleration FromMillistandardGravity(double millistandardgravity) => new Acceleration(millistandardgravity, AccelerationUnit.MillistandardGravity);

        /// <summary>
        ///     Creates a <see cref="Acceleration"/> from <see cref="AccelerationUnit.NanometerPerSecondSquared"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Acceleration FromNanometersPerSecondSquared(double nanometerspersecondsquared) => new Acceleration(nanometerspersecondsquared, AccelerationUnit.NanometerPerSecondSquared);

        /// <summary>
        ///     Creates a <see cref="Acceleration"/> from <see cref="AccelerationUnit.StandardGravity"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Acceleration FromStandardGravity(double standardgravity) => new Acceleration(standardgravity, AccelerationUnit.StandardGravity);

        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="AccelerationUnit" /> to <see cref="Acceleration" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Acceleration unit value.</returns>
        public static Acceleration From(double value, AccelerationUnit fromUnit)
        {
            return new Acceleration(value, fromUnit);
        }

        #endregion

                #region Conversion Methods

                /// <summary>
                ///     Convert to the unit representation <paramref name="unit" />.
                /// </summary>
                /// <returns>Value converted to the specified unit.</returns>
                public double As(AccelerationUnit unit) => GetValueAs(unit);

                /// <summary>
                ///     Converts this Duration to another Duration with the unit representation <paramref name="unit" />.
                /// </summary>
                /// <returns>A Duration with the specified unit.</returns>
                public Acceleration ToUnit(AccelerationUnit unit)
                {
                    var convertedValue = GetValueAs(unit);
                    return new Acceleration(convertedValue, unit);
                }

                /// <summary>
                ///     Converts the current value + unit to the base unit.
                ///     This is typically the first step in converting from one unit to another.
                /// </summary>
                /// <returns>The value in the base unit representation.</returns>
                private double GetValueInBaseUnit()
                {
                    return Unit switch
                    {
                        AccelerationUnit.CentimeterPerSecondSquared => (_value) * 1e-2d,
                        AccelerationUnit.DecimeterPerSecondSquared => (_value) * 1e-1d,
                        AccelerationUnit.FootPerSecondSquared => _value * 0.304800,
                        AccelerationUnit.InchPerSecondSquared => _value * 0.0254,
                        AccelerationUnit.KilometerPerSecondSquared => (_value) * 1e3d,
                        AccelerationUnit.KnotPerHour => _value * 0.5144444444444 / 3600,
                        AccelerationUnit.KnotPerMinute => _value * 0.5144444444444 / 60,
                        AccelerationUnit.KnotPerSecond => _value * 0.5144444444444,
                        AccelerationUnit.MeterPerSecondSquared => _value,
                        AccelerationUnit.MicrometerPerSecondSquared => (_value) * 1e-6d,
                        AccelerationUnit.MillimeterPerSecondSquared => (_value) * 1e-3d,
                        AccelerationUnit.MillistandardGravity => (_value * 9.80665) * 1e-3d,
                        AccelerationUnit.NanometerPerSecondSquared => (_value) * 1e-9d,
                        AccelerationUnit.StandardGravity => _value * 9.80665,
                        _ => throw new NotImplementedException($"Can not convert {Unit} to base units.")
                    };
                    }

                private double GetValueAs(AccelerationUnit unit)
                {
                    if (Unit == unit)
                        return _value;

                    var baseUnitValue = GetValueInBaseUnit();

                    return unit switch
                    {
                        AccelerationUnit.CentimeterPerSecondSquared => (baseUnitValue) / 1e-2d,
                        AccelerationUnit.DecimeterPerSecondSquared => (baseUnitValue) / 1e-1d,
                        AccelerationUnit.FootPerSecondSquared => baseUnitValue / 0.304800,
                        AccelerationUnit.InchPerSecondSquared => baseUnitValue / 0.0254,
                        AccelerationUnit.KilometerPerSecondSquared => (baseUnitValue) / 1e3d,
                        AccelerationUnit.KnotPerHour => baseUnitValue / 0.5144444444444 * 3600,
                        AccelerationUnit.KnotPerMinute => baseUnitValue / 0.5144444444444 * 60,
                        AccelerationUnit.KnotPerSecond => baseUnitValue / 0.5144444444444,
                        AccelerationUnit.MeterPerSecondSquared => baseUnitValue,
                        AccelerationUnit.MicrometerPerSecondSquared => (baseUnitValue) / 1e-6d,
                        AccelerationUnit.MillimeterPerSecondSquared => (baseUnitValue) / 1e-3d,
                        AccelerationUnit.MillistandardGravity => (baseUnitValue / 9.80665) / 1e-3d,
                        AccelerationUnit.NanometerPerSecondSquared => (baseUnitValue) / 1e-9d,
                        AccelerationUnit.StandardGravity => baseUnitValue / 9.80665,
                        _ => throw new NotImplementedException($"Can not convert {Unit} to {unit}.")
                    };
                    }

                #endregion
    }
}

