using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace ABC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int kareBoyutW = 30;
        int kareBoyutH = 30;
        List<Color> renkler = new List<Color>();
        List<Nesne> nesneler = new List<Nesne>();

        int renkCesit = 5;
        void oyunYukle()
        {
            renkleriOlustur(renkCesit);
            Random rdm = new Random();
            for (int i = 0; i < 10; i++)
            {
                for (int J = 0; J < 10; J++)
                {
                    int deger = rdm.Next(renkCesit);
                    Label lbl = new Label();
                    lbl.AutoSize = false;
                    lbl.Font = new Font(FontFamily.GenericSerif, 5);
                    lbl.Width = kareBoyutW;
                    lbl.Height = kareBoyutH;
                    lbl.BackColor = renkler[deger];
                    lbl.BorderStyle = BorderStyle.Fixed3D;
                    Point p = new Point(i * kareBoyutH, J * kareBoyutW);
                    //this.Controls.Add(lbl);
                    lbl.Text = "X:" + p.X.ToString() + "Y:" + p.Y.ToString();// "" + i + "-" + J + "";
                    lbl.Click += Lbl_Click;
                    nesneler.Add(new Nesne(kareBoyutW, kareBoyutH, lbl, deger, p));
                    //this.Refresh();
                }
            }
            Ciz();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            oyunYukle();
        }
        void Ciz()
        {
            foreach (Nesne item in nesneler)
            {
                item.lbl.Location = item.lokal;
                this.Controls.Add(item.lbl);

            }
        }
        void renkleriOlustur(int _cesit)
        {
            Random rdm = new Random();
            rdm = new Random();
            renkler.Clear();
            for (int i = 0; i < _cesit; i++)
            {
                renkler.Add(Color.FromArgb(rdm.Next(255), rdm.Next(255), rdm.Next(255)));
            }
        }
        void Kontrol(Nesne GelenNesne, int yon)
        {
            Point lp;//= new Point(-1, -1);

            //if (yon == 1)//sağ
            //{
                lp = new Point(GelenNesne.lbl.Location.X + kareBoyutW, GelenNesne.lbl.Location.Y);
                Nesne nn = nesneler.FirstOrDefault(s => s.lokal == lp);
                if (nn != null)
                {
                    if (!GelenNesne.sag)
                    {

                        if (nn.deger == GelenNesne.deger)
                        {
                            GelenNesne.sag = true;
                            nn.lbl.Text = $@"";
                            nn.lbl.BackColor =Color.White;
                            Kontrol(nn, 1);
                        }
                        else
                        {
                            GelenNesne.sag = true;
                            Kontrol(GelenNesne, 1);
                            Kontrol(GelenNesne, 2);
                            Kontrol(GelenNesne, 3);
                            Kontrol(GelenNesne, 4);

                        }

                    }
                }
            //}
            //if (yon == 2)//sol
            //{
                lp = new Point(GelenNesne.lbl.Location.X - kareBoyutW, GelenNesne.lbl.Location.Y);
                 nn = nesneler.FirstOrDefault(s => s.lokal == lp);
                if (nn != null)
                {

                    if (!GelenNesne.sol)
                    {

                        if (nn.deger == GelenNesne.deger)
                        {
                            GelenNesne.sol = true;
                            nn.lbl.Text = "";
                            nn.lbl.BackColor = Color.White;

                            Kontrol(nn, 2);
                        }
                        else
                        {
                            GelenNesne.sol = true;
                            Kontrol(GelenNesne, 1);
                           // Kontrol(GelenNesne, 2);
                            Kontrol(GelenNesne, 3);
                            Kontrol(GelenNesne, 4);
                        }
                    }
                }
            //}
            //if (yon == 3)//aşşağı
            //{
                lp = new Point(GelenNesne.lbl.Location.X, GelenNesne.lbl.Location.Y + kareBoyutH);
                 nn = nesneler.FirstOrDefault(s => s.lokal == lp);
                if (nn != null)
                {
                    if (!GelenNesne.asagi)
                    {

                        if (nn.deger == GelenNesne.deger)
                        {
                            GelenNesne.asagi = true;
                            nn.lbl.BackColor = Color.White;

                            nn.lbl.Text = "";
                            Kontrol(nn, 3);
                        }
                        else
                        {
                            GelenNesne.asagi = true;
                            Kontrol(GelenNesne, 1);
                            Kontrol(GelenNesne, 2);
                           // Kontrol(GelenNesne, 3);
                            Kontrol(GelenNesne, 4);
                        }
                    }
                }
            //}
            //if (yon == 4)//yukarı
            //{
                lp = new Point(GelenNesne.lbl.Location.X, GelenNesne.lbl.Location.Y - kareBoyutH);
                 nn = nesneler.FirstOrDefault(s => s.lokal == lp);
                if (nn != null)
                {
                    if (!GelenNesne.yukari)
                    {

                        if (nn.deger == GelenNesne.deger)
                        {
                            GelenNesne.yukari = true;
                            nn.lbl.BackColor = Color.White;

                            nn.lbl.Text = "";
                            Kontrol(nn, 4);
                        }
                        else
                        {
                            GelenNesne.yukari = true;
                            Kontrol(GelenNesne, 1);
                            Kontrol(GelenNesne, 2);
                            Kontrol(GelenNesne, 3);
                          //  Kontrol(GelenNesne, 4);
                        }
                    }
                }
            }
        //}
        private void Lbl_Click(object sender, EventArgs e)
        {
            Label l = sender as Label;
            Nesne nn = nesneler.First(s => s.lbl == l);

            Kontrol(nn, 1);
            //for (int i = 0; i < nesneler.Count; i++)
            //{
            //    if (!string.IsNullOrWhiteSpace(nesneler[i].lbl.Text))
            //    {
            //        nesneler[i].asagi = false;
            //        nesneler[i].yukari = false;
            //        nesneler[i].sag = false;
            //        nesneler[i].sol = false;
            //    }

            //}

        }
        int sayi(int i)
        {
            return i++;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Nesne item in nesneler)
            {
                item.lbl.Dispose();
            }
            nesneler.Clear();
            oyunYukle();
            //foreach (var item in this.Controls)
            //{
            //    if (item.GetType() ==typeof( Label))
            //    {
            //        Label l = item as Label;
            //        for (int i = 0; i < nesneler.Count; i++)
            //        {
            //            if (l == nesneler[i].lbl)
            //            {
            //                l.Dispose();
            //                nesneler.Remove(nesneler[i]);
            //                continue;
            //            }
            //        }
            //    }
            //}

            //progressBar1.Maximum = 1000;
            //for (int i = 0; i < 1000; i++)
            //{
            //    progressBar1.Value = sayi(i);
            //    listBox1.Items.Add(i);
            //}
        }
    }
}