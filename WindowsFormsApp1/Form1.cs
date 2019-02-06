using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public int onay = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            string s = textBox1.Text.Trim();
            string[] aranacakdeger = { "yazdir","oku"};
            var say = 0;
            string[] kelimeler = s.Split(';');
            int top = kelimeler.Length - 1;
            if (s.Substring(0,6)=="BASLA{" && kelimeler[kelimeler.Length-1]=="\r\n}")
            {

            for (int k = 0;k < top; k++)
            {
                for (int i = 0; i < aranacakdeger.Length; i++)
                {

               
            int deger = s.IndexOf(aranacakdeger[i],say);
                if (deger!=-1)
                {
            
            var ara = s.IndexOf(";",say+1);
            if (ara!=-1)
            {
                       
                    say = ara;
                        if (i == 0)
                        {
                            string al = s.Substring(deger, ara - deger) + ";";

                            var ilk = al.IndexOf("\"");
                            var ikinci = al.IndexOf("\"", ilk + 1);
                                    if (ilk < 0 && ikinci < 0)
                                    {
                                        textBox2.Text = "Yazılan komut eksik veya yanlış...";
                                        return;
                                    }
                           var sonuc = al.Substring(ilk + 1, ikinci - ilk - 1);


                            if ("yazdir(\"" + sonuc + "\");" == al)
                            {
                                        if (textBox2.Text=="")
                                        {
                                            textBox2.Text += sonuc;
                                        }
                                        else
                                        {
                                            textBox2.Text += "\r\n" + sonuc;
                                        }
                               
                            }
                        }else if (i == 1) {
                           
                            string al = s.Substring(deger, ara - deger) + ";";
                                var ilk = al.IndexOf("\"");
                                var ikinci = al.IndexOf("\"", ilk + 1);
                                    if (ilk<0 && ikinci<0)
                                    {
                                        textBox2.Text = "Yazılan komut eksik veya yanlış...";
                                        return;
                                    }
                                var sonuc = al.Substring(ilk + 1, ikinci - ilk - 1);
                                     if ("oku(\"" + sonuc + "\");" == al)
                                     {
                                                   fOkuyucu ff = new fOkuyucu();
                                                   ff.label1.Text = sonuc;
                                                   ff.ShowDialog();
                                                    if (textBox2.Text=="")
                                                    {
                                                        textBox2.Text += ff.txtdeger.Text;
                                                    }
                                                    else
                                                    {
                                                        textBox2.Text += "\r\n" + ff.txtdeger.Text;
                                                    }
                                       

                                    }
                                    
                        }
                        else
                       {
                        textBox2.Text = "Yazılan komut eksik veya yanlış...";
                        }
            }else if (ara + 2 == s.Length)
              {
                  return;
              }
            else
            {
                textBox2.Text = "Yazılan komut eksik veya yanlış...";
            }
                }
            }
          }
            }
            else
            {
               textBox2.Text = "Yazılan komut eksik veya yanlış...";
            }

        }

       
  }
}
