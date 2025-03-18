using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using test2.Data;
using test2.Model;
namespace test2;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    Context context = new Context();
    
    public MainWindow()
    {
        InitializeComponent();
        ListViewsProduct.ItemsSource = context.Products.ToList(); 
    }

    private void ComboBoxSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var prop = typeof(Product).GetProperty((ComboBoxSort.SelectedItem as ComboBoxItem).Content.ToString());

        if (prop.PropertyType == typeof(bool))
        {
            ListViewsProduct.ItemsSource = context.Products.ToList().OrderByDescending(q => prop.GetValue(q));
        }
        else { ListViewsProduct.ItemsSource = context.Products.ToList().OrderBy(q => prop.GetValue(q)); }

    }

    private void TexBoxBySort_KeyUp(object sender, KeyEventArgs e)
    {
        var prop =  typeof(Product).GetProperty((ComboBoxSortByTextBox.SelectedItem as ComboBoxItem).Content.ToString()); 
        ListViewsProduct.ItemsSource = context.Products
            .ToList()
            .Where(q => (prop.GetValue(q) as string).ToLower().Contains(TexBoxBySort.Text.ToLower()));
    }

    private void ComboBoxSortByTextBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        TexBoxBySort.Text = "";
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Product selectedItem = ListViewsProduct.SelectedItem as Product;
        context.Products.Remove(selectedItem);
        ListViewsProduct.ItemsSource = context.Products;
    }

    private void ListViewsProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        Product selectedItem = ListViewsProduct.SelectedItem as Product;
        if (selectedItem != null) {
            TexBoxPrice.Text = selectedItem.Price.ToString();
        }

    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        Product selectedItem = ListViewsProduct.SelectedItem as Product;

        selectedItem.Price = Convert.ToDouble(TexBoxPrice.Text);
        ListViewsProduct.Items.Refresh();
    }
}