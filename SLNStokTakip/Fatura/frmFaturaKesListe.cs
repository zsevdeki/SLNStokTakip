using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SLNStokTakip.Hangar;

namespace SLNStokTakip.Fatura
{
    public partial class frmFaturaKesListe : Form
    {
        DbStokDataContext _db = new DbStokDataContext();
        Formlar _f = new Formlar();

        public bool Secim = false;
        int _secimId = -1;
        public string UstL;

        public frmFaturaKesListe()
        {
            InitializeComponent();
        }

        private void frmFaturaKesListe_Load(object sender, EventArgs e)
        {
            Listele();
        }

        void Listele()
        {
            Liste.Rows.Clear();
            int i = 0;
            var lst = (from s in _db.ftFaturaKesUsts select s).ToList();
            foreach(var k in lst)
            {
                Liste.Rows.Add();
                Liste.Rows[i].Cells[0].Value = k.FKayitNo;
                Liste.Rows[i].Cells[1].Value = k.bgFirma.Fadi;
                Liste.Rows[i].Cells[2].Value = k.Tarih;
                Liste.Rows[i].Cells[3].Value = k.Saat;
                Liste.Rows[i].Cells[4].Value = k.Ttutar;
                i++;
            }
            Liste.AllowUserToAddRows = false;
        }
        void Sec()
        {
            try
            {
                _secimId = int.Parse(Liste.CurrentRow.Cells[0].Value.ToString());
            }
            catch (Exception)
            {
                _secimId = -1;
            }
        }

        private void btnBul_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Liste_DoubleClick(object sender, EventArgs e)
        {
            Sec();
            //Secim = true;
            switch(UstL)
            {
                case "D":
                    if (Secim && _secimId > 0)
                    {
                        AnaSayfa.Aktarma1 = _secimId;
                        Close();
                        //_f.FaturaCikis();
                    }
                    break;
                case "S":
                    if (Secim && _secimId > 0)
                    {
                        AnaSayfa.Aktarma1 = _secimId;
                        Close();
                         _f.FaturaCikis();
                    }
                    break;
            }            
        }
    }
}
