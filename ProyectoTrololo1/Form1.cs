using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSGL12;

namespace ProyectoTrololo1
{
    public partial class Form1 : Form
    {

        public Handler handler;

        public Form1()
        {
            InitializeComponent();
        //llamar el handler de opengl
            handler = new Handler(); // manejador de eventos de OpenGL
            //Registrar los manejadores de eventos de OpenGL y sobreescrituras de paint, mouse, etc...
            csgL12Control1.OpenGLStarted += new CSGL12Control.DelegateOpenGLStarted(handler.OpenGLStarted);
            csgL12Control1.Paint += new PaintEventHandler(handler.Paint);
        }
    }
}
