namespace TwitterApi.Bussines.Helpers
{
    public static class PathConstants
    {
        public static string UserImg => Path.Combine("assets", "img", "user");

        public static string PostFile => Path.Combine("assets", "img", "post");

        public static string RootPath { get; set; }
    }
}
