using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace NeroEvents
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (PdfDocument doc = new PdfDocument())
            {
                PdfPage page = doc.AddPage();

                XGraphics gfx = XGraphics.FromPdfPage(page);

                XFont font = new XFont("Arial", 60, XFontStyle.Bold);
                

                gfx.DrawRectangle(XBrushes.Black, new XRect(0, 0, page.Width, page.Height));

                string logoPath = "../../Resources/NEROEVENTSHIRE2.png";

                DrawLogoImage(gfx, logoPath, 10, 20, 100, 100);


                string name = txtName.Text;
                XColor color = XColor.FromArgb(90, 86, 54);

                gfx.DrawString("YOUR INVOICE", font, XBrushes.DarkGray, new XRect(140, 0, page.Width, 120), XStringFormats.CenterLeft);

                
                gfx.DrawLine(new XPen(color, 0.1), 10, 150, (page.Width - 10), 150);

                gfx.DrawLine(new XPen(color, 0.1), 10, (page.Height - 50), (page.Width - 10), (page.Height - 50));

                Random rand = new Random();

                var randString = rand.Next();

                string fileName = String.Format(@"C:\Users\kwezim\Documents\PoE\NeroEventsAndHire{0}.pdf", randString.ToString());
                doc.Save(fileName);
                
                Process.Start(fileName);
                
            }
        }

        private void DrawLogoImage(XGraphics gfx, string logoPath, int x, int y, int width, int height)
        {
            XImage logo = XImage.FromFile(logoPath);
            gfx.DrawImage(logo, x, y, width, height);
        }
        
    }
}
