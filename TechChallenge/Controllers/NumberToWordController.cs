using System;
using System.Web.Http;
using System.Web.Http.Description;
using TechChallenge.Models;

namespace TechChallenge.Controllers
{
    public class NumberToWordController : ApiController
    {
        private INumberToWord numToWord = new NumberToWord();

        public NumberToWordController() { }

        public NumberToWordController(INumberToWord numContext)
        {
            numToWord = numContext;
        }

        // GET: api/NumberToWord
        [ResponseType(typeof(InputNumber))]
        public IHttpActionResult GetNumberToWord(string name, decimal number)
        {
            try
            {
                InputNumber word = numToWord.ConvertNumberToWord(name, number);
                return Ok(word);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
