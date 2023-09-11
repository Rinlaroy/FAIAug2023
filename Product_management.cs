using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Assessments
{
    
    class Product
    {
        public string Name { get; set; }
        public int Quantity { get; set; } 
        public decimal Price { get; set; }

        public Product(string name,decimal price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }
        

        public override bool Equals(object obj)
        {
            if (obj is Product)
            {
                var temp = obj as Product;
                return temp.Name == this.Name;
            }
            return false;
        }

        public void DeepCopy(Product other)
        {
            Name = other.Name;
            Price = other.Price;
            Quantity = other.Quantity;
        }

    }
    class Product_management
       
    {


        const string filename = @"C:\Users\rcmary\source\repos\Assessments\Assessments\Models\menu.txt";
        // const int size = 5;
        //static string[] products = new string[size];
        static List<Product> products = new List<Product>();
        
        static void Main(string[] args)
        {
          

           // FileStream fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            var content = File.ReadAllText(filename);
            Console.WriteLine(content);
            do
            {
                
                Console.WriteLine("Enter Your Choice");
                string choice = Console.ReadLine();
                choiceselection(choice);
            } while (true);
            //csvfilepath();
           
        }

        private static void csvfilepath()
        {
            string csvFilePath = "products.csv";
            using (StreamWriter writer = new StreamWriter(csvFilePath))
            {
                writer.WriteLine("Prodct Name,Price,Quantity");
                foreach (var product in products)
                {
                    writer.WriteLine($"{product.Name},{product.Price},{product.Quantity}");
                }
            }
            Console.WriteLine($"Products saved to {csvFilePath}");
             
                var content = File.ReadAllText(csvFilePath);
                Console.WriteLine(content);
            
        }

        private static bool choiceselection(string choice) { 
        
            switch (choice)
            {
                case "A": AddProduct();
                     return true;
                case "DEL": DeleteProduct();
                     return true;
                case "U": UpdateProduct();
                     return true;
                case "D": DisplayProducts();
                     return true;
                case "E":  return false;
               
                default: Console.WriteLine("Invalid choice");
                    break;
            }

            return false;
        }
       


        private static void DeleteProduct()
        {
            Console.WriteLine("Enter product to delete");
            string productnameTodelete = Console.ReadLine();
            Product productToRemove = products.Find(Product => Product.Name.Equals(productnameTodelete, StringComparison.OrdinalIgnoreCase));
            if(productToRemove != null)
            {
                products.Remove(productToRemove);
                Console.WriteLine("Deleted");
            }
            else
            {
                Console.WriteLine("Product not found");
            }
        }

         public static void AddProduct()
        {

            Console.WriteLine("Enter product name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter product price");
            decimal price = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter product quantity");
            int quantity = int.Parse(Console.ReadLine());
            Product newProduct = new Product(name, price, quantity);
            products.Add(newProduct);
            Console.WriteLine("Product added successfully");
           
        }
        static void DisplayProducts()
        {
            foreach(Product product in products)
            {
                Console.WriteLine($"Name:{product.Name}, Price:{product.Price}, Quantity:{product.Quantity}");
            }
        }
        static void UpdateProduct()
        {
            Console.WriteLine("Enter the name of the product to update");
            string productNameToUpdate = Console.ReadLine();
            Product productToUpdate = products.Find(product => product.Name.Equals(productNameToUpdate, StringComparison.OrdinalIgnoreCase));
            if(productToUpdate != null)
            {
                Console.WriteLine("Enter new price");
                decimal newPrice = decimal.Parse(Console.ReadLine());
                productToUpdate.Price = newPrice;
                Console.WriteLine("Product updated successfully");
                Console.WriteLine("Enter new quantity");
                int newquantity = int.Parse(Console.ReadLine());
                productToUpdate.Quantity = newquantity;
                Console.WriteLine("Product updated successfully");
            }

        }

    }
}
