using System.Text.Json.Serialization;
using E_CarShop.Core.ReponseModels;
using System.Text.Json;

namespace E_CarShop.Core.JsonConverterConfiguration
{
    public class CarResponseConfiguration : JsonConverter<CarResponse>
    {
        public override CarResponse Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }

            CarResponse car = new CarResponse();

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                {
                    return car;
                }

                if (reader.TokenType != JsonTokenType.PropertyName)
                {
                    throw new JsonException();
                }

                string propertyName = reader.GetString();
                reader.Read();

                //switch (propertyName)
                //{
                //    case "Name":
                //        car.Name = reader.GetString();
                //        break;
                //    case "Color":
                //        car.Color = reader.GetString();
                //        break;
                //    case "IsVisible":
                //        car.IsVisible = reader.GetBoolean();
                //        break;
                //    case "Description":
                //        car.Description = reader.GetString();
                //        break;
                //    case "Price":
                //        car.Price = reader.GetInt32();
                //        break;
                //    default:
                //        reader.Skip();
                //        break;
                //}
            }

            throw new JsonException();
        }

        public override void Write(Utf8JsonWriter writer, CarResponse value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
                writer.WriteNumber("Id", value.Id);
                writer.WriteString("Name", value.Name);
                writer.WriteString("Color", value.Color);
                writer.WriteBoolean("IsVisible", value.IsVisible);
                writer.WriteString("Description", value.Description);
                writer.WriteNumber("Price", value.Price);

                writer.WriteStartArray("Images");
                foreach (var image in value.Images)
                {
                    writer.WriteStartObject();
                    writer.WriteNumber("Id", image.Id);
                    writer.WriteString("Name", image.Name);
                    writer.WriteString("Base64String", image.Base64String);
                    writer.WriteEndObject();
                }
                writer.WriteEndArray();

                writer.WriteStartArray("Users");
                foreach (var user in value.Users)
                {
                    writer.WriteStartObject();
                    writer.WriteNumber("Id", user.Id);
                    writer.WriteString("Name", user.Name);
                    writer.WriteString("Password", user.Password);
                    writer.WriteEndObject();
                }
                writer.WriteEndArray();

                writer.WriteNumber("BrandId", value.BrandId);
                writer.WriteStartObject("Brand");
                writer.WriteString("Name", value?.Brand?.Name);
                writer.WriteEndObject();

            writer.WriteEndObject();
        }
    }
}
