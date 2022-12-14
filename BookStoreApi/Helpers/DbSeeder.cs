using BookStoreApi.Contexts;
using BookStoreApi.Entities;
using static System.Reflection.Metadata.BlobBuilder;

namespace BookStoreApi.Helpers
{
    public class DbSeeder
    {
        private readonly AppDbContext _appContext;
        public DbSeeder(AppDbContext appContext)
        {
            _appContext = appContext ?? throw new ArgumentNullException(nameof(appContext));
        }

        public void Seed()
        {
            if (!_appContext.Authors.Any())
            {
                var author = new Author()
                {
                    Id = Guid.Parse("97893410-5B03-4766-BA29-F6D6CB7B01A7"),
                    FirstName = "Martin",
                    LastName = "Fowler",
                    Books = new List<Book>()
                                {
                                    new Book()
                                    {
                                        Id = Guid.Parse("863117BB-62AD-4A22-85FA-6E8A5F89D855"),
                                        Title = "Being Ironman",
                                        Description = "Tony Stark",
                                        Price = 29.99M,
                                        AuthorId = Guid.Parse("97893410-5B03-4766-BA29-F6D6CB123456"),
                                        Author = new Author()
                                    },
                                    new Book()
                                    {
                                        Id = Guid.Parse("D77ACBDD-0675-48D0-A16D-347777924AB5"),
                                        Title = "Domain Specific Languages",
                                        Description = "Martin Fowler",
                                        Price = 45.29M,
                                        AuthorId = Guid.Parse("97893410-5B03-4766-BA29-F6D6CB654321"),
                                        Author = new Author()
                                    },
                                    new Book()
                                    {
                                        Id = Guid.Parse("F88ACBDD-0676-48D0-A16D-348888924BA6"),
                                        Title = "Being Spiderman",
                                        Description = "Peter Parker",
                                        Price = 64.84M,
                                        AuthorId = Guid.Parse("97893410-5B03-4766-BA29-F6D6CB7B01A7"),
                                        Author = new Author()
                                    }                    }

                };
                _appContext.Authors.Add(author);
            }
            
            _appContext.SaveChanges();
        }
    }
}
