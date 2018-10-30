# Elly

Simple rendering library for .NET Core

## Example

```csharp
Elly.CreateElement(
    "p",
    new Dictionary<string, string>
    {
        { "class", "extra-large" },
        { "style", "color: blue;" }
    },
    "Hello World"
);
```
