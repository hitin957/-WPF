using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Бюджет
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Data> dataList = new List<Data>();
        List<string> coloms = new List<string>();

        string Text;
        string Money;
        string type;
        string Sum;
        DateTime SelDate;
        bool proG;
        int Cymma;
        public MainWindow()
        {
            InitializeComponent();
            string text = File.ReadAllText("file.json");
            List<Data> dataList = JsonConvert.DeserializeObject<List<Data>>(text);
            List_Grid.ItemsSource = null;
            List_Grid.ItemsSource = dataList;

        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            Text = name_Zapis.Text;
            Money = Cymma_money.Text;
            SelDate = Convert.ToDateTime(Date.Text);
            Math_ITOG(Money);
            dataList.Add(new Data(Text,Sum,type,proG, SelDate));
            name_Zapis.Text = null;
            Cymma_money.Text = null;
            string json=JsonConvert.SerializeObject(dataList);
            File.WriteAllText("file.json",json);
            List_Grid.ItemsSource = null;
            List_Grid.ItemsSource = dataList;
        }
        private void Math_ITOG(string money)//Математический итог
        {
            int x = Convert.ToInt32(money);
            Cymma = Cymma + x;
            if (x > 0)
            {
                proG = false;
            }
            if (x < 0)
            {
                x = x * -1;
                proG = true;
            }
            Sum = Convert.ToString(x);
            string str = Convert.ToString(Cymma);
            ITOG.Text = str;
        }

        private void btn_delet_Click(object sender, RoutedEventArgs e)
        {
            dataList.Remove(new Data(Text, Sum, type, proG, SelDate));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_add_new_type_Click(object sender, RoutedEventArgs e)
        {
            NewWindow newWindow = new NewWindow();
            newWindow.ShowDialog();
            coloms.Add(newWindow.MyText);
            List_Combo.ItemsSource = null;
            List_Combo.ItemsSource = coloms;

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void List_Grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Data selected = List_Grid.SelectedItem as Data;
            name_Zapis.Text=selected.Text;
            Cymma_money.Text = selected.Money;
        }

        private void List_Combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            type = List_Combo.Items[List_Combo.SelectedIndex] as string;
        }

        private void Date_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var todayDataList = new List<Data>();
            foreach (var item in dataList)
            {
                if (item.Date == Convert.ToDateTime(Date.Text))
                {
                    todayDataList.Add(item);
                }
            }

            List_Grid.ItemsSource = todayDataList;
        }
    }
}
