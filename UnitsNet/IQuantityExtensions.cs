// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Linq;

namespace UnitsNet;

/// <summary>
///     Extension methods for <see cref="IQuantity"/>, to avoid duplicating the implementations for our 100+ quantity types.
/// </summary>
// ReSharper disable once InconsistentNaming
public static class IQuantityExtensions
{
    /// <summary>
    ///     Gets the value in the unit determined by the given <see cref="UnitSystem"/>. If multiple units were found for the given <see cref="UnitSystem"/>,
    ///     the first match will be used.
    /// </summary>
    /// <param name="quantity">The quantity.</param>
    /// <param name="unitSystem">The <see cref="UnitSystem"/> to convert the quantity value to.</param>
    /// <returns>The converted value.</returns>
    public static double As(this IQuantity quantity, UnitSystem unitSystem)
    {
        if (unitSystem is null)
            throw new ArgumentNullException(nameof(unitSystem));

        var unitInfos = quantity.QuantityInfo.GetUnitInfosFor(unitSystem.BaseUnits);

        var firstUnitInfo = unitInfos.FirstOrDefault();
        if (firstUnitInfo == null)
            throw new ArgumentException("No units were found for the given UnitSystem.", nameof(unitSystem));

        return quantity.As(firstUnitInfo.Value);
    }
}
