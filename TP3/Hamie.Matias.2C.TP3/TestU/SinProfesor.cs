using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesAbstractas;
using EntidadesInstanciables;
using Excepciones;

namespace TestU
{
    [TestClass]
    public class SinProfesor
    {
        [TestMethod]
        [ExpectedException(typeof(SinProfesorException))]
        public void TestMethod1()
        {
            Universidad universidad = new Universidad();

            universidad += Universidad.EClases.Legislacion;
        }
    }
}
