using System.Text;
using System.Text.Json;
using System.Xml.Serialization;

namespace MyApp;

public class Triangle
{
    public double FirstSide { get; set; }
    public double SecondSide { get; set; }
    public double ThirdSide { get; set; }

    public string ToString(string extension)
    {
        if (extension == FileExtensions.Txt)
        {
            var builder = new StringBuilder();
            builder.Append($"{nameof(FirstSide)} = {FirstSide}\n");
            builder.Append($"{nameof(SecondSide)} = {SecondSide}\n");
            builder.Append($"{nameof(ThirdSide)} = {ThirdSide}\n");

            return builder.ToString();
        }

        if (extension == FileExtensions.Json)
        {
            return JsonSerializer.Serialize(this);
        }

        if (extension == FileExtensions.Xml)
        {
            using var stringWriter = new Utf8StringWriter();
            var serializer = new XmlSerializer(typeof(Triangle));
            serializer.Serialize(stringWriter, this);

            return stringWriter.ToString();
        }

        throw new Exception("Неизвестное расширение файла!");
    }
}