using ex.Models;
using System.Windows;
using ex.Services;
using System.Windows.Controls;


namespace ex.Views
{
    public partial class OrderForm : Window
    {
        public Order Order { get; set; }
        public OrderForm(List<Address> address, List<User> user, Order order = null)
        {
            InitializeComponent();
            cboAddress.ItemsSource = address;
            cboUser.ItemsSource = user;
            if (order != null)
            {
                Order = order;
                txtArticle.Text = order.Article;
                dpOdate.SelectedDate = order.Odate;
                dpDdate.SelectedDate = order.Ddate;
                cboAddress.SelectedValue = order.AddressId;
                cboUser.SelectedValue = order.UserId;
                txtCode.Text = order.Code.ToString();
                txtStatus.Text = order.Status;
            }
            else
            {
                Order = new Order { Odate = DateTime.Today };
                dpOdate.SelectedDate = DateTime.Today;
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Order.Article = txtArticle.Text;
            Order.Odate = dpOdate.SelectedDate ?? DateTime.Today;
            Order.Ddate = dpDdate.SelectedDate ?? DateTime.Today;
            Order.AddressId = (int)(cboAddress.SelectedValue ?? 0);
            Order.UserId = (int)(cboUser.SelectedValue ?? 0);
            Order.Code = int.Parse(txtCode.Text);
            Order.Status = txtStatus.Text;

            DialogResult = true;
            Close();
        }
    }
}
