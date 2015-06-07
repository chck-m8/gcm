using Foodie.Data;
using Foodie.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Main.Util
{
    public static class FoodieHelper
    {
        /// <summary>
        /// Converts a string input into a type T enumeration.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public static T StringToEnum<T>(string name) 
        {
            try { 
                return (T)Enum.Parse(typeof(T), name.Capitalize());
            }
            catch(Exception ex)
            {
                throw new Exception(string.Format("An erorr occurred in {0}.", "StringToEnum"), ex);
            }
        }

        /// <summary>
        /// Capitalize first letter of string.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static string Capitalize(this string value){
            if (value.Length >= 1)
                return (value[0] + "").ToUpper() + value.ToLower().Substring(1, value.Length - 1);
            else
                return "";
        }

        /// <summary>
        /// A method to simplify splitting a string into a list.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static List<string> Parse(this string value, string delim)
        {
            return value.Split(delim.ToCharArray()[0]).ToList();
        }
    }
}
