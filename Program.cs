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
            
            //In ra ten sp, ten thuong hieu, co gia (300-400) gia giam dan
        //   products.Where(p=>p.Price>=300 && p.Price<=400).OrderByDescending(p=>p.Price)
        //     .Join(brands, p=>p.Brand, b=>b.ID, (p,b)=>{
        //         return new {
        //             Ten=p.Name,
        //             ThuongHieu=b.Name
        //         };
        //     }).ToList().ForEach(x=>Console.WriteLine(x));

            /*
                1) Xac dinh nguon: from tenphantu in IEnumerable (array, list)
                ...Where, order by
                2) Lay du lieu ra: select, group by...
            */
            
            //lay ten cac sp
            // var query= from p in products select p.Name;
            // query.ToList().ForEach(x=>Console.WriteLine(x));
            // foreach(var name in query){
            //     Console.WriteLine(name);
            // }

            //tra ve chuoi 
            // var query=from p in products select $"{p.Name} {p.Price}";
            // query.ToList().ForEach(name=>Console.WriteLine(name));

            //tra ve phan tu phuc tap kieu vo danh 
            // var query=from p in products select new{
            //         Ten=p.Name,
            //         Price=p.Price,
            //         Abc="afe",
            // };
            // query.ToList().ForEach(x=>Console.WriteLine(x));

            //Hay lay ra cac sp co price 400

            // var query=from p in products 
            //         where p.Price<400 
            //         select new {
            //             Ten=p.Name,
            //             Price=p.Price,
            //          };
            // query.ToList().ForEach(p=>Console.WriteLine(p));
            //Nhieu nguon nhieu from
            //Gia <=500, mau xanh

            // var query=from p in products 
            //             from c in p.Colors
            //         where p.Price<=500 && c=="Xanh"
            //         orderby p.Price descending
            //         select new {
            //             Ten=p.Name,
            //             Gia=p.Price,
            //             CacMau=p.Colors,
            //         };
            // query.ToList().ForEach(p=>{
            //     Console.WriteLine(p.Ten +" - "+p.Gia);
            //     Console.WriteLine(string.Join(", ",p.CacMau));
            // });


            //Nhom sp theo gia
        
            // var query=from p in products 
            //         group p by  p.Price;
            // query.ToList().ForEach(group=>{
            //     Console.WriteLine(group.Key);
            //     group.ToList().ForEach(x=>Console.WriteLine(x));
            // });


            //into ket qua luu vao bien tam
            // var query=from p in products 
            //         group p by  p.Price into gr
            //         orderby gr.Key
            //         select gr;
            // query.ToList().ForEach(group=>{
            //     Console.WriteLine(group.Key);
            //     group.ToList().ForEach(x=>Console.WriteLine(x));
            // });

        //     var query= from p in products 
        //     group p by p.Price into gr
        //     orderby gr.Key
        //     let sl="So luong "+gr.Count()
        //     select new {
        //         Gia=gr.Key,
        //         Cacsanpham=gr.ToList(),
        //         SoLuong=sl,
        //     };


        //   query.ToList().ForEach(i=>{
        //     Console.WriteLine(i.Gia);
        //     Console.WriteLine(i.SoLuong);
        //     i.Cacsanpham.ForEach(p=>Console.WriteLine(p));
        //   });

        //Join

        // var query= from product in products join brand in brands on product.Brand equals brand.ID
        // select new {
        //     Ten=product.Name,
        //     Gia=product.Price,
        //     thuongHieu=brand.Name
        // };
        // query.ToList().ForEach(x=>{
        //     Console.WriteLine($"{x.Ten,10} {x.thuongHieu,15} {x.Gia,5}");
        // });


        //TH lay trung
        var query = from product in products join brand in brands on product.Brand equals brand.ID into t
        from b in t.DefaultIfEmpty()
        select new{
           Ten=product.Name,
            Gia=product.Price,
            thuongHieu=(b!=null) ?b.Name :"Khong co thuong hieu"
        };
        query.ToList().ForEach(x=>{
            Console.WriteLine($"{x.Ten,10} {x.thuongHieu,15} {x.Gia,5}");
        });
        }
    }
}

