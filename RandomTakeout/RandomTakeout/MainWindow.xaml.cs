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
using System.Windows.Threading;

namespace RandomTakeout
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        //private System.Timers.Timer timerRandom;
        private DispatcherTimer timerRandom;
        private int start;
        private int count;
        public MainWindow()
        {
            InitializeComponent();
            start = 0;
            count = 0;
            timerRandom = new DispatcherTimer();
            timerRandom.Tick += OnTimer;
            timerRandom.Interval = new TimeSpan(500000);
        }

        private void OnTimer(object sender, EventArgs e)
        {
            int num = menuList.Items.Count;
            labEat.Content = menuList.Items[(start + count) % num];
            count--;
            if (count == 0)
            {
                timerRandom.Stop();
                labEat.Content += "!";
            }
        }

        private void AddMenu()
        {
            if (textboxAdd.Text.Length > 0)
            {
                menuList.Items.Add(textboxAdd.Text);
                textboxAdd.Clear();
                Keyboard.Focus(textboxAdd);
            }
            else
            {
                MessageBox.Show("请输入菜单名");
            }
        }

        private void OnBtnAdd(object sender, RoutedEventArgs e)
        {
            AddMenu();
        }

        private void OnTextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                AddMenu();
            }
        }

        private void OnBtnRemove(object sender, RoutedEventArgs e)
        {
            while (menuList.SelectedIndex >= 0)
            {
                menuList.Items.Remove(menuList.SelectedItem);
            }
        }

        private void OnBtnStart(object sender, RoutedEventArgs e)
        {
            if (menuList.Items.Count > 0)
            {
                Random random = new Random();
                start = random.Next(menuList.Items.Count);
                count = random.Next(10, 30);
                timerRandom.Start();
            }
            else
            {
                MessageBox.Show("请输入菜单");
            }
        }

        private void OnBtnSave(object sender, RoutedEventArgs e)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter("menu.dat", false))
            {
                foreach (string menu in menuList.Items)
                {
                    file.WriteLine(menu);
                }
            }
        }

        private void OnBtnLoad(object sender, RoutedEventArgs e)
        {
            menuList.UnselectAll();
            menuList.Items.Clear();
            string[] lines = System.IO.File.ReadAllLines("menu.dat");
            foreach (string line in lines)
            {
                menuList.Items.Add(line);
            }
        }
    }
}
