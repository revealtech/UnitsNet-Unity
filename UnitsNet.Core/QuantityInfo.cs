// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitsNet
{
    /// <summary>
    ///     Function to create a quantity with the given value and unit.
    /// </summary>
    public delegate IQuantity CreateQuantityDelegate(QuantityValue value, Enum unit);

    /// <summary>
    ///     Information about the quantity, such as names, unit values and zero quantity.
    ///     This is useful to enumerate units and present names with quantities and units
    ///     chose dynamically at runtime, such as unit conversion apps or allowing the user to change the
    ///     unit representation.
    /// </summary>
    /// <remarks>
    ///     Typically you obtain this by looking it up via <see cref="IQuantity.QuantityInfo" />.
    /// </remarks>
    public class QuantityInfo
    {
        private readonly Action<UnitConverter> _configureUnitConversions;
        private readonly Action<UnitAbbreviationsCache> _configureUnitAbbreviations;

        /// <summary>
        ///     Function to create a quantity with the given value and unit.
        /// </summary>
        private CreateQuantityDelegate FromValueUnitDelegate { get; }

        /// <summary>
        ///     Constructs an instance.
        /// </summary>
        /// <param name="name">Name of the quantity.</param>
        /// <param name="quantityType">The quantity struct type, such as Length.</param>
        /// <param name="unitType">The unit enum type, such as LengthUnit.</param>
        /// <param name="unitInfos">The information about the units for this quantity.</param>
        /// <param name="baseUnit">The base unit enum value.</param>
        /// <param name="zero">The zero quantity.</param>
        /// <param name="baseDimensions">The base dimensions of the quantity.</param>
        /// <param name="fromValueUnitDelegate">Function to create a quantity with the given value and unit.</param>
        /// <param name="configureUnitConversions">Configure unit conversions with <see cref="UnitConverter.SetConversionFunction{TQuantity}"/>.</param>
        /// <param name="configureUnitAbbreviations">Configure unit abbreviation localization with <see cref="UnitAbbreviationsCache.PerformAbbreviationMapping"/>.</param>
        /// <exception cref="ArgumentException">Quantity type can not be undefined.</exception>
        /// <exception cref="ArgumentNullException">If units -or- baseUnit -or- zero -or- baseDimensions is null.</exception>
        public QuantityInfo(string name,
            Type quantityType,
            Type unitType,
            UnitInfo[] unitInfos,
            Enum baseUnit,
            IQuantity zero,
            BaseDimensions baseDimensions,
            CreateQuantityDelegate fromValueUnitDelegate,
            Action<UnitConverter> configureUnitConversions,
            Action<UnitAbbreviationsCache> configureUnitAbbreviations)
        {
            if (baseUnit == null) throw new ArgumentNullException(nameof(baseUnit));

            BaseDimensions = baseDimensions ?? throw new ArgumentNullException(nameof(baseDimensions));
            Zero = zero ?? throw new ArgumentNullException(nameof(zero));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            QuantityType = quantityType ?? throw new ArgumentNullException(nameof(quantityType));
            UnitType = unitType ?? throw new ArgumentNullException(nameof(unitType));
            UnitInfos = unitInfos ?? throw new ArgumentNullException(nameof(unitInfos));

            BaseUnitInfo = UnitInfos.First(unitInfo => unitInfo.Value.Equals(baseUnit));
            ValueType = zero.GetType();
            FromValueUnitDelegate = fromValueUnitDelegate ?? throw new ArgumentNullException(nameof(fromValueUnitDelegate));
            _configureUnitConversions = configureUnitConversions ?? throw new ArgumentNullException(nameof(configureUnitConversions));
            _configureUnitAbbreviations = configureUnitAbbreviations ?? throw new ArgumentNullException(nameof(configureUnitAbbreviations));
        }

        /// <summary>
        ///     Quantity name, such as "Length" or "Mass".
        /// </summary>
        public string Name { get; }

        /// <summary>
        ///     The units for this quantity.
        /// </summary>
        public UnitInfo[] UnitInfos { get; }

        /// <summary>
        ///     The base unit of this quantity.
        /// </summary>
        public UnitInfo BaseUnitInfo { get; }

        /// <summary>
        ///     Zero value of quantity, such as Length.Zero.
        /// </summary>
        public IQuantity Zero { get; }

        /// <summary>
        ///     The quantity struct type, such as Length.
        /// </summary>
        public Type QuantityType { get; set; }

        /// <summary>
        ///     Unit enum type, such as LengthUnit or MassUnit.
        /// </summary>
        public Type UnitType { get; }

        /// <summary>
        ///     Quantity value type, such as Length or Mass.
        /// </summary>
        public Type ValueType { get; }

        /// <summary>
        ///     The <see cref="BaseDimensions" /> for a quantity.
        /// </summary>
        public BaseDimensions BaseDimensions { get; }

        /// <summary>
        /// Create a quantity with the given value and unit.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="unit">The unit.</param>
        /// <returns>The quantity.</returns>
        public IQuantity CreateQuantity(QuantityValue value, Enum unit)
        {
            return FromValueUnitDelegate(value, unit);
        }

        /// <summary>
        /// Configure unit conversion functions for this quantity.
        /// </summary>
        /// <param name="unitConverter">The unit converter to assign new conversion functions.</param>
        public void ConfigureUnitConversions(UnitConverter unitConverter)
        {
            _configureUnitConversions(unitConverter);
        }

        /// <summary>
        /// Configure unit abbreviation localization for this quantity.
        /// </summary>
        /// <param name="cache">The unit abbreviation cache to update.</param>
        public void ConfigureUnitAbbreviations(UnitAbbreviationsCache cache)
        {
            _configureUnitAbbreviations(cache);
        }
    }

    /// <inheritdoc cref="QuantityInfo" />
    /// <remarks>
    ///     This is a specialization of <see cref="QuantityInfo" />, for when the unit type is known.
    ///     Typically you obtain this by looking it up statically from Length.Info or
    ///     Length.QuantityInfo, or dynamically via <see cref="IQuantity{TUnitType}.QuantityInfo" />.
    /// </remarks>
    /// <typeparam name="TUnit">The unit enum type, such as LengthUnit. </typeparam>
    public class QuantityInfo<TUnit> : QuantityInfo
        where TUnit : Enum
    {
        /// <inheritdoc />
        public QuantityInfo(string name,
            Type quantityType,
            UnitInfo<TUnit>[] unitInfos,
            TUnit baseUnit,
            IQuantity<TUnit> zero,
            BaseDimensions baseDimensions,
            CreateQuantityDelegate fromValueUnitDelegate,
            Action<UnitConverter> configureUnitConversions,
            Action<UnitAbbreviationsCache> configureUnitAbbreviations)
            : base(name,
                quantityType,
                typeof(TUnit),
                unitInfos.ToArray<UnitInfo>(),
                baseUnit,
                zero,
                baseDimensions,
                fromValueUnitDelegate,
                configureUnitConversions,
                configureUnitAbbreviations)
        {
            Zero = zero;
            UnitInfos = unitInfos ?? throw new ArgumentNullException(nameof(unitInfos));
            BaseUnitInfo = UnitInfos.First(unitInfo => unitInfo.Value.Equals(baseUnit));
            UnitType = baseUnit;
        }

        /// <inheritdoc cref="QuantityInfo.UnitInfos" />
        public new UnitInfo<TUnit>[] UnitInfos { get; }

        /// <inheritdoc cref="QuantityInfo.BaseUnitInfo" />
        public new UnitInfo<TUnit> BaseUnitInfo { get; }

        /// <inheritdoc cref="QuantityInfo.Zero" />
        public new IQuantity<TUnit> Zero { get; }

        /// <inheritdoc cref="QuantityInfo.UnitType" />
        public new TUnit UnitType { get; }

        /// <inheritdoc cref="QuantityInfo.GetUnitInfoFor" />
        public new UnitInfo<TUnit> GetUnitInfoFor(BaseUnits baseUnits)
        {
            return (UnitInfo<TUnit>)base.GetUnitInfoFor(baseUnits);
        }

        /// <inheritdoc cref="QuantityInfo.GetUnitInfosFor" />
        public new IEnumerable<UnitInfo<TUnit>> GetUnitInfosFor(BaseUnits baseUnits)
        {
            return base.GetUnitInfosFor(baseUnits).Cast<UnitInfo<TUnit>>();
        }
    }
}
