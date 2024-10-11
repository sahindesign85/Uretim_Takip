using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;

namespace Üretimtakip.Formlar
{
    public partial class Kategori : Form

        
    {
        public Kategori()
        {
            InitializeComponent();
        }

        private void Kategori_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'denemeSakınveriyazma.TblSubKategori' table. You can move, or remove it, as needed.
            this.tblSubKategoriTableAdapter.Fill(this.denemeSakınveriyazma.TblSubKategori);
            // TODO: This line of code loads data into the 'denemeSakınveriyazma.TblMalzeme' table. You can move, or remove it, as needed.
          
            // TODO: This line of code loads data into the 'denemeSakınveriyazma.TblSubKategori' table. You can move, or remove it, as needed.
            this.tblSubKategoriTableAdapter.Fill(this.denemeSakınveriyazma.TblSubKategori);
            // TODO: This line of code loads data into the 'denemeSakınveriyazma.TblBabaKategori' table. You can move, or remove it, as needed.
            this.tblBabaKategoriTableAdapter.Fill(this.denemeSakınveriyazma.TblBabaKategori);
            g4listele();
            tblmalzemelistele();
            g5listele();
        }

        istakipEntities1 db = new istakipEntities1();   

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            textBox1.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
        }

        void listele()
        {
            //ColumnView view = gridView2;
            //view.ActiveFilter.Add(view.Columns["AnaKategori"], new ColumnFilterInfo("[Altkategori] Like '"+textBox1.Text+"%'", ""));
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int anakategorisec = 1;
            anakategorisec = Convert.ToInt32(textBox1.Text);
            dataGridView1.DataSource = db.TblSubKategori.Where(x => x.AnaKategori == anakategorisec).ToList();
        }

        void g4listele()
        {
            var degerler = (from x in db.TblSubKategori
                            select new
                            {
                                x.ID,
                                x.AnaKategori,
                                x.AltKategori,
                                

                               

                            });
            dataGridView1.DataSource = degerler.ToList();

        }

       void tblmalzemelistele()
        {
            var degerler = (from x in db.TblMalzeme
                            select new
                            {
                                x.ID,
                                x.Malzemeler,
                                x.Aciklama,
                                x.Görsel,





                            });
            dataGridView1.DataSource = degerler.ToList();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        //    int altkategorisec = 1;
        //    altkategorisec = Convert.ToInt32(textBox2.Text);
        //    dataGridView2.DataSource = db.TblSubKategori.Where(x => x.AnaKategori == altkategorisec).ToList();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
           //textBox2.Text = dataGridView2.GetFocusedRowCellValue("ID").ToString();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
           //
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

        }
        #region grid view 2 işlemleri

        void g5listele()
        {
            var degerler = (from x in db.TblSubKategori
                            select new
                            {
                                x.ID,
                                x.AnaKategori,
                                x.AltKategori,




                            });
            gridControl2.DataSource = degerler.ToList();

        }



        void gridView2_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            
        }
        #endregion




    }
}
