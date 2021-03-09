using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace NylandCallingCinJavascript
{
    public partial class Form1 : Form
    {
        [ComVisible(true)]
        public Form1()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form1_Load);
            this webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);

            //if you want to call the C# code (method in java script function then write this code
            webBrowser1.ObjectForScripting = this;
            webBrowser1.ScriptErrorsSuppressed = false;

            //if you want to disable right click on web browser control then write this code
            webBrowser1.IsWebBrowserContextMenuEnabled = false;
            webBrowser1.AllowWebBrowserDrop = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // in below written code you have to get the directory of this application
            string CurrentDirectory = Directory.GetCurrentDirectory();
            //Here you have to call HTML page using navigate method. It's mandatoryto call navigate method when you have to fire web browser Document Completed Event
            webBrowser1.Navigate(Path.Combine(CurrentDirectory, "HTMLPageforJavaScript.html"));
        }

        private void Report()
        {
            //here I have to get the HTML page from if of Div
            HtmlElement div = webBrowser1.Document.GetElementById("reportContent");

            //here create a simple html content
            StringBuilder sb = new StringBuilder();
            sb.Append("<table>");
            sb.Append("<tr><td><B> Hi this is my report demo</B></td></tr>");
            sb.Append("</table>");

            //here I have to assign content to the HTML page div which is displayed on browser control
            div.InnerHtml = sb.ToString();
        }
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //when the form is load cursor focus on the Web Browser control
            webBrowser1.Focus();

            //call report method which contains the report content
            Report();
        }

        public void PrintReport()
        {
            //this will show print dialog and call print methog of webbrowser control
            DialogResult dr = printDialog1.ShowDialog();

            if (dr.ToString() == "OK")
            {
                webBrowser1.Print();
            }
            else
            {
                return;
            }

        }
    }
}
