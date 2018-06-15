using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SGGW.MR.Cieniowanie
{
   

   static public partial class Hilbert
    {
      
        private static Curve cur_curve;
        public static Curve CurvePoints(int depth)
        {



            if (depth <= 0)
            {
                cur_curve = new Curve();

            }
            else
            {

                Curve temp = CurvePoints(depth - 1);
                Curve prev_curve = new Curve { X = temp.X, Y = temp.Y };// Create new object instead of copying referece. 


                cur_curve.X = CalcXCoordinates(prev_curve);
                cur_curve.Y = CalcYCoordinates(prev_curve);
                cur_curve.Scale(.5);
            }
            return cur_curve;
        }
        
        #region Calculations on lists

        #region new coordinates of points
        private static List<double> CalcXCoordinates(Curve prev)
        {
            List<double> XCoordinates = new List<double>(Curve.initial_size);
            XCoordinates.AddRange(IncreaseValues(prev.Y, -0.5));
            XCoordinates.AddRange(IncreaseValues(prev.X, -0.5));
            XCoordinates.AddRange(IncreaseValues(prev.X, 0.5));
            XCoordinates.AddRange(DecreaseValues(prev.Y, 0.5));

            return XCoordinates;
        }


        private static List<double> CalcYCoordinates(Curve prev)
        {
            List<double> YCoordinates = new List<double>(Curve.initial_size);

            YCoordinates.AddRange(IncreaseValues(prev.X, -0.5));

            ICollection<double> temp = IncreaseValues(prev.Y, 0.5);
            YCoordinates.AddRange(temp);
            YCoordinates.AddRange(temp);
            YCoordinates.AddRange(DecreaseValues(prev.X, -0.5));

            return YCoordinates;
        }
        #endregion

        #region HelperMethods
        private static ICollection<double> DecreaseValues(List<double> X, double num)
        {
            ICollection<double> values = new List<double>(Curve.initial_size);
            for (int i = 0; i < X.Count; i++)
            {
                values.Add(num - X[i]);
                
            }
            return values;
        }

        private static ICollection<double> IncreaseValues(List<double> X, double num)
        {
            ICollection<double> values = new List<double>(Curve.initial_size);

            for (int i = 0; i < X.Count; i++)
            {

                values.Add(num + X[i]);
                
            }
            return values;
        }
        #endregion

        #endregion
    }


    public class Curve
    {

        public static int initial_size = 256;
        public List<double> X { get; set; }
        public List<double> Y { get; set; }

        public int Length { get { return X.Count; } }
        public Curve()
        {
            this.X = new List<double>(initial_size) { 0.0 };
            this.Y = new List<double> (initial_size){ 0.0 };
        }

        public void Scale(double num)
        {
            if (X.Count == Y.Count)
            {
                for (int i = 0; i < Y.Count; i++)
                {
                    X[i] *= num;
                    Y[i] *= num;
                }
            }
        }
        public override string ToString()
        {
            StringBuilder sbX = new StringBuilder();
            StringBuilder sbY = new StringBuilder();
            sbX.Append("X = [ ");
            sbY.Append("Y = [ ");
            if (X.Count == Y.Count)
            {
                for (int i = 0; i < X.Count; i++)
                {
                    sbX.Append(X[i]).Append(" ");
                    sbY.Append(Y[i]).Append(" ");
                }
            }
            sbX.Append("];");
            sbY.Append("];");

            sbX.Append(sbY);

            return sbX.ToString();
        }

        public void ExportDataToTxt(String path)
        {
            System.IO.File.WriteAllText(path, this.ToString());
        }
    }





}

