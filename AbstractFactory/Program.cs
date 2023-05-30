namespace AbstractFactory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GetDrink(new CocoDrinkFactory());
            GetDrink(new FiftyBlueDrinkFactory());
        }

        static void GetDrink(IDrinkFactory factory)
        {
            var blackTea = factory.CreateBlackTea();
            var milkTea = factory.CreateMilkTea();
            blackTea.CreateProduct();
            milkTea.CreateProduct();
        }
    }

    interface IBlackTea
    {
        void CreateProduct();
    }

    interface IMikeTea
    {
        void CreateProduct();
    }

    class CocoBlackTea : IBlackTea
    {
        public void CreateProduct() => Console.WriteLine("Coco blackTea create");
    }

    class CocoMikeTea : IMikeTea
    {
        public void CreateProduct() => Console.WriteLine("Coco mikeTea create");
    }

    class FiftyBlueBlackTea : IBlackTea
    {
        public void CreateProduct() => Console.WriteLine("FiftyBlue blackTea create");
    }

    class FiftyBlueMikeTea : IMikeTea
    {
        public void CreateProduct() => Console.WriteLine("FiftyBlue mikeTea create");
    }

    interface IDrinkFactory
    {
        IBlackTea CreateBlackTea();
        IMikeTea CreateMilkTea();
    }

    class CocoDrinkFactory : IDrinkFactory
    {
        public IBlackTea CreateBlackTea() => new CocoBlackTea();
        public IMikeTea CreateMilkTea() => new CocoMikeTea();
    }

    class FiftyBlueDrinkFactory : IDrinkFactory
    {
        public IBlackTea CreateBlackTea() => new FiftyBlueBlackTea();
        public IMikeTea CreateMilkTea() => new FiftyBlueMikeTea();
    }
}