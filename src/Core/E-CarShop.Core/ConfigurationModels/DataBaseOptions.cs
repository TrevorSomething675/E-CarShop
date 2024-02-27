namespace E_CarShop.Core.ConfigurationModels
{
    public class DataBaseOptions
    {
        public const string SectionName = "DataBaseOptions";
        public string ConnectionString { get; set; }
    }
}