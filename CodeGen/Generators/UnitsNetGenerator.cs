// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using CodeGen.Generators.UnitsNetGen;
using CodeGen.Helpers.UnitEnumValueAllocation;
using CodeGen.JsonTypes;
using Serilog;

namespace CodeGen.Generators
{
    /// <summary>
    ///     Code generator for UnitsNet and UnitsNet.Tests projects.
    /// </summary>
    [SuppressMessage("ReSharper", "TemplateIsNotCompileTimeConstantProblem")]
    internal static class UnitsNetGenerator
    {
        /// <summary>
        ///     Generate source code for UnitsNet project for the given parsed quantities.
        ///     Outputs files relative to the given root dir to these locations:
        ///     <list type="bullet">
        ///         <item>
        ///             <description>UnitsNet/GeneratedCode (quantity and unit types, Quantity, UnitAbbreviationCache)</description>
        ///         </item>
        ///         <item>
        ///             <description>UnitsNet.Tests/GeneratedCode (tests)</description>
        ///         </item>
        ///         <item>
        ///             <description>UnitsNet.Tests/CustomCode (test stubs, one for each quantity if not already created)</description>
        ///         </item>
        ///     </list>
        /// </summary>
        /// <param name="rootDir">Path to repository root directory.</param>
        /// <param name="quantities">The parsed quantities.</param>
        /// <param name="quantityNameToUnitEnumValues">Allocated unit enum values for generating unit enum types.</param>
        public static void Generate(string rootDir, Quantity[] quantities, QuantityNameToUnitEnumValues quantityNameToUnitEnumValues)
        {
            var unitsNetDir = $"{rootDir}/UnitsNet";
            var numberExtensionsGenDir = $"{rootDir}/UnitsNet.NumberExtensions/GeneratedCode";
            var numberExtensionsTestsGenDir = $"{rootDir}/UnitsNet.NumberExtensions.Tests/GeneratedCode";
            var testProjectDir = $"{rootDir}/UnitsNet.Tests";

            // Ensure output directories exist
            Directory.CreateDirectory($"{unitsNetDir}/Quantities");
            Directory.CreateDirectory($"{unitsNetDir}/Units");
            Directory.CreateDirectory($"{numberExtensionsGenDir}");
            Directory.CreateDirectory($"{numberExtensionsTestsGenDir}");
            Directory.CreateDirectory($"{testProjectDir}/GeneratedCode");
            Directory.CreateDirectory($"{testProjectDir}/GeneratedCode/TestsBase");
            Directory.CreateDirectory($"{testProjectDir}/GeneratedCode/QuantityTests");

            foreach (var quantity in quantities)
            {
                var projectName = $"UnitsNet.{quantity.Name}";
                var projectDir = Path.Combine(unitsNetDir, projectName);
                Directory.CreateDirectory(projectDir);

                UnitEnumNameToValue unitEnumValues = quantityNameToUnitEnumValues[quantity.Name];

                GenerateQuantity(quantity, $"{projectDir}/{quantity.Name}.g.cs");
                GenerateUnitType(quantity, $"{projectDir}/{quantity.Name}Unit.g.cs", unitEnumValues);
                GenerateProject(quantity, Path.Combine(projectDir, $"{projectName}.csproj"));
                GenerateSolution(quantities, Path.Combine(unitsNetDir, "UnitsNet2.sln"));

                GenerateNumberToExtensions(quantity, $"{numberExtensionsGenDir}/NumberTo{quantity.Name}Extensions.g.cs");
                GenerateNumberToExtensionsTestClass(quantity, $"{numberExtensionsTestsGenDir}/NumberTo{quantity.Name}ExtensionsTest.g.cs");

                // Example: CustomCode/Quantities/LengthTests inherits GeneratedCode/TestsBase/LengthTestsBase
                // This way when new units are added to the quantity JSON definition, we auto-generate the new
                // conversion function tests that needs to be manually implemented by the developer to fix the compile error
                // so it cannot be forgotten.
                GenerateQuantityTestBaseClass(quantity, $"{testProjectDir}/GeneratedCode/TestsBase/{quantity.Name}TestsBase.g.cs");
                GenerateQuantityTestClassIfNotExists(quantity, $"{testProjectDir}/CustomCode/{quantity.Name}Tests.cs");

                Log.Information("✅ {Quantity}", quantity.Name);
            }

            Log.Information("");
            GenerateIQuantityTests(quantities, $"{testProjectDir}/GeneratedCode/IQuantityTests.g.cs");

            var unitCount = quantities.SelectMany(q => q.Units).Count();
            Log.Information("");
            Log.Information("Total of {UnitCount} units and {QuantityCount} quantities", unitCount, quantities.Length);
            Log.Information("");
        }

        private static void GenerateQuantityTestClassIfNotExists(Quantity quantity, string filePath)
        {
            if (File.Exists(filePath)) return;

            var content = new UnitTestStubGenerator(quantity).Generate();
            File.WriteAllText(filePath, content);
            Log.Information("✅ {Quantity} initial test stub", quantity.Name);
        }

        private static void GenerateQuantity(Quantity quantity, string filePath)
        {
            var content = new QuantityGenerator(quantity).Generate();
            File.WriteAllText(filePath, content);
        }

        private static void GenerateNumberToExtensions(Quantity quantity, string filePath)
        {
            var content = new NumberExtensionsGenerator(quantity).Generate();
            File.WriteAllText(filePath, content);
        }

        private static void GenerateNumberToExtensionsTestClass(Quantity quantity, string filePath)
        {
            var content = new NumberExtensionsTestClassGenerator(quantity).Generate();
            File.WriteAllText(filePath, content);
        }

        private static void GenerateUnitType(Quantity quantity, string filePath, UnitEnumNameToValue unitEnumValues)
        {
            var content = new UnitTypeGenerator(quantity, unitEnumValues).Generate();
            File.WriteAllText(filePath, content);
        }

        private static void GenerateQuantityTestBaseClass(Quantity quantity, string filePath)
        {
            var content = new UnitTestBaseClassGenerator(quantity).Generate();
            File.WriteAllText(filePath, content);
        }

        private static void GenerateIQuantityTests(Quantity[] quantities, string filePath)
        {
            var content = new IQuantityTestClassGenerator(quantities).Generate();
            File.WriteAllText(filePath, content);
            Log.Information("✅ IQuantityTests.g.cs");
        }

        private static void GenerateProject(Quantity quantity, string filePath)
        {
            var content = new ProjectGenerator(quantity).Generate();
            File.WriteAllText(filePath, content);
        }

        private static void GenerateSolution(Quantity[] quantities, string filePath)
        {
            var content = new SolutionGenerator(quantities).Generate();

            File.WriteAllText(filePath, content);
            Log.Information($"✅ {Path.GetFileName("UnitsNet2.sln")}");
        }

    }
}
