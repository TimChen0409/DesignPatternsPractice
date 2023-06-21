namespace Singleton
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomerServiceCenter service1 = CustomerServiceCenter.GetInstance();
            service1.ServeCustomer();
            CustomerServiceCenter service2 = CustomerServiceCenter.GetInstance();
            service2.ServeCustomer();

            service2.SetIsMorning(true);
            Console.WriteLine("--白天了--");

            service1.ServeCustomer();
            service2.ServeCustomer();
        }
    }

    sealed class CustomerServiceCenter
    {
        private static CustomerServiceCenter? _instance = null;
        private bool isMorning;
        private List<Worker> morningWorkers;
        private List<Worker> nightWorkers;

        private CustomerServiceCenter()//禁止外部直接實體化該物件
        {
            isMorning = false;
            morningWorkers = new List<Worker>() {
                new Worker() { Name = "morningWorker1" },
                new Worker() { Name = "morningWorker2" }
            };

            nightWorkers = new List<Worker>() {
                new Worker() { Name = "nightWorker1" },
                new Worker() { Name = "nightWorker1" }
            };
        }
        public static CustomerServiceCenter GetInstance()
        {
            if (_instance == null)
            {
                _instance = new CustomerServiceCenter();
            }
            return _instance;
        }

        public void SetIsMorning(bool isMorning)
        {
            this.isMorning = isMorning;
        }

        public void ServeCustomer()
        {
            if (isMorning)
            {
                foreach (var worker in morningWorkers)
                {
                    worker.ServeCustomer();
                }
            }
            else
            {
                foreach (var worker in nightWorkers)
                {
                    worker.ServeCustomer();
                }
            }
        }
    }

    class Worker
    {
        public string Name { get; set; }
        public void ServeCustomer()
        {
            Console.WriteLine(Name + " 正在工作");
        }
    }
}