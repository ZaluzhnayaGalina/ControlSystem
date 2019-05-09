using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ControlSystem
{
    class GraphCheck
    {
        public static double Check(double[] xTrueAnsw, double[] yTrueAnsw, double[] xFactAnsw, double[] yFactAnsw, int numbOfFactor)
        {
            double[,] XYtrue = new double[2, xTrueAnsw.Count()];
            double[,] XYfact = new double[2, xFactAnsw.Count()];

            for (int i = 0; i < XYtrue.Length/2; i++)
            {
                XYtrue[0, i] = xTrueAnsw[i];
                XYtrue[1, i] = yTrueAnsw[i];
            }
            for (int i = 0; i < XYfact.Length/2; i++)
            {
                XYfact[0, i] = xFactAnsw[i];
                XYfact[1, i] = yFactAnsw[i];
            }

            double[,] trueMatrix = MakeSystem(XYtrue, numbOfFactor);
            double[,] factMatrix = MakeSystem(XYfact, numbOfFactor);

            double[] trueCof = Gauss(trueMatrix, numbOfFactor, numbOfFactor + 1);
            double[] factCof = Gauss(factMatrix, numbOfFactor, numbOfFactor + 1);

            for (int i = 0; i < trueCof.Count(); i++)
            {
                if (trueCof[0] != 0)
                {
                    trueCof[i] = trueCof[i] / Math.Abs(trueCof[0]);
                }
                if (factCof[0] != 0)
                {
                    factCof[i] = factCof[i] / Math.Abs(factCof[0]);
                }
            }

            double err = 0;
            for (int i = 0; i < trueCof.Count(); i++)
            {
                err += Math.Pow(trueCof[i] - factCof[i], 2);
            }
            err = err / trueCof.Count();

            return err;
        }

        private static double[,] MakeSystem(double[,] xyTable, int basis)
        {
            double[,] matrix = new double[basis, basis + 1];
            for (int i = 0; i < basis; i++)
            {
                for (int j = 0; j < basis; j++)
                {
                    matrix[i, j] = 0;
                }
            }
            for (int i = 0; i < basis; i++)
            {
                for (int j = 0; j < basis; j++)
                {
                    double sumA = 0, sumB = 0;
                    for (int k = 0; k < xyTable.Length/2; k++)
                    {
                        sumA += Math.Pow(xyTable[0, k], i) * Math.Pow(xyTable[0, k], j);
                        sumB += xyTable[1, k] * Math.Pow(xyTable[0, k], i);
                    }
                    matrix[i, j] = sumA;
                    matrix[i, basis] = sumB;
                }
            }
            return matrix;
        }

        private static double[] Gauss(double[,] matrix, int rowCount, int colCount)
        {
            int i;
            int[] mask = new int[colCount - 1];
            for (i = 0; i < colCount - 1; i++) mask[i] = i;
            if (GaussDirectPass(ref matrix, ref mask, colCount, rowCount))
            {
                double[] answer = GaussReversePass(ref matrix, mask, colCount, rowCount);
                return answer;
            }
            else return null;
        }

        private static bool GaussDirectPass(ref double[,] matrix, ref int[] mask,
            int colCount, int rowCount)
        {
            int i, j, k, maxId, tmpInt;
            double maxVal, tempDouble;
            for (i = 0; i < rowCount; i++)
            {
                maxId = i;
                maxVal = matrix[i, i];
                for (j = i + 1; j < colCount - 1; j++)
                    if (Math.Abs(maxVal) < Math.Abs(matrix[i, j]))
                    {
                        maxVal = matrix[i, j];
                        maxId = j;
                    }
                if (maxVal == 0) return false;
                if (i != maxId)
                {
                    for (j = 0; j < rowCount; j++)
                    {
                        tempDouble = matrix[j, i];
                        matrix[j, i] = matrix[j, maxId];
                        matrix[j, maxId] = tempDouble;
                    }
                    tmpInt = mask[i];
                    mask[i] = mask[maxId];
                    mask[maxId] = tmpInt;
                }
                for (j = 0; j < colCount; j++) matrix[i, j] /= maxVal;
                for (j = i + 1; j < rowCount; j++)
                {
                    double tempMn = matrix[j, i];
                    for (k = 0; k < colCount; k++)
                        matrix[j, k] -= matrix[i, k] * tempMn;
                }
            }
            return true;
        }

        private static double[] GaussReversePass(ref double[,] matrix, int[] mask,
            int colCount, int rowCount)
        {
            int i, j, k;
            for (i = rowCount - 1; i >= 0; i--)
                for (j = i - 1; j >= 0; j--)
                {
                    double tempMn = matrix[j, i];
                    for (k = 0; k < colCount; k++)
                        matrix[j, k] -= matrix[i, k] * tempMn;
                }
            double[] answer = new double[rowCount];
            for (i = 0; i < rowCount; i++) answer[mask[i]] = matrix[i, colCount - 1];
            return answer;
        }
    }
}
