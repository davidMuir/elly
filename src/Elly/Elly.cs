using System;
using System.Collections.Generic;

namespace Elly
{
    public static class Elly
    {
        public static Element CreateElement(
            string tagName,
            IDictionary<string, string> attributes,
            params Element[] children
        )
        {
            return new Element
            {
                TagName = tagName,
                Attributes = attributes,
                Children = children
            };
        }

        public static Element CreateElement(
            string tagName,
            IDictionary<string, string> attributes,
            ElementKind elementKind,
            params Element[] children
        )
        {
            return new Element
            {
                TagName = tagName,
                Attributes = attributes,
                Children = children,
                Kind = elementKind
            };
        }

        public static Element CreateElement(
            string tagName,
            IDictionary<string, string> attributes,
            string content
        )
        {
            return new Element
            {
                TagName = tagName,
                Attributes = attributes,
                Content = content
            };
        }

        public static Element CreateElement(
            string tagName,
            IDictionary<string, string> attributes,
            ElementKind elementKind,
            string content
        )
        {
            return new Element
            {
                TagName = tagName,
                Attributes = attributes,
                Content = content,
                Kind = elementKind
            };
        }

        public static Element CreateElement<TComponent, TProps>(
            TProps props,
            params Element[] contents
        ) where TComponent : Component<TProps>, new()
        {
            var component = new TComponent();

            component.Init(props, contents);

            return component.Render();
        }

        public static Element CreateElement<TComponent>(
            params Element[] contents
        ) where TComponent : Component, new()
        {
            var component = new TComponent();

            component.Init(contents);

            return component.Render();
        }

        public static Element CreateText(string text)
        {
            return CreateElement(
                null,
                null,
                text
            );
        }

        public static Element CreateFragment(params Element[] contents)
        {
            return CreateElement(
                null,
                null,
                contents
            );
        }

        public static Element CreateVoidElement(
            string tagName,
            IDictionary<string, string> attributes)
        {
            return CreateElement(
                tagName,
                attributes,
                ElementKind.Void
            );
        }
    }
}
