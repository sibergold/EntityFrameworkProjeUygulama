using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityProjeUygulama
{
    public partial class FrmUrun : Form
    {
        public FrmUrun()
        {
            InitializeComponent();
        }
        DbEntityUrunEntities db=new DbEntityUrunEntities();
        public void Listele()
        {
            dataGridView1.DataSource = (from x in db.TBLURUN select new { x.URUNID, x.URUNAD, x.FİYAT, x.MARKA, x.TBLKATEGORI.AD, x.DURUM,x.STOK }).ToList();
        }
        private void btnUrunListele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            TBLURUN t=  new TBLURUN();
            t.URUNAD = txtUrunAd.Text;
            t.MARKA=txtUrunMarka.Text;
            t.STOK = short.Parse(txtUrunStok.Text);
            t.KATEGORI=int.Parse(cmbUrunKategori.Text);
            t.FİYAT=decimal.Parse(txtUrunFiyat.Text);
            t.DURUM = true;
            db.TBLURUN.Add(t);
            db.SaveChanges();
            MessageBox.Show("Ürün Kaydedildi.");
            Listele();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txtUrunId.Text);
            var urun = db.TBLURUN.Find(x);
            db.TBLURUN.Remove(urun);
            db.SaveChanges();
            MessageBox.Show("Ürün Silindi.", "Bilgi");
            Listele();
        }

        private void FrmUrun_Load(object sender, EventArgs e)
        {
            Listele();
            var kategoriler = (from x in db.TBLKATEGORI select new { x.ID, x.AD }).ToList();
            cmbUrunKategori.ValueMember = "ID";
            cmbUrunKategori.DisplayMember = "AD";
            cmbUrunKategori.DataSource= kategoriler;


        }

        private void btnUrunGuncelle_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txtUrunId.Text);
            var urun = db.TBLURUN.Find(x);
            urun.URUNAD=txtUrunAd.Text;
            urun.STOK=short.Parse(txtUrunStok.Text);
            urun.FİYAT = decimal.Parse(txtUrunFiyat.Text);
            urun.MARKA=txtUrunMarka.Text;
            db.SaveChanges();
            MessageBox.Show("Ürün Güncellendi.");
            Listele();


        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {

        }
    }
}
