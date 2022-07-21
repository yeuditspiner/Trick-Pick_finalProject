using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;

namespace Bll
{
 public  class CheckingConstraints
    {
        //מחלקה האחראית על מילוי מטריצת הציונים
        SmartMatchEntities db = new SmartMatchEntities();
         public DbClass dbcls = new DbClass();
        List<ConstraintTbl> constraintsLst;
        List<PreferenceTbl> preferencesLst;
        public CheckingConstraints(int placementId)
        {
            constraintsLst = db.ConstraintTbl.Where(x => x.Placement == placementId).ToList();//(List<ConstraintTbl>)dbcls.GetConstarintsByPlacement(placementId).Data;
            preferencesLst = db.PreferenceTbl.ToList(); 
        }
        //tutorId, apprenticeId החזרת ציון ערכי אילוצים עבור 
        public int GetMarkForConstarints(int tutorId,int apprenticeId)
        {
            int mark=0;
            TutorCharacterizationConstraintTbl tutor;
            CharacterizationConstraintApprenticeTbl apprentice;
            foreach (var item in constraintsLst)
            {
                //רשימת ערכי אילוץ נוכחי
                List<CharacterizationConstraintsTbl> lstValues = (List<CharacterizationConstraintsTbl>)dbcls.CharacterizationConstraintsByConstraints(item.ConstraintID).Data;
                //תבנית אילוץ נוכחי
                PattrenConstaraintTbl p = (PattrenConstaraintTbl)dbcls.GetPattrenConstaraintByConstarintId(item.ConstraintID).Data;
                switch (p.ConstraintPatternType)
                {
                    case 1:
                        foreach (var value in lstValues)
                        {
                            //שליפת ניקוד החניך והחונך עבור האילוץ הנוכחי
                            tutor = dbcls.GetTutorCharacterizationConstraintById(tutorId, value.CharacterizationConstraintsId);
                            apprentice = dbcls.GetApprenticeCharacterizationConstraintById(apprenticeId, value.CharacterizationConstraintsId);
                            if (tutor != null && apprentice != null)
                            {
                                //אם זה ערך אילוץ ישר
                                if (value.IsOpposit == false)
                                {
                                    if (tutor.Status > apprentice.Status)
                                    {
                                           //מצוין
                                        if ((tutor.Status - apprentice.Status) >= 3)
                                            mark += (int)(tutor.Status + apprentice.Status + 50);
                                        else
                                           //בינוני
                                        if (((int)(tutor.Status - apprentice.Status)) == 2)
                                            mark += (int)(tutor.Status + apprentice.Status + 20);
                                        else
                                            // מתאים פחות
                                            mark += (int)(tutor.Status + apprentice.Status);
                                    }
                                }
                                //ערך אילוץ הפוך 
                                else
                                {
                                    if(apprentice.Status > tutor.Status)
                                    {
                                        if ((apprentice.Status -tutor.Status) >= 3) 
                                            mark += (int)(tutor.Status + apprentice.Status + 50);
                                        else
                                        if (((int)(apprentice.Status - tutor.Status)) == 2)
                                            mark += (int)(tutor.Status + apprentice.Status + 20);
                                        else
                                            mark += (int)(tutor.Status + apprentice.Status);
                                    }
                                }
                            }
                        }
                        break;
                    case 0:
                        tutor = dbcls.GetTutorCharacterizationConstraintById(tutorId, lstValues[0].CharacterizationConstraintsId);
                        apprentice = dbcls.GetApprenticeCharacterizationConstraintById(apprenticeId, lstValues[0].CharacterizationConstraintsId);
                        if (tutor != null && apprentice != null && tutor.Status == apprentice.Status)
                            mark += 50;
                        break;
                    default:
                        break;
                }
            }
            return mark;
        }
        //tutorId, apprenticeId החזרת ציון עדיפויות  עבור 
        public int GetMarkForPreferenses(int tutorId,int apprenticeId)   
        {
            int mark = 0;
            PreferenceApprenticeTbl apprentice;
            PreferenceTutorTbl tutor;
            foreach (var item in preferencesLst)
            {
                apprentice = db.PreferenceApprenticeTbl.Where(x => x.PreferenceID == item.PreferenceID && x.ApprenticeID == apprenticeId).FirstOrDefault(); //(PreferenceApprenticeTbl)dbcls.GetPreferenceApprenticeById(item.PreferenceID, apprenticeId).Data;
                tutor = db.PreferenceTutorTbl.Where(x => x.PreferenceID == item.PreferenceID && x.TutorID == tutorId).FirstOrDefault();//(PreferenceTutorTbl)dbcls.GetPreferenceTutorById(item.PreferenceID, tutorId).Data;
                if(tutor !=null &&  apprentice !=null)
                if ((Math.Abs((int)(apprentice.Status - tutor.Status)) <= 2))
                    mark += 30;
                else  
                    mark += 5;
            }
            return mark;
        }
        // tutorId, apprenticeId החזרת ציון כולל עבור 
        public int GetFinalMark(int tutorId,int apprenticeId)
        {
            int constarintMark = GetMarkForConstarints(tutorId, apprenticeId);
            int preferenceMark = GetMarkForPreferenses(tutorId, apprenticeId);
            if (constarintMark < preferenceMark)
                return constarintMark % preferenceMark;
            return constarintMark + preferenceMark;
        }
    }
}
