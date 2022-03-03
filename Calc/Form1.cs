using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calc
{
    public partial class Form1 : Form
    {       
        static string first = "";
        static string second = "";
        static string nothing = "";

        public Form1()
        {
            InitializeComponent();
        }

        public double CALCULATOR(string first, string second, string nothing)
        {
            if (nothing == "+") {  return double.Parse(first) + double.Parse(second);   }

            else if (nothing == "-"){ return double.Parse(first) - double.Parse(second);  }

            else if (nothing == "/") { if (double.Parse(second) == 0) {  return 0; }  return double.Parse(first) / double.Parse(second); }

            else if (nothing == "X") {   return double.Parse(first) * double.Parse(second);    }

            return 0;
        }

        private void Click_Button(object sender, EventArgs e)
        {


            if (sender is Button)
            {
                Button btn = (Button)sender;

                if (btn.Text == "0" || btn.Text == "1" || btn.Text == "2" || btn.Text == "3" || btn.Text == "4" || btn.Text == "5" || btn.Text == "6" || btn.Text == "7" || btn.Text == "8" || btn.Text == "9")
                {
                    if (label1.Text == "0" || label1.Text == "+" || label1.Text == "-" || label1.Text == "X" || label1.Text == "/") { label1.Text = btn.Text; }
                    else   { label1.Text += btn.Text; }
                }

                else if (btn.Text == "+" || btn.Text == "-" || btn.Text == "X" || btn.Text == "/")
                {
                    if (label1.Text == "+" || label1.Text == "-" || label1.Text == "X" || label1.Text == "/"){  label1.Text = btn.Text;  nothing = btn.Text; }
                   
                    else{ first = label1.Text;  nothing = btn.Text;  label1.Text = btn.Text; }
                }

                else if (btn.Text == "C")
                {
                    label1.Text = "0";
                    first = "";
                    second = "";
                    nothing = "";
                }

                else if (btn.Text == "+/-")
                {
                    if (label1.Text != "0" || label1.Text != "+" || label1.Text != "-" || label1.Text != "*" || label1.Text != "/")  { label1.Text = (double.Parse(label1.Text) * -1).ToString();}
                }

                else if (btn.Text == "DELETE")
                {
                    if (label1.Text.Length == 1) { label1.Text = "0";  }

                    else { label1.Text = label1.Text.Remove(label1.Text.Length - 1); }
                }

                else if (btn.Text == "=")
                {
                    if (first != "" && nothing != "")  { second = label1.Text; label1.Text = CALCULATOR(first, second, nothing).ToString(); }

                    else
                    {
                        label1.Text = CALCULATOR(first, second, nothing).ToString();
                        first = "";
                        nothing = "";
                    }
                } 

                else if (btn.Text == ".")
                {
                    if (label1.Text.Split('.').Length == 1)  { label1.Text += ","; }
                }


            }

        }
    }
}
