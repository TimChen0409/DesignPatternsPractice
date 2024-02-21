using System.Drawing;

namespace Flyweight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var treeFactory = new TreeFactory();
            var forest = new Forest(treeFactory);

            forest.PlantTree("Oak", KnownColor.Brown, "Oak texture", 10.0, 12.0);
            forest.PlantTree("Oak", KnownColor.Brown, "Oak texture", 5.0, -77.4);
            forest.PlantTree("Maple", KnownColor.Brown, "Maple texture", 171.0, -28.7);
            forest.PlantTree("Birch", KnownColor.White, "Birch texture", 55.0, 15.0);
            forest.PlantTree("Willow", KnownColor.Brown, "Willow texture", -33.6, 12.2);
            forest.PlantTree("Oak", KnownColor.Brown, "Oak texture", 77.1, 18.8);

            Console.WriteLine();
            forest.Render();
            Console.ReadLine();
        }
    }

    /// <summary>
    /// 享元工廠決定是重複使用現有的享元還是建立新物件
    /// </summary>
    public class TreeFactory
    {
        private readonly Dictionary<string, TreeType> _treeTypes;
        public TreeFactory()
        {
            _treeTypes = new Dictionary<string, TreeType>();
        }

        public TreeType GetTreeType(string name, KnownColor color, string texture)
        {
            var key = GetTreeTypeKey(name, color, texture);

            if (_treeTypes.TryGetValue(key, out var treeType))
            {
                Console.WriteLine($"Returning already initialized {name} tree with {color} color and {texture} from the tree factory...");
                return treeType;
            }

            treeType = new TreeType(name, color, texture);
            _treeTypes.Add(key, treeType);
            Console.WriteLine($"Registered new type: {name} tree with {color} color and {texture}");

            return treeType;
        }

        private static string GetTreeTypeKey(string name, KnownColor color, string texture) => $"{name}-{color}-{texture}";
    }

    public class TreeType(string name, KnownColor color, string texture)
    {
        public string Name { get; } = name;
        public KnownColor Color { get; } = color;
        public string Texture { get; } = texture;

        public void Render(double latitude, double longitude) =>
            Console.WriteLine($"{Name} tree with {Color} color and {Texture} is rendered " + $"at coordinates ({latitude}, {longitude})");
    }

    public class Forest(TreeFactory treeFactory)
    {
        private readonly TreeFactory _treeFactory = treeFactory;
        private readonly List<Tree> _trees = new List<Tree>();

        public void PlantTree(string name, KnownColor color, string texture, double latitude, double longitude)
        {
            var treeType = _treeFactory.GetTreeType(name, color, texture);
            var tree = new Tree(latitude, longitude, treeType);

            _trees.Add(tree);
        }

        public void Render()
        {
            foreach (var tree in _trees)
            {
                tree.Render();
            }
        }
    }

    public class Tree(double latitude, double longitude, TreeType treeType)
    {
        public double Latitude { get; } = latitude;
        public double Longitude { get; } = longitude;
        public TreeType TreeType { get; } = treeType;

        public void Render() => TreeType.Render(Latitude, Longitude);
    }
}
