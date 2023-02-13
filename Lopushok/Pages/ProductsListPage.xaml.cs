using Lopushok.Properties;
using System;
using System.Collections.Generic;
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
    public partial class ProductsListPage : Page
    {
        public List<Product> Products { get; set; }
        public List<Product> FilteredProducts { get; set; }

        public ProductsListPage()
        {
            InitializeComponent();
            Products = DataAccess.GetProducts();
            FilteredProducts = Products.ToList();

            this.DataContext = this;
            DataAccess.NewItemAddedEvent += DataAccess_NewItemAddedEvent;
        }

        private void DataAccess_NewItemAddedEvent()
        {
            Products = DataAccess.GetProducts();

            lvProducts.Items.Refresh();
        }
        private void lvProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {   
            btnEditPrice.Visibility = lvProducts.SelectedItems == null ? Visibility.Hidden : Visibility.Visible;
        }
        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApplyFilters();
        }

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProductPage(new Product(), true));
        }

        private void lvProducts_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lvProducts.SelectedItem as Product == null)
                return;
            NavigationService.Navigate(new ProductPage(lvProducts.SelectedItem as Product));

        }

        private void ApplyFilters(bool filtersChanged = true)
        {
            var searchingText = tbSearch.Text.ToLower();

            FilteredProducts = Products.FindAll(product => product.Name.ToLower().Contains(searchingText));
            lvProducts.ItemsSource = FilteredProducts;
        }

        private void btnEditPrice_Click(object sender, RoutedEventArgs e)
        {
            var products = lvProducts.SelectedItems.Cast<Product>().ToList();
            var result = new Windows.EditPriceWindow(products).ShowDialog();

            if (result.Value)
                MessageBox.Show("Цены успешно обновлены", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
