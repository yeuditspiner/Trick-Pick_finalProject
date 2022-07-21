using Dal;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Bll
{
    public static class ExpansionMethods
    {
        //קבלת מערך משורה / עמודה ממטריצה
        public static int[] GetArr(TutorForApprenticeTbl[,] mat, int line,bool isLine)
        {
            int[] arr = new int[mat.GetLength(0)];
            for (int i = 0; i < arr.Length; i++)
            {
                if(isLine)
                arr[i] = (int)mat[line, i].MatchLevelScore;
                else
                    arr[i] = (int)mat[i, line].MatchLevelScore;
            }
            return arr;
        }
     
        //מס אפסים במערך שורה או בעמודה
        public static int CountZeroInArr(int[] arr)
        {
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 0)
                    count++;
            }
            return count;
        }

        //מס אפסים בשורות / עמודות אקסטרה
        public static int ExtraCountZeroInArr(TutorForApprenticeTbl[,] mat, int line, Dictionary<int, Point> dNon,bool isLine)
        {
            if (isLine == true)
                return CountZeroInArrExtra(GetArr(mat, line, true), dNon, line, true);
               return CountZeroInArrExtra(GetArr(mat, line, false), dNon, line, false);
        }

        //מס אפסים בשורות / בעמודות רגילות 
        public static int ZeroInArr(TutorForApprenticeTbl[,] mat, int row,bool isLine)
        {
            return isLine ? CountZeroInArr(GetArr(mat, row, true)) : CountZeroInArr(GetArr(mat, row, false));
        }

        //איבר מינימלי במערך
        public static int MinInArr(int[] arr)
        {
            int min = int.MaxValue;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < min)
                    min = arr[i];
            }
            return min;
        }
        //בודק האם יש 0 במטריצה שלא נמצא באף מילון
        public static bool iSZero(TutorForApprenticeTbl[,] mat, Dictionary<int, Point> dMarked, Dictionary<int, Point> dNon)
        {
            
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(0); j++)
                {
                    if (mat[i, j].MatchLevelScore == 0)
                    {
                        Point point = new Point(i, j);
                        if (!dMarked.Values.Contains(point) && !dNon.Values.Contains(point))
                            return false;
                    }
                }
            }
            return true;
        }
        //מס האפסים בשורה שלא נמצאים במילון המסומנים וגם לא במילון האסורים
        public static int CountZeroInArrExtra(int[] arr, Dictionary<int, Point> dNon, int row ,bool isLine)
        {

            int count = 0;
            Point p;
            for (int i = 0; i < arr.Length; i++)
            {
                if(isLine)
                   p = new Point(row, i);
                else
                    p = new Point(i, row);
                if (arr[i] == 0 && !dNon.Values.Contains(p))
                    count++;
            }
            return count;

        }
        // ערך מינימלי בשורה / עמודה 
        public static int GetMinValueInArr(TutorForApprenticeTbl[,] mat, int line,bool isLine)
        {
            int[] arr = GetArr(mat, line,true);
            int min = int.MaxValue;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < min)
                {
                    if(isLine)
                        min = (int)mat[line, i].MatchLevelScore;
                    else
                        min = (int)mat[i, line].MatchLevelScore;
                }
                    
            }
            return min;
        } 
        //הוספה לאיבר המכוסה פעמיים
        public static void AddToDouble(this TutorForApprenticeTbl[,] mat, int mininmat,  Dictionary<int, List<int>> dCoulnms, Dictionary<int, List<int>> dRows)
        {
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(0); j++)
                {
                    if (isInDic(j, dCoulnms) && isInDic(i, dRows))
                        mat[i, j].MatchLevelScore += mininmat;
                }
            }
        }
        //חיסור לשורה לא מכוסה 
        public static void UnCoveredLine(this TutorForApprenticeTbl[,] mat,int mininmat, Dictionary<int, List<int>> dCoulnms, Dictionary<int, List<int>> dRows)
        {
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(0); j++)
                {
                    if (!isInDic(i, dRows) && !isInDic(j, dCoulnms))
                        mat[i, j].MatchLevelScore -= mininmat;
                }
            }
        }
        // הערך המינימלי שלא מכוסה
        public static int GetMinValueInMat(TutorForApprenticeTbl[,] mat, Dictionary<int, List<int>> dCoulnms, Dictionary<int, List<int>> dRows)
        {
            int min = int.MaxValue;
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    // אם הערך הנוכחי לא 0 וגם קטן מהמינימום וגם לא קיים באף מילון
                    if (mat[i, j].MatchLevelScore != 0 && mat[i, j].MatchLevelScore < min &&
                        !IsInDic((int)mat[i, j].MatchLevelScore, i, dRows) &&
                        !IsInDic((int)mat[i, j].MatchLevelScore, j, dCoulnms))
                        min = (int)mat[i, j].MatchLevelScore;
                }
            }
            return min;
        }
        ///תת שלב 1- הפחתת הערך המינימלי מכל  עמודה/שורה
        public static void Reduction(this TutorForApprenticeTbl[,] mat, bool isRow)
        {
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                //i ערך מינימילי בשורה 
                int min = GetMinValueInArr(mat, i,true);
                //  i הפחתת ערך מינימלי ב שורה           
                for (int p = 0; p < mat.GetLength(0); p++)
                {
                    if (isRow) mat[i, p].MatchLevelScore -= min;
                    else mat[p, i].MatchLevelScore -= min;
                }
            }
        }

        // מתודה בוליאנית המחזירה האם שורה  נמצאת במילון  כל שהוא
     public  static bool isInDic(int r, Dictionary<int, List<int>> entry) => entry.Keys.Contains(r);


        //מתודות הכנסה למילון
        public static void EnterToDictanery(int index, List<int> lstValues, Dictionary<int, List<int>> dRows) => dRows.Add(index, lstValues);

        // בדיקה האם מס מסוים נמצא במילון  
        public static bool IsInDic(int num, int row, Dictionary<int, List<int>> entry)
        {
            if (isInDic(row, entry))
            {
                foreach (var _ in entry.Values.ToList().Where(item => item.Contains(num)).Select(item => new { }))
                {
                    return true;
                }
            }
            return false;
        }

    }
}
