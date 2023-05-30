namespace FactoryMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var carStorage = new CarStorage();
            carStorage.ImportCars();
        }
    }

    public class CarStorage
    {
        List<Car> Storage { get; set; } = new List<Car>();
        public void ImportCars()
        {
            var factoryX = new ModelXFactory();
            var factoryY = new ModelYFactory();
            for (int i = 0; i < 5; i++)
            {
                Storage.Add(factoryX.MakeCar());
            }
            for (int i = 5; i < 10; i++)
            {
                Storage.Add(factoryY.MakeCar());
            }
        }
    }

    abstract class Car
    {
        public abstract void TurnOnEngine();
        public abstract void TurnOffEngine();
    }

    class ModelX : Car
    {
        public override void TurnOnEngine() => Console.WriteLine("ModelX TurnOnEngine");
        public override void TurnOffEngine() => Console.WriteLine("ModelX turnOffEngine");
    }

    class ModelY : Car
    {
        public override void TurnOnEngine() => Console.WriteLine("ModelY TurnOnEngine");
        public override void TurnOffEngine() => Console.WriteLine("ModelY turnOffEngine");
    }

    abstract class CarFactory
    {
        public abstract Car MakeCar();
    }

    class ModelXFactory : CarFactory
    {
        public override Car MakeCar()
        {
            Car modelX = new ModelX();
            modelX.TurnOnEngine();
            modelX.TurnOffEngine();
            return modelX;
        }
    }

    class ModelYFactory : CarFactory
    {
        public override Car MakeCar()
        {
            Car modelY = new ModelY();
            modelY.TurnOnEngine();
            modelY.TurnOffEngine();
            return modelY;
        }
    }
}