using Microsoft.Web.WebView2.WinForms;
using Microsoft.Web.WebView2.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;
using static System.Net.WebRequestMethods;
namespace NavegadorWeb1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void buttonIr_Click(object sender, EventArgs e)
        {
            String nombrearchivo = @"C:\Users\dpalpirez\Downloads\NavegadorWeb1\NavegadorWeb1\Historial.txt";

            // por si escribo algo en combobox
            string url = comboBox1.Text.ToString(); 
            string direccion = comboBox1.Text.ToString(); 
            if (comboBox1.SelectedItem==null)
            {
                
                if (!(url.Contains("http")))
                {
                    url = "http://" + url;

                }
                webView21.CoreWebView2.Navigate( url);
                //webBrowser2.Navigate(new Uri(url));
                if (!(direccion.Contains('.')))
                {
                    direccion = $"http:// www.google.com/search?q={Uri.EscapeDataString(direccion)}";
                }
                webView21.CoreWebView2.Navigate(direccion);
                //webBrowser1.Navigate(direccion);
            }
            else
            {
                webView21.CoreWebView2.Navigate(comboBox1.SelectedItem.ToString());
               // webBrowser1.Navigate(new Uri(comboBox1.SelectedItem.ToString()));
            }

            FileStream flujo = new FileStream(nombrearchivo, FileMode.Append, FileAccess.Write);
            StreamWriter guardar = new StreamWriter(flujo);
            guardar.WriteLine(url);
            //Cerrar el archivo, esta linea es importante porque sino despues de correr varias veces el programa daría error de que el archivo quedó abierto muchas veces. Entonces es necesario cerrarlo despues de terminar de leerlo.
            guardar.Close();

            StreamReader reader = new StreamReader(flujo);

            while (reader.Peek() > -1)
            //Esta linea envía el texto leído a un control richTextBox, se puede cambiar para que
            //lo muestre en otro control por ejemplo un combobox
            {
                comboBox1.Items.Add(reader.ReadLine());
            }
            //Cerrar el archivo, esta linea es importante porque sino despues de correr varias veces el programa daría error de que el archivo quedó abierto muchas veces. Entonces es necesario cerrarlo despues de terminar de leerlo.
            reader.Close();
            

        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string home = "https://www.google.com/webhp?hl=es-419&sa=X&ved=0ahUKEwjeiOnihJyEAxX0TDABHcSeCzgQPAgJ";
            webView21.CoreWebView2.Navigate(home);
        }

        private void hacToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webView21.GoForward();
        }

        private void haciaDelanteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webView21.GoBack();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
