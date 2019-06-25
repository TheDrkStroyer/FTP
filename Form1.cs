using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace FTP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Subir_Click(object sender, EventArgs e)
        {
            //Aqui se crea el request
            FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create("ftp://files.000webhost.com/public_html/" + "/" + Path.GetFileName("C:\\Users\\dass1\\OneDrive\\Escritorio\\a20146288.txt")); //Ubicación del archivo
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential("test1pweb", "computadora321"); //Usuario y contraseña del servidor
            request.UsePassive = true;
            request.UseBinary = true;
            request.KeepAlive = false;

            //Seleccionar el archivo a subir (Ubicación del archivo)
            FileStream stream = File.OpenRead("C:\\Users\\dass1\\OneDrive\\Escritorio\\a20146288.txt"); 
            byte[] buffer = new byte[stream.Length];
            stream.Read(buffer, 0, buffer.Length);
            stream.Close();

            //Esto es para subir el archivo
            Stream reqStream = request.GetRequestStream();
            reqStream.Write(buffer, 0, buffer.Length);
            reqStream.Close();

        }
    }
}
