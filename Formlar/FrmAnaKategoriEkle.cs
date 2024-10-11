using DevExpress.Internal.WinApi.Windows.UI.Notifications;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraLayout.Customization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Üretimtakip.Formlar
{
    public partial class FrmAnaKategoriEkle : Form
    {
        istakipEntities1 db = new istakipEntities1(); 
        public FrmAnaKategoriEkle()
        {
            InitializeComponent();
        }

        private void FrmAnaKategoriEkle_Load(object sender, EventArgs e)
        {
            listele();
            
        }

       
           
        

        void listele()
        {
            var degerler = (from x in db.TblBabaKategori
                            select new
                            {
                                x.ID,
                                x.Babakategori,

                            });
            gridControl1.DataSource = degerler.ToList();

        }

       
        private void btnAnaKategoriEkle_Click(object sender, EventArgs e)
    {
            #region Ana Kategori ekleme
            TblBabaKategori t = new TblBabaKategori();
            t.Babakategori = Convert.ToString(txtAnaKategori.Text);
            db.TblBabaKategori.Add(t);
            db.SaveChanges();
            listele();

            #endregion

            #region TBL Alt kategori ID bulma

            SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-A1R71B7\\SQLEXPRESS;Initial Catalog=istakip;Integrated Security=True;");
            baglanti.Open();
            SqlCommand sorgu2 = new SqlCommand("Select Max(ID) From TblBabaKategori", baglanti);
            SqlDataReader oku = sorgu2.ExecuteReader();
            while (oku.Read())
            {
                textBox3.Text = oku[0].ToString();
            }
            baglanti.Close();

            #endregion

            #region gelenID'den kayıt açma
           
            TblSubKategori td = new TblSubKategori();
            td.AnaKategori = int.Parse(textBox3.Text);
            textBox4.Text = "Kayıt Başlangıç";
            td.AltKategori = textBox4.Text;
            db.TblSubKategori.Add(td);
            db.SaveChanges();
            listele();
            #endregion


            #region Malzeme tablosu için Alt kategorinin ID'sini bulma
            SqlConnection baglanti5 = new SqlConnection("Data Source=DESKTOP-A1R71B7\\SQLEXPRESS;Initial Catalog=istakip;Integrated Security=True;");
            baglanti5.Open();
            SqlCommand sorgu3 = new SqlCommand("Select Max(ID) From TblSubKategori", baglanti5);
            SqlDataReader oku1 = sorgu3.ExecuteReader();
            while (oku1.Read())
            {
                textBox4.Text = oku1[0].ToString();
            }
            baglanti5.Close();

            #endregion




            #region Malzeme kayıt açma
            TblMalzeme td2 = new TblMalzeme();
            td2.AnaKategori = int.Parse(textBox3.Text);


            td2.AltKategori = int.Parse(textBox4.Text);
            td2.Malzemeler = textBox3.Text = "Kayıt Başlangıç";
            db.TblMalzeme.Add(td2);

            textBox3.Text = "";
            db.SaveChanges();

            listele();
            #endregion






            MessageBox.Show("Kayıt başarılı bir şekilde eklendi.");
     }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var x = int.Parse(textBox3.Text); //ID tekstteki değeri x değerine aktar
            var deger = db.TblBabaKategori.Find(x); // tbl Personel tablosunda x değişkeni yani id'nin konumunu ve doğal olarak satırını bulup deger değişkenine atamak için
            deger.Durum = false; // degerin bulunduğu satırdaki deger durum değişkenini false yapıyor. Veritabanından silmek
            // yerine false yapıldığında ileriye yönelik hatalar giderilmiş oluyor. ilerde silinen personelin listelendiği ayrı bir sayfa yapılacaak.
            db.SaveChanges(); //değişilikleri datagride yansıtmak için
            XtraMessageBox.Show("Ana KAtegori başarılı bir şekilde silindi. ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
        }

        #region Silme işlemi için gridden textbox3'e veri alma
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            textBox3.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
        }
        #endregion
    }
}
