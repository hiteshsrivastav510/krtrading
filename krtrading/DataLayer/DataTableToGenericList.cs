using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Reflection;

namespace krtrading.DataLayer
{
    public static class DataTableToGenericList
    {
        [Obsolete("This is old method, Use method with SkipProperty.")]
        public static List<T> DataTableToList<T>(DataTable table) where T:class,new()
        {
            try{
                List<T> classList=new List<T>();
                foreach(var row in table.AsEnumerable()){
                    T objClass=new T();
                    foreach(var prop in objClass.GetType().GetProperties()){
                        try{
                            PropertyInfo propertyInfo=objClass.GetType().GetProperty(prop.Name);
                            propertyInfo.SetValue(objClass,Convert.ChangeType(row[prop.Name],propertyInfo.PropertyType),null);
                        }
                        catch{
                            continue;
                        }
                    }
                    classList.Add(objClass);
                }
                return classList;
            }
            catch{
                return null;
            }
        }

        public static List<T> DataTableToList<T>(DataTable table,bool? SkipProperty) where T:class,new()
        {
            var ColumnContains=new HashSet<string>();
            var stringArray=table.Columns.Cast<DataColumn>().Select(x=>x.ColumnName).ToArray();
            foreach(var  ColumnName in stringArray.AsEnumerable()){
                ColumnContains.Add(ColumnName);
            }
            try{
                List<T> classList=new List<T>();
                foreach(var row in table.AsEnumerable()){
                    T objClass=new T();
                    foreach(var prop in objClass.GetType().GetProperties().Where(property=>ColumnContains.Contains(property.Name)))
                    {
                        try{
                            PropertyInfo propertyInfo =objClass.GetType().GetProperty(prop.Name);
                            propertyInfo.SetValue(objClass,Convert.ChangeType(row[prop.Name],propertyInfo.PropertyType),null);
                        }
                        catch{
                            continue;
                        }
                    }
                    classList.Add(objClass);
                }
                return classList;
            }
            catch{
                return null;
            }
        }
    }
}