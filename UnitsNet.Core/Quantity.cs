using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace UnitsNet
{
    /// <summary>
    ///     Dynamically parse or construct quantities when types are only known at runtime.
    /// </summary>
    public static class Quantity
    {
        private static readonly Lazy<Dictionary<(Type, string), UnitInfo>> UnitTypeAndNameToUnitInfoLazy;
        private static Lazy<ConcurrentDictionary<string, QuantityInfo>> _byName = new(GetQuantityNameToInfo);
        private static QuantityInfo[] _infos = Array.Empty<QuantityInfo>();

        static Quantity()
        {
            Names = Infos.Select(qt => qt.Name).ToArray();

            UnitTypeAndNameToUnitInfoLazy = new Lazy<Dictionary<(Type, string), UnitInfo>>(() =>
            {
                return Infos
                    .SelectMany(quantityInfo => quantityInfo.UnitInfos
                        .Select(unitInfo => new KeyValuePair<(Type, string), UnitInfo>(
                            (unitInfo.Value.GetType(), unitInfo.Name),
                            unitInfo)))
                    .ToDictionary(x => x.Key, x => x.Value);
            });
        }

        /// <summary>
        /// All QuantityInfo instances mapped by quantity name that are present in UnitsNet by default.
        /// </summary>
        public static ConcurrentDictionary<string, QuantityInfo> ByName => _byName.Value;

        /// <summary>
        /// All enum value names of <see cref="Infos"/>, such as "Length" and "Mass".
        /// </summary>
        public static string[] Names { get; }

        /// <summary>
        /// All quantity information objects, such as Length.Info and Mass.Info.
        /// </summary>
        public static QuantityInfo[] Infos
        {
            get => _infos;
            set
            {
                _infos = value;
                ResetLazy();
            }
        }

        private static void ResetLazy()
        {
            _byName = new Lazy<ConcurrentDictionary<string, QuantityInfo>>(GetQuantityNameToInfo);
        }

        /// <summary>
        /// Get <see cref="UnitInfo"/> for a given unit enum value.
        /// </summary>
        public static UnitInfo GetUnitInfo(Enum unitEnum) => UnitTypeAndNameToUnitInfoLazy.Value[(unitEnum.GetType(), unitEnum.ToString())];

        /// <summary>
        /// Try to get <see cref="UnitInfo"/> for a given unit enum value.
        /// </summary>
        public static bool TryGetUnitInfo(Enum unitEnum, out UnitInfo unitInfo) =>
            UnitTypeAndNameToUnitInfoLazy.Value.TryGetValue((unitEnum.GetType(), unitEnum.ToString()), out unitInfo);

        /// <summary>
        ///     Dynamically construct a quantity.
        /// </summary>
        /// <param name="value">Numeric value.</param>
        /// <param name="unit">Unit enum value.</param>
        /// <returns>An <see cref="IQuantity"/> object.</returns>
        /// <exception cref="ArgumentException">Unit value is not a know unit enum type.</exception>
        public static IQuantity From(QuantityValue value, Enum unit)
        {
            if (TryFrom(value, unit, out IQuantity? quantity))
                return quantity!;

            throw new ArgumentException(
                $"Unit value {unit} of type {unit.GetType()} is not a known unit enum type. Expected types like UnitsNet.Units.LengthUnit. Did you pass in a third-party enum type defined outside UnitsNet library?");
        }

        /// <inheritdoc cref="TryFrom(QuantityValue,System.Enum,out UnitsNet.IQuantity)"/>
        public static bool TryFrom(double value, Enum unit, out IQuantity? quantity)
        {
            // Implicit cast to QuantityValue would prevent TryFrom from being called,
            // so we need to explicitly check this here for double arguments.
            if (double.IsNaN(value) || double.IsInfinity(value))
            {
                quantity = default(IQuantity);
                return false;
            }

            return TryFrom((QuantityValue)value, unit, out quantity);
        }

        /// <summary>
        ///     Try to dynamically construct a quantity.
        /// </summary>
        /// <param name="value">Numeric value.</param>
        /// <param name="unit">Unit enum value.</param>
        /// <param name="quantity">The resulting quantity if successful, otherwise <c>default</c>.</param>
        /// <returns><c>True</c> if successful with <paramref name="quantity"/> assigned the value, otherwise <c>false</c>.</returns>
        public static bool TryFrom(QuantityValue value, Enum unit, out IQuantity? quantity)
        {
            var quantityInfo = Infos.FirstOrDefault(qi => qi.UnitType.Equals(unit.GetType()));
            if (quantityInfo != null)
            {
                quantity = quantityInfo.From(value, unit);
                return true;
            }

            quantity = default;
            return false;
        }

        /// <inheritdoc cref="Parse(IFormatProvider, System.Type,string)"/>
        public static IQuantity Parse(Type quantityType, string quantityString) => Parse(null, quantityType, quantityString);

        /// <summary>
        ///     Dynamically parse a quantity string representation.
        /// </summary>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
        /// <param name="quantityType">Type of quantity, such as Length.</param>
        /// <param name="quantityString">Quantity string representation, such as "1.5 kg". Must be compatible with given quantity type.</param>
        /// <returns>The parsed quantity.</returns>
        /// <exception cref="ArgumentException">Type must be of type UnitsNet.IQuantity -or- Type is not a known quantity type.</exception>
        public static IQuantity Parse(IFormatProvider? formatProvider, Type quantityType, string quantityString)
        {
            if (!typeof(IQuantity).IsAssignableFrom(quantityType))
                throw new ArgumentException($"Type {quantityType} must be of type UnitsNet.IQuantity.");

            if (TryParse(formatProvider, quantityType, quantityString, out IQuantity? quantity))
                return quantity!;

            throw new ArgumentException($"Quantity string could not be parsed to quantity {quantityType}.");
        }

        /// <inheritdoc cref="TryParse(IFormatProvider,System.Type,string,out UnitsNet.IQuantity)"/>
        public static bool TryParse(Type quantityType, string quantityString, out IQuantity? quantity) =>
            TryParse(null, quantityType, quantityString, out quantity);

        /// <summary>
        ///     Try to dynamically parse a quantity string representation.
        /// </summary>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
        /// <param name="quantityType">Type of quantity, such as Length.</param>
        /// <param name="quantityString">Quantity string representation, such as "1.5 kg". Must be compatible with given quantity type.</param>
        /// <param name="quantity">The resulting quantity if successful, otherwise <c>default</c>.</param>
        /// <returns>The parsed quantity.</returns>
        public static bool TryParse(IFormatProvider? formatProvider, Type quantityType, string quantityString, out IQuantity? quantity)
        {
            quantity = default;

            QuantityInfo quantityInfo = Infos.SingleOrDefault(i => i.QuantityType == quantityType) ??
                                        throw new InvalidOperationException($"No QuantityInfo found for type '{quantityType}'.");

            return QuantityParser.Default.TryParse(quantityString, quantityInfo.UnitType, formatProvider, quantityInfo.FromValueUnitDelegate, out quantity);
        }

        /// <summary>
        ///     Get a list of quantities that has the given base dimensions.
        /// </summary>
        /// <param name="baseDimensions">The base dimensions to match.</param>
        public static IEnumerable<QuantityInfo> GetQuantitiesWithBaseDimensions(BaseDimensions baseDimensions)
        {
            return Infos.Where(info => info.BaseDimensions.Equals(baseDimensions));
        }

        private static ConcurrentDictionary<string, QuantityInfo> GetQuantityNameToInfo()
        {
            return new ConcurrentDictionary<string, QuantityInfo>(Infos.ToDictionary(x => x.Name, x => x));
        }
    }
}
