using GreenE.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
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
using System.Windows.Shapes;

namespace GreenE
{
    /// <summary>
    /// Логика взаимодействия для Kladov.xaml
    /// </summary>
    public class ProductQr1
    {
        public BitmapImage ProdQrCode { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int id { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime Validility { get; set; }
    }
    public partial class Kladov : Window
    {
        ObservableCollection<ProductQr> QrProducts { get; set; }
        public Kladov()
        {
            InitializeComponent();
            QrProducts = new ObservableCollection<ProductQr>();
            var a = DbCon.db.Product;
            foreach (var i in a)
            {
                ProductQr prodQr = new ProductQr();
                prodQr.Name = i.Name;
                prodQr.Price = i.Price;
                prodQr.Validility = i.Validity;
                prodQr.Deadline = i.Deadline;
                prodQr.id = i.Id_Product;

                string soucer_xl = i.Id_Product.ToString();
                QRCoder.QRCodeGenerator qr = new QRCoder.QRCodeGenerator();
                QRCoder.QRCodeData data = qr.CreateQrCode(soucer_xl, QRCoder.QRCodeGenerator.ECCLevel.L);
                QRCoder.QRCode code = new QRCoder.QRCode(data);
                Bitmap bitmap = code.GetGraphic(100);
                using (MemoryStream memory = new MemoryStream())
                {
                    bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                    memory.Position = 0;
                    BitmapImage bitmapimage = new BitmapImage();
                    bitmapimage.BeginInit();
                    bitmapimage.StreamSource = memory;
                    bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapimage.EndInit();
                    prodQr.ProdQrCode = bitmapimage;
                }
                QrProducts.Add(prodQr);
            }
            Table.ItemsSource = QrProducts;

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}
