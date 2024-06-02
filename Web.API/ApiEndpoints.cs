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
            public const string Base = $"{ApiBase}/authors";
            public const string Create = Base;
            public const string Get = $"{Base}/{{id:int}}";
            public const string GetAll = Base;
            public const string Update = $"{Base}/{{id:int}}";
            public const string Delete = $"{Base}/{{id:int}}";
        }

        public static class BankAccount
        {
            public const string Base = $"{ApiBase}/accounts";
            public const string Create = Base;
            public const string Get = $"{Base}/{{id:int}}";
            public const string GetAll = Base;
            public const string Update = $"{Base}/{{id:int}}";
            public const string Delete = $"{Base}/{{id:int}}";
        }

        public static class Category
        {
            public const string Base = $"{ApiBase}/categories";
            public const string Create = Base;
            public const string Get = $"{Base}/{{id:int}}";
            public const string GetAll = Base;
            public const string Update = $"{Base}/{{id:int}}";
            public const string Delete = $"{Base}/{{id:int}}";
        }

        public static class Customer
        {
            public const string Base = $"{ApiBase}/customers";
            public const string Create = Base;
            public const string Get = $"{Base}/{{id:int}}";
            public const string GetAll = Base;
            public const string Update = $"{Base}/{{id:int}}";
            public const string Delete = $"{Base}/{{id:int}}";
        }

        public static class Order
        {
            public const string Base = $"{ApiBase}/orders";
            public const string Create = Base;
            public const string Get = $"{Base}/{{id:int}}";
            public const string GetAll = Base;
            public const string Update = $"{Base}/{{id:int}}";
            public const string Delete = $"{Base}/{{id:int}}";
        }

        public static class OrderItem
        {
            public const string Base = $"{ApiBase}/orderItems";
            public const string Create = Base;
            public const string Get = $"{Base}/{{id:int}}";
            public const string GetAll = Base;
            public const string Update = $"{Base}/{{id:int}}";
            public const string Delete = $"{Base}/{{id:int}}";
        }

        public static class Publisher
        {
            public const string Base = $"{ApiBase}/publishers";
            public const string Create = Base;
            public const string Get = $"{Base}/{{id:int}}";
            public const string GetAll = Base;
            public const string Update = $"{Base}/{{id:int}}";
            public const string Delete = $"{Base}/{{id:int}}";
        }
    }
}
