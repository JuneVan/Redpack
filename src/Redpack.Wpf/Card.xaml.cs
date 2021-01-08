using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Redpack.Wpf
{
    /// <summary>
    /// Card.xaml 的交互逻辑
    /// </summary>
    public partial class Card : UserControl
    {
        internal string Title { get; set; }
        internal string Num { get; set; }
        public Card()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            LabTitle.Content = Title;
            ImgNum.Source = new BitmapImage(new Uri($"/Assets/{Num}.png", UriKind.RelativeOrAbsolute));
        }
    }
}
