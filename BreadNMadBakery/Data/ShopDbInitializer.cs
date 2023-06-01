public class ShopDbInitializer
{
    public static void Seed(IApplicationBuilder builder)
    {
        using (var serviceScope = builder.ApplicationServices.CreateScope())
        {
            var context = serviceScope.ServiceProvider.GetService<ShopContext>();

            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product() { Price = 2800, Name = "Полунично-ванільний торт з макарунами", ImageName = "fraiser%20cake.jpg" },
                    new Product() { Price = 2300, Name = "Торт з баварським кремом та полуницею", ImageName = "charlotte%20cake.jpg" },
                    new Product() { Price = 2250, Name = "Малиново-ванільний торт з марципаном", ImageName = "framboiser%20cake.jpg" },
                    new Product() { Price = 1700, Name = "Торт із заварни кремом та карамеллю", ImageName = "custard%20tart.jpg" },
                    new Product() { Price = 2300, Name = "Моркв'яно-горіховий торт з апельсином", ImageName = "carrot%20cake.jpg" },
                    new Product() { Price = 1800, Name = "Малиновий мусовий торт з полуничним желе", ImageName = "raspberry%20cake.jpg" },
                    new Product() { Price = 1800, Name = "Лимонно-чорничний тарт з м'ятою та горіхами", ImageName = "lemon_tart_small.jpg" },
                    new Product() { Price = 1650, Name = "Лимоно-лаймовий тарт з м'якоттю та кокосом", ImageName = "lt2.jpg" },
                    new Product() { Price = 1300, Name = "Яблуневий тарт з малиною та агрусом", ImageName = "tart1_2.jpg" },
                    new Product() { Price = 1300, Name = "Мусовий торт з різнии видами шоколаду", ImageName = "trio%20chocolate.jpg" },
                    new Product() { Price = 1100, Name = "Чизкейк з карамеллю і листовим тістом", ImageName = "fromage.jpg" },
                    new Product() { Price = 1800, Name = "Шоколадний торт з полуничним джемом", ImageName = "chiki%20cake.jpg" }
                );

                context.SaveChanges();
            }
        }
    }
}