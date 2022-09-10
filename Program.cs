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
            //take
            // products.Take(4).ToList().ForEach(p=>Console.WriteLine(p));

            //skip 
            //bo di cac phan tu dau tien lay di cac phan tu con lai
            
            // products.Skip(2).ToList().ForEach(p=>Console.WriteLine(p));

            //sort
            //OrderBy /OrderByDescending (max=>min)

            // products.OrderBy(p=>p.Price).ToList().ForEach(p=>Console.WriteLine(p));
            // products.OrderByDescending(p=>p.Price).ToList().ForEach(p=>Console.WriteLine(p));

            //reverse

            // numbers.Reverse().ToList().ForEach(n=>Console.WriteLine(n));

            // GroupBY
            //moi phan tu theo nhom
            //nhom cac san pham theo gia
            //voi moi phan tu trong product
            // var query =products.GroupBy(p=>p.Price);
            // foreach(var group in query){
            //     Console.WriteLine(group.Key);//key dung de nhom
            //     foreach (var item in group)
            //     {
            //         Console.WriteLine(item);
            //     }
            // }

            //Distinct
            //loai bo cung gia tri neu trung chi giu lay 1
            //lay mau sac cua cac sp
            var result= products.SelectMany(p=>p.Colors).Distinct().ToList();
            foreach(var item in result){
                Console.WriteLine(item);
            }

            
        }
    }
}

