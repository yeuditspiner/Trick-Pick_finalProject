using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto;
using System.Drawing;
using System.Collections.ObjectModel;

namespace Bll
{

    public class HungarianAlgorithmInitializer
    {
        SmartMatchEntities db = new SmartMatchEntities();
        public DbClass dbClass = new DbClass();
        CheckingConstraints checkingConstraints;
        HungrarianAlgorithm algorithm;//משתנה מסוג מחלקה המבצעת את האלגוריתם
        FinalResult finalResult;//משתנה מסוג המחלקה המחזירה את התוצאה הסופית
        Point pointInMat = new Point();
        //global mat
        public TutorForApprenticeTbl[,] globalMat;
        //the orginal mat
        public TutorForApprenticeTbl[,] orginalMat;

        //פונקציה המנהלת את תהליך האלגוריתם
        public List<string> Main(List<int> areaLst, int placementId)
        {
            CreatePlacementByArea(areaLst, placementId);
            CopyGlobalMat();
            MaxMat();
            algorithm = new HungrarianAlgorithm(globalMat);
            globalMat = algorithm.Hungary();
            finalResult = new FinalResult(globalMat,orginalMat);
            List<TutorForApprenticeTbl> l = finalResult.getFinalLst();
            List<string > lst =  Final(l);
            return lst;
        }
        //**************פונקציות הכנה לאלגוריתם****************

        public List<string> Final(List<TutorForApprenticeTbl> lst)
        {
            int count = 0;
            List<string> l = new List<string>();
            foreach (var item in lst)
            {
                if (item.ApprenticeID != -1 && item.TutorID != -1)
                {
                    count++;
                    //item.TutorForApprenticeId = db.TutorForApprenticeTbl.Count() + 1+100;
                    dbClass.AddTutorForApprintce(item);
                    string tutorForApprintice = dbClass.GetApprenticeById((int)item.ApprenticeID).Data + dbClass.GetCharacterizationConstraintsByApprentice((int)item.ApprenticeID).ToString() + "," + dbClass.GetTutorById((int)item.TutorID).Data.ToString() + dbClass.GetCharacterizationConstraintByTutor((int)item.TutorID).ToString() + " score: " + item.MatchLevelScore;
                       
                    l.Add(tutorForApprintice+ "//\n");
                }
            }
            return l;
        }
        //ממקסמת את המטריצה
        public void MaxMat()
        {
            for (int i = 0; i < globalMat.GetLength(0); i++)
            {
                for (int j = 0; j < globalMat.GetLength(1); j++)
                    globalMat[i, j].MatchLevelScore *= -1;
            }
        }
        // פונקציה היוצרת ערכי דמה במקרה של מס חניכים וחונכים לא מאוזן
        public void Effectivy(List<ApprenticeTbl> lst1, List<TutorTbl> lst2)
        {
            int difference = Math.Abs(lst1.Count() - lst2.Count());
            int matchlevel = Math.Max(lst1.Count(), lst2.Count());


            //יצירת עמודות דמה:                 
            if (difference != 0)
            {
                if (lst1.Count() > lst2.Count())
                {
                    for (int j = 0; j < difference; j++)//מס העמודות שצריכות אפקטיביות
                    {
                        for (int i = matchlevel - difference; i < matchlevel; i++)//באיזה טור - עמודה צריך אץת האפקטיביות
                        {
                            for (int c = 0; c < matchlevel; c++)//עובר על כל העמודה הנוכחית
                            {
                                globalMat[c, i] = new TutorForApprenticeTbl();
                                globalMat[c, i].MatchLevelScore = 0;
                                globalMat[c, i].TutorID = -1;
                            }
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < difference; j++)//מס השורות שצריכות אפקטיביות
                    {
                        for (int i = matchlevel - difference; i < matchlevel; i++)//באיזה שורה  צריך  האפקטיביות
                        {
                            for (int c = 0; c < matchlevel; c++)//עובר על כל השורה הנוכחית
                            {
                                globalMat[i, c] = new TutorForApprenticeTbl();
                                globalMat[i, c].MatchLevelScore = 0;
                                globalMat[i, c].ApprenticeID = -1;
                            }
                        }
                    }
                }
            }
        }
        /// מחזירה את מיקום החונך והחניך במטריצה
        public Point FindInMat(int apprintceID, int tutorID)
        {
            Point p = new Point(0, 0);
            for (int i = 0; i < globalMat.GetLength(0); i++)
                for (int j = 0; j < globalMat.GetLength(1); j++)
                    if (globalMat[i, j].ApprenticeID == apprintceID && globalMat[i, j].TutorID == tutorID)
                    {
                        p.X = i;
                        p.Y = j;
                        return p;
                    }
            return p;
        }
        // מאתחלת את המטריצה הגלובלית
        public void InitGlobALMat(TutorForApprenticeTbl[,] mat, List<ApprenticeTbl> l1, List<TutorTbl> l2)
        {
            List<ApprenticeTbl> a = db.ApprenticeTbl.ToList();
            List<TutorTbl> t = db.TutorTbl.ToList();

            for (int i = 0; i < l1.Count(); i++)
                for (int j = 0; j < l2.Count(); j++)
                {
                    mat[i, j] = new TutorForApprenticeTbl();
                    mat[i, j].ApprenticeID = l1[i].ApprenticeID;
                    mat[i, j].TutorID = l2[j].TutorID;
                    mat[i, j].MatchLevelScore = 0;
                    mat[i, j].PlacementID = l1[i].PlacementId; 
                }
            if (l1.Count() != l2.Count())
                Effectivy(l1, l2);
        }
        //מאתחלת את המטריצה המקורית
        public void CopyGlobalMat()
        {
            orginalMat = new TutorForApprenticeTbl[globalMat.GetLength(0), globalMat.GetLength(0)];
            for (int i = 0; i < globalMat.GetLength(0); i++)
            {
                for (int j = 0; j < globalMat.GetLength(1); j++)
                {
                    orginalMat[i, j] = new TutorForApprenticeTbl(globalMat[i, j]);
                }
            }
        }
        //  יצירת שיבוץ עבור האזורים שברשימה  AreaLst-  פונקציה ראשונית
        public void CreatePlacementByArea(List<int> Arealst, int placementId)
        {
            checkingConstraints = new CheckingConstraints(placementId);
            //רשימות מועמדים לשיבוץ:
            List<ApprenticeTbl> apprentices = (List<ApprenticeTbl>)dbClass.GetApprenticesByArea(Arealst, placementId).Data;
            List<TutorTbl> tutors = (List<TutorTbl>)dbClass.GetTutorsByArea(Arealst, placementId).Data;
            int matchLevel = Math.Max(apprentices.Count(), tutors.Count());
            this.globalMat = new TutorForApprenticeTbl[matchLevel, matchLevel];
            //אתחול המטריצה
            InitGlobALMat(globalMat, apprentices, tutors);
            foreach (var apprentice in apprentices)
                foreach (var tutor in tutors)
                {
                    pointInMat = FindInMat(apprentice.ApprenticeID, tutor.TutorID);
                    int markForTutorandApprentice = checkingConstraints.GetFinalMark(tutor.TutorID, apprentice.ApprenticeID);
                    globalMat[pointInMat.X, pointInMat.Y].MatchLevelScore += markForTutorandApprentice;
                }
        }
        ////בדיקה האם קיים שיבוץ אופטימלי
        //public bool IsOptimal(TutorForApprenticeTbl[,] mat, int apprentices, int tutors)
        //{
        //    for (int i = 0; i < apprentices; i++)
        //    {
        //        int l = ZeroInLine(mat, i, mat.GetLength(0));
        //        int c = ZeroInColum(mat, i, mat.GetLength(0));
        //        if (l > 1 || c > 1 || l >= 1 && c >= 1)
        //            return false;
        //        continue;
        //    }
        //    return true;
    }

}
