using ex.Services;
using System.Windows;
using ex.Models;

namespace ex.Views
{
    public partial class MainWindow : Window
    {
        private DataServices _ds = new DataServices();
        private List<Order> _order;
        private List<Product> _product;
        public MainWindow()
        {
            InitializeComponent();
            Loaded += (s, e) => LoadAll();
        }
        private void LoadAll()
        {
            _order = _ds.GetOrders();
            _product = _ds.GetProducts();

            dgOrder.ItemsSource = _order;
            dgProducts.ItemsSource = _product;
        }
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            App.CurrentUser = null;
            new Login().Show();
            Close();
        }
        private void TabControl_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e) { }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            var form = new ProductForm();
            if (form.ShowDialog() == true)
            {
                _ds.AddProduct(form.Product);
                LoadAll();
            }
        }

        private void EditProduct_Click(object sender, RoutedEventArgs e)
        {
            var b = dgProducts.SelectedItem as Product;
            if (b == null) { MessageBox.Show("Выберите product"); return; }
            var form = new ProductForm(b);
            if (form.ShowDialog() == true)
            {
                _ds.UpdateProduct(form.Product);
                LoadAll();
            }
        }

        private void DeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            var b = dgProducts.SelectedItem as Product;
            if (b == null) { MessageBox.Show("Выберите Product"); return; }
            if (MessageBox.Show("Удалить Product?", "Подтверждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                _ds.DeleteProduct(b.Id);
                LoadAll();
            }
        }
        private void AddOrder_Click(object sender, RoutedEventArgs e)
        {
            var form = new OrderForm(_ds.GetAddress(), _ds.GetUser());
            if (form.ShowDialog() == true)
            {
                _ds.AddOrder(form.Order);
                LoadAll();
            }
        }

        private void EditOrder_Click(object sender, RoutedEventArgs e)
        {
            var i = dgOrder.SelectedItem as Order;
            if (i == null) { MessageBox.Show("Выберите Order"); return; }
            var form = new OrderForm(_ds.GetAddress(), _ds.GetUser(), i);
            if (form.ShowDialog() == true)
            {
                _ds.UpdateOrder(form.Order);
                LoadAll();
            }
        }

        private void DeleteOrder_Click(object sender, RoutedEventArgs e)
        {
            var i = dgOrder.SelectedItem as Order;
            if (i == null) { MessageBox.Show("Выберите Order"); return; }
            if (MessageBox.Show("Удалить Order?", "Подтверждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                _ds.DeleteOrder(i.Id);
                LoadAll();
            }
        }
    }
}
