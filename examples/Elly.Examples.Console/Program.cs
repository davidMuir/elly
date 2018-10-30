using System;
using System.Collections.Generic;
using Elly;

namespace Elly.Examples.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = Elly.CreateElement(
                "html",
                new Dictionary<string, string>
                {
                    { "lang", "en-gb" }
                },
                Elly.CreateElement<HeadComponent>(),
                Elly.CreateElement(
                    "body",
                    null,
                    Elly.CreateElement<HelloWorldComponent, HelloWorldProps>(
                        new HelloWorldProps
                        {
                            Greeting = "Hi",
                            Subject = "Folks"
                        }
                    ),
                    Elly.CreateElement(
                        "small",
                        new Dictionary<string, string>
                        {
                            { "class", "tiny" },
                            { "style", "color: pink;" }
                        },
                        " (Nice to meet you!)"
                    )
                )
            );

            var renderer = new Html5Renderer();

            System.Console.WriteLine(renderer.Render(tree));
        }
    }

    public class HelloWorldComponent : Component<HelloWorldProps>
    {
        public override Element Render()
        {
            return Elly.CreateElement(
                "h1",
                null,
                $"{Props.Greeting} {Props.Subject}!"
            );
        }
    }

    public class HelloWorldProps
    {
        public string Greeting { get; set; } = "Hello";
        public string Subject { get; set; } = "World";
    }

    public class HeadComponent : Component
    {
        public override Element Render()
        {
            return Elly.CreateElement(
                "head",
                null,
                Elly.CreateElement("title", null, "My Elly Document"),
                Elly.CreateVoidElement(
                    "link",
                    new Dictionary<string, string>
                    {
                        { "href", "/content/main.css" },
                        { "rel", "stylesheet" }
                    })
            );
        }
    }
}
