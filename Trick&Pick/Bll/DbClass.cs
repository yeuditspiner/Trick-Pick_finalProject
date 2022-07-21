using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dto;

namespace Bll
{
    public class DbClass
    {
        public SmartMatchEntities db = new SmartMatchEntities();


        //מחלקת שליפות נתונים מהדאטה בייס

        //טיפול בחונכים
        //חונך עפי תז
        public RequestResult GetTutorById(int id)
        {
            TutorTbl tutor = db.TutorTbl.ToList().Where(x => x.TutorID == id).FirstOrDefault();
            return new RequestResult() { Data = tutor.TutorName, Message = "success", Status = true };
        }
        //קבלת מזהה אילוץ עפי שם אילוץ
        public RequestResult GetConstraintIdByName(string constarintName)
        {
            ConstraintTbl constraint = db.ConstraintTbl.Where(x => x.ConstraintName.Equals(constarintName)).FirstOrDefault();
            return new RequestResult() { Data = constraint.ConstraintID, Message = "success", Status = true };
        }

        public RequestResult GetPlacementByName(string placementName)
        {
            PlacementDto placement;
            PlacementTbl p = db.PlacementTbl.Where(x => x.PlacementName.Equals(placementName)).First();
            placement = PlacementDto.DalToDto(p);
            return new RequestResult() { Data = placement.PlacementID, Message = "success", Status = true };
        }

        //קבלת מאפייני חונך
        public RequestResult GetTutorCharacterizationConstraint(int tutorId)
        {
            List<TutorCharacterizationConstraintDto> lst = new List<TutorCharacterizationConstraintDto>();
            foreach (var item in db.TutorCharacterizationConstraintTbl.ToList())
            {
                if (item.TutorId == tutorId)
                    lst.Add(TutorCharacterizationConstraintDto.DalToDto(item));
            }
            return new RequestResult() { Data = lst, Message = "success", Status = true };

        }
        //קבלת מאפייני חניך
        public RequestResult GetApprenticeCharacterizationConstraint(int ApprenticeId)
        {
            List<CharacterizationConstraintApprenticeDto> lst = new List<CharacterizationConstraintApprenticeDto>();
            foreach (var item in db.CharacterizationConstraintApprenticeTbl.ToList())
            {
                if (item.ApprenticeId == ApprenticeId)
                    lst.Add(CharacterizationConstraintApprenticeDto.DalToDto(item));
            }
            return new RequestResult() { Data = lst, Message = "success", Status = true };

        }
        //חונך עפ"  שם
        public RequestResult GetTutorByName(string name)
        {
            TutorTbl tutor = db.TutorTbl.Where(x => x.TutorName == name).FirstOrDefault();
            return new RequestResult() { Data = tutor, Message = "success", Status = true };
        }
        //חונך עפי שם משתמש וסיסמא
        public RequestResult GetTutorByLogIn(string name, string password)
        {
            TutorDto t = new TutorDto();
            TutorTbl tutor = db.TutorTbl.Where(x => x.TutorName.Equals(name) && x.PasswordID.Equals(password)).FirstOrDefault();
            t = TutorDto.DalToDto(tutor);
            return new RequestResult() { Data = t, Message = "success", Status = true };
        }
        //שליפת ערכי אילוץ חונך
        public RequestResult GetTutorConstraintsValuesByConstarint(int tutorId, int CharacterizationId)
        {
            var TutorConstraintsValues = db.TutorCharacterizationConstraintTbl.Where(x => x.TutorId == tutorId && x.CharacterizationConstarintId == CharacterizationId).ToList();
            return new RequestResult() { Data = TutorConstraintsValues, Message = "success", Status = true };
        }
        //טיפול בחניכים
        public RequestResult GetApprenticeById(int id)
        {
            ApprenticeTbl apprentice = db.ApprenticeTbl.ToList().Where(x => x.ApprenticeID == id).FirstOrDefault();
            return new RequestResult() { Data = apprentice.ApprenticeName, Message = "success", Status = true };
        }

        //חניך עפי שם משתמש וסיסמא
        public RequestResult GetApprenticeByLogIn(string name, string password)
        {
            ApprenticeDto a = new ApprenticeDto();
            ApprenticeTbl apprentice = db.ApprenticeTbl.Where(x => x.ApprenticeName.Equals(name) && x.Password.Equals(password)).FirstOrDefault();
            a = ApprenticeDto.DalToDto(apprentice);
            return new RequestResult() { Data = a, Message = "success", Status = true };
        }


        //חניך עפ שם
        public RequestResult GetApprenticeByName(string name)
        {
            ApprenticeTbl apprentice = db.ApprenticeTbl.Where(x => x.ApprenticeName == name).FirstOrDefault();
            return new RequestResult() { Data = apprentice, Message = "success", Status = true };
        }
        ////קבלת מאפייני איל
        //public CharacterizationConstraintApprenticeTbl GetConstraintsWithApprenticeById(int apprenticeId,int CharacterizationId)
        //{
        //    return db.CharacterizationConstraintApprenticeTbl.Where(x => x.ApprenticeId == apprenticeId && x.CharacterizationConstraintId == CharacterizationId).FirstOrDefault();
        //}


        //שליפת ערכי אילוץ חניך
        public RequestResult GetApprenticeConstraintsValuesByConstarint(int apprenticeId, int CharacterizationId)
        {
            var TutorConstraintsValues = db.CharacterizationConstraintApprenticeTbl.Where(x => x.ApprenticeId == apprenticeId && x.CharacterizationConstraintId == CharacterizationId).ToList();
            return new RequestResult() { Data = TutorConstraintsValues, Message = "success", Status = true };
        }
        //שליפת מאפיין אילוץ חניך ע"י תז
        public CharacterizationConstraintApprenticeTbl GetApprenticeCharacterizationConstraintById(int apprenticeId, int CharacterizationConstraintId)
        {
            return db.CharacterizationConstraintApprenticeTbl.Where(x => x.ApprenticeId == apprenticeId && x.CharacterizationConstraintId == CharacterizationConstraintId).FirstOrDefault();
        }
        //שליפת מאפיין אילוץ חונך ע"י תז
        public TutorCharacterizationConstraintTbl GetTutorCharacterizationConstraintById(int tutorId, int CharacterizationConstraintId)
        {
            return db.TutorCharacterizationConstraintTbl.Where(x => x.TutorId == tutorId && x.CharacterizationConstarintId == CharacterizationConstraintId).FirstOrDefault();
        }
        //תבנית אילוץ
        public RequestResult GetPattrenConstaraintByConstarintId(int constarintId)
        {
            var PattrenConstaraint = db.PattrenConstaraintTbl.Where(x => x.ConstarintId == constarintId).FirstOrDefault();
            return new RequestResult() { Data = PattrenConstaraint, Message = "success", Status = true };
        }
        //areaId   רשימת חונכים באזור   
        public RequestResult GetTutorsByArea(List<int> lstArea, int placementId)
        {
            List<TutorTbl> l = new List<TutorTbl>();
            foreach (var item in db.TutorTbl.ToList())
            {
                AreaTbl a = db.AreaTbl.Where(x => x.AreaID == item.AreaID && item.PlacementId == placementId).FirstOrDefault();

                if (lstArea.Contains(item.AreaID))
                    l.Add(item);
            }
            return new RequestResult() { Data = l, Message = "success", Status = true };

        }
        // areaId  רשימת חניכים באזור 
        public RequestResult GetApprenticesByArea(List<int> lst, int placementId)
        {
            List<ApprenticeTbl> l = new List<ApprenticeTbl>();
            foreach (var item in db.ApprenticeTbl.ToList())
            {
                AreaTbl a = db.AreaTbl.Where(x => x.AreaID == item.AreaID && item.PlacementId == placementId).FirstOrDefault();
                if (lst.Contains(item.AreaID))
                    l.Add(item);
            }
            return new RequestResult() { Data = l, Message = "success", Status = true };
        }

        //כל החונכים
        public RequestResult GettAllTutor()
        {
            List<TutorDto> lst = new List<TutorDto>();
            foreach (var item in db.TutorTbl.ToList())
            {
                lst.Add(TutorDto.DalToDto(item));
            }
            return new RequestResult() { Data = lst, Message = "success", Status = true };
        }
        //הוספת חונך
        public void AddTutor(TutorDto tutor)
        {
            TutorTbl t = db.TutorTbl.ToList().Last();

           // tutor.TutorID = t.TutorID + 1;
            //הוספת החונך
            db.TutorTbl.Add(tutor.DtoToDal());
            db.SaveChanges();
            //הוספת החונך כמשתמש
            AddUser(tutor);
            //הוספת כל ערכי אילוצים לחונך
            AddUserCharacterizationConstraint(tutor);
            //הוספת כל העדפות לחונך
            AddUserPreference(tutor);
        }
        public void AddUser(Object user)
        {
            //נוצר גם יוזר חדש עבור הכניסות המשניות של החונך שנוצר עכשיו
            UserDto newUser = new UserDto();
            switch (user.GetType().Name)
            {
                case "TutorDto":
                    newUser.UserName = (user as TutorDto).TutorName;
                    newUser.Password = (user as TutorDto).PasswordID;
                    break;
                case "ApprenticeDto":
                    newUser.UserName = (user as ApprenticeDto).ApprenticeName;
                    newUser.Password = (user as ApprenticeDto).Password;
                    break;
                default:
                    break;
            }
            //   newUser.UserID = db.UserTbl.Count() + 1000;
            //newUser.Password = user.pa";
            db.UserTbl.Add(newUser.DtoToDal());
            db.SaveChanges();
        }
        //הוספת ערכי אילוצים לחונך
        public void AddUserCharacterizationConstraint(Object user)
        {
            //נוצר גם אילוצי חונך
            foreach (var item in db.ConstraintTbl)
            {
                List<CharacterizationConstraintsTbl> lstValues = db.CharacterizationConstraintsTbl.Where(x => x.ConstarintId == item.ConstraintID).ToList();
                foreach (var item1 in lstValues)
                {
                    if (user is TutorDto)
                    {
                        TutorCharacterizationConstraintDto t = new TutorCharacterizationConstraintDto();
                        t.CharacterizationConstarintId = item1.CharacterizationConstraintsId;
                        t.TutorId = (user as TutorDto).TutorID;

                        t.Status = 1;
                        db.TutorCharacterizationConstraintTbl.Add(t.DtoToDal());
                        //break;
                    }
                    else
                    {
                        CharacterizationConstraintApprenticeDto a = new CharacterizationConstraintApprenticeDto();
                        //a.CharacterizationConstraintId = db.CharacterizationConstraintApprenticeTbl.Count() + 100;
                        a.CharacterizationConstraintId = item1.CharacterizationConstraintsId;
                        a.ApprenticeId = (user as ApprenticeDto).ApprenticeID;
                        a.Status = 1;
                        db.CharacterizationConstraintApprenticeTbl.Add(a.DtoToDal());
                        //db.SaveChanges();
                        //// break;

                    }
                }
            }
            db.SaveChanges();
        }
        //הוספת עדיפוית חונך   
        public void AddUserPreference(Object user)
        {

            foreach (var item in db.PreferenceTbl)
            {
                if (user is TutorDto)
                {
                    PreferenceTutorDto p = new PreferenceTutorDto();
                    p.PreferenceID = item.PreferenceID;
                    p.Status = 0;
                    p.TutorID = (user as TutorDto).TutorID;
                    db.PreferenceTutorTbl.Add(p.DtoToDal());
                }
                else
                {
                    PreferenceApprenticeDto preferenceApprentice = new PreferenceApprenticeDto();
                    preferenceApprentice.PreferenceID = item.PreferenceID;
                    preferenceApprentice.Status = 0;
                    preferenceApprentice.ApprenticeID = (user as ApprenticeDto).ApprenticeID;
                    db.PreferenceApprenticeTbl.Add(preferenceApprentice.DtoToDal());
                }

            }
            db.SaveChanges();

        }
        //עדכון מאפיין אילוץ חניך - שקופית 6 
        public void UpdateApprenticeCharacterizationConstraint(CharacterizationConstraintApprenticeDto CharacterizationConstraintApp)
        {
            bool flag = false;
            CharacterizationConstraintApprenticeTbl characterizationConstraintApprentice;
            try
            {
                characterizationConstraintApprentice = db.CharacterizationConstraintApprenticeTbl.Where(x => x.ApprenticeId == CharacterizationConstraintApp.ApprenticeId && x.CharacterizationConstraintId == CharacterizationConstraintApp.CharacterizationConstraintId).FirstOrDefault();
                if(characterizationConstraintApprentice!=null)
                flag = true;
              
            }

            catch (Exception)
            {
                flag = false;
                throw new Exception("NOT FOUND");
            }
            if(flag==true)
            {
                characterizationConstraintApprentice.Status = CharacterizationConstraintApp.Status;
                db.SaveChanges();
            }
           


        }
        //עדכון מאפיין אילוץ חונך - שקופית 6 
        public void UpdatTutorCharacterizationConstraint(TutorCharacterizationConstraintDto CharacterizationConstraintsTu)
        {

            TutorCharacterizationConstraintTbl characterizationConstraint = db.TutorCharacterizationConstraintTbl.Where(x => x.TutorId == CharacterizationConstraintsTu.TutorId
         && x.CharacterizationConstarintId == CharacterizationConstraintsTu.CharacterizationConstarintId).FirstOrDefault();
            characterizationConstraint.Status = CharacterizationConstraintsTu.Status;
            db.SaveChanges();

        }
        //עדכון עדיפות חונך
        public void UpdateTutorPreference(PreferenceTutorDto preferenceTutor)
        {


            PreferenceTutorTbl preferenceTutor2 = db.PreferenceTutorTbl.Where(x => x.TutorID == preferenceTutor.TutorID && x.PreferenceID == preferenceTutor.PreferenceID).FirstOrDefault();
            preferenceTutor2.Status = preferenceTutor.Status;
            db.SaveChanges();


        }
        //עדכון עדיפות חניך
        public void UpdateApprenticePreference(PreferenceApprenticeDto preferenceApprentice)
        {


            PreferenceApprenticeTbl preferenceApprentice2 = db.PreferenceApprenticeTbl.Where(x => x.ApprenticeID == preferenceApprentice.ApprenticeID && x.PreferenceID == preferenceApprentice.PreferenceID).FirstOrDefault();
            preferenceApprentice.Status = preferenceApprentice.Status;
            db.SaveChanges();


        }
        //מחיקת חונך

        public void DeleteTutor(TutorDto tutor)
        {

            System.Windows.Forms.MessageBox.Show(tutor.DtoToDal().TutorName);
            object p = db.TutorTbl.Remove(tutor.DtoToDal());
            db.SaveChanges();

        }

        //רשימת ערכי אילוץ לפי קוד אילוץ
        public RequestResult CharacterizationConstraintsByConstraints(int constarintId)
        {
            var constarintValues = db.CharacterizationConstraintsTbl.Where(x => x.ConstarintId == constarintId).ToList();
            return new RequestResult() { Data = constarintValues, Message = "success", Status = true };

        }
        //כל החניכים
        public RequestResult GettAllApprentice()
        {

            List<ApprenticeDto> lst = new List<ApprenticeDto>();
            foreach (var item in db.ApprenticeTbl.ToList())
            {
                lst.Add(ApprenticeDto.DalToDto(item));
            }
            return new RequestResult() { Data = lst, Message = "success", Status = true };
        }
        //הוספת חניך
        public void AddApprentice(ApprenticeDto apprentice)
        {
             apprentice.ApprenticeID = db.ApprenticeTbl.Count() + 1;
            // apprentice.CityId = 1;
            db.ApprenticeTbl.Add(apprentice.DtoToDal());
            db.SaveChanges();

            AddUser(apprentice);
            apprentice.ApprenticeID = db.ApprenticeTbl.ToList().Last().ApprenticeID;
            AddUserCharacterizationConstraint(apprentice);
            AddUserPreference(apprentice);
        }
        //טיפול באילוצים

        //כל האילוצים
        public RequestResult GettAllConstraint()
        {

            List<ConstraintDto> lst = new List<ConstraintDto>();
            foreach (var item in db.ConstraintTbl.ToList())
            {
                lst.Add(ConstraintDto.DalToDto(item));
            }
            return new RequestResult() { Data = lst, Message = "success", Status = true };
        }
        //כל אילוצי שיבוץ מסוים - עבור שקופית 6
        public RequestResult GetConstarintsByPlacement(int placementId)
        {

            List<ConstraintDto> lst = new List<ConstraintDto>();
            foreach (var item in db.ConstraintTbl.ToList())
            {
                if (item.Placement == placementId)
                    lst.Add(ConstraintDto.DalToDto(item));
            }
            return new RequestResult() { Data = lst, Message = "success", Status = true };
        }
        //הוספת אילוץ
        public void AddConstraint(ConstraintDto constraint)
        {
            if(constraint.Placement==0)
            {
                throw new Exception("Not Valid!");
            }
            db.ConstraintTbl.Add(constraint.DtoToDal());
            db.SaveChanges();

        }
        //הוספת תבנית אילוץ
        public void AddPattrenConstaraint(PattrenConstaraintDto pattrenConstaraint)
        {
            db.PattrenConstaraintTbl.Add(pattrenConstaraint.DtoToDal());
            db.SaveChanges();
        }
        //הוספת ערכי אילוצים  
        public void AddAddCharacterizationConstraints(CharacterizationConstraintDto characterizationConstraints)
        {
            ConstraintTbl c = db.ConstraintTbl.ToList().Last();
            characterizationConstraints.ConstarintId = c.ConstraintID;
            db.CharacterizationConstraintsTbl.Add(characterizationConstraints.DtoToDal());


            db.SaveChanges();
        }


        //קבלת רשימת ערכי אילוץ
        public RequestResult GetCharacterizationByConstraint(int constarintId)
        {
            List<CharacterizationConstraintDto> lst = new List<CharacterizationConstraintDto>();
            List<CharacterizationConstraintsTbl> lstValues = db.CharacterizationConstraintsTbl.Where(x => x.ConstarintId == constarintId).ToList();
            foreach (var item in db.CharacterizationConstraintsTbl.ToList())
            {
                if (item.ConstarintId == constarintId)
                    lst.Add(CharacterizationConstraintDto.DalToDto(item));
            }
            return new RequestResult() { Data = lst, Message = "success", Status = true };
        }
        //// Creating a list of suitable apprentices for the CoinstarintId constraint
        //public RequestResult CreateApprenticeLstByCoinstarintId(List<ApprenticeDto>l,  int CoinstarintId)
        //{

        //    List<ApprenticeDto> apprenticelst = new List<ApprenticeDto>();
        //    foreach (var item in l.ToList())
        //    {
        //        foreach (var item1 in db.CharacterizationConstraintApprenticeTbl)
        //        {
        //            if (item1.ConstarintId== CoinstarintId && item1.ApprenticeId == item.ApprenticeID && item1.Status == 5)
        //                apprenticelst.Add((item));
        //        }
        //    }

        //    return new RequestResult() { Data = apprenticelst, Message = "success", Status = true };
        //}

        //Creating a list of suitable tutors for the CoinstarintId constraint
        //public RequestResult CreateTutorsListByCoinstarintId(List<TutorDto> l1,int CoinstarintId)
        //{
        //    List<TutorDto> tutorslst = new List<TutorDto>();

        //    foreach (var item in l1.ToList())
        //    {

        //        foreach (var item1 in db.TutorCharacterizationConstraintTbl)
        //        {
        //            if (item1.ConstarintId == CoinstarintId && item1.TutorTbl == item.TutorID && item1.Status == 5)
        //                tutorslst.Add(item);
        //        }
        //    }

        //    return new RequestResult() { Data = tutorslst, Message = "success", Status = true };
        //}

        //// כל אילוצי חניכים 
        //public RequestResult GetAllConstraintsApprentice()
        //{
        //    List<ConstraintsApprenticeDto> lst = new List<ConstraintsApprenticeDto>();
        //    foreach (var item in db.ConstraintsApprenticeTbl.ToList())
        //    {

        //        lst.Add(ConstraintsApprenticeDto.DalToDto(item));
        //    }
        //    return new RequestResult() { Data = lst, Message = "success", Status = true };
        //}
        //הוספת  ערך אילוץ לחניך
        public void AddConstraintsApprentice(CharacterizationConstraintApprenticeDto characterizationConstraintApprentice)
        {

            {
                db.CharacterizationConstraintApprenticeTbl.Add(characterizationConstraintApprentice.DtoToDal());
                db.SaveChanges();
            }
        }
        //קבלת ערך אילוץ חונך
        public RequestResult GetCharacterizationConstraintByTutor(int tutorId, int CharacterizationConstraintId, int constarintId)
        {
            TutorCharacterizationConstraintDto CharacterizationConstraint;
            TutorCharacterizationConstraintTbl tutorCharacterizationConstraint = db.TutorCharacterizationConstraintTbl.Where(x => x.CharacterizationConstarintId == CharacterizationConstraintId && x.TutorId == tutorId).FirstOrDefault();
            CharacterizationConstraint = TutorCharacterizationConstraintDto.DalToDto(tutorCharacterizationConstraint);
            return new RequestResult() { Data = tutorCharacterizationConstraint, Message = "success", Status = true };
        }
        //קבלת ערך אילוץ חניך
        public RequestResult GetCharacterizationConstraintByApprentice(int apprenticeId, int CharacterizationConstraintId, int constarintId)
        {
            CharacterizationConstraintApprenticeDto CharacterizationConstraint;
            CharacterizationConstraintApprenticeTbl apprenticeCharacteriztion = db.CharacterizationConstraintApprenticeTbl.Where(x => x.CharacterizationConstraintId == CharacterizationConstraintId && x.ApprenticeId == apprenticeId).FirstOrDefault();
            CharacterizationConstraint = CharacterizationConstraintApprenticeDto.DalToDto(apprenticeCharacteriztion);
            return new RequestResult() { Data = CharacterizationConstraint, Message = "success", Status = true };
        }
        //הוספת  ערך אילוץ לחונך
        public void AddConstraintsTutor(TutorCharacterizationConstraintDto tutorCharacterizationConstraint)
        {

            db.TutorCharacterizationConstraintTbl.Add(tutorCharacterizationConstraint.DtoToDal());
            db.SaveChanges();


        }
        public string GetNameCharacterizationConstraintBy(int CharacterizationConstraintId)
        {
            return db.CharacterizationConstraintsTbl.Where(x => x.CharacterizationConstraintsId == CharacterizationConstraintId).Select(x => x.Value).FirstOrDefault();
        }
        //  id כל  ערכי האילוצים של חונך 
        public string GetCharacterizationConstraintByTutor(int tutorid)
        {
            string l = " ";
            List<TutorCharacterizationConstraintDto> lst = new List<TutorCharacterizationConstraintDto>();
            foreach (var item in db.TutorCharacterizationConstraintTbl.ToList())
            {
                if (item.TutorId == tutorid)
                {
                    l += this.GetNameCharacterizationConstraintBy(item.CharacterizationConstarintId) + " - " + item.Status.ToString();


                    //lst.Add(TutorCharacterizationConstraintDto.DalToDto(item));
                }
            }
            return l;

        }
        //  id כל  ערכי האילוצים של חניך 
        public string GetCharacterizationConstraintsByApprentice(int apprenticeid)
        {
            string l = " ";
            List<CharacterizationConstraintApprenticeDto> lst = new List<CharacterizationConstraintApprenticeDto>();
            foreach (var item in db.CharacterizationConstraintApprenticeTbl.ToList())
            {
                if (item.ApprenticeId == apprenticeid)
                {
                    l += this.GetNameCharacterizationConstraintBy(item.CharacterizationConstraintId) + " - " + item.Status.ToString();
                    lst.Add(CharacterizationConstraintApprenticeDto.DalToDto(item));
                }

            }
            return l;
            //return new RequestResult() { Data = l, Message = "success", Status = true };

        }
        //*******טיפול בערים********
        //כל הערים
        public RequestResult GettAllCity()
        {
            List<CityDto> lst = new List<CityDto>();
            int x = db.CityTbl.Count();
            foreach (var item in db.CityTbl.ToList())
            {
                lst.Add(CityDto.DalToDto(item));
                // Console.WriteLine(item);
            }
            return new RequestResult() { Data = lst, Message = "success", Status = true };
        }
        //הוספת עיר
        public void AddCity(CityDto city)
        {
            //if (!IsFind(city.CityName))
            {
                db.CityTbl.Add(city.DtoToDal());
                db.SaveChanges();
            }
        }
        //מחיקת עיר
        public void DeleteCity(CityDto city)
        {
            if (IsFind(city.CityName))
            {

                db.CityTbl.Remove(city.DtoToDal());
                db.SaveChanges();
            }
        }
        //חיפוש עיר
        public bool IsFind(string name)
        {

            int x = db.CityTbl.Count();
            if (x > 0)
                return false
                    ;
            return true;

        }
        //עדכון עיר
        public void Update(string cityName, CityDto city)
        {
            if (!IsFind(city.CityName))
            {
                city.CityName = cityName;
                db.SaveChanges();
            }
        }
        //עיר ע"י קוד
        public string GetCityById(int cityId)
        {
            CityTbl c = db.CityTbl.Where(x => x.CityId == cityId).FirstOrDefault();
            return c.CityName;
        }
        //**********טיפול באזורים********
        //כל אזורים
        public RequestResult GettAllArea()
        {
            List<AreaDto> lst = new List<AreaDto>();
            foreach (var item in db.AreaTbl.ToList())
            {
                lst.Add(AreaDto.DalToDto(item));
                Console.WriteLine(item);
            }
            return new RequestResult() { Data = lst, Message = "success", Status = true };
        }
        //רשימת אזורים ע"י קוד עיר
        public RequestResult GetAreasByCity(int cityId)
        {
            List<AreaDto> l = new List<AreaDto>();
            foreach (var item in db.AreaTbl.ToList())
            {
                if (item.CityId == cityId)
                    l.Add(AreaDto.DalToDto(item));
            }
            return new RequestResult() { Data = l, Message = "success", Status = true };
        }
        //הוספת אזור
        public void AddArea(AreaDto area)
        {
            db.AreaTbl.Add(area.DtoToDal());
            db.SaveChanges();
        }
        //*********טיפול בעדיפויות*******
        //כל העדפות
        public RequestResult GettAllPreference()
        {
            List<PreferenceDto> lst = new List<PreferenceDto>();
            foreach (var item in db.PreferenceTbl.ToList())
            {
                lst.Add(PreferenceDto.DalToDto(item));
                Console.WriteLine(item);
            }
            return new RequestResult() { Data = lst, Message = "success", Status = true };
        }
        //הוספת עדיפות
        public void AddPreference(PreferenceDto preference)
        {
            db.PreferenceTbl.Add(preference.DtoToDal());
            db.SaveChanges();
        }
        //כל העדפות חניכים
        public RequestResult GettAllPreferenceApprentice()
        {
            List<PreferenceApprenticeDto> lst = new List<PreferenceApprenticeDto>();
            foreach (var item in db.PreferenceApprenticeTbl.ToList())
            {
                lst.Add(PreferenceApprenticeDto.DalToDto(item));
                Console.WriteLine(item);
            }
            return new RequestResult() { Data = lst, Message = "success", Status = true };
        }
        //הוספת העדפה לחניך
        public void AddPreferenceApprentice(PreferenceApprenticeDto preferenceApprentice)
        {
            db.PreferenceApprenticeTbl.Add(preferenceApprentice.DtoToDal());
            db.SaveChanges();
        }
        //כל העדפות חונכים
        public RequestResult GetAllPreferenceTutor()
        {
            List<PreferenceTutorDto> lst = new List<PreferenceTutorDto>();
            int x = db.PreferenceTutorTbl.Count();
            foreach (var item in db.PreferenceTutorTbl.ToList())
            {
                lst.Add(PreferenceTutorDto.DalToDto(item));
                Console.WriteLine(item);
            }
            return new RequestResult() { Data = lst, Message = "success", Status = true };
        }
        //הוספת העדפה לחונך
        public void AddPreferenceTutor(PreferenceTutorDto preferenceTutor)
        {
            db.PreferenceTutorTbl.Add(preferenceTutor.DtoToDal());
            db.SaveChanges();
        }
        // קבלת עדיפות  חונך עפ"י תז
        public RequestResult GetPreferenceTutorById(int PreferenceId, int tutorId)
        {
            PreferenceTutorTbl preferenceTutor = db.PreferenceTutorTbl.Where(x => x.PreferenceID == PreferenceId && x.TutorID == tutorId).FirstOrDefault();
            PreferenceTutorDto preferenceTutorDto = PreferenceTutorDto.DalToDto(preferenceTutor);
            return new RequestResult() { Data = preferenceTutorDto, Message = "success", Status = true };
        }
        // קבלת עדיפות  חניך עפ"י תז
        public RequestResult GetPreferenceApprenticeById(int PreferenceId, int apprenticeId)
        {
            PreferenceApprenticeTbl preferenceApprentice = db.PreferenceApprenticeTbl.Where(x => x.PreferenceID == PreferenceId && x.ApprenticeID == apprenticeId).FirstOrDefault();
            PreferenceApprenticeDto preferenceApprenticeDto = PreferenceApprenticeDto.DalToDto(preferenceApprentice);
            return new RequestResult() { Data = preferenceApprenticeDto, Message = "success", Status = true };
        }
        //כל העדפות חניך
        public RequestResult GetAllPreferencesApprentice(int apprenticeId)
        {
            List<PreferenceApprenticeDto> l = new List<PreferenceApprenticeDto>();
            foreach (var item in db.PreferenceApprenticeTbl)
            {
                if (item.ApprenticeID == apprenticeId)
                    l.Add(PreferenceApprenticeDto.DalToDto(item));
            }
            return new RequestResult() { Data = l, Message = "success", Status = true };
        }
        //כל העדפות חונך
        public RequestResult GetAllTutorPreferences(int tutorId)
        {
            List<PreferenceTutorDto> l = new List<PreferenceTutorDto>();
            foreach (var item in db.PreferenceTutorTbl)
            {
                if (item.TutorID == tutorId)
                    l.Add(PreferenceTutorDto.DalToDto(item));
            }
            return new RequestResult() { Data = l, Message = "success", Status = true };
        }
        //*********טיפול באילוצים *******
        //קבלת ערכי אילוץ
        public RequestResult GetlstValues(int constaraintId)
        {
            List<CharacterizationConstraintDto> lst = new List<CharacterizationConstraintDto>();
            foreach (var item in db.CharacterizationConstraintsTbl.ToList())
            {
                if (item.ConstarintId == constaraintId)
                    lst.Add(CharacterizationConstraintDto.DalToDto(item));
            }
            return new RequestResult() { Data = lst, Message = "success", Status = true };
        }
        //******טיפול בשיבוצים********
        //קבלת ציון עבור זוג שיצא כמשובץ
        public int GetMarkForTutorandApprentice(int apprenticeId, int tutorId)
        {
            TutorForApprenticeTbl tutorForApprentice = db.TutorForApprenticeTbl.Where(x => x.ApprenticeID == apprenticeId && x.TutorID == tutorId).FirstOrDefault();
            return (int)tutorForApprentice.MatchLevelScore;

        }
        public RequestResult GetPlacement(List<int> l, int placementId)
        {
            HungarianAlgorithmInitializer ls = new HungarianAlgorithmInitializer();
            List<string> x = ls.Main(l, placementId);
            return new RequestResult() { Data = x, Message = "success", Status = true };
        }
        //הוספת שיבוץ חדש
        public void AddPlacement(PlacementDto placement)
        {
            db.PlacementTbl.Add(placement.DtoToDal());
            db.SaveChanges();
        }
        //קבלת שיבוץ עי קוד
        public RequestResult GetPlacementById(int placementId)
        {
            PlacementTbl p = db.PlacementTbl.ToList().Where(x => x.PlacementID == placementId).FirstOrDefault();

            return new RequestResult() { Data = p, Message = "success", Status = true };
        }
        //הוספת עצם מסוג זוג - חניך לחונך
        public void AddTutorForApprintce(TutorForApprenticeTbl tutorForApprentice)
        {
            tutorForApprentice.TutorForApprenticeId = db.TutorForApprenticeTbl.Count() + 3001;
            db.TutorForApprenticeTbl.Add(tutorForApprentice);
            db.SaveChanges();
        }
        //קבלת כל השיבוצים
        public RequestResult GetAllPlacement()
        {
            List<PlacementDto> lst = new List<PlacementDto>();
            foreach (var item in db.PlacementTbl)
            {
                lst.Add(PlacementDto.DalToDto(item));
            }
            return new RequestResult() { Data = lst, Message = "success", Status = true };
        }
        //קבלת תוצאת שיבוץ עי קוד שיבוץ
        public RequestResult GetTutorFoeApprenticeByPlacement(int placementId)
        {
            List<TutorForApprenticeDto> l = new List<TutorForApprenticeDto>();
            foreach (var item in db.TutorForApprenticeTbl)
            {
                if (item.PlacementID == placementId)
                    l.Add(TutorForApprenticeDto.DalToDto(item));
            }
            return new RequestResult() { Data = l, Message = "success", Status = true };
        }

        //קבלת ערכים עבור הטולטיפ
        public RequestResult finalForTolTip(int placementId)
        {
            List<string> lstResult = new List<string>();
            List<TutorForApprenticeTbl> l = db.TutorForApprenticeTbl.Where(x => x.PlacementID == placementId).ToList();
            foreach (var item in l)
            {
                string tutorForApprintice = GetApprenticeById((int)item.ApprenticeID).Data + GetCharacterizationConstraintsByApprentice((int)item.ApprenticeID).ToString() + "," + GetTutorById((int)item.TutorID).Data.ToString() + GetCharacterizationConstraintByTutor((int)item.TutorID).ToString() + " score: " + item.MatchLevelScore;
                lstResult.Add(tutorForApprintice + "//\n");
            }
            return new RequestResult() { Data = lstResult, Message = "success", Status = true };
        }
        //מחזיר רשימת חוכים שבשיבוץ ID
        public RequestResult GetResultTutorToTable(int placementId)
        {
            List<TutorForApprenticeTbl> l = db.TutorForApprenticeTbl.Where(x => x.PlacementID == placementId).ToList();
            List<TutorDto> lstT = new List<TutorDto>();
            foreach (var item in l)
            {

                TutorTbl t = db.TutorTbl.Where(x => x.TutorID == item.TutorID).FirstOrDefault();
                lstT.Add(TutorDto.DalToDto(t));
            }

            return new RequestResult() { Data = lstT, Message = "success", Status = true };
        }
        //רשימת חניכים שבשיבוץ ID
        public RequestResult GetResultApprenticeToTable(int placementId)
        {
            List<TutorForApprenticeTbl> l = db.TutorForApprenticeTbl.Where(x => x.PlacementID == placementId).ToList();
            List<ApprenticeDto> lstA = new List<ApprenticeDto>();
            foreach (var item in l)
            {

                ApprenticeTbl a = db.ApprenticeTbl.Where(x => x.ApprenticeID == item.ApprenticeID).FirstOrDefault();

                lstA.Add(ApprenticeDto.DalToDto(a));
            }
            return new RequestResult() { Data = lstA, Message = "success", Status = true };
        }
        //קבלת מערך של ניקודי שיבוץ
        public RequestResult GetScoreResultToTable(int placementId)
        {
            List<int> lScore = new List<int>();
            foreach (var item in db.TutorForApprenticeTbl)
            {
                if (item.PlacementID == placementId)
                {
                    lScore.Add((int)item.MatchLevelScore);
                }
            }
            return new RequestResult() { Data = lScore, Message = "success", Status = true };
        }
        //******** טיפול בלוגין ********
        //הוספת משתמש חדש
        public void AddUser(UserDto user)
        {
            db.UserTbl.Add(user.DtoToDal());
            db.SaveChanges();
        }
        //קבלת חונך עפי סיסמא - עבור לוגין
        public RequestResult GetTutorByPassword(string password)
        {
            TutorDto t = new TutorDto();
            TutorTbl tutor = db.TutorTbl.Where(x => x.PasswordID.Equals(password)).FirstOrDefault();
            t = TutorDto.DalToDto(tutor);
            return new RequestResult { Data = t, Message = "success", Status = true };
        }
        //קבלת חניך עפי סיסמא - עבור לוגין
        public RequestResult GetApprenticeByPassword(string password)
        {
            ApprenticeDto a = new ApprenticeDto();
            ApprenticeTbl apprentice = db.ApprenticeTbl.Where(x => x.Password.Equals(password)).FirstOrDefault();
            a = ApprenticeDto.DalToDto(apprentice);
            return new RequestResult { Data = a, Message = "success", Status = true };
        }
        //מתודה בוליאנית המחזירה האם המשתמש הוא  חונך
        public bool IsTutor(string password, string username)
        {
            foreach (var item in db.TutorTbl)
            {
                if (item.TutorName.Equals(username) && item.PasswordID.Equals(password))
                    return true;
            }
            return false;
        }

        //מתודה המחזירה האם המשתמש הוא חניך
        public bool IsApprentice(string password, string username)
        {
            foreach (var item in db.ApprenticeTbl)
            {
                if (item.ApprenticeName.Equals(username) && item.Password.Equals(password))
                    return true;
            }
            return false;
        }
        //משתמש לפי שם וסיסמא - פונקצית לוגין
        public RequestResult GetUserByUserNameAndPassword(string username, string password)
        {
            bool flagT, flagA;
            UserTbl user = db.UserTbl.Where(predicate: x => x.UserName == username && x.Password == password).FirstOrDefault();
            if (user == null)
                return new RequestResult { Data = null, Message = "success", Status = true };
            flagT = IsTutor(user.Password, user.UserName);
            flagA = IsApprentice(user.Password, user.UserName);

            if (flagA == true)
                return new RequestResult { Data = false, Message = "success", Status = true };
            return new RequestResult { Data = true, Message = "success", Status = true };

        }

    }
}
 