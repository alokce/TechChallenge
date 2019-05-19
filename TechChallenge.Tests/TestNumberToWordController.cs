using System;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechChallenge.Controllers;
using TechChallenge.Models;

namespace TechChallenge.Tests
{
    [TestClass]
    public class TestNumberToWordController
    {
        [TestMethod]
        public void Get_NumberToWord()
        {
            var controller = new NumberToWordController();
            var result = controller.GetNumberToWord("John Smith", 123.45m) as OkNegotiatedContentResult<InputNumber>;
            
            Assert.IsNotNull(result);

            Assert.AreEqual("John Smith", result.Content.Name);

            Assert.AreEqual("One Hundred Twenty Three Dollars and Fourty Five Cents", result.Content.Word);
        }

        
    }
}
