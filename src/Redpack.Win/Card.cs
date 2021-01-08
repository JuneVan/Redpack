using System;
using System.Drawing;
using System.Windows.Forms;

namespace Redpack
{
    public partial class Card : UserControl
    {
        public Card()
        {
            InitializeComponent();
        }
        public string Title { get; set; }
        public string Num { get; set; }
        private void Card_Load(object sender, EventArgs e)
        {
            labTitle.Text = Title;
            labNum.Text = Num;
        }
    }
}
