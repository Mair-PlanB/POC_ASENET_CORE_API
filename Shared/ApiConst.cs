namespace Shared
{
    public class ApiConst
    {
        public static readonly string ApiBaseRoute = @"https://localhost:7103/api/";
        public static readonly string ApiMainRoute = Path.Combine(ApiBaseRoute, "main");
        public static readonly string ApiItemRoute = Path.Combine(ApiBaseRoute, "todoItems");

    }
}