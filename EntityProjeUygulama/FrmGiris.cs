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
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            DbEntityUrunEntities db=new DbEntityUrunEntities();
            var sorgu = from x in db.TBLADMIN where x.KULLANICI == txtKullaniciAd.Text && x.SIFRE == txtSifre.Text select x;
            if (sorgu.Any())
            {
                  FrmAnaForm frm= new FrmAnaForm();
                frm.ShowDialog();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Giriş","Bilgi");
            }
        }
    }
}
