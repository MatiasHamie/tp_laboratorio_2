using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesAbstractas;
using EntidadesInstanciables;
using Excepciones;

namespace TestU
{
    [TestClass]
    public class Null
    {
        [TestMethod]
        public void TestNotNullListAlumnos()
        { 
            Universidad universidad = new Universidad();
            Assert.IsNotNull(universidad.Alumnos);
        }
        [TestMethod]
        public void TestNotNullListInstructores()
        {
            Universidad universidad = new Universidad();
            Assert.IsNotNull(universidad.Instructores);
        }
        [TestMethod]
        public void TestNotNullListJornadas()
        {
            Universidad universidad = new Universidad();
            Assert.IsNotNull(universidad.Jornadas);
        }
    }
}
