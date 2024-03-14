using WenceyWang.FIGlet; // dotnet add package FIGlet.Net
using Markdig; // dotnet add package Markdig

// FYI - Figlet font DB: https://github.com/xero/figlet-fonts/tree/master

var renderers = new []
{
    new TextRenderer(),
    new FigletRenderer("Fonts/Bloody.flf"),
    new FigletRenderer("Fonts/Bigfig.flf"),
    new FigletRenderer("Fonts/3d.flf"),
    new MarkdownRenderer(),
};

foreach (var renderer in renderers)
{
    var renderedText = renderer.RenderText([
        "# Hello HTL Leonding!",
        "Love to be here"
    ]);
    Console.WriteLine($"{renderer.GetType().Name}:\n\n{string.Join('\n', renderedText)}\n");
}

class TextRenderer
{
    // Base class is a renderer that just returns the input text
    public virtual string[] RenderText(string[] text) => text;
}

class FigletRenderer() : TextRenderer
{
    private readonly FIGletFont? font;

    public FigletRenderer(string fontPath) : this()
    {
        using var stream = File.OpenRead(fontPath);
        font = new FIGletFont(stream);
    }

    public override string[] RenderText(string[] text)
    {
        var result = new List<string>();
        foreach (var line in base.RenderText(text))
        {
            var art = new AsciiArt(line, font);
            result.AddRange(art.ToString().Split('\n'));
        }

        return [.. result];
    }
}

class MarkdownRenderer : TextRenderer
{
    public override string[] RenderText(string[] text)
    {
        var markdown = string.Join('\n', base.RenderText(text));
        var html = Markdown.ToHtml(markdown);
        return html.Split('\n');
    }
}
