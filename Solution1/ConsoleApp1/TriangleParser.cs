using System.Text.Json;
using System.Xml;
namespace MyApp;

public static class TriangleParser
{
    public static Triangle ParseTriangleXml(string path)
    {
        var xml = new XmlDocument();
        var triangle = new Triangle();
        xml.Load(path);
        var root = xml.DocumentElement;
        foreach (XmlNode node in root.ChildNodes)
        {
            if (node.Name == nameof(Triangle.FirstSide))
            {
                triangle.FirstSide = double.Parse(node.InnerText);
            }
            else if (node.Name == nameof(Triangle.SecondSide))
            {
                triangle.SecondSide = double.Parse(node.InnerText);
            }
            else if (node.Name == nameof(Triangle.ThirdSide))
            {
                triangle.ThirdSide = double.Parse(node.InnerText);
            }
        }

        return triangle;
    }
    
    public static Triangle ParseTriangleJson(string path)
    {
        using var sr = new StreamReader(path);
        return JsonSerializer.Deserialize<Triangle>(sr.ReadToEnd());
    }
    
    public static Triangle ParseTriangleTxt(string path)
    {
        using var sr = new StreamReader(path);
        var source = sr.ReadToEnd();
        return ParseTriangleFromString(source);
    }

    public static Triangle ParseTriangleFromString(string source)
    {
        var fields = source.Split(new []{'\r', '\n'}, StringSplitOptions.RemoveEmptyEntries);
        var dict = new Dictionary<string, double>();

        foreach (var field in fields)
        {
            var fieldInfo = field.Split(" = ");
            dict[fieldInfo[0]] = double.Parse(fieldInfo[1]);
        }

        return new Triangle
        {
            FirstSide = dict[nameof(Triangle.FirstSide)],
            SecondSide = dict[nameof(Triangle.SecondSide)],
            ThirdSide = dict[nameof(Triangle.ThirdSide)]
        };
    }
}