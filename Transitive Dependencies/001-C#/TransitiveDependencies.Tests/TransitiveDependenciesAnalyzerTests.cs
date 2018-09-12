using TransitiveDependencies;
using NUnit.Framework;
using LanguageExt;
using System.Collections.Generic;
using System.Linq;

namespace TransitiveDependencies.Tests
{
    [TestFixture]
    public class TransitiveDependenciesAnalyzerTests
    {
        private DependenciesAnalyzer _analyzer;

        [SetUp]
        public void SetUp()
        {
            _analyzer = new DependenciesAnalyzer();
        }

        [Test]
        public void ItShouldReturnNoneOptionForNotExistingArtifact()
        {
            Option<IEnumerable<string>> dependencies = _analyzer.GetDependencies("A");

            Assert.That(dependencies.IsNone, Is.True);
        }

        [Test]
        public void ItShouldAllowToAddModuleWithNoDependencies()
        {
            _analyzer.AddModule("A");
        }

        [Test]
        public void ItShouldReturnEmptyListForModuleWithNoDependencies()
        {
            _analyzer.AddModule("A");

            Option<IEnumerable<string>> dependencies = _analyzer.GetDependencies("A");

            Assert.That(dependencies.IsSome, Is.True);
            dependencies.IfSome(x => Assert.That(x, Is.Empty));
        }

        [Test]
        public void ItShouldAllowToAddModuleWithDependencies()
        {
            _analyzer.AddModule("A", new string[] { "B", "C" });
        }

        [Test]
        public void ItShouldReturnModuleDependenciesWhenNoTransitiveDependenciesArePresent()
        {
            _analyzer.AddModule("B");
            _analyzer.AddModule("C");
            _analyzer.AddModule("D");

            _analyzer.AddModule("A", new string[] { "B", "C" });

            Option<IEnumerable<string>> dependencies = _analyzer.GetDependencies("A");

            string[] expected = { "B", "C" };

            Assert.That(dependencies.IsSome, Is.True);
            dependencies.IfSome(x => Assert.That(x, Is.EquivalentTo(expected)));
        }

        [Test]
        public void ItShouldReturnModuleDependenciesWhenTransitiveDependenciesArePresent()
        {
            _analyzer.AddModule("B");
            _analyzer.AddModule("C");
            _analyzer.AddModule("D");

            _analyzer.AddModule("A", new string[] { "B", "C" });
            _analyzer.AddModule("C", new string[] { "D", "B" });

            Option<IEnumerable<string>> dependencies = _analyzer.GetDependencies("A");

            string[] expected = { "B", "C", "D" };

            Assert.That(dependencies.IsSome, Is.True);
            dependencies.IfSome(x => Assert.That(x, Is.EquivalentTo(expected)));
        }

        [Test]
        // I am not sure if this should work this way or return error
        // In next attempt I will try to implement it the other way
        public void ItShoulReturnCorrectDependenciesWhenCircualarReferencesArePresent()
        {
            _analyzer.AddModule("A", new[] { "B" });
            _analyzer.AddModule("B", new[] { "C" });
            _analyzer.AddModule("C", new[] { "A" });

            Option<IEnumerable<string>> dependencies = _analyzer.GetDependencies("A");

            string[] expected = { "B", "C" };

            Assert.That(dependencies.IsSome, Is.True);
            dependencies.IfSome(x => Assert.That(x, Is.EquivalentTo(expected)));
        }
    }
}