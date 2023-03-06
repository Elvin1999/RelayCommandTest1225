using System;
using System.Collections.Generic;
using System.IO;
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

namespace RelayCommandTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int Age
        {
            get { return (int)GetValue(AgeProperty); }
            set { SetValue(AgeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Age.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AgeProperty =
            DependencyProperty.Register("Age", typeof(int), typeof(MainWindow));




        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Message.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", typeof(string), typeof(MainWindow));



        public RelayCommand SendCommand { get; set; }
        public RelayCommand SendMessageCommand { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            //SendCommand = new RelayCommand((obj) =>
            //{
            //    MessageBox.Show($"Your age is {Age}");
            //}
            //, (pred) =>
            //{
            //    return Age >= 18;
            //});


            SendMessageCommand = new RelayCommand((obj) =>
            {
                File.WriteAllText("some.txt", Message);
                MessageBox.Show("Your message send successfully");
            });

            SendCommand = new RelayCommand((obj) =>
            {
                MessageBox.Show($"Your age is {Age}");
            });
        }
    }
}
