using System.Collections.Generic;
using Xunit;

namespace Elly.Tests
{
    public class Html5RendererTests
    {
        [Fact]
        public void RendersTagNameCorrectly()
        {
            var expected = "<main></main>";

            var element = Elly.CreateElement("main", null);

            var renderer = new Html5Renderer();

            var actual = renderer.Render(element);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RendersAttributesCorrectly()
        {
            var expected = "<nav style=\"background-color: black;\" data-toggle=\"true\"></nav>";

            var element = Elly.CreateElement(
                "nav",
                new Dictionary<string, string>
                {
                    { "style", "background-color: black;" },
                    { "data-toggle", "true" }
                }
            );

            var renderer = new Html5Renderer();

            var actual = renderer.Render(element);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RendersVoidElementsCorrectly()
        {
            var expected = "<link href=\"/content/main.css\" rel=\"stylesheet\">";

            var element = Elly.CreateVoidElement(
                "link",
                new Dictionary<string, string>
                {
                    { "href", "/content/main.css" },
                    { "rel", "stylesheet" }
                });

            var renderer = new Html5Renderer();

            var actual = renderer.Render(element);

            Assert.Equal(expected, actual);
        }
    }
}