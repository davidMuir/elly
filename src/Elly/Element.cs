using System.Collections.Generic;

namespace Elly
{
    public class Element
    {
        public string TagName { get; set; }
        public IDictionary<string, string> Attributes { get; set; }
        public string Content { get; set; }
        public IEnumerable<Element> Children { get; set; }
        public ElementKind Kind { get; set; } = ElementKind.Normal;
    }
}