using ex.Models;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;

namespace ex.Views
{
    public partial class ProductForm : Window
    {
        public Product Product { get; set; }

        public ProductForm(Product product = null)
        {
            InitializeComponent();
            if (product != null)
            {
                Product = product;
                txtName.Text = product.Name;
                txtArticle.Text = product.Article;
                txtUnit.Text = product.Unit;
                txtPrice.Text = product.Price.ToString();
                txtSupplier.Text = product.Supplier;
                txtManufacturer.Text = product.Manufacturer;
                txtCategory.Text = product.Category;
                txtDiscount.Text = product.Discount.ToString();
                txtQuantity.Text = product.Quantity.ToString();
                txtDescription.Text = product.Description;
                txtCategory.Text = product.Category;
                txtImage.Text = product.Image;

            }
            else Product = new Product();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Product.Name = txtName.Text;
            Product.Article = txtArticle.Text;
            Product.Unit = txtUnit.Text;
            Product.Supplier = txtSupplier.Text;
            Product.Manufacturer = txtManufacturer.Text;
            Product.Category = txtCategory.Text;
            Product.Price = Decimal.Parse(txtPrice.Text);
            Product.Discount = int.Parse(txtDiscount.Text);
            Product.Quantity = int.Parse(txtQuantity.Text);
            Product.Description = txtDescription.Text;
            Product.Category = txtCategory.Text;
            Product.Image = txtImage.Text;

            DialogResult = true;
            Close();
        }
    }
}

