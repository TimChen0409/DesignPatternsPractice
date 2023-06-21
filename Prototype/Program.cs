namespace Prototype
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BaskerballStore.InitBasketballProducts();
            var b1 = BaskerballStore.GetBasketball("Nike400");
            var b2 = BaskerballStore.GetBasketball("Molten7");
            var b3 = BaskerballStore.GetBasketball("Molten9"); //不存在
        }
    }

    public abstract class Basketball
    {
        public string Brand { get; set; }
        public int Size { get; set; }
        public double Weight { get; set; }
        public string MadeIn { get; set; }
        public abstract Basketball Clone();
    }

    public class M7Basketball : Basketball
    {
        public override Basketball Clone()
        {
            Console.WriteLine($"Cloning BasketBall: 品牌: {Brand}, 尺寸: {Size}, 重量: {Weight}, 產地: {MadeIn} ");
            return (Basketball)MemberwiseClone();
        }
    }

    public class Nike400Basketball : Basketball
    {
        public override Basketball Clone()
        {
            Console.WriteLine($"Cloning BasketBall: 品牌: {Brand}, 尺寸: {Size}, 重量: {Weight}, 產地: {MadeIn} ");
            return (Basketball)MemberwiseClone();
        }
    }

    public class BaskerballStore
    {
        private static readonly Dictionary<string, Basketball> _basketballProduct = new Dictionary<string, Basketball>();

        public static Basketball GetBasketball(string model)
        {
            if (_basketballProduct.ContainsKey(model))
            {
                Basketball b = _basketballProduct[model];
                return b.Clone();
            }
            else {
                Console.WriteLine("找不到該型號，所以回傳預設的Nike400");
                Basketball b = _basketballProduct["Nike400"];
                return b.Clone();
            }
        }

        public static void InitBasketballProducts()
        {
            Nike400Basketball b1 = new Nike400Basketball() { Brand = "Nike", Size = 4, Weight = 280.5, MadeIn = "Taiwan" };
            _basketballProduct.Add("Nike400", b1);
            M7Basketball b2 = new M7Basketball() { Brand = "Molten", Size = 7, Weight = 290.0, MadeIn = "Japan" };
            _basketballProduct.Add("Molten7", b2);
        }
    }
}