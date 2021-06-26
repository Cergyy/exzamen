using ekzBast.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace ekzBast
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
       {
        public List<Vvid> VvidList { get; set; }
        private IEnumerable<Product> _ProductList = null;
        private string SelectedVvid;
        private string SearchFilter = "";
        public IEnumerable<Product> ProductList
        {
            get
            {
                var res = _ProductList;
                res = res.Where(c => (SelectedVvid == "Все виды" || c.Vvid == SelectedVvid));
                if (SearchFilter != "")
                    res = res.Where(c => c.Name.IndexOf(SearchFilter, StringComparison.OrdinalIgnoreCase) >= 0);
                if (SortAsc) res = res.OrderBy(c => c.Cena);
                else res = res.OrderByDescending(c => c.Cena);
                return res;

            }
            set { _ProductList = value; }
        }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Globals.dataProvider = new LocalDataProvider();
            ProductList = Globals.dataProvider.GetProducts();
            VvidList = Globals.dataProvider.GetProductVvid().ToList();
            VvidList.Insert(0, new Vvid { Title = "Все виды" });
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        private void VvidFilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedVvid = (VvidFilterComboBox.SelectedItem as Vvid).Title;
            Invalidate();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void Invalidate()
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("ProductList"));
        }
        private void SearchFilter_KeyUp(object sender, KeyEventArgs e)
        {
            SearchFilter = SearchFilterTextBox.Text;
            Invalidate();
        }
        private bool SortAsc = true;

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            SortAsc = (sender as RadioButton).Tag.ToString() == "1";
            Invalidate();
        }
    }

}