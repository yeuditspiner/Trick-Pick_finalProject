using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
namespace Bll
{
    public class HungrarianAlgorithm
    {

        public int Lines = 0;
        Dictionary<int, List<int>> dRows = new Dictionary<int, List<int>>();
        Dictionary<int, List<int>> dCoulnms = new Dictionary<int, List<int>>();
        public int key = 0;
        Dictionary<int, Point> dNon;//מילון אברים אסורים
        Dictionary<int, Point> dMarked;//מילון  אברים מסומנים    
        int[] linesOptimal;//מערך שורות מוקצות
        int[] linesoNotptimal;//מערך שורות   לא מוקצות
        int[] cells;//מערך עמודות
        //global mat
        public TutorForApprenticeTbl[,] globalMat;
        //the orginal mat
        public TutorForApprenticeTbl[,] orginalMat;
        //list of coulnm without plalcment
        public List<int> lstNonOptimalCoulnm = new List<int>();
        //list of rows without plalcment
        public List<int> lstNonOptimalRow = new List<int>();
        int row, column, minInMat = 10000;
        bool isChangeStep2, isChangeStep3;

        //מאתלחת את המטריצה
        public HungrarianAlgorithm(TutorForApprenticeTbl[,] tutorForApprentices)
        {
            globalMat = new TutorForApprenticeTbl[tutorForApprentices.GetLength(0), tutorForApprentices.GetLength(0)];
            for (int i = 0; i < tutorForApprentices.GetLength(0); i++)
            {
                for (int j = 0; j < tutorForApprentices.GetLength(0); j++)
                {
                    globalMat[i, j] = new TutorForApprenticeTbl(tutorForApprentices[i, j]);
                }
            }
            row = globalMat.GetLength(0);
            column = globalMat.GetLength(1);
        }


        //פונקציה המבצעת בשלבים את האלגוריתם
        public TutorForApprenticeTbl[,] Hungary()
        {
            ExpansionMethods.Reduction(globalMat, true);//שלב 1
            ExpansionMethods.Reduction(globalMat, false);//שלב 2
            MinimumLinesToCoverZeros();//שלב 3
            return globalMat;

        }
        //אתחול פרמטרים
        public void InitParameters()
        {
            Lines = 0;
            isChangeStep2 = true;
            isChangeStep3 = true;
            dRows = new Dictionary<int, List<int>>();
            dCoulnms = new Dictionary<int, List<int>>();
            dMarked = new Dictionary<int, Point>();
            dNon = new Dictionary<int, Point>();
            linesOptimal = new int[globalMat.GetLength(0)];
            linesoNotptimal = new int[globalMat.GetLength(0)];
            cells = new int[globalMat.GetLength(0)];
        }
        //אלגוריתם למציאת מס קויים מינימלי לכיסוי האפסים
        public void MinimumLinesToCoverZeros()
        {
            while (Lines < globalMat.GetLength(0))
            {

                InitParameters();//אתחול פרמטרים 
                step1(globalMat);
                while (!ExpansionMethods.iSZero(globalMat, dMarked, dNon))
                {
                    step1(globalMat);//סימון השורות שללא השיבוץ
                }
                isChangeStep2 = step2(globalMat);//סימון את העמודות שלהן אפסים בשורות מסומנות
                isChangeStep3 = step3(globalMat);//סימון את השורות עם שיבוץ בעמודות מסומנות
                //step 4 - חזרה על שלבים 2,3 כל עוד אין שינוי
                while (isChangeStep2 && isChangeStep3)
                {
                    isChangeStep2 = step2(globalMat);
                    isChangeStep3 = step3(globalMat);
                }
                step5(globalMat);//כיסוי בקווים את העמודות המסומנות ואת השורות הלא מסומנות
                if (Lines < globalMat.GetLength(0))
                {
                    minInMat = ExpansionMethods.GetMinValueInMat(globalMat, dRows, dCoulnms);//הערך המינימלי במטריצה שלא כוסה
                    ExpansionMethods.AddToDouble(globalMat, minInMat, dCoulnms, dRows);//הוספת האיבר לאיבר המכוסה פעמיים
                    ExpansionMethods.UnCoveredLine(globalMat, minInMat, dCoulnms, dRows);//חיסור האיבר מן האברים הלא מכוסים
                }
            }
        }
        //********פונקציות עזר לאלגוריתם************


        // למילון[i,j] הכנסת איבר ה 
        public void InsertEntry(int i, int j, TutorForApprenticeTbl[,] mat)
        {
            Point p = new Point(i, j);
            linesOptimal[i] = 1;
            dMarked.Add(key++, p);
            MarkedX(mat, i, j);
        }
        //חילוק כל איברי ה -0 במטריצה למילון המסומנים ולמילון האסורים
        public void step1(TutorForApprenticeTbl[,] mat)
        {
            //  while (!ExpansionMethods.iSZero(mat,dMarked,dNon))

            bool flag = false;
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                int r = ExpansionMethods.ExtraCountZeroInArr(mat, i, dNon, true);
                int row = ExpansionMethods.ZeroInArr(mat, i, true);
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    int c = ExpansionMethods.ExtraCountZeroInArr(mat, j, dNon, false);
                    int cell = ExpansionMethods.ZeroInArr(mat, j, false);
                    Point p = new Point(i, j);
                    //אפס אחד בשורה ובעמודה

                    if (mat[i, j].MatchLevelScore == 0 && !dMarked.Values.Contains(p) && !dNon.Values.Contains(p) && (row == 1 && cell == 1))
                    {
                        Point p1 = new Point(i, j);
                        linesOptimal[i] = 1;
                        dMarked.Add(key++, p1);
                        MarkedX(mat, i, j);
                        flag = true;
                        break;
                    }
                    //InsertEntry(i, j, mat);
                    //flag = true;
                    //break;

                    // אפס אחד רק בשורה  - כל שאר אברי האפס כבר נמצאים במילון  
                    if (mat[i, j].MatchLevelScore == 0 && !dMarked.Values.Contains(p) && !dNon.Values.Contains(p) && (r == 1 || c == 1))
                    {
                        Point p1 = new Point(i, j);
                        linesOptimal[i] = 1;
                        dMarked.Add(key++, p1);
                        MarkedX(mat, i, j);
                        flag = true;
                        break;
                        //InsertEntry(i, j, mat);
                        //flag = true;
                        //break;
                    }
                }
            }
            ////סימון השורות שלא הוקצו
            //for (int i = 0; i < mat.GetLength(0); i++)
            //{
            //    if (linesOptimal[i] == 0)
            //        linesoNotptimal[i] = 1;
            //}
            if (flag == false)//כלומר אם לא היה שום שינוי
            {
                for (int i = 0; i < mat.GetLength(0); i++)
                {
                    for (int j = 0; j < mat.GetLength(0); j++)
                    {
                        Point p = new Point(i, j);
                        if (mat[i, j].MatchLevelScore == 0 && !dMarked.Values.Contains(p) && !dNon.Values.Contains(p))
                        {
                            InsertEntry(i, j, mat);
                            flag = true;
                            break;
                        }
                    }
                }
            }
        }
        //סימון העמודות המשובצות
        public bool step2(TutorForApprenticeTbl[,] mat)
        {
            bool flag = false;
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                if (linesOptimal[i] == 0)//אם זה שורה לא מסומנת
                {
                    for (int a = 0; a < mat.GetLength(0); a++)
                    {
                        Point p = new Point(i, a);
                        if (mat[i, a].MatchLevelScore == 0 && dNon.Values.Contains(p) && cells[a] == 0)
                        {
                            cells[a] = 1;
                            flag = true;//אם יש שינוי
                        }
                    }
                }
            }
            return flag;
        }
        //סימון השורות עם שיבוץ בעמודות מסומנות
        public bool step3(TutorForApprenticeTbl[,] mat)
        {
            bool flag = false;
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                if (cells[i] == 1)//אם   העמודה מסומנת וגם לשורה יש הקצאה 
                {
                    for (int x = 0; x < mat.GetLength(0); x++)
                    {
                        Point p = new Point(x, i);
                        if (dMarked.Values.Contains(p))//סימון כלא מוקצה
                        {
                            linesOptimal[x] = 0;
                            flag = true;//אם יש שינוי
                        }
                    }
                }
                linesoNotptimal[i] = 1;//סימון כשורה לא מסומנת
            }
            return flag;
        }
        //כיסוי בקווים את  העמודות מסומנות ואת השורות הלא מסומנות
        public void step5(TutorForApprenticeTbl[,] mat)
        {
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                if (linesOptimal[i] == 1 && !ExpansionMethods.isInDic(i, dRows))
                {
                    lstNonOptimalRow = craeteValyeList(i, mat.GetLength(0), mat, true);
                    ExpansionMethods.EnterToDictanery(i, lstNonOptimalRow, dRows);
                    Lines++;
                }
                for (int j = 0; j < mat.GetLength(0); j++)
                {
                    if (cells[j] == 1 && ExpansionMethods.isInDic(j, dCoulnms) == false)//אם העמודה מוקצה
                    {
                        lstNonOptimalCoulnm = craeteValyeList(j, mat.GetLength(0), mat, false);
                        dCoulnms.Add(j, lstNonOptimalCoulnm);
                        Lines++;
                    }
                }
            }
        }
        //סימון "באיקסים" את ה0 שלא יכולים להיות כמוקצים
        public void MarkedX(TutorForApprenticeTbl[,] mat, int row, int cell)
        {
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                if (i == row)
                {
                    for (int r = 0; r < mat.GetLength(0); r++)
                    {
                        Point p = new Point(i, r);
                        if (mat[i, r].MatchLevelScore == 0 && !dMarked.Values.Contains(p) && !dNon.Values.Contains(p))
                        {
                            // על 0 זה X סימון
                            Point p1 = new Point(i, r);
                            dNon.Add(key++, p1);
                        }
                    }
                }
                if (i == cell)
                {
                    for (int c = 0; c < mat.GetLength(0); c++)
                    {
                        Point p = new Point(c, i);
                        if (mat[c, i].MatchLevelScore == 0 && !dMarked.Values.Contains(p))
                        {
                            // על 0 זה X סימון
                            Point p1 = new Point(c, i);
                            dNon.Add(key++, p1);
                        }
                    }
                }
            }
        }
        //יצירת רשימה של ערכים  i
        private List<int> craeteValyeList(int index, int tutors, TutorForApprenticeTbl[,] mat, bool isLine)
        {
            List<int> lst = new List<int>();
            for (int i = 0; i < tutors; i++)
            {
                if (isLine == true)
                    lst.Add((int)mat[index, i].MatchLevelScore);
                else
                    lst.Add((int)mat[i, index].MatchLevelScore);
            }
            return lst;
        }
    }
}
