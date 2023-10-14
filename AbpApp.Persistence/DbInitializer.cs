using AbpApp.Domain.Entities;

namespace AbpApp.Persistence
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Options.Any())
            {
                var options = new List<Option>
                {
                    new Option
                    {
                        Key = Key.button_color,
                        Value = "#FF0000",
                        Weight = 33.3M
                    },
                    new Option
                    {
                        Key = Key.button_color,
                        Value = "#00FF00",
                        Weight = 33.3M
                    },
                    new Option
                    {
                        Key = Key.button_color,
                        Value = "#0000FF",
                        Weight = 33.3M
                    },
                    new Option
                    {
                        Key = Key.price,
                        Value = "10",
                        Weight = 75M
                    },
                    new Option
                    {
                        Key = Key.price,
                        Value = "20",
                        Weight = 10M
                    },
                    new Option
                    {
                        Key = Key.price,
                        Value = "50",
                        Weight = 5M
                    },
                    new Option
                    {
                        Key = Key.price,
                        Value = "5",
                        Weight = 10M
                    }
                };

                context.Options.AddRange(options);
                context.SaveChanges();
            }
        }
    }
}
