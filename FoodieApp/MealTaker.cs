using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Foodie.Data;
using Foodie.Data.Entity;
using Foodie.Data.Common;
using System.Linq.Expressions;
using Foodie.Data.Repo;
using Foodie.Main.Interface;
using Foodie.Main.Util;
using Foodie.Main.Config;
using Autofac;


namespace Foodie.Main
{
    public class MealTaker : IOutput
    {
        private const string _DELIM = ", ";
        private const string _ERROR = "error";

        FoodieContext _context; 
        TimeOfDay _timeOfDay;
        List<Parameter> _parameters = new List<Parameter>();
        List<string> _output;

        public MealTaker(string userParams)
        {
            var paramList = userParams.ToLower().Parse(",");

            _context = new FoodieContext();
            _timeOfDay = FoodieHelper.StringToEnum<TimeOfDay>(paramList.FirstOrDefault());
            _output = new List<string>();
            _parameters = new List<Parameter>();
            _parameters = FillParameters(paramList);
        }

        public string Output()
        {
            if (_parameters.Count() >= 1)
            {
                foreach (var param in _parameters.OrderBy(d => d.Item))
                {
                    var dishType = (DishType)param.Item;
                    var name = "";
                    var food = _context.Foods.First(d => d.TimeOfDay == _timeOfDay
                                                      && d.DishType == dishType);
                    var count = param.Count;

                    if (food != null)
                    {
                        name = food.Name;
                        if (count > 1)
                        {
                            if (food.AllowMultiples)
                            {
                                _output.RemoveAll(d => d == name);
                                _output.Add(name + "(x" + count + ")");
                            }
                            else
                            {
                                // Error
                                _output.Add(name);
                                _output.Add(_ERROR);
                                break;
                            }
                        }
                        else
                        {
                            _output.Add(name);
                        }
                    }
                    else
                    {
                        // Error
                        _output.Add(_ERROR);
                        break;
                    }
                }

                return string.Join(_DELIM, _output).ToLower();
            }
            else
            {
                // Can't have 0 parameters
                return _ERROR;
            }
        }

        public List<Parameter> FillParameters(List<string> paramList)
        {
            try
            {
                var startIndex = 1;
                var count = paramList.Count() - 1;
                _parameters.Clear();
                foreach (var param in paramList.GetRange(startIndex, count).Where(d => d != ""))
                {
                    if (_parameters.FirstOrDefault(d => d.Item == int.Parse(param)) == null)
                        _parameters.Add(new Parameter { Item = int.Parse(param), Count = paramList.Count(d => d == param) });
                }
                return _parameters;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("An erorr occurred in {0}.", "FillParameters"), ex);
            }
        }
    }
}
