using System;
using System.Drawing;
using System.Windows.Forms;

class Nesne
{
    public Label lbl;
    public int w;
    public int h;
    public int deger;
    public Point lokal;
    public int GeldiYon;
    public bool yukari;
    public bool asagi;
    public bool sol;
    public bool sag;
    public Nesne(int w, int h, Label lbl, int deger, Point lokal)
    {
        this.lbl = lbl;
        this.w = w;
        this.h = h;
        this.deger = deger;
        this.lokal = lokal;

    }
}