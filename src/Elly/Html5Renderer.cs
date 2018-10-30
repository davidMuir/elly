using System;
using System.Text;

namespace Elly
{
    public class Html5Renderer : IRenderer
    {
        private const char NewLine = '\n';
        private const char Tab = '\t';

        public string Render(Element element)
        {
            var builder = new StringBuilder();

            Build(builder, element);

            return builder.ToString();
        }

        private void Build(StringBuilder builder, Element element)
        {
            OpenTag(builder, element);

            if (element.Kind == ElementKind.Void) return;

            if (!string.IsNullOrEmpty(element.Content))
            {
                builder.Append(element.Content);
            }
            else if (!(element.Children is null))
            {
                foreach (var child in element.Children)
                {
                    Build(builder, child);
                }
            }

            CloseTag(builder, element);
        }

        private void OpenTag(StringBuilder builder, Element element)
        {
            if (element.TagName is null) return;

            builder.Append($"<{element.TagName}");

            if (!(element.Attributes is null))
            {
                foreach (var attribute in element?.Attributes)
                {
                    builder.Append($" {attribute.Key}");

                    if (!(attribute.Value is null))
                    {
                        builder.Append($"=\"{attribute.Value}\"");
                    }
                }
            }

            builder.Append(">");
        }

        private void CloseTag(StringBuilder builder, Element element)
        {
            if (element.TagName is null) return;

            builder.Append($"</{element.TagName}>");
        }
    }
}