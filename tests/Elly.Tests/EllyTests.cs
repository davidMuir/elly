using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Elly.Tests
{
    public class EllyTests
    {
        [Fact]
        public void SetsTagNameCorrectly()
        {
            var expected = "strong";

            var actual = Elly.CreateElement(
                expected,
                null
            ).TagName;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SetsAttributesCorrectly()
        {
            var expected = new Dictionary<string, string>
            {
                { "style", "color: red;" }
            };

            var actual = Elly.CreateElement(
                "p",
                expected
            ).Attributes;

            Assert.Equal(expected.Count, actual.Count);
            Assert.False(expected.Except(actual).Any());
        }

        [Fact]
        public void SetsContentCorrectly()
        {
            var expected = "Elly";

            var actual = Elly.CreateElement(
                "div",
                null,
                expected
            ).Content;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SetsChildrenCorrectly()
        {
            var expected = new Element[]
            {
                new Element
                {
                    TagName = "one"
                },
                new Element
                {
                    TagName = "two"
                },
                new Element
                {
                    TagName = "three"
                }
            };

            var actual = Elly.CreateElement(
                "div",
                null,
                expected
            ).Children;

            Assert.Equal(expected.Count(), actual.Count());

            for (var i = 0; i < expected.Count(); i++)
            {
                Assert.Equal(
                    expected.ElementAt(i).TagName, 
                    actual.ElementAt(i).TagName);
            }
        }
    }
}
