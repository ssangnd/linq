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
            //join
            //moi sp lay ra ten sp, hang sx, 
            //nguon join vs tham so dau tien la nguon ket hop, thu 2 la du lieu nao trong product de ket hop
            //du lieu nao trong nguon tham so thu nhat de ket hop
            
            // var query=products.Join(brands, p=>p.Brand, b=>b.ID,(p,b)=>{
            //     return new {
            //         Ten=p.Name,
            //         Thuonghieu=b.Name,
            //     };
            // });
            
            // foreach(var item in query){
            //     Console.WriteLine(item);
            // }

            //GroupJoin

            var query=brands.GroupJoin(products,b=>b.ID, p=>p.Brand, (brand, product)=>{
                return new {
                    Thuonghieu= brand.Name,
                    Cacsanpham=product,
                };
            });

            foreach (var item in query)
            {
                Console.WriteLine(item.Thuonghieu);
                foreach (var p in item.Cacsanpham)
                {
                    Console.WriteLine(p);
                }
            }
        }
    }
}

