using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Correo:IMostrar<List<Paquete>>
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

        public void FinEntregas()
        {
            foreach (Thread t in this.mockPaquetes)
            {
                if(t != null)
                {
                    if (t.IsAlive)
                    {
                        t.Abort();
                    }
                }
            }
        }

        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            List<Paquete> listaPaquetesAuxiliar = (List<Paquete>)elementos;
            string datosPaquetes = "";

            foreach (Paquete p in listaPaquetesAuxiliar)
            {
                datosPaquetes+=string.Format($"{p.TrackingID} para {p.DireccionEntrega} ({p.Estado.ToString()})\n");
            }

            return datosPaquetes;
        }

        #region Sobrecarga
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
