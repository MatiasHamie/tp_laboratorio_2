using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Entidades.PaqueteDAO;

namespace FrmPpal
{
    public partial class FrmPpal : Form
    {
        Correo correo;

        public FrmPpal()
        {
            InitializeComponent();
            correo = new Correo();
            PaqueteDAO.errorCargaBD += PaqueteDAO_errorCargaBD;
        }

        private void PaqueteDAO_errorCargaBD(string m)
        {
            if (this.InvokeRequired)
            {
                MensajeErrorSQL d = new MensajeErrorSQL(PaqueteDAO_errorCargaBD);
                this.Invoke(d, new object[] { m });
            }
            else
            {
                MessageBox.Show(m, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Métodos

        /// <summary>
        /// Muestra informacion del paquete deseado
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elemento"></param>
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (!(elemento is null))
            {
                try
                {
                    this.rtbMostrar.Text = elemento.MostrarDatos(elemento);
                }
                catch (Exception exc)
                {
                    throw new Exception("ERROR al mostrar el paquete seleccionado", exc);
                }

                
                try
                {
                    this.rtbMostrar.Text.Guardar("salida.txt");
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al guardar archivo", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Borra los listBox y los actualiza según estado de los paquetes
        /// </summary>
        private void ActualizarEstados()
        {
            lstEstadoIngresado.Items.Clear();
            lstEstadoEnViaje.Items.Clear();
            lstEstadoEntregado.Items.Clear();

            foreach (Paquete paquete in this.correo.Paquetes)
            {
                switch (paquete.Estado)
                {
                    case Paquete.EEstado.Ingresado:
                        lstEstadoIngresado.Items.Add(paquete);
                        break;
                    case Paquete.EEstado.EnViaje:
                        lstEstadoEnViaje.Items.Add(paquete);
                        break;
                    case Paquete.EEstado.Entregado:
                        lstEstadoEntregado.Items.Add(paquete);
                        break;
                    default:
                        break;
                }
            }
        }
        #endregion

        /// <summary>
        /// Agrega paquetes al correo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if(txtDireccion.Text!="" && mtxtTrackingID.Text != "")
            {
                Paquete p = new Paquete(txtDireccion.Text, mtxtTrackingID.Text);
                try
                {
                    this.correo += p;
                    p.InformaEstado += paq_InformaEstado;
                    this.ActualizarEstados();
                }
                catch (TrackingIdRepetidoException)
                {
                    MessageBox.Show("Paquete Repetido!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Falta informacion del paquete!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handler del evento InformaEstado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                this.ActualizarEstados();
            }
        }

        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.correo.FinEntregas();
        }

        /// <summary>
        /// Muestra información de todos los paquetes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMostrarTodos_Click(object sender, EventArgs e)
        {
            try
            {
                this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
            }
            catch (Exception exc)
            {
                throw new Exception("ERROR al querer mostrar paquetes!", exc);
            }
        }

        private void FrmPpal_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Muestra información del paquete seleccionado en el rtbMostrar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
            }
            catch (Exception exc)
            {
                throw new Exception("ERROR al querer mostrar paquetes!", exc);
            }
        }
    }
}
