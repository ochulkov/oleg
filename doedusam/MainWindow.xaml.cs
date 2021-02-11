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

namespace doedusam
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
        public partial class Service
        {
            public Uri ImageUri
            {
                get
                {
                    return new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, MainImagePath));
                }
            }
        public string CostString
        {
            get
            {
                // тут должно быть понятно - преобразование в строку с нужной точностью
                return Cost.ToString("#.##");
            }
        }

        public string CostWithDiscount
        {
            get
            {
                // Convert.ToDecimal - преобразует double в decimal
                // Discount ?? 0 - разнуливает "Nullable" переменную
                return (Cost * Convert.ToDecimal(1 - Discount ?? 0)).ToString("#.##");
            }
        }

        // ну и сразу пишем геттер на наличие скидки
        public Boolean HasDiscount
        {
            get
            {
                return Discount > 0;
            }
        }

        // и перечёркивание старой цены
        public string CostTextDecoration
        {
            get
            {
                return HasDiscount ? "None" : "Strikethrough";
            }
        }

    }


        public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            ServiceList = Core.DB.Service.ToList();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
            
        }
        private List<Service> _ServiceList;
        public List<Service> ServiceList
        {
            get { return _ServiceList; }
            set { _ServiceList = value; }
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
