using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using CSGL12;
using System.Diagnostics;

namespace ProyectoTrololo1
{
    public class Handler
    {
        public Handler()
        {
        }
        public void OpenGLStarted(CSGL12Control csgl12Control)
        {
            GL gl = csgl12Control.GetGL();
            if (null == gl) { return; }
            // evitar parpadeos
            if (true == gl.bwglSwapIntervalEXT)
            {
                gl.wglSwapIntervalEXT(1);
            }
        }
        public void Paint(object sender, PaintEventArgs e)
        {
            if (null == sender) { return; }
            if (false == (sender is CSGL12Control)) { return; }
            //Sacar el control de GL y sus dimensiones
            CSGL12Control csgl12Control = (sender as CSGL12Control);
            GL gl = csgl12Control.GetGL();
            int clientWidth = csgl12Control.ClientRectangle.Width;
            int clientHeight = csgl12Control.ClientRectangle.Height;
            if (clientWidth <= 0)
            {
                clientWidth = 1;
            }
            if (clientHeight <= 0)
            {
                clientHeight = 1;
            }
            //Asignar un viewport 
            gl.glViewport(0, 0, clientWidth, clientHeight);
            //Limpiar la pantalla con un color de fondo
            gl.glClearColor(0.0f, 0.0f, 0.0f, 1.0f); // NEGRO
            //gl.glClearColor(1.0f, 1.0f, 0.0f, 0.0f); // AMARILLO
            //gl.glClearColor(0.0f, 0.0f, 1.0f, 1.0f); // AZUL
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

            //Proyección
            gl.glMatrixMode(GL.GL_PROJECTION);
            //El efecto de la proyeccion ortogonal es que podremos ver profundidad
            //VOy a poner aqui GL IDENTITY para que no se pierda el dibujo cuando 
            //mueva la pantalla una vez realiada la proyeccion ortogonal
            gl.glLoadIdentity();
            //gl.glOrtho(0, 10, 0 , 5, -1, 1);

            gl.glMatrixMode(GL.GL_MODELVIEW);

            // CLASE DE DIBUJOS BASICOS ***************************************

            //aqui va tu dibujito feo
            //gl.glLoadIdentity();

            //Punto en el centro de la pantalla
            //gl.glBegin(GL.GL_POINTS);

            //GL_LINES Agarra los vertices de par en par y los denomina extremos de una linea
            //Se toman en el orden que se declaran
            //gl.glBegin(GL.GL_LINES);

            //GL_TRIANGLES agarra de tres en tres puntos y dibuja un triangulo en medio 
            //gl.glBegin(GL.GL_TRIANGLES);

            //GL_QUADS hace lo mismo pero con puntos de cuatro en cuatro
            //el orden de los puntos sigue importando por que es como hará la geometría
            //el resultado es un cuadrilatero
            //gl.glBegin(GL.GL_QUADS);

            //TRIANGLE STRIP Y QUADSTRIP dibujan figuras regulares pero que se tocan y 
            //provocan franjas vacias

            //LINE STRIP hace lineas que se tocan
            //gl.glBegin(GL.GL_LINE_STRIP);

            //GlColor me acepta colores RGB
            //gl.glColor3f(1.0f, 0, 0);

            //acepta tres flotantes
            //gl.glVertex3f(0, 0, 0);
            //3fv acepta arreglos de flotantes

            //gl.glColor3f(1.0f, 0, 1.0f);
            //gl.glVertex3f(-0.5f, 0.5f, 0);

            //gl.glColor3f(1.0f, 1.0f, 0);
            //float[] a = { 0.5f, 0.5f, 0 };
            //gl.glVertex3fv(a);

            //gl.glVertex3f(0, 0.5f, 0);

            //gl.glColor3f(1.0f, 0, 1.0f);
            //gl.glVertex3f(0.5f, 0.0f, 0);

            //gl.glColor3f(1.0f, 1.0f, 0);
            //gl.glVertex3f(-0.5f, -0.5f, 0);

            //iv acepta un arreglo de enteros

            //FIN DE LA CLASE DE DIBUJOS BASICOS **************************************

            //VAMOS AELABORAR UN ALGORITMO PARA PINTAR 100 PUNTOS EN UN ARREGLO FRACTAL

            //MOVER LA CAMARA
            //gl.gluLookAt(
            //    0, .5, .5,
            //    0, 0, 0,
            //    0, 1, 0
            //    );

            gl.glBegin(GL.GL_POINTS);
            //gl.glBegin(GL.GL_TRIANGLES);

            //Damos tres puntos iniciales
            float[] a = { -1f, 1f, -1f };
            float[] b = { 0, 1f, 0 };
            float[] c = { 0, -1f, 1f };

            gl.glVertex3fv(a);
            gl.glVertex3fv(b);
            gl.glVertex3fv(c);

            int loteria;
            float lottoHoy = 1;
            float lottoAyer = 1;
            float lottoAntier = 1;
            Random r = new Random();
            float[] x = a;
            float[] y = {0,0,0};

            for (int i = 0; i < 9000; i++)
            {
                if (i > 0)
                {
                    if (i > 1)
                    {
                        lottoAntier = lottoAyer;
                    }
                    lottoAyer = lottoHoy;
                }

                loteria = r.Next(0, 3);
                Debug.WriteLine(loteria);
                //lottoHoy = loteria / 2.0f;
                lottoHoy = loteria / 2;
                //Debug.WriteLine(lottoHoy);

                //gl.glColor3f(lottoHoy, lottoAyer, lottoAntier);

                switch (loteria)
                {
                    case 0:
                        //if (i > 0)
                        //{
                        //    if (i > 1)
                        //    {
                        //        lottoAntier = lottoAyer;
                        //    }
                        //    lottoAyer = lottoHoy;
                        //}
                        y[0] = (a[0]+x[0])/2;
                        y[1] = (a[1]+x[1])/2;
                        y[2] = (a[2]+x[2])/2;
                        //gl.glColor3f(1.0f, 0.0f, 0); //ROJO
                        gl.glColor3f(lottoHoy, lottoAyer, lottoAntier);
                        //gl.glColor3f(lottoHoy, lottoAyer, lottoAntier);
                        gl.glVertex3fv(y);
                        x = y;
                        break;
                    case 1:
                        //if (i > 0)
                        //{
                        //    if (i > 1)
                        //    {
                        //        lottoAntier = lottoAyer;
                        //    }
                        //    lottoAyer = lottoAyer;
                        //}
                        y[0] = (b[0]+x[0])/2;
                        y[1] = (b[1]+x[1])/2;
                        y[2] = (b[2]+x[2])/2;
                        //gl.glColor3f(0.0f, 1.0f, 0); //VERDE
                        gl.glColor3f(lottoAntier, lottoHoy, lottoAyer);
                        //gl.glColor3f(lottoHoy, lottoAyer, lottoAntier);
                        gl.glVertex3fv(y);
                        x = y;
                        break;
                    case 2:
                        //if (i > 0)
                        //{
                        //    if (i > 1)
                        //    {
                        //        lottoAntier = lottoHoy;
                        //    }
                        //    lottoAyer = lottoHoy;
                        //}
                        y[0] = (c[0]+x[0])/2;
                        y[1] = (c[1]+x[1])/2;
                        y[2] = (c[2]+x[2])/2;
                        //gl.glColor3f(0.0f, 0.0f, 1.0f); //AZUL
                        gl.glColor3f(lottoAyer, lottoAntier, lottoHoy);
                        //gl.glColor3f(lottoHoy, lottoAyer, lottoAntier);
                        gl.glVertex3fv(y);
                        x = y;
                        break;
                    default:
                        break;
                }
            
            }

            gl.glEnd();

            // Forzar el dibujado de todo y cambiar el buffer de ser necesario
            gl.wglSwapBuffers(csgl12Control.GetHDC());
        }
    }
}
