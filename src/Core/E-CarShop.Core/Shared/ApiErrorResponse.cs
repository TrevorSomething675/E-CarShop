using System.Text.Json.Serialization;

namespace E_CarShop.Core.Shared
{
    [method: JsonConstructor]
    public sealed class ApiErrorResponse(string message)
    {
        public string Message { get; } = message;

        public override string ToString() => Message;
    }
}