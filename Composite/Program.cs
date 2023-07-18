namespace Composite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var shoppingCartService = new ShoppingCartService();
            shoppingCartService.AddCart(new MacBookPro());
            shoppingCartService.AddCart(new IPadAir());
            shoppingCartService.AddCart(new AppleWatch());
            shoppingCartService.AddCart(new AppleBundle());

            var total = shoppingCartService.CalculatePrice();
            Console.WriteLine($"總和：{total}");
        }
    }

    public interface IPrice
    {
        double GetPrice();
    }

    public class MacBookPro : IPrice
    {
        private const double Price = 60000.0;
        public double GetPrice()
        {
            return Price;
        }
    }

    public class IPadAir : IPrice
    {
        private const double Price = 12000.0;
        public double GetPrice()
        {
            return Price;
        }
    }

    public class AppleWatch : IPrice
    {
        private const double Price = 10000.0;
        public double GetPrice()
        {
            return Price;
        }
    }

    public class AppleBundle : IPrice
    {
        private const double Discount = 0.9;
        private readonly List<IPrice> _products;
        public AppleBundle()
        {
            _products = new List<IPrice>
            {
                new MacBookPro(),
                new IPadAir(),
                new AppleWatch()
            };
        }

        public double GetPrice()
        {
            return Discount * _products.Sum(product => product.GetPrice());
        }
    }

    public class ShoppingCartService
    {
        private readonly List<IPrice> _carts = new List<IPrice>();
        public void AddCart(IPrice product)
        {
            _carts.Add(product);
        }

        public double CalculatePrice()
        {
            return _carts.Sum(product => product.GetPrice());
        }
    }
}