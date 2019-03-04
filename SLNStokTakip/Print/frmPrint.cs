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
using SLNStokTakip.Bilgi;
using SLNStokTakip.Print;

namespace SLNStokTakip.Print
{
    public partial class frmPrint : Form
    {
        DbStokDataContext _db = new DbStokDataContext();
        public string HangiListe;

        public frmPrint()
        {
            InitializeComponent();
        }

        private void frmPrint_Load(object sender, EventArgs e)
        {
            switch (HangiListe)
            {
                case "KulListe":
                    kulliste();
                    break;
                case "UC":
                    uruncikis();
                    break;
                default:
                    break;
            }
        }
        private void kulliste()
        {
            frmKulListe kl = Application.OpenForms["frmKulListe"] as frmKulListe;

            KulListesi cr = new KulListesi();

            var lst = (from s in _db.bgKullanicilars
                       select s).ToList();
            if(lst!=null)
            {
                PrintYardım ch = new PrintYardım();
                DataTable dt = ch.ConvertTo(lst);
                cr.SetDataSource(dt);
                crvPrint.ReportSource = cr;
            }
        }

        private void uruncikis()
        {
            int id = AnaSayfa.Aktarma;
            Stok.frmUrunCikis uc = Application.OpenForms["frmUrunCikis"] as Stok.frmUrunCikis;

            Print.pUrunCikis cr = new pUrunCikis();

            var srg = (from s in _db.vwUCs
                       where s.CikisNo == id
                       select s).ToList();
            if(srg!=null)
            {
                PrintYardım ch = new PrintYardım();
                DataTable dt = ch.ConvertTo(srg);
                cr.SetDataSource(dt);
                crvPrint.ReportSource = cr;
            }
            AnaSayfa.Aktarma = -1;
        }
    }
}
