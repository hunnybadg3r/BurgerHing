using BurgerHing.Support.Local.Models;

namespace BurgerHing.Support.Local.Services
{
    public interface IMenuService
    {
        List<MenuItemInfo> GetMenuItems(string category);
    }

    public class MenuService : IMenuService
    {
        public List<MenuItemInfo> GetMenuItems(string category)
        {
            if (category == "Burger")
            {
                return GetMainMenu();
            }
            else if (category == "Beverages")
            {
                return GetBeveragesMenu();
            }
            else if (category == "Salads")
            {
                return GetSaladsMenu();
            }
            else if (category == "Chicken")
            {
                return GetChickenMenu();
            }
            else if (category == "Dessert")
            {
                return GetDessertMenu();
            }
            else if (category == "Sides")
            {
                return GetSidesMenu();
            }
            else
            {
                throw new ArgumentNullException($"Category {category} is not exist.");
            }
        }
        private List<MenuItemInfo> GetSaladsMenu()
        {
            return new List<MenuItemInfo>
            {
                new MenuItemInfo
                {
                    Category = "Salads",
                    Order = 0,
                    Name = "Salad",
                    Description = "Come enjoy our salad bowl with special sauce on its own or as a healthy swap with your next BH meal!",
                    ImagePath = "pack://application:,,,/Assets/Salads/salad.png",
                    Price = 6400
                },
            };
        }

        private List<MenuItemInfo> GetChickenMenu()
        {
             return new List<MenuItemInfo>
            {
                new MenuItemInfo
                {
                    Category = "Chicken",
                    Order = 0,
                    Name = "Crispy Fried Chicken 2Pcs",
                    Description = "Indulge in 2 pieces of our signature crispy fried chicken, bursting with flavor.",
                    ImagePath = "pack://application:,,,/Assets/Sides/crispy-fried-chicken.png",
                    Price = 3800
                },
            };
        }

        private List<MenuItemInfo> GetBeveragesMenu()
        {
            return new List<MenuItemInfo>
            {
                new MenuItemInfo
                {
                    Category = "Beverages",
                    Order = 0,
                    Name = "Soft Drink",
                    Description = "Choose your preferred soft drink and enjoy the freedom to dispense it yourself.",
                    ImagePath = "pack://application:,,,/Assets/Beverages/soft-drink.png",
                    Price = 2200
                },
                new MenuItemInfo
                {
                    Category = "Beverages",
                    Order = 1,
                    Name = "Hot Tea",
                    Description = "Delight in a comforting cup of hot Lipton tea, perfect for any time of day.",
                    ImagePath = "pack://application:,,,/Assets/Beverages/hot-tea.png",
                    Price = 2800
                },
                new MenuItemInfo
                {
                    Category = "Beverages",
                    Order = 2,
                    Name = "Ice Milo",
                    Description = "Indulge in the refreshing taste of Ice Milo, a delightful blend of chocolate and malt served over ice.",
                    ImagePath = "pack://application:,,,/Assets/Beverages/ice-milo.png",
                    Price = 3000
                },
            };
        }

        private List<MenuItemInfo> GetDessertMenu()
        {
            return new List<MenuItemInfo>
            {
                new MenuItemInfo
                {
                    Category = "Dessert",
                    Order = 0,
                    Name = "Apple Pie",
                    Description = "Savor the classic taste of our homemade apple pie, filled with sweet, cinnamon-spiced apples and encased in a flaky pastry crust.",
                    ImagePath = "pack://application:,,,/Assets/Dessert/apple-pie.png",
                    Price = 1600
                },
                new MenuItemInfo
                {
                    Category = "Dessert",
                    Order = 1,
                    Name = "Chocolate Sundae",
                    Description = "Delight in decadence with our irresistible chocolate sundae, featuring creamy vanilla ice cream accompanied by rich chocolate syrup.",
                    ImagePath = "pack://application:,,,/Assets/Dessert/chocolate-sundae.png",
                    Price = 2400
                },
            };
        }

        private List<MenuItemInfo> GetSidesMenu()
        {
            return new List<MenuItemInfo>
            {
                new MenuItemInfo
                {
                    Category = "Sides",
                    Order = 0,
                    Name = "French Fries",
                    Description = "Enjoy our delicious French fries made from locally sourced Gangwon Province potatoes.",
                    ImagePath = "pack://application:,,,/Assets/Sides/french-fries.png",
                    Price = 1800
                },
                new MenuItemInfo
                {
                    Category = "Sides",
                    Order = 1,
                    Name = "Nuggets 6Pcs",
                    Description = "Treat yourself to 6 pieces of crispy and savory chicken nuggets.",
                    ImagePath = "pack://application:,,,/Assets/Sides/nuggets-6pcs.png",
                    Price = 3000
                },
                new MenuItemInfo
                {
                    Category = "Sides",
                    Order = 2,
                    Name = "Onion Ring 5Pcs",
                    Description = "Savor the crispy goodness of 5 pieces of golden-brown onion rings, made with premium onions from Muan, emphasizing their quality and flavor.",
                    ImagePath = "pack://application:,,,/Assets/Sides/onion-ring-5pcs.png",
                    Price = 2600
                },
            };
        }

        private List<MenuItemInfo> GetMainMenu()
        {
            return new List<MenuItemInfo>
            {
                new MenuItemInfo
                {
                    Category = "Burger",
                    Order = 0,
                    Name = "Wowpper",
                    Description = "A flame-grilled beef patty, topped with tomatoes, fresh cut lettuce, mayo, pickles, a swirl of ketchup, and sliced onions on a soft sesame seed bun.",
                    ImagePath = "pack://application:,,,/Assets/Burger/wowpper.png",
                    Price = 7100
                },
                new MenuItemInfo
                {
                    Category = "Burger",
                    Order = 1,
                    Name = "Double Double",
                    Description = "Bacon, cheese, patty, cheese, patty",
                    ImagePath = "pack://application:,,,/Assets/Burger/double-double-bacon.png",
                    Price = 7700
                },
                new MenuItemInfo
                {
                    Category = "Burger",
                    Order = 2,
                    Name = "Grilled Chicken",
                    Description = "Tender chicken breast sandwich with crispy lettuce and mayo.",
                    ImagePath = "pack://application:,,,/Assets/Burger/grilled-chicken.png",
                    Price = 7100
                },
                new MenuItemInfo
                {
                    Category = "Burger",
                    Order = 3,
                    Name = "Double Double Onion Ring",
                    Description = "Onion Ring, Bacon, cheese, patty, cheese, patty",
                    ImagePath = "pack://application:,,,/Assets/Burger/double-onion-cheese.png",
                    Price = 9400
                },
                new MenuItemInfo
                {
                    Category = "Burger",
                    Order = 4,
                    Name = "Bacon Cheese",
                    Description = "Bacon Cheese",
                    ImagePath = "pack://application:,,,/Assets/Burger/bacon-cheese.png",
                    Price = 8700
                },
                new MenuItemInfo
                {
                    Category = "Burger",
                    Order = 5,
                    Name = "Premium Bacon Cheese",
                    Description = "I AM WEALTHY.\nI’d like my burger all the way.",
                    ImagePath = "pack://application:,,,/Assets/Burger/premium-bacon-cheese.png",
                    Price = 10900
                },
                new MenuItemInfo
                {
                    Category = "Burger",
                    Order = 6,
                    Name = "Dummy",
                    Description = "For testing scrolling behavior",
                    ImagePath = "pack://application:,,,/Assets/Burger/premium-bacon-cheese.png",
                    Price = 12900
                },
                new MenuItemInfo
                {
                    Category = "Burger",
                    Order = 7,
                    Name = "Long Description Dummy",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text",
                    ImagePath = "pack://application:,,,/Assets/Burger/premium-bacon-cheese.png",
                    Price = 13900
                },
            };
        }
    }
}