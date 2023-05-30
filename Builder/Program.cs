namespace Builder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MilkteaDirector director = new MilkteaDirector(new OolongMilkteaBuilder());
            director.MakeMiketea();
            director.ChangeBuilder(new GreenMilkteaBuilder());
            director.MakeMiketea();
            director.Make("oolong");
            director.Make("greenTea");

            CustomizedMilkteaBuilder builder = new CustomizedMilkteaBuilder();
            builder.Reset();
            builder.AddTopping("boba");
            builder.AddTea("Oolong");
            builder.AddSuger(10);
            builder.AddIce("A little");
            builder.GetMilktea();
        }
    }

    class Milktea
    {
        public double Price { get; set; } = 7.0;
        public string Topping { get; set; } = "boba";
        public string Tea { get; set; } = "regularMilkTea";
        public int Suger { get; set; } = 100;
        public string Ice { get; set; } = "Normal";
    }

    class OolongMilktea : Milktea
    {
        public OolongMilktea()
        {
            Price = 15.0;
        }
    }

    class GreenMilktea : Milktea
    {
        public GreenMilktea()
        {
            Price = 12.0;
        }
    }

    interface IMilkteaBuilder
    {
        void Reset();
        void AddTopping();
        void AddTea();
        void AddIce();
        void AddSuger();
        Milktea GetMilktea();
    }

    class OolongMilkteaBuilder : IMilkteaBuilder
    {
        public OolongMilktea Product { get; set; }
        public void Reset()
        {
            Product = new OolongMilktea();
        }

        public void AddTopping()
        {
            Product.Topping = "Boba";
        }

        public void AddIce()
        {
            Product.Ice = "Less";
        }

        public void AddSuger()
        {
            Product.Suger = 100;
        }

        public void AddTea()
        {
            Product.Tea = "Oolong";
        }

        public Milktea GetMilktea()
        {
            Console.WriteLine($"OolongTea :{Product.Tea},{Product.Topping},{Product.Ice},{Product.Suger}");
            return Product;
        }
    }

    class GreenMilkteaBuilder : IMilkteaBuilder
    {
        public GreenMilktea Product { get; set; }
        public void Reset()
        {
            Product = new GreenMilktea();
        }

        public void AddTopping()
        {
            Product.Topping = "Coconut jelly";
        }

        public void AddIce()
        {
            Product.Ice = "Normal";
        }

        public void AddSuger()
        {
            Product.Suger = 50;
        }

        public void AddTea()
        {
            Product.Tea = "Greentea";
        }

        public Milktea GetMilktea()
        {
            Console.WriteLine($"Greentea :{Product.Tea},{Product.Topping},{Product.Ice},{Product.Suger}");
            return Product;
        }
    }

    class CustomizedMilkteaBuilder
    {
        public Milktea Product { get; set; }
        public void Reset()
        {
            Product = new Milktea();
        }
        public void AddTopping(string boba)
        {
            Product.Topping = boba;
        }
        public void AddTea(string tea)
        {
            Product.Tea = tea;
        }
        public void AddSuger(int sugar)
        {
            Product.Suger = sugar;
        }

        public void AddIce(string ice)
        {
            Product.Ice = ice;
        }

        public Milktea GetMilktea()
        {
            Console.WriteLine($"CustomizedMilktea :{Product.Tea},{Product.Topping},{Product.Ice},{Product.Suger}");
            return Product;
        }
    }

    class MilkteaDirector
    {
        private IMilkteaBuilder milkteaBuilder;

        public MilkteaDirector(IMilkteaBuilder builder)
        {
            milkteaBuilder = builder;
        }

        public void ChangeBuilder(IMilkteaBuilder builder)
        {
            milkteaBuilder = builder;
        }

        public Milktea MakeMiketea()
        {
            milkteaBuilder.Reset();
            milkteaBuilder.AddTopping();
            milkteaBuilder.AddTea();
            milkteaBuilder.AddIce();
            milkteaBuilder.AddSuger();
            return milkteaBuilder.GetMilktea();
        }

        public Milktea Make(string type)
        {
            if (type == "oolong")
            {
                ChangeBuilder(new OolongMilkteaBuilder());
            }
            else if (type == "greenTea")
            {
                ChangeBuilder(new GreenMilkteaBuilder());

            }
            return MakeMiketea();
        }
    }
}