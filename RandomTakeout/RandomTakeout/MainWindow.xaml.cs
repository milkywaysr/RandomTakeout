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
            while(menuList.SelectedIndex >= 0)
            {
                menuList.Items.Remove(menuList.SelectedItem);
            }
        }

        private void onBtnStart(object sender, RoutedEventArgs e)
        {
            if (menuList.Items.Count > 0)
            {
                Random random = new Random();
                int i = random.Next(menuList.Items.Count);
                labEat.Content = menuList.Items.GetItemAt(i);
            }
            else
            {
                MessageBox.Show("请输入菜单");
            }
        }

        private void onBtnSave(object sender, RoutedEventArgs e)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter("menu.dat", false))
            {
                foreach(string menu in menuList.Items)
                {
                    file.WriteLine(menu);
                }
            }
        }

        private void onBtnLoad(object sender, RoutedEventArgs e)
        {
            menuList.UnselectAll();
            menuList.Items.Clear();
            string[] lines = System.IO.File.ReadAllLines("menu.dat");
            foreach(string line in lines)
            {
                menuList.Items.Add(line);
            }

        }
    }
}
