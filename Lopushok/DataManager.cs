using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Lopushok
{
    public static class DataAccess
    {
        public delegate void NewItemAddedDeledate();
        public static event NewItemAddedDeledate NewItemAddedEvent;

        public static List<Product> GetProducts() => BaseConnection.connection.Product.ToList();
        public static List<ProductType> GetProductTypes() => BaseConnection.connection.ProductType.ToList();
        public static List<Material> GetMaterials() => BaseConnection.connection.Material.ToList();
        public static List<MaterialType> GetMaterialTypes() => BaseConnection.connection.MaterialType.ToList();
        public static List<Workshop> GetWorkshops() => BaseConnection.connection.Workshop.ToList();

        public static void SaveProduct(Product product)
        {
            if (!GetProducts().Any(x => x == product))
                BaseConnection.connection.Product.Add(product);

            BaseConnection.connection.SaveChanges();
            NewItemAddedEvent?.Invoke();
        }

        public static void DeleteProduct(Product product)
        {
            BaseConnection.connection.Product.Remove(product);

            BaseConnection.connection.SaveChanges();
            NewItemAddedEvent?.Invoke();
        }

        public static void DeleteProductMaterial(ProductMaterial productMaterial)
        {
            BaseConnection.connection.ProductMaterial.Remove(productMaterial);
        }
    }
}
