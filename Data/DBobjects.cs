using OnlineStore.Data.Models;

namespace OnlineStore.Data
{
    public class DBobjects
    {
        private static Dictionary<string, Category> categories;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if(categories is null)
                {
                    var list = new List<Category> 
                    {
                        new Category() { Id = Guid.NewGuid(), Name = "Toys"},
                        new Category() { Id = Guid.NewGuid(), Name = "Clothes"},
                        new Category() { Id = Guid.NewGuid(), Name = "Bags"},
                        new Category() { Id = Guid.NewGuid(), Name = "KitchenUtensils"}
                    };

                    categories = new Dictionary<string, Category>();

                    foreach(Category c in list)
                    {
                        categories.Add(c.Name, c);
                    }
                }

                return categories;
            }
        }

        public static void Initial(ApplicationDBContent content)
        {
            if(!content.Category.Any())
            {
                content.Category.AddRange(Categories.Select(c => c.Value));
            }

            if(!content.Good.Any())
            {
                content.Good.AddRange(new List<Good>() 
                {
                    new Good() 
                    {
                        Id = Guid.NewGuid(),
                        Name = "Bag ball",
                        Price = 20,
                        LongDescription = "Baseball bag. Manufactured by Nike. A good gift for lovers of unusual things.",
                        ShortDescription = "Beautiful bag with baseball sword design.",
                        Image = "/img/bag ball.jpg",
                        Availible = true,
                        CategoryId = Categories["Bags"].Id,
                        Category = Categories["Bags"]
                    },
                    new Good()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Black hoodie",
                        Price = 13,
                        LongDescription = "Huge black hoodie. Quality material and pleasant to the touch.",
                        ShortDescription = "Cotton thick hoodie.",
                        Image = "/img/black hoodie.jpg",
                        Availible = true,
                        CategoryId = Categories["Clothes"].Id,
                        Category = Categories["Clothes"]
                    },
                    new Good()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Green hoodie",
                        Price = 13,
                        LongDescription = "Hoodie with double material. Light sleeves and pleasant cotton material.",
                        ShortDescription = "Cotton thick hoodie.",
                        Image = "/img/green hoodie.jpg",
                        Availible = true,
                        CategoryId = Categories["Clothes"].Id,
                        Category = Categories["Clothes"]
                    },
                    new Good()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Long cat",
                        Price = 10,
                        LongDescription = "Plush cat toy. Can be used as pillows or huggable items. The fabric is pleasant to the touch.",
                        ShortDescription = "Soft pillow toy.",
                        Image = "/img/long cat.jpg",
                        Availible = true,
                        CategoryId = Categories["Toys"].Id,
                        Category = Categories["Toys"]
                    },
                    new Good()
                    {
                        Id = Guid.NewGuid(), 
                        Name = "Mug with a snake",
                        Price = 6,
                        LongDescription = "Cup with snakes instead of a handle. Sturdy material, cute design and comfortable fit.",
                        ShortDescription = "Handmade cup with beautiful design.",
                        Image = "/img/mug with a snake.jpg",
                        Availible = true,
                        CategoryId = Categories["KitchenUtensils"].Id,
                        Category = Categories["KitchenUtensils"]
                    },
                    new Good()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Pink bag",
                        Price = 15,
                        LongDescription = "Miniature women's bag. The pair comes with several straps for comfortable wear. Suitable for any day.",
                        ShortDescription = "Women's joy for every day.",
                        Image = "/img/pink bag.jpg",
                        Availible = true,
                        CategoryId = Categories["Bags"].Id,
                        Category = Categories["Bags"]
                    },
                    new Good()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Pink hoodie",
                        Price = 12,
                        LongDescription = "Thick fabric hoodie. Consists mainly of cotton. Beautiful colour.",
                        ShortDescription = "Cotton thick hoodie.",
                        Image = "/img/pink hoodie.jpg",
                        Availible = true,
                        CategoryId = Categories["Clothes"].Id,
                        Category = Categories["Clothes"]
                    },
                    new Good()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Purpule bag",
                        Price = 21,
                        LongDescription = "Nice purple bag. Minimalistic design. The chain has a soft style and is perfect for comfortable wear.",
                        ShortDescription = "Bag with a chain and a beautiful design.",
                        Image = "/img/purpule bag.jpg",
                        Availible = true,
                        CategoryId = Categories["Bags"].Id,
                        Category = Categories["Bags"]
                        },
                    new Good()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Small cat",
                        Price = 9,
                        LongDescription = "Funny cute pillow cat. Compact format. Suitable for children and adults.",
                        ShortDescription = "Small round cat toy.",
                        Image = "/img/small cat.jpg",
                        Availible = true,
                        CategoryId = Categories["Toys"].Id,
                        Category = Categories["Toys"]
                    },
                    new Good()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Teapot",
                        Price = 11,
                        LongDescription = "Unusual teapot for a feast. Good for lemon tea. Material ceramics.",
                        ShortDescription = "Ceramic teapot in the form of a lemon.",
                        Image = "/img/teapot.jpg",
                        Availible = true,
                        IsFavourite = true,
                        CategoryId = Categories["KitchenUtensils"].Id,
                        Category = Categories["KitchenUtensils"]
                    },
                    new Good()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Yellow hoodie_",
                        Price = 14,
                        LongDescription = "Thick fabric hoodie. Consists mainly of cotton. Beautiful colour.",
                        ShortDescription = "Cotton thick hoodie.",
                        Image = "/img/yellow hoodie_.jpg",
                        Availible = true,
                        IsFavourite = true,
                        CategoryId = Categories["Clothes"].Id,
                        Category = Categories["Clothes"]
                    },
                    new Good()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Yellow mug",
                        Price = 5,
                        LongDescription = "A yellow mug with processes in the form of the eyes of the abyss. Craftsmanship using quality materials.",
                        ShortDescription = "Mug with black eye design.",
                        Image = "/img/yellow mug.jpg",
                        Availible = true,
                        IsFavourite = true,
                        CategoryId = Categories["KitchenUtensils"].Id,
                        Category = Categories["KitchenUtensils"]
                    },
                });
            }

            content.SaveChanges();
        }
    }
}