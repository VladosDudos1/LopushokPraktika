using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lopushok.Pages
{
    public partial class ProductPage : Page
    {
        public Product Product { get; set; }

        public List<Workshop> Workshops { get; set; }
        public List<ProductType> ProductTypes { get; set; }
        public List<Material> Materials{ get; set; }
        public ProductPage(Product product, bool isNewProduct = false)
        {
            InitializeComponent();

            Product = product;
            Workshops = DataAccess.GetWorkshops();
            ProductTypes = DataAccess.GetProductTypes();
            Materials = DataAccess.GetMaterials();

            Title = Product.Name;

            if (isNewProduct)
            {
                Title = "Новый продукт";
                btnDelete.Visibility = Visibility.Hidden;
            }

            this.DataContext = this;

            if (product.ProductSale.Count != 0)
                btnDelete.Visibility = Visibility.Hidden;
        }

        private void lvMaterials_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var material = lvMaterials.SelectedItem as ProductMaterial;
                if (material == null)
                    return;
                var result = MessageBox.Show("Вы точно хотите удалить материал?", "Предупреждение", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
                if (result != MessageBoxResult.Yes)
                    return;
                Product.ProductMaterial.Remove(material);
                DataAccess.DeleteProductMaterial(material);

                lvMaterials.ItemsSource = Product.ProductMaterial;
                lvMaterials.Items.Refresh();
            }
            catch { }

        }

        private void cbMaterial_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var material = cbMaterial.SelectedItem as Material;
            if (material == null || Product.ProductMaterial.Any(x => x.Material == material))
                return;

            Product.ProductMaterial.Add(new ProductMaterial() { Product = Product, Material = material });

            lvMaterials.ItemsSource = Product.ProductMaterial;
            lvMaterials.Items.Refresh();
        }
        private void btnAddImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                Filter = "*.png|*.png|*.jpeg|*.jpeg|*.jpg|*.jpg"
            };

            if (fileDialog.ShowDialog().Value)
            {
                var image = File.ReadAllBytes(fileDialog.FileName);
                Product.Image = image;

                imgProduct.Source = new BitmapImage(new Uri(fileDialog.FileName));
            }
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Вы точно хотите удалить данный продукт?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.No)
                return;
            DataAccess.DeleteProduct(Product);
            NavigationService.GoBack();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (IsArticleUnique())
            {
                MessageBox.Show("Артикул не уникален", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                DataAccess.SaveProduct(Product);
            }
            catch
            {
                MessageBox.Show("Введены некорректные значения", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DataAccess.SaveProduct(Product);
            NavigationService.GoBack();
        }

        public bool IsArticleUnique()
        {
            return DataAccess.GetProducts().Any(product => product == Product && product.Article != Product.Article);
        }

        private void cbMaterial_TextChanged(object sender, TextChangedEventArgs e)
        {
            cbMaterial.ItemsSource = Materials.FindAll(material => material.Name.ToLower().Contains(cbMaterial.Text.ToLower()));
            cbMaterial.IsDropDownOpen = true;
        }
    }
}
