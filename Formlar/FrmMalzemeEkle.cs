using Bogus;
using DevExpress.Internal.WinApi;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using Bogus.DataSets;




namespace Üretimtakip.Formlar
{
    
    public partial class BtnSil : Form
    {

       
		
	
        istakipEntities1 db = new istakipEntities1();




        public BtnSil()
        {
            InitializeComponent();
        }

        private void FrmMalzemeEkle_Load(object sender, EventArgs e)
        {
            txtID.Enabled = false;
            txtAnaKategori.Enabled = false;
            txtAltKategori.Enabled = false;
            anakategorilistele();
            altkategorilistele();
            malzemelistele();
             
            
        }

        
       

        private void btnMalzemeEkle_Click(object sender, EventArgs e)
        {
            try
            {

          
           TblMalzeme t = new TblMalzeme(); 

            t.AnaKategori = Convert.ToInt32(txtanakategoriid.Text);
            t.AltKategori = Convert.ToInt32(txtAltKategoriId.Text);
            t.Malzemeler = txtMalzeme.Text;
            t.Aciklama = rtAciklama.Text;
            t.Görsel = txtImageSave.Text;
            db.TblMalzeme.Add(t);
            db.SaveChanges();

            MessageBox.Show("Kayıt başarılı bir şekilde eklendi.");
            malzemelistele();
            }
            catch (Exception)
            {

                MessageBox.Show("Hata");
            }

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
            txtImageSave.Text = openFileDialog1.FileName;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            txtID.Enabled = true;
           

            
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            System.Media.SystemSounds.Hand.Play(); //uyarı sesi
            
            DialogResult x = MessageBox.Show("Kayıt silinecek. Emin Misiniz?", "Çıkış Mesajı!", MessageBoxButtons.YesNo);
            if (x == DialogResult.Yes)
            {
                MessageBox.Show("silme işlemine geçilecek buradan");


            }
            else if (x == DialogResult.No)
            {
                MessageBox.Show("vazgeçildi dedi ve kapattı");
                
            }
        }




        private void gridView2_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            txtAnaKategori.Text = gridView2.GetFocusedRowCellValue("Babakategori").ToString();
            txtanakategoriid.Text = gridView2.GetFocusedRowCellValue("ID").ToString();
            altkategorilistele();
            txtAltKategori.Text = gridView3.GetFocusedRowCellValue("AltKategori").ToString();

        }

        void anakategorilistele()
        {
            var degerler = (from x in db.TblBabaKategori
                            select new
                            {
                                x.ID,
                                x.Babakategori

                            });
            gridControl2.DataSource = degerler.ToList();

        }

        void altkategorilistele()
        {
            int altkategorisec;
             altkategorisec = Convert.ToInt32(txtanakategoriid.Text);
            gridControl3.DataSource = db.TblSubKategori.Where(x => x.AnaKategori == altkategorisec).ToList();
        }

        private void gridView3_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
           
            txtAltKategori.Text = gridView3.GetFocusedRowCellValue("AltKategori").ToString();
            txtAltKategoriId.Text = gridView3.GetFocusedRowCellValue("ID").ToString();
        }

        void malzemelistele()
        {
            var degerler = (from x in db.TblMalzeme
                            select new
                            {

                                x.Malzemeler,
                                x.Aciklama,
                                x.Görsel,
                                x.SonGuncellenme,

                            });
            gridControl4.DataSource = degerler.ToList();
        }

        private void gridView4_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            
            
        }

        private void btnAnaKategoriEkle_Click(object sender, EventArgs e)
        {
            FrmAnaKategoriEkle frm1 = new FrmAnaKategoriEkle();
           
            frm1.Show();
        }
    }
}
