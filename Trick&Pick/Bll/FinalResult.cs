using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Bll
{
   public class FinalResult
    {
        SmartMatchEntities db = new SmartMatchEntities();
        Dictionary<int, List<TutorForApprenticeTbl>> dResult = new Dictionary<int, List<TutorForApprenticeTbl>>();
        public TutorForApprenticeTbl[,] globalMat;
        public TutorForApprenticeTbl[,] orginalMat;

        public FinalResult(TutorForApprenticeTbl [,] gMat, TutorForApprenticeTbl[,] oMat)
        {
            globalMat = new TutorForApprenticeTbl[gMat.GetLength(0), gMat.GetLength(0)];
            orginalMat = new TutorForApprenticeTbl[oMat.GetLength(0), oMat.GetLength(0)];
            for (int i = 0; i < gMat.GetLength(0); i++)
            {
                for (int j = 0; j < gMat.GetLength(0); j++)
                {
                    globalMat[i, j] = new TutorForApprenticeTbl(gMat[i, j]);
                    orginalMat[i, j] = new TutorForApprenticeTbl(oMat[i, j]);
                }
            }
        }
        // מקבלת מטריצה ומחזירה מילון ובו כל הפתרונות האופטימליים שהתקבלו לאחר ביצוע האלגוריתם
        public Dictionary<int, List<TutorForApprenticeTbl>> LstFinalResult()
        {
            Dictionary<int, List<TutorForApprenticeTbl>> dSolution = new Dictionary<int, List<TutorForApprenticeTbl>>();
            int count = 0;
            TutorForApprenticeTbl[,] tempMat;
            TutorForApprenticeTbl[,] Orginalm;
            for (int i = 0; i < globalMat.GetLength(0); i++)
            {
                if (globalMat[0, i].MatchLevelScore == 0)
                {
                    TutorForApprenticeTbl firstInLst = orginalMat[0, i];
                    tempMat = GetSubmatrix(globalMat, 0, i);//תת מטריצה נוכחית
                    Orginalm = GetSubmatrix(orginalMat, 0, i);//תת מטריצה מקורית 
                    if (IsSubFiniteIsZero(tempMat))
                    {
                        List<List<TutorForApprenticeTbl>> slo = ReturnsAllPossibleSolutions(tempMat, Orginalm, firstInLst);
                        foreach (var item in slo.ToList())
                            dSolution.Add(count++, item);
                    }
                }
            }
            return dSolution;
        }

        //פעולה המקבלת מטריצה ומחזירה את תת המטריצה שלה
        public TutorForApprenticeTbl[,] GetSubmatrix(TutorForApprenticeTbl[,] mat, int row, int coulnm)
        {
            TutorForApprenticeTbl[,] subMat = new TutorForApprenticeTbl[mat.GetLength(0) - 1, mat.GetLength(0) - 1];
            int r = 0, c = 0;
            //הכנת התת מטריצה
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(0); j++)
                {
                    if (i != row && j != coulnm)
                    {
                        if (r < subMat.GetLength(0) && c < subMat.GetLength(0))
                            subMat[r, c] = new TutorForApprenticeTbl(mat[i, j]);
                        c++;
                        if (c == mat.GetLength(0) - 1 && r + 1 < mat.GetLength(0) - 1)
                        {
                            c = 0;
                            r++;
                        }
                    }
                }
            }
            return subMat;
        }
        /// פונקציה המקבלת מטריצה לאחר ביצוע "הונגרי" ומחזירה את כל הפתרונות האפשריים של תת מטריצה מסוים
        public List<List<TutorForApprenticeTbl>> ReturnsAllPossibleSolutions(TutorForApprenticeTbl[,] mat, TutorForApprenticeTbl[,] matorginal, TutorForApprenticeTbl first)
        {
            List<List<TutorForApprenticeTbl>> lstSlo = new List<List<TutorForApprenticeTbl>>();
            for (int j = 0; j < mat.GetLength(0); j++)
            {
                List<int> Rows = new List<int>(), Colunms = new List<int>();
                List<TutorForApprenticeTbl> finalSluotion = new List<TutorForApprenticeTbl>();
                TutorForApprenticeTbl[,] subMatrix = GetSubmatrix(mat, 0, j);//תת מטריצה 
                if (mat[0, j].MatchLevelScore == 0)
                {
                    if (IsSubFiniteIsZero(subMatrix))
                    {
                       
                        finalSluotion.Add(matorginal[0, j]);
                        Rows.Add(0);
                        Colunms.Add(j);

                        for (int r = 0; r < mat.GetLength(0); r++)
                        {
                            for (int c = 0; c < mat.GetLength(0); c++)
                            {
                                if (mat[r, c].MatchLevelScore == 0)
                                {
                                    TutorForApprenticeTbl[,] m1 = GetSubmatrix(mat, r, c);
                                    if (IsSubFiniteIsZero(m1) && !Colunms.Contains(c) && !Rows.Contains(r))
                                    {
                                        finalSluotion.Add(matorginal[r, c]);
                                        Rows.Add(r);
                                        Colunms.Add(c);
                                    }
                                }
                            }
                        }
                    }
                }
                if (finalSluotion.Count() == mat.GetLength(0))
                {
                    finalSluotion.Add(first);
                    lstSlo.Add(finalSluotion);
                }

            }
            return lstSlo;

        }
        //פונקציה רקורסיבית אשר מחזירה עבור תת מטריצה האם הוא 0
        public bool IsSubFiniteIsZero(TutorForApprenticeTbl[,] mat)
        {
            if (mat.GetLength(0) == 0)
            {
                return true;
                if (mat[0, 0].MatchLevelScore == 0)
                    return true;
                return false;
            }
            if (mat.GetLength(0) == 1)
            {
               if( mat[0, 0].MatchLevelScore == 0)
                return true;
                  return false;
            }
            else
            {
                TutorForApprenticeTbl[,] submatrix;
                int zeros = ExpansionMethods.ZeroInArr(mat, 0,true); 
                if (zeros == 0)
                    return false;
                for (int i = 0; i < mat.GetLength(0); i++)
                {
                    if (mat[0, i].MatchLevelScore == 0)
                    {
                        submatrix = GetSubmatrix(mat, 0, i);
                        if (IsSubFiniteIsZero(submatrix))
                            return true;
                    }
                }
            }
            return true;
        }
        // מקבלת מילון רשימות תוצאות ומחזירה את הרשימה בעלת הסטיית תקו הנמוכה ביותר
        public List<TutorForApprenticeTbl> getFinalSlution(Dictionary<int, List<TutorForApprenticeTbl>> resultDictionary)
        {
            double min = int.MaxValue;
            int min_i = 0;
            foreach (KeyValuePair<int, List<TutorForApprenticeTbl>> entry in resultDictionary)
            {
                double sd = StandardDeviation(entry.Value);
                if (sd < min)
                {
                    min = sd;
                    min_i = entry.Key;
                }
            }
            return resultDictionary[min_i];
        }
        // מקבלת רשימה ומחזירה את סטיית התקן שלה
        public double StandardDeviation(List<TutorForApprenticeTbl> lst)
        {
            int sum = 0;
            double avg = 0, standard_deviation = 0, sd = 0;

            foreach (var item in lst)
            {
                sum += Convert.ToInt32(item.MatchLevelScore);
            }
            avg = sum / lst.Count();
            foreach (var item in lst)
            {
                sd += Math.Pow((double)(item.MatchLevelScore - avg), 2);
            }
            double result = (double)1 / (double)lst.Count();
            result *= sd;
            standard_deviation = Math.Sqrt(result);
            return standard_deviation;

        }
        public List<TutorForApprenticeTbl > getFinalLst()
        {
            dResult = LstFinalResult();
            List<TutorForApprenticeTbl> l = getFinalSlution(dResult);
            return l;
        }
    }
  
}
