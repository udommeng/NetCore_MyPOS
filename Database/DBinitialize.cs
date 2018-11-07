using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyPOS.Models;

namespace MyPOS.Database
{
  public static class DBinitialize
    {
        public static void INIT(IServiceProvider ServiceProvider)
        {
            var context = new DatabaseContext(ServiceProvider.GetRequiredService<DbContextOptions<DatabaseContext>>());

            // If database does not exist then the database and all its schema are created
            context.Database.EnsureCreated();

            InsertData(context);
        }

        private static void InsertData(DatabaseContext Context)
        {
            // If category table has data, it will return.
            if (Context.Category.Any())
            {
                return;
            }

            Context.Category.AddRange(DummyCategory());
            Context.SaveChanges();

            Context.Products.AddRange(DummyProducts());
            Context.SaveChanges();

            Context.ProductSize.AddRange(DummyProductSize());
            Context.SaveChanges();
        }

        private static IEnumerable<Category> DummyCategory()
        {
            return new List<Category>{
              new Category
              {
                  Name = "Polo-shirt",
                  Description = "Tempore non nam quia repellendus aperiam. Dolores in rerum et labore a tenetur. Maiores dolorem quam a quo aut quia. Possimus hic libero et dicta voluptatem. Voluptate sapiente aspernatur qui aperiam ad cupiditate aut. Doloribus ipsa ut quia. Accusamus qui accusantium minima et architecto omnis et eius. Nihil inventore adipisci quos omnis repellendus recusandae aut. Laborum tempore perspiciatis in architecto et aut vero. Velit odio laudantium nihil aut aut sed commodi. Quaerat iste dolorum eos molestiae. Quam minima dolores quis.",
              },
              new Category
              {
                  Name = "Aloha-shirt",
                  Description = "Eius quae ab earum inventore maiores occaecati recusandae eos libero. Repudiandae delectus alias est nostrum sapiente. Harum odit ullam repellat quia aut aut. Tempora blanditiis qui tenetur est. Est voluptas libero hic explicabo. Veniam modi nobis nesciunt assumenda molestiae totam modi. Sint nemo eveniet dolorem. Cumque voluptatibus assumenda ea ab repellat qui. Sunt recusandae odio optio dolore exercitationem quo nihil. Similique ut ea ab et velit. Illum ut unde ad perferendis quo asperiores nemo nulla velit.",
              },
              new Category
              {
                  Name = "Sweat-shirt",
                  Description = "Quibusdam sit consequatur placeat ut ea quia excepturi. Dolor ipsa est consequatur optio. Vero aut omnis explicabo iste ratione esse voluptas explicabo. Veritatis iusto voluptatem. Eius tempore dolor veniam molestiae ullam et. Sed accusantium nihil distinctio. Itaque dignissimos debitis. Reprehenderit corrupti deleniti rem repudiandae. Possimus voluptates eum dicta ex et aut optio. Laborum voluptatem nemo consequuntur exercitationem asperiores ea ratione debitis. Rem dignissimos ratione quam laboriosam molestias. Consectetur vero et aut accusantium sit. Aliquid et labore assumenda necessitatibus unde sint autem amet.",
              },
              new Category
              {
                  Name = "T-shirt",
                  Description = "Optio nihil aperiam alias rem error. Voluptas consequatur facere qui aliquam quia harum fugit nemo pariatur. Vel aut nihil. Quia non esse omnis. Doloremque praesentium ipsa fuga culpa suscipit error rerum dolor. Neque quas nulla cum expedita. Et sed reiciendis adipisci culpa. Aliquam accusamus sequi saepe harum ut soluta necessitatibus ex. Quia alias temporibus eligendi at nesciunt ex quia quae fugit. Nisi exercitationem inventore quisquam laboriosam beatae hic nisi. Et molestias eos a cum quasi incidunt ducimus. Doloribus vel vel est id ea. Quibusdam qui quia odit illum nesciunt accusantium explicabo.",
              },
              new Category
              {
                  Name = "Sleeveless-shirt",
                  Description = "Molestias qui et cumque sit et itaque quis porro. Autem et ipsum eaque quia rerum autem quam laudantium. Soluta quis sit rerum assumenda necessitatibus dolores magni. Ex corrupti aperiam officiis. Deserunt atque pariatur vero ut. Suscipit illo repellat quidem cupiditate laborum. Omnis quod excepturi repellat ipsa maiores et sed. Error saepe error. Reprehenderit aliquid itaque maxime quod iure. Porro ad quam molestiae est asperiores exercitationem.",
              },
              new Category
              {
                  Name = "Poet-shirt",
                  Description = "Omnis eum exercitationem est adipisci. Distinctio ullam recusandae deserunt atque sed. Et voluptas tempora et maxime est consequatur nihil. Veniam tenetur aut. Cumque modi corporis eos perferendis. Distinctio ex aut a iste nam tenetur. Eos eum aut in. Placeat nobis voluptas. Corporis corporis eum rerum. Et sed eius odit expedita qui hic.",
              },
              new Category
              {
                  Name = "Henley-shirt",
                  Description = "Ipsum voluptatem repellendus ducimus ut et. Molestias dolorum aut quasi labore eveniet autem. Excepturi labore nemo qui officiis architecto minima. Repellendus ex non amet. Explicabo est dolorum. Nemo eum nam nihil adipisci in sit sed ut. Atque accusamus culpa. Assumenda quia in asperiores odit expedita praesentium consequatur neque sint. Et placeat qui cumque voluptates ducimus adipisci et rerum rerum. Odio iusto nam sint aliquid repudiandae. Error adipisci corrupti laudantium. Consequatur adipisci occaecati.",
              }
            };
        }

        private static IEnumerable<Product> DummyProducts()
        {
            return new List<Product> {
                new Product
                {
                     CodeName = "cm-0001",
                     Name = "American Favorite Canvas",
                     Detail = "Nihil accusantium ratione ipsam non iure eaque optio facere dolore. Laboriosam debitis aut repellat aut enim repellendus aut et molestiae. Atque mollitia autem dicta reiciendis quas rerum excepturi. Totam possimus suscipit quis cupiditate. Est magni est.",
                     Price = 2790.00m,
                     CategoryID = 3,
                     Image = "pa1.jpg",
                     Timestamp = "23-02-2560"
                },
                 new Product
                {
                     CodeName = "cm-0002",
                     Name = "Monochromatic Comb Art",
                     Detail = "Praesentium harum facilis quia. Aut ipsa pariatur exercitationem voluptatem nulla tenetur veritatis cumque. Laudantium veniam illum rerum. Consequatur reprehenderit qui eos esse suscipit impedit vel voluptates iusto. Quod et laboriosam. Quam nam omnis et ad sit mollitia voluptatum harum libero. Inventore est voluptas sint possimus omnis voluptate tempore. Maiores nam dolores maxime laborum veritatis tempore perferendis. Ut aut id ducimus tempora blanditiis. Quo sed sit debitis quam ipsam.",
                     Price = 550.00m,
                     CategoryID = 5,
                     Image = "pb1.jpg",
                     Timestamp = "23-02-2560"
                },
                  new Product
                {
                     CodeName = "cm-0003",
                     Name = "Toles Long-Sleeve",
                     Detail = "Tenetur consectetur et est est dolorem eos. Corporis iste velit quaerat voluptatum at accusamus vel ullam. Aliquam quas dolor reprehenderit beatae laboriosam commodi. Enim totam dolorum cumque. Laborum consectetur voluptatem quo eligendi laudantium. Pariatur enim autem nulla ullam natus et unde. Eaque id et aut quas consequatur et harum. Veniam est fugiat ut. Tenetur deserunt corporis. Optio quidem dolor rerum pariatur dolorem amet sed dolor et. Veniam dignissimos dolore qui hic maxime sunt aut. Quaerat labore ipsum et ab ducimus nam excepturi voluptatum. Blanditiis amet pariatur eaque facilis dolores nesciunt.",
                     Price = 320.00m,
                     CategoryID = 7,
                     Image = "pc1.jpg",
                     Timestamp = "23-02-2560"
                },
            };
        }

        private static IEnumerable<ProductSize> DummyProductSize()
        {
            List<ProductSize> data = new List<ProductSize>();

            Random random = new Random();

            const int countProduct = 3;
            const int countSize = 4;

            for (int i = 1; i <= countProduct; i++)
            {
                for (int j = 0; j < countSize; j++)
                {
                    ProductSize productSize = new ProductSize();

                    productSize.ProductID = i;
                    productSize.Count = random.Next(0, 60);

                    switch (j)
                    {
                        case 0:
                            productSize.Size = "S";
                            break;
                        case 1:
                            productSize.Size = "M";
                            break;
                        case 2:
                            productSize.Size = "L";
                            break;
                        case 3:
                            productSize.Size = "XL";
                            break;
                    }

                    data.Add(productSize);
                }
            }
            return data;
        }
    }
}