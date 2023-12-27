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
using GreenE.Data;

namespace GreenE
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (TLogin.Text != "" && Tpassword.Password != "")
            {
                var user = DbCon.db.Account.Where(x => x.Login == TLogin.Text).FirstOrDefault();
                if (user != null)
                {
                    if (user.Password == Tpassword.Password)
                    {
                        if (user.Role.Name == "ManegerProd")
                        {
                            ManegerPkup maneger = new ManegerPkup();
                            maneger.Show();
                        }
                        else if (user.Role.Name == "Kladovshik")
                        {
                            Kladov kladov = new Kladov();
                            kladov.Show();
                        }
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Пароль не правильный.");
                    }
                }
                else
                {
                    MessageBox.Show("Пользователя с таким логином не существует.");
                }
            }
            else
            {
                MessageBox.Show("Не все поля заполнены.");
            }
        }
    }
}

