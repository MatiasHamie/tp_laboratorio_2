using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        #region Campos
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;
        #endregion

        #region Propiedades
        public List<Paquete> Paquetes
        {
            get { return this.paquetes; }
            set { this.paquetes = value; }
        }
        #endregion

        #region Métodos

        #region Constructores
        public Correo()
        {
            mockPaquetes = new List<Thread>();
            paquetes = new List<Paquete>();
        }
        #endregion

        /// <summary>
        /// Finaliza todos los threads que sigan abiertos
        /// </summary>
        public void FinEntregas()
        {
            foreach (Thread t in this.mockPaquetes)
            {
                if (t != null)
                {
                    if (t.IsAlive)
                    {
                        t.Abort();
                    }
                }
            }
        }
    
        /// <summary>
        /// Muestra datos del paquete
        /// </summary>
        /// <param name="elementos"></param>
        /// <returns>string datoPaquetes</returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            Correo cAuxiliar = (Correo)elementos;
            string datosPaquetes = "";

            foreach (Paquete p in cAuxiliar.paquetes)
            {
                datosPaquetes+=string.Format($"{p.TrackingID} para {p.DireccionEntrega} ({p.Estado.ToString()})\n");
            }

            return datosPaquetes;
        }

        #region Sobrecarga

        /// <summary>
        /// Verifica y agrega un paquete al correo
        /// </summary>
        /// <param name="c"></param>
        /// <param name="p"></param>
        /// <returns>Correo correo</returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            if(c.paquetes is null)
            {
                c.paquetes.Add(p);
            }
            else
            {
                foreach (Paquete paqueteExtraido in c.paquetes)
                {
                    if (paqueteExtraido == p)
                    {
                        throw new TrackingIdRepetidoException("El paquete ya está agregado a la lista");
                    }
                }

                c.paquetes.Add(p);
            }
            
            Thread t = new Thread(p.MockCicloDeVida);
            c.mockPaquetes.Add(t);
            t.Start();

            return c;
        }
        #endregion
        
        #endregion
    }
}
