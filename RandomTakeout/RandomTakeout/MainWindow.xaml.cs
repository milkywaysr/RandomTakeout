using System;
using System.Collections.Generic;
using System.Linq;
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

namespace RandomTakeout
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void onBtnAdd(object sender, RoutedEventArgs e)
        {
            if(textboxAdd.Text.Length > 0)
            {
                menuList.Items.Add(textboxAdd.Text);
                textboxAdd.Text = "";
            }
            else
            {
                MessageBox.Show("请输入菜单名");
            }
            
        }

        private void onBtnRemove(object sender, RoutedEventArgs e)
        {
            System.Collections.IList items = menuList.SelectedItems;
            for(int i = 0; i < items.Count; i++)
            {
                menuList.Items.Remove(items[i]);
            }
            menuList.UnselectAll();
        }
    }
}
