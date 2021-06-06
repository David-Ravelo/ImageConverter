using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageConvertGUI
{
    public partial class ImageConvert : Form
    {
        public ImageConvert()
        {
            InitializeComponent();
        }
        string ubicacion = "";
        bool imagen = false;
        string nombreFile;
        private void BtnUbicacion_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Multiselect = false, Filter = "JPEG,PNG,BMP,EMF,WMF,TIFF,ICON|*.JPG;*.PNG;*.BMP;*.EMF;*.WMF;*.TIFF;*.ICO" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    ubicacion = ofd.FileName;
                    TxtUbicacion.Text = ubicacion.ToString();
                    PtbPreview.FillColor = Color.Transparent;
                    PtbPreview.Image = Image.FromFile(ofd.FileName);
                    nombreFile = Path.GetFileNameWithoutExtension(ofd.FileName);
                    imagen = true;
                }
            }
        }
        int posX = 0;
        int posY = 0;
        private void PnlSuperior_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                posX = e.X;
                posY = e.Y;
            }
            else
            {
                Left += (e.X - posX);
                Top += (e.Y - posY);
            }
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BtnConvertir_Click(object sender, EventArgs e)
        {
            if (imagen == false)
            {
                MessageBox.Show("Seleccione una imagen", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (CmbExtension.Text == "")
            {
                MessageBox.Show("Seleccione formato a convertir", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }else if (TxtDestino.Text == "")
            {
                MessageBox.Show("Seleccione una ruta de destino", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Conversion();
            }
        }
        private void Conversion()
        {
            if(CmbExtension.Text == "PNG")
            {
                var png = Image.FromFile(ubicacion);
                png.Save(TxtDestino.Text.ToString() + "\\" + nombreFile + ".png", ImageFormat.Png);
                MessageBox.Show("Conversión exitosa","Información",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if(CmbExtension.Text == "JPEG")
            {
                var jpeg = Image.FromFile(ubicacion);
                jpeg.Save(TxtDestino.Text.ToString() + "\\"+nombreFile+".jpeg", ImageFormat.Jpeg);
                MessageBox.Show("Conversión exitosa", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if(CmbExtension.Text == "BMP")
            {
                Image img = Image.FromFile(ubicacion);
                img.Save(TxtDestino.Text.ToString() + "\\" + nombreFile + ".bmp", System.Drawing.Imaging.ImageFormat.Bmp);
                MessageBox.Show("Conversión exitosa", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (CmbExtension.Text == "EMF")
            {
                Image img = Image.FromFile(ubicacion);
                img.Save(TxtDestino.Text.ToString() + "\\" + nombreFile + ".emf", System.Drawing.Imaging.ImageFormat.Emf);
                MessageBox.Show("Conversión exitosa", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (CmbExtension.Text == "WMF")
            {
                Image img = Image.FromFile(ubicacion);
                img.Save(TxtDestino.Text.ToString() + "\\" + nombreFile + ".wmf", System.Drawing.Imaging.ImageFormat.Wmf);
                MessageBox.Show("Conversión exitosa", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (CmbExtension.Text == "TIFF")
            {
                Image img = Image.FromFile(ubicacion);
                img.Save(TxtDestino.Text.ToString() + "\\" + nombreFile + ".tiff", System.Drawing.Imaging.ImageFormat.Tiff);
                MessageBox.Show("Conversión exitosa", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (CmbExtension.Text == "ICO")
            {
                Image img = Image.FromFile(ubicacion);
                Bitmap theBitmap = new Bitmap(img, new Size(256, 256));
                theBitmap.Save(TxtDestino.Text.ToString() + "\\" + nombreFile + ".ico", System.Drawing.Imaging.ImageFormat.Icon);
                MessageBox.Show("Conversión exitosa", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void BtnDestino_Click(object sender, EventArgs e)
        {
            using(FolderBrowserDialog ofd = new FolderBrowserDialog()) 
            { 
                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    TxtDestino.Text = ofd.SelectedPath;
                }
            }
        }
    }
}
