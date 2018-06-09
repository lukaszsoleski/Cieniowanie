using Microsoft.VisualStudio.TestTools.UnitTesting;
using SGGW.MR.HilbertCurve;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace SGGW.MR.HilbertCurve.Tests
{
    [TestClass()]
    public class HilbertTests
    {
        private readonly List<double> x1 = new List<double> { -0.25000, -0.25000, 0.25000, 0.25000 };
        private readonly List<double> y1 = new List<double> { -0.25000, 0.25000, 0.25000, -0.25000 };

        private readonly List<double> x2 = new List<double> { -0.37500, -0.12500, -0.12500, -0.37500, -0.37500, -0.37500, -0.12500, -0.12500, 0.12500, 0.12500, 0.37500, 0.37500, 0.37500, 0.12500, 0.12500, 0.37500 };
        private readonly List<double> y2 = new List<double> { -0.37500, -0.37500, -0.12500, -0.12500, 0.12500, 0.37500, 0.37500, 0.12500, 0.12500, 0.37500, 0.37500, 0.12500, -0.12500, -0.12500, -0.37500, -0.37500 };



        [TestMethod()]
        public void CurveCoordinatesHaveProperLenght()
        {
            Curve c1 = Hilbert.CurvePoints(1);
            Assert.AreEqual(c1.X.Count, x1.Count);
            Assert.AreEqual(c1.Y.Count, y1.Count);
            Assert.AreEqual(c1.Y.Count, c1.X.Count);

            Curve c2 = Hilbert.CurvePoints(2);
            Assert.AreEqual(c2.X.Count, x2.Count);
            Assert.AreEqual(c2.Y.Count, y2.Count);
            Assert.AreEqual(c2.Y.Count, c2.X.Count);
        }
        [TestMethod()]
        public void CurveCoordinatesForN1HaveProperValues()
        {
            Curve c1 = Hilbert.CurvePoints(1);
            for (int i = 0; i < 4; i++)
            {
                Assert.AreEqual(c1.X[i], x1[i]);
                Assert.AreEqual(c1.Y[i], y1[i]);
            }
        }
        [TestMethod()]
        public void CurveCoordinatesForN2HaveProperValues()
        {
            Curve c2 = Hilbert.CurvePoints(2);
            for (int i = 0; i < 16; i++)
            {
                Assert.AreEqual(c2.X[i], x2[i]);
                Assert.AreEqual(c2.Y[i], y2[i]);
            }
        }
        [TestMethod()]
        public void GenerateFilesWithCurveCoordinatesUpToN8()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("en-US");

            string currentPath = Directory.GetCurrentDirectory();
            string targetPath = Path.Combine(currentPath, "HilbertCurves_8");

            if (Directory.Exists(Path.Combine(currentPath, "HilbertCurves_8")))
                Directory.Delete(targetPath);

            Directory.CreateDirectory(targetPath);

            for (int i = 1; i <= 8; i++)
            {
                Curve c = Hilbert.CurvePoints(i);
                c.ExportDataToTxt(Path.Combine(targetPath, string.Format("Hilbert{0}.txt", i)));
            }
            Assert.IsTrue(true);

        }

        [TestMethod()]
        public void DiscretizationTest()
        {

            var c = Hilbert.Discretization(1);
            Console.WriteLine("N(1) : " + c);
            c = Hilbert.Discretization(2);
            Console.WriteLine("N(2): " + c);

            Assert.IsTrue(true);
        }
    }
}