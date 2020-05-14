using Programming.API.Attributes;
using Programming.API.Security;
using Programming.DAL;
using Programming.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Programming.API.Controllers
{
    [ApiExceptionAttribures]

    public class LaunguageController : ApiController
    {
        LaunguageDAL languageDAL = new LaunguageDAL();

      
        [ResponseType(typeof(IEnumerable<Language>))]
        [ApiAuthorizeAttribute(Roles ="A")]
        public IHttpActionResult Get()
        {
            var languages = languageDAL.GetAllLanguages();
            return Ok(languages);
        }


        [ResponseType(typeof(Language))]
        public IHttpActionResult Get(int id)
        {
                var language = languageDAL.GetLanguagesById(id);
                if (language == null)
                    return NotFound();

                return Ok(language);
          
        }


        [ResponseType(typeof(Language))]
        public IHttpActionResult Post(Language language)
        {
            if (ModelState.IsValid)
            {
                var createdLanguage = languageDAL.CreateLanguage(language);
                return CreatedAtRoute("DefaultApi", new { id = createdLanguage.Id }, createdLanguage);
            }
            else
            {
                return BadRequest(ModelState);
            }

        }

        [ResponseType(typeof(Language))]
        public IHttpActionResult Put(int id, Language language)
        {
            if (languageDAL.IsThereAnyLanguage(id) == false)
            {
                return NotFound();
            }
            else if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            else
            {
                return Ok(languageDAL.UpdateLanguage(id, language));
            }

        }

        public IHttpActionResult Delete(int id)
        {
            if (languageDAL.IsThereAnyLanguage(id) == false)
                return NotFound();


            languageDAL.DeleteLanguage(id);
            return Ok();
        }
    }
}
