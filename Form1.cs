using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Üretimtakip.Formlar;

namespace Üretimtakip
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        istakipEntities1 db= new istakipEntities1();  
       

        private void txtMalzemeEkle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BtnSil frm1 = new BtnSil();
            frm1.MdiParent = this;
            frm1.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Kategori frm2 = new Kategori();
            frm2.MdiParent = this;
            frm2.Show();
        }
    }
}
