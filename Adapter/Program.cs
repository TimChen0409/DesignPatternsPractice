namespace Adapter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var f = new Fahrenheit(87.8);
            ICelsius FahrenheitToCelsiusAdapter = new FahrenheitToCelsiusAdapter(f);
            Console.WriteLine("Output攝氏溫度：" + FahrenheitToCelsiusAdapter.GetCTemperature());
        }
    }

    public interface ICelsius
    {
        double GetCTemperature();
    }

    class FahrenheitToCelsiusAdapter : ICelsius
    {
        private readonly Fahrenheit fahrenheit;

        public FahrenheitToCelsiusAdapter(Fahrenheit fahrenheit)
        {
            this.fahrenheit = fahrenheit;
        }

        public double GetCTemperature()
        {
            Console.WriteLine("Input華氏溫度：" + fahrenheit.GetFTemperature());
            return (fahrenheit.GetFTemperature() - 32) * 5 / 9;
        }
    }

    class Fahrenheit
    {
        private readonly double temperature;

        public Fahrenheit(double temperature)
        {
            this.temperature = temperature;
        }

        public double GetFTemperature()
        {
            return temperature;
        }
    }
}