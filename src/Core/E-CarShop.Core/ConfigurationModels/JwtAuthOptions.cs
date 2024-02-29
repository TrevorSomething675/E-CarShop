namespace E_CarShop.Core.ConfigurationModels
{
    public class JwtAuthOptions
    {
        public const string SectionName = "JwtAuthOptions";
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Key { get; set; }
        public int ExpAccessTokenInDays { get; set; }
        public int ExpRefreshTokenInDays { get; set; }
    }
}