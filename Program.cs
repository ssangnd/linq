namespace linq
{

    public class Brand
    {
        public string Name { set; get; }
        public int ID { set; get; }
    }
    public class Product
    {
        public int ID { set; get; }
        public string Name { set; get; }         // tên
        public double Price { set; get; }        // giá
        public string[] Colors { set; get; }     // các màu sắc
        public int Brand { set; get; }           // ID Nhãn hiệu, hãng
        public Product(int id, string name, double price, string[] colors, int brand)
        {
            ID = id; Name = name; Price = price; Colors = colors; Brand = brand;
        }
        // Lấy chuỗi thông tin sản phẳm gồm ID, Name, Price
        override public string ToString()
           => $"{ID,3} {Name,12} {Price,5} {Brand,2} {string.Join(",", Colors)}";

    }
    class Program
    {
        static void Main(string[] args)
        {
            var brands = new List<Brand>() {
            new Brand{ID = 1, Name = "Công ty AAA"},
            new Brand{ID = 2, Name = "Công ty BBB"},
            new Brand{ID = 4, Name = "Công ty CCC"},
        };

            var products = new List<Product>()
        {
            new Product(1, "Bàn trà",    400, new string[] {"Xám", "Xanh"},         2),
            new Product(2, "Tranh treo", 400, new string[] {"Vàng", "Xanh"},        1),
            new Product(3, "Đèn trùm",   500, new string[] {"Trắng"},               3),
            new Product(4, "Bàn học",    200, new string[] {"Trắng", "Xanh"},       1),
            new Product(5, "Túi da",     300, new string[] {"Đỏ", "Đen", "Vàng"},   2),
            new Product(6, "Giường ngủ", 500, new string[] {"Trắng"},               2),
            new Product(7, "Tủ áo",      600, new string[] {"Trắng"},               3),
        };
            int[] numbers={1,2,3,4,5,6,7,8};
            
            //Single SingleOrDefault
            //Single ktra cac phan tu thoa man dk neu co 1 kq thoa man dk logic thi tra ve phan tu do
            //neu ko co hoac co nhieu hon 1 phan tu thoa man dk logic => phat sinh loi
            
            var product= products.Single(p=>p.Price==600);// neu co 2 cai 400 phat sinh loi
            //Console.WriteLine(product);

            //TH ko muon phat sinh loi
            var productDefault=products.SingleOrDefault(p=>p.Price==120);
            //TH tim thay nhung nhieu loi
    
            // Console.WriteLine(productDefault);
            
            //Any tra ve true neu thoa man dk logic
            var p=products.Any(p=>p.Price==700);
            // Console.WriteLine(p);
            //All tra ve bool neu thoa man cac dk logic
            var pAll=products.All(p=>p.Price>0);
            // Console.WriteLine(pAll);

            //Count
            var pCount=products.Count(p=>p.Price>=200);
            Console.WriteLine(pCount);

        }
    }
}

