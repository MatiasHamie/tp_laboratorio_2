using System;
using System.Collections.Generic;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestUnitarios
{
    [TestClass]
    public class TestUnitariosCorreo
    {
        [TestMethod]
        public void PaqueteInstanciado()
        {
            Correo c = new Correo();

            Assert.IsInstanceOfType(c.Paquetes, typeof(List<Paquete>));
        }

        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void PaquetesIguales()
        {
            Correo c = new Correo();
            Paquete p1 = new Paquete("sarasa 162", "0303456");
            Paquete p2 = new Paquete("sin nombre 856", "0303456");

            c += p1;
            c += p2;
        }
    }
}
