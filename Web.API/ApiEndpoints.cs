namespace Web.API
{
    public static class ApiEndpoints
    {
        private const string ApiBase = "api";

        public static class Book
        {
            public const string Base = $"{ApiBase}/book";
            public const string Create = Base;
            public const string Get = $"{Base}/{{id:int}}";
            public const string GetAll = Base;
            public const string Update = $"{Base}/{{id:int}}";
            public const string Delete = $"{Base}/{{id:int}}";
        }

        public static class Author
        {
            public const string Base = $"{ApiBase}/auhtors";
            public const string Create = Base;
            public const string Get = $"{Base}/{{id:int}}";
            public const string GetAll = Base;
            public const string Update = $"{Base}/{{id:int}}";
            public const string Delete = $"{Base}/{{id:int}}";
        }
    }
}
