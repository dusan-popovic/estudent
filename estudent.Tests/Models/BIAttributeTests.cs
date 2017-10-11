using Microsoft.VisualStudio.TestTools.UnitTesting;
using estudent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace estudent.Models.Tests
{
    [TestClass()]
    public class BIAttributeTests
    {
        [TestMethod()]
        public void IsValidTest()
        {
           //(new PrivateObject(new BIAttribute())).Invoke("IsValid", new object[] { (object)"13/129", new ValidationContext(new object()) }    ); 

            string[] validCombinations = { "13/129","2013/129", "17/1", "17/5000" };
            string[] inValidCombinations = { null,"", "text", "1", " ", "a", " 13/129","129/13", "17/5001", "17/0", "17/-1", "300/129" };

            foreach (string combination in validCombinations)
                Assert.IsTrue(IsValid_Proxy(new BIAttribute(),combination, null) == null);
            
            foreach (string combination in inValidCombinations)
                Assert.IsTrue(IsValid_Proxy(new BIAttribute(), combination, null) != null);

        }

        ValidationResult IsValid_Proxy(BIAttribute testedObj,object value, ValidationContext context)
        {
            PrivateObject obj = new PrivateObject(testedObj);
            return (ValidationResult)obj.Invoke("IsValid", new object[] { value, context });
        }
    }
}