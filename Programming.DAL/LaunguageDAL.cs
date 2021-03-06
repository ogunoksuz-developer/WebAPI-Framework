﻿using Programming.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming.DAL
{
   public class LaunguageDAL:BaseDAL
    {
       

        public IEnumerable<Language> GetAllLanguages()
        {
            return db.Language;
        }


        public Language GetLanguagesById(int id)
        {
            return db.Language.Find(id);
        }


        public Language CreateLanguage(Language language)
        {
            db.Language.Add(language);
            db.SaveChanges();
            return language;
        }

        public Language UpdateLanguage(int id,Language language)
        {
            db.Entry(language).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return language;
        }

        public void DeleteLanguage(int id)
        {
            db.Language.Remove(db.Language.Find(id));
            db.SaveChanges();
        }

        public bool IsThereAnyLanguage(int id)
        {
            return db.Language.Any(x => x.Id == id);
        }

    }
}
