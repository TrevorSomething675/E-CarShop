using System.Text.Json.Serialization;
using E_CarShop.Core.ResponseModels;
using System.Text.Json;

namespace E_CarShop.Core.JsonConverterConfiguration
{
    public class ImageResponseConfiguration : JsonConverter<ImageResponse>
    {
        public override ImageResponse? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }

            ImageResponse image = new ImageResponse();

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                {
                    return image;
                }

                if (reader.TokenType != JsonTokenType.PropertyName)
                {
                    throw new JsonException();
                }

                string propertyName = reader.GetString();
                reader.Read();
            }

            throw new JsonException();
        }

        public override void Write(Utf8JsonWriter writer, ImageResponse value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteNumber("Id", value.Id);
            writer.WriteString("Name", value.Name);
            writer.WriteString("Base64String", value.Base64String);
            writer.WriteEndObject();
        }
    }
}