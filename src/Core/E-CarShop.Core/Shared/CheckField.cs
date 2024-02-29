namespace E_CarShop.Core.Shared
{
    public static class CheckField
    {
        public static bool IsNumber(int number)
        {
            return int.TryParse(number.ToString(), out number);
        }
    }
}