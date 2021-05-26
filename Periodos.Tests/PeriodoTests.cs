using Periodos.LibraryClass;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Periodos.Tests
{
    [TestClass]
    public class PeriodoTests
    {

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NaoDeveSerDataValida()
        {
            _ = new Periodo("aaaa");
        }

        [TestMethod]
        public void DeveRetornarDiasDecorridos()
        {
            Periodo data = new Periodo("25/05/2021");

            Assert.AreEqual("Um dia atrás", data.TempoDecorrido);
        }

        [TestMethod]
        public void DeveRetornarSemanasDecorridas()
        {
            Periodo data = new Periodo("19/05/2021");

            Assert.AreEqual("Uma semana atrás", data.TempoDecorrido);
        }

        [TestMethod]
        public void DeveRetornarMesesDecorridos()
        {
            Periodo data = new Periodo("26/01/2021");

            Assert.AreEqual("Tres meses atrás", data.TempoDecorrido);
        }

        [TestMethod]
        public void DeveRetornarAnosDecorridos()
        {
            Periodo data = new Periodo("26/05/2019");

            Assert.AreEqual("Dois anos atrás", data.TempoDecorrido);
        }
    }
}
