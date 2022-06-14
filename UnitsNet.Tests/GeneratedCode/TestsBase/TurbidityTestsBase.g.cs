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
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using UnitsNet.Tests.TestsBase;
using UnitsNet.Units;
using Xunit;

// Disable build warning CS1718: Comparison made to same variable; did you mean to compare something else?
#pragma warning disable 1718

// ReSharper disable once CheckNamespace
namespace UnitsNet.Tests
{
    /// <summary>
    /// Test of Turbidity.
    /// </summary>
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class TurbidityTestsBase : QuantityTestsBase
    {
        protected abstract double NTUInOneNTU { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double NTUTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        protected (double UnitsInBaseUnit, double Tolerence) GetConversionFactor(TurbidityUnit unit)
        {
            return unit switch
            {
                TurbidityUnit.NTU => (NTUInOneNTU, NTUTolerance),
                _ => throw new NotSupportedException()
            };
        }

        public static IEnumerable<object[]> UnitTypes = new List<object[]>
        {
            new object[] { TurbidityUnit.NTU },
        };

        [Fact]
        public void DefaultCtor_ReturnsQuantityWithZeroValueAndBaseUnit()
        {
            var quantity = new Turbidity();
            Assert.Equal(0, quantity.Value);
            Assert.Equal(TurbidityUnit.NTU, quantity.Unit);
        }

        [Fact]
        public void Ctor_WithInfinityValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Turbidity(double.PositiveInfinity, TurbidityUnit.NTU));
            Assert.Throws<ArgumentException>(() => new Turbidity(double.NegativeInfinity, TurbidityUnit.NTU));
        }

        [Fact]
        public void Ctor_WithNaNValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Turbidity(double.NaN, TurbidityUnit.NTU));
        }

        [Fact]
        public void Ctor_NullAsUnitSystem_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new Turbidity(value: 1, unitSystem: null));
        }

        [Fact]
        public void Ctor_SIUnitSystem_ThrowsArgumentExceptionIfNotSupported()
        {
            Func<object> TestCode = () => new Turbidity(value: 1, unitSystem: UnitSystem.SI);
            if (SupportsSIUnitSystem)
            {
                var quantity = (Turbidity) TestCode();
                Assert.Equal(1, quantity.Value);
            }
            else
            {
                Assert.Throws<ArgumentException>(TestCode);
            }
        }

        [Fact]
        public void Turbidity_QuantityInfo_ReturnsQuantityInfoDescribingQuantity()
        {
            var quantity = new Turbidity(1, TurbidityUnit.NTU);

            QuantityInfo<TurbidityUnit> quantityInfo = quantity.QuantityInfo;

            Assert.Equal(Turbidity.Zero, quantityInfo.Zero);
            Assert.Equal("Turbidity", quantityInfo.Name);

            var units = EnumUtils.GetEnumValues<TurbidityUnit>().ToArray();
            var unitNames = units.Select(x => x.ToString());
        }

        [Fact]
        public void NTUToTurbidityUnits()
        {
            Turbidity ntu = Turbidity.FromNTU(1);
            AssertEx.EqualTolerance(NTUInOneNTU, ntu.NTU, NTUTolerance);
        }

        [Fact]
        public void From_ValueAndUnit_ReturnsQuantityWithSameValueAndUnit()
        {
            var quantity00 = Turbidity.From(1, TurbidityUnit.NTU);
            AssertEx.EqualTolerance(1, quantity00.NTU, NTUTolerance);
            Assert.Equal(TurbidityUnit.NTU, quantity00.Unit);

        }

        [Fact]
        public void FromNTU_WithInfinityValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Turbidity.FromNTU(double.PositiveInfinity));
            Assert.Throws<ArgumentException>(() => Turbidity.FromNTU(double.NegativeInfinity));
        }

        [Fact]
        public void FromNTU_WithNanValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Turbidity.FromNTU(double.NaN));
        }

        [Fact]
        public void As()
        {
            var ntu = Turbidity.FromNTU(1);
            AssertEx.EqualTolerance(NTUInOneNTU, ntu.As(TurbidityUnit.NTU), NTUTolerance);
        }

        [Fact]
        public void As_SIUnitSystem_ThrowsArgumentExceptionIfNotSupported()
        {
            var quantity = new Turbidity(value: 1, unit: Turbidity.BaseUnit);
            Func<object> AsWithSIUnitSystem = () => quantity.As(UnitSystem.SI);

            if (SupportsSIUnitSystem)
            {
                var value = (double) AsWithSIUnitSystem();
                Assert.Equal(1, value);
            }
            else
            {
                Assert.Throws<ArgumentException>(AsWithSIUnitSystem);
            }
        }

        [Fact]
        public void Parse()
        {
            try
            {
                var parsed = Turbidity.Parse("1 NTU", CultureInfo.GetCultureInfo("en-US"));
                AssertEx.EqualTolerance(1, parsed.NTU, NTUTolerance);
                Assert.Equal(TurbidityUnit.NTU, parsed.Unit);
            } catch (AmbiguousUnitParseException) { /* Some units have the same abbreviations */ }

        }

        [Fact]
        public void TryParse()
        {
            {
                Assert.True(Turbidity.TryParse("1 NTU", CultureInfo.GetCultureInfo("en-US"), out var parsed));
                AssertEx.EqualTolerance(1, parsed.NTU, NTUTolerance);
                Assert.Equal(TurbidityUnit.NTU, parsed.Unit);
            }

        }

        [Fact]
        public void ParseUnit()
        {
            try
            {
                var parsedUnit = Turbidity.ParseUnit("NTU", CultureInfo.GetCultureInfo("en-US"));
                Assert.Equal(TurbidityUnit.NTU, parsedUnit);
            } catch (AmbiguousUnitParseException) { /* Some units have the same abbreviations */ }

        }

        [Fact]
        public void TryParseUnit()
        {
            {
                Assert.True(Turbidity.TryParseUnit("NTU", CultureInfo.GetCultureInfo("en-US"), out var parsedUnit));
                Assert.Equal(TurbidityUnit.NTU, parsedUnit);
            }

        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public void ToUnit(TurbidityUnit unit)
        {
            var inBaseUnits = Turbidity.From(1.0, Turbidity.BaseUnit);
            var converted = inBaseUnits.ToUnit(unit);

            var conversionFactor = GetConversionFactor(unit);
            AssertEx.EqualTolerance(conversionFactor.UnitsInBaseUnit, (double)converted.Value, conversionFactor.Tolerence);
            Assert.Equal(unit, converted.Unit);
        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public void ToUnit_WithSameUnits_AreEqual(TurbidityUnit unit)
        {
            var quantity = Turbidity.From(3.0, unit);
            var toUnitWithSameUnit = quantity.ToUnit(unit);
            Assert.Equal(quantity, toUnitWithSameUnit);
        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public void ToUnit_FromNonBaseUnit_ReturnsQuantityWithGivenUnit(TurbidityUnit unit)
        {
            // See if there is a unit available that is not the base unit, fallback to base unit if it has only a single unit.
            var fromUnit = Turbidity.Units.Where(u => u != Turbidity.BaseUnit).DefaultIfEmpty(Turbidity.BaseUnit).First();

            var quantity = Turbidity.From(3.0, fromUnit);
            var converted = quantity.ToUnit(unit);
            Assert.Equal(converted.Unit, unit);
        }

        [Fact]
        public void ConversionRoundTrip()
        {
            Turbidity ntu = Turbidity.FromNTU(1);
            AssertEx.EqualTolerance(1, Turbidity.FromNTU(ntu.NTU).NTU, NTUTolerance);
        }

        [Fact]
        public void ArithmeticOperators()
        {
            Turbidity v = Turbidity.FromNTU(1);
            AssertEx.EqualTolerance(-1, -v.NTU, NTUTolerance);
            AssertEx.EqualTolerance(2, (Turbidity.FromNTU(3)-v).NTU, NTUTolerance);
            AssertEx.EqualTolerance(2, (v + v).NTU, NTUTolerance);
            AssertEx.EqualTolerance(10, (v*10).NTU, NTUTolerance);
            AssertEx.EqualTolerance(10, (10*v).NTU, NTUTolerance);
            AssertEx.EqualTolerance(2, (Turbidity.FromNTU(10)/5).NTU, NTUTolerance);
            AssertEx.EqualTolerance(2, Turbidity.FromNTU(10)/Turbidity.FromNTU(5), NTUTolerance);
        }

        [Fact]
        public void ComparisonOperators()
        {
            Turbidity oneNTU = Turbidity.FromNTU(1);
            Turbidity twoNTU = Turbidity.FromNTU(2);

            Assert.True(oneNTU < twoNTU);
            Assert.True(oneNTU <= twoNTU);
            Assert.True(twoNTU > oneNTU);
            Assert.True(twoNTU >= oneNTU);

            Assert.False(oneNTU > twoNTU);
            Assert.False(oneNTU >= twoNTU);
            Assert.False(twoNTU < oneNTU);
            Assert.False(twoNTU <= oneNTU);
        }

        [Fact]
        public void CompareToIsImplemented()
        {
            Turbidity ntu = Turbidity.FromNTU(1);
            Assert.Equal(0, ntu.CompareTo(ntu));
            Assert.True(ntu.CompareTo(Turbidity.Zero) > 0);
            Assert.True(Turbidity.Zero.CompareTo(ntu) < 0);
        }

        [Fact]
        public void CompareToThrowsOnTypeMismatch()
        {
            Turbidity ntu = Turbidity.FromNTU(1);
            Assert.Throws<ArgumentException>(() => ntu.CompareTo(new object()));
        }

        [Fact]
        public void CompareToThrowsOnNull()
        {
            Turbidity ntu = Turbidity.FromNTU(1);
            Assert.Throws<ArgumentNullException>(() => ntu.CompareTo(null));
        }

        [Theory]
        [InlineData(1, TurbidityUnit.NTU, 1, TurbidityUnit.NTU, true)]  // Same value and unit.
        [InlineData(1, TurbidityUnit.NTU, 2, TurbidityUnit.NTU, false)] // Different value.
        [InlineData(2, TurbidityUnit.NTU, 1, TurbidityUnit.NTU, false)] // Different value and unit.
        public void Equality_MatchesOnValueAndUnit(double valueA, TurbidityUnit unitA, double valueB, TurbidityUnit unitB, bool expectEqual)
        {
            var a = new Turbidity(valueA, unitA);
            var b = new Turbidity(valueB, unitB);

            // Operator overloads.
            Assert.Equal(a == b, expectEqual);
            Assert.Equal(b == a, expectEqual);
            Assert.Equal(a != b, !expectEqual);
            Assert.Equal(b != a, !expectEqual);

            // IEquatable<T>
            Assert.Equal(a.Equals(b), expectEqual);
            Assert.Equal(b.Equals(a), expectEqual);

            // IEquatable
            Assert.Equal(a.Equals((object)b), expectEqual);
            Assert.Equal(b.Equals((object)a), expectEqual);

            // "The result of the expression is always 'false'..."
            #pragma warning disable CS8073
            Assert.False(a == null);
            Assert.False(null == a);
            #pragma warning restore CS8073
        }

        [Fact]
        public void Equals_Object_ReturnsFalseIfNull()
        {
            var a = Turbidity.Zero;
            Assert.False(a.Equals((object)null));
        }

        [Fact]
        public void Equals_RelativeTolerance_IsImplemented()
        {
            var v = Turbidity.FromNTU(1);
            Assert.True(v.Equals(Turbidity.FromNTU(1), NTUTolerance, ComparisonType.Relative));
            Assert.False(v.Equals(Turbidity.Zero, NTUTolerance, ComparisonType.Relative));
        }

        [Fact]
        public void Equals_NegativeRelativeTolerance_ThrowsArgumentOutOfRangeException()
        {
            var v = Turbidity.FromNTU(1);
            Assert.Throws<ArgumentOutOfRangeException>(() => v.Equals(Turbidity.FromNTU(1), -1, ComparisonType.Relative));
        }

        [Fact]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            Turbidity ntu = Turbidity.FromNTU(1);
            Assert.False(ntu.Equals(new object()));
        }

        [Fact]
        public void EqualsReturnsFalseOnNull()
        {
            Turbidity ntu = Turbidity.FromNTU(1);
            Assert.False(ntu.Equals(null));
        }

        [Fact]
        public void HasAtLeastOneAbbreviationSpecified()
        {
            var units = Enum.GetValues(typeof(TurbidityUnit)).Cast<TurbidityUnit>();
            foreach(var unit in units)
            {
                var defaultAbbreviation = UnitAbbreviationsCache.Default.GetDefaultAbbreviation(unit);
            }
        }

        [Fact]
        public void BaseDimensionsShouldNeverBeNull()
        {
            Assert.False(Turbidity.BaseDimensions is null);
        }

        [Fact]
        public void ToString_ReturnsValueAndUnitAbbreviationInCurrentCulture()
        {
            var prevCulture = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            try {
                Assert.Equal("1 NTU", new Turbidity(1, TurbidityUnit.NTU).ToString());
            }
            finally
            {
                Thread.CurrentThread.CurrentCulture = prevCulture;
            }
        }

        [Fact]
        public void ToString_WithSwedishCulture_ReturnsUnitAbbreviationForEnglishCultureSinceThereAreNoMappings()
        {
            // Chose this culture, because we don't currently have any abbreviations mapped for that culture and we expect the en-US to be used as fallback.
            var swedishCulture = CultureInfo.GetCultureInfo("sv-SE");

            Assert.Equal("1 NTU", new Turbidity(1, TurbidityUnit.NTU).ToString(swedishCulture));
        }

        [Fact]
        public void ToString_SFormat_FormatsNumberWithGivenDigitsAfterRadixForCurrentCulture()
        {
            var oldCulture = CultureInfo.CurrentCulture;
            try
            {
                CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
                Assert.Equal("0.1 NTU", new Turbidity(0.123456, TurbidityUnit.NTU).ToString("s1"));
                Assert.Equal("0.12 NTU", new Turbidity(0.123456, TurbidityUnit.NTU).ToString("s2"));
                Assert.Equal("0.123 NTU", new Turbidity(0.123456, TurbidityUnit.NTU).ToString("s3"));
                Assert.Equal("0.1235 NTU", new Turbidity(0.123456, TurbidityUnit.NTU).ToString("s4"));
            }
            finally
            {
                CultureInfo.CurrentCulture = oldCulture;
            }
        }

        [Fact]
        public void ToString_SFormatAndCulture_FormatsNumberWithGivenDigitsAfterRadixForGivenCulture()
        {
            var culture = CultureInfo.InvariantCulture;
            Assert.Equal("0.1 NTU", new Turbidity(0.123456, TurbidityUnit.NTU).ToString("s1", culture));
            Assert.Equal("0.12 NTU", new Turbidity(0.123456, TurbidityUnit.NTU).ToString("s2", culture));
            Assert.Equal("0.123 NTU", new Turbidity(0.123456, TurbidityUnit.NTU).ToString("s3", culture));
            Assert.Equal("0.1235 NTU", new Turbidity(0.123456, TurbidityUnit.NTU).ToString("s4", culture));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("en-US")]
        public void ToString_NullFormat_DefaultsToGeneralFormat(string cultureName)
        {
            var quantity = Turbidity.FromNTU(1.0);
            CultureInfo formatProvider = cultureName == null
                ? null
                : CultureInfo.GetCultureInfo(cultureName);

            Assert.Equal(quantity.ToString("g", formatProvider), quantity.ToString(null, formatProvider));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("g")]
        public void ToString_NullProvider_EqualsCurrentCulture(string format)
        {
            var quantity = Turbidity.FromNTU(1.0);
            Assert.Equal(quantity.ToString(format, CultureInfo.CurrentCulture), quantity.ToString(format, null));
        }

        [Fact]
        public void Convert_ToBool_ThrowsInvalidCastException()
        {
            var quantity = Turbidity.FromNTU(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ToBoolean(quantity));
        }

        [Fact]
        public void Convert_ToByte_EqualsValueAsSameType()
        {
            var quantity = Turbidity.FromNTU(1.0);
           Assert.Equal((byte)quantity.Value, Convert.ToByte(quantity));
        }

        [Fact]
        public void Convert_ToChar_ThrowsInvalidCastException()
        {
            var quantity = Turbidity.FromNTU(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ToChar(quantity));
        }

        [Fact]
        public void Convert_ToDateTime_ThrowsInvalidCastException()
        {
            var quantity = Turbidity.FromNTU(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ToDateTime(quantity));
        }

        [Fact]
        public void Convert_ToDecimal_EqualsValueAsSameType()
        {
            var quantity = Turbidity.FromNTU(1.0);
            Assert.Equal((decimal)quantity.Value, Convert.ToDecimal(quantity));
        }

        [Fact]
        public void Convert_ToDouble_EqualsValueAsSameType()
        {
            var quantity = Turbidity.FromNTU(1.0);
            Assert.Equal((double)quantity.Value, Convert.ToDouble(quantity));
        }

        [Fact]
        public void Convert_ToInt16_EqualsValueAsSameType()
        {
            var quantity = Turbidity.FromNTU(1.0);
            Assert.Equal((short)quantity.Value, Convert.ToInt16(quantity));
        }

        [Fact]
        public void Convert_ToInt32_EqualsValueAsSameType()
        {
            var quantity = Turbidity.FromNTU(1.0);
            Assert.Equal((int)quantity.Value, Convert.ToInt32(quantity));
        }

        [Fact]
        public void Convert_ToInt64_EqualsValueAsSameType()
        {
            var quantity = Turbidity.FromNTU(1.0);
            Assert.Equal((long)quantity.Value, Convert.ToInt64(quantity));
        }

        [Fact]
        public void Convert_ToSByte_EqualsValueAsSameType()
        {
            var quantity = Turbidity.FromNTU(1.0);
            Assert.Equal((sbyte)quantity.Value, Convert.ToSByte(quantity));
        }

        [Fact]
        public void Convert_ToSingle_EqualsValueAsSameType()
        {
            var quantity = Turbidity.FromNTU(1.0);
            Assert.Equal((float)quantity.Value, Convert.ToSingle(quantity));
        }

        [Fact]
        public void Convert_ToString_EqualsToString()
        {
            var quantity = Turbidity.FromNTU(1.0);
            Assert.Equal(quantity.ToString(), Convert.ToString(quantity));
        }

        [Fact]
        public void Convert_ToUInt16_EqualsValueAsSameType()
        {
            var quantity = Turbidity.FromNTU(1.0);
            Assert.Equal((ushort)quantity.Value, Convert.ToUInt16(quantity));
        }

        [Fact]
        public void Convert_ToUInt32_EqualsValueAsSameType()
        {
            var quantity = Turbidity.FromNTU(1.0);
            Assert.Equal((uint)quantity.Value, Convert.ToUInt32(quantity));
        }

        [Fact]
        public void Convert_ToUInt64_EqualsValueAsSameType()
        {
            var quantity = Turbidity.FromNTU(1.0);
            Assert.Equal((ulong)quantity.Value, Convert.ToUInt64(quantity));
        }

        [Fact]
        public void Convert_ChangeType_SelfType_EqualsSelf()
        {
            var quantity = Turbidity.FromNTU(1.0);
            Assert.Equal(quantity, Convert.ChangeType(quantity, typeof(Turbidity)));
        }

        [Fact]
        public void Convert_ChangeType_UnitType_EqualsUnit()
        {
            var quantity = Turbidity.FromNTU(1.0);
            Assert.Equal(quantity.Unit, Convert.ChangeType(quantity, typeof(TurbidityUnit)));
        }

        [Fact]
        public void Convert_ChangeType_QuantityInfo_EqualsQuantityInfo()
        {
            var quantity = Turbidity.FromNTU(1.0);
            Assert.Equal(Turbidity.Info, Convert.ChangeType(quantity, typeof(QuantityInfo)));
        }

        [Fact]
        public void Convert_ChangeType_BaseDimensions_EqualsBaseDimensions()
        {
            var quantity = Turbidity.FromNTU(1.0);
            Assert.Equal(Turbidity.BaseDimensions, Convert.ChangeType(quantity, typeof(BaseDimensions)));
        }

        [Fact]
        public void Convert_ChangeType_InvalidType_ThrowsInvalidCastException()
        {
            var quantity = Turbidity.FromNTU(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ChangeType(quantity, typeof(QuantityFormatter)));
        }

        [Fact]
        public void GetHashCode_Equals()
        {
            var quantity = Turbidity.FromNTU(1.0);
            Assert.Equal(new {Turbidity.Info.Name, quantity.Value, quantity.Unit}.GetHashCode(), quantity.GetHashCode());
        }

        [Theory]
        [InlineData(1.0)]
        [InlineData(-1.0)]
        public void NegationOperator_ReturnsQuantity_WithNegatedValue(double value)
        {
            var quantity = Turbidity.FromNTU(value);
            Assert.Equal(Turbidity.FromNTU(-value), -quantity);
        }
    }
}
