using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Foodie.Main;
using Foodie.Data;
using Foodie.Data.Repo;
using System.Collections.Generic;
using Autofac;
using Foodie.Data.Entity;
using Foodie.Data.Common;
using Foodie;
using Foodie.Main.Util;

namespace FoodieTest
{
    [TestClass]
    public class FoodieTest
    {
        MealTaker _mealTaker;

        [TestMethod]
        [TestCategory("MealTaker_Output")]
        public void CorrectInput()
        {
            var userStr = "morning,1,2,3";
            _mealTaker = new MealTaker(userStr);
            var output = _mealTaker.Output();
            Assert.AreEqual("eggs, toast, coffee",output, "Output incorrect.");
        }
    
        [TestMethod]
        [TestCategory("MealTaker_Output()")]
        public void WithAllowMultiples()
        {
            var userStr = "morning,1,2,3,3,3";
            _mealTaker = new MealTaker(userStr);
            var output = _mealTaker.Output();
            Assert.AreEqual("eggs, toast, coffee(x3)", output, "Items with [AllowMultiples = true] and are listed more than one time should be converted to following format: {Name}(x{Count})");
        }

        [TestMethod]
        [TestCategory("MealTaker_Output()")]
        public void DontAllowMultiples()
        {
            var userStr = "morning,1,2,2,3";
            _mealTaker = new MealTaker(userStr);
            var output = _mealTaker.Output();
            Assert.AreEqual("eggs, toast, error", output, "Output should end with error when a former item in the list runs into an issue");
        }

        [TestMethod]
        [TestCategory("MealTaker_Output()")]
        public void DontAllowEmptyInputs()
        {
            var userStr = "morning,1,2,3,,,";
            _mealTaker = new MealTaker(userStr);
            var output = _mealTaker.Output();
            Assert.AreEqual("eggs, toast, coffee", output, "Output should ignore commas (,)");
        }

        [TestMethod]
        [TestCategory("MealTaker_Output()")]
        public void IncorrectType()
        {
            var userStr = "morning,123232";
            _mealTaker = new MealTaker(userStr);
            var output = _mealTaker.Output();
            Assert.AreEqual("error", output, "DishType must exist");
        }

        [TestMethod]
        [TestCategory("MealTaker_Output()")]
        public void IncorrectTypeOrder()
        {
            var userStr = "morning,3,2,1";
            _mealTaker = new MealTaker(userStr);
            var output = _mealTaker.Output();
            Assert.AreEqual("eggs, toast, coffee", output, "Output should be in the following order: [Entree],[Side],[Drink],[Dessert]");
        }

        [TestMethod]
        [TestCategory("MealTaker_Output()")]
        public void NoParameters()
        {
            var userStr = "morning";
            _mealTaker = new MealTaker(userStr);
            var output = _mealTaker.Output();
            Assert.AreEqual("error", output, "Output will not work without Parameters.");
        }

        [TestMethod]
        [TestCategory("Type_TimeOfDay")]
        [ExpectedException(typeof(Exception))]
        public void TimeOFDay_Error()
        {
            var userStr = "doesntWork";
            var output = FoodieHelper.StringToEnum<DishType>(userStr);
        }

        [TestMethod]
        [TestCategory("Type_DishType")]
        public void DishType_Error()
        {
            for (var i = 1; i < 6; i++)
            {
                var output = FoodieHelper.StringToEnum<DishType>(i.ToString());
                Assert.AreEqual((DishType)i, output);
            }
        }
    }
}
