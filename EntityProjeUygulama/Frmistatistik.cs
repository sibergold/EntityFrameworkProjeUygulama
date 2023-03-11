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
    public partial class Frmistatistik : Form
    {
        public Frmistatistik()
        {
            InitializeComponent();
        }
             DbEntityUrunEntities db=new DbEntityUrunEntities();
        private void Frmistatistik_Load(object sender, EventArgs e)
        {
            lblToplamKategori.Text= db.TBLKATEGORI.Count().ToString();
            lblUrunSayisi.Text=db.TBLURUN.Count().ToString(); 
            lblAktifMusteri.Text=db.TBLMUSTERI.Count(x=>x.DURUM==true).ToString();
            lblPasifMusteri.Text = db.TBLMUSTERI.Count(x => x.DURUM == false).ToString();
            lblToplamStok.Text=db.TBLURUN.Sum(y=>y.STOK).ToString();
            lblKasaTutar.Text = db.TBLSATIS.Sum(z => z.FIYAT).ToString()+ "TL";
            lblEnYuksek.Text=(from x in db.TBLURUN orderby x.FİYAT descending select x.URUNAD).FirstOrDefault();
            lblEnDusuk.Text=(from x in db.TBLURUN orderby x.FİYAT ascending select x.URUNAD).FirstOrDefault();
            lblBeyazEsya.Text = db.TBLURUN.Count(x => x.KATEGORI == 1).ToString();
            lblToplamBuzdolabi.Text= db.TBLURUN.Count(x=>x.URUNAD=="BUZDOLABI").ToString();
            lblSehir.Text=(from x in db.TBLMUSTERI select x.MUSTERISEHIR ).Distinct().Count().ToString();
            lblEnFazlaMarka.Text=db.MARKAGETIR().FirstOrDefault();


        }
    }
}
