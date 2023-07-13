using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using krtrading.DataLayer;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.Data.SqlClient;


namespace krtrading.BL
{
    public class CommonBL
    {
        public void CaptureError(string MethodName,string ControllerName,string ErrorMessage)
        {
            string UserName = string.Empty;
            if(HttpContext.Current.Session["UserName"]!=null)
            {
                UserName = HttpContext.Current.Session["UserName"].ToString();
            }
            StackTrace stackTrace = new StackTrace();
            StackFrame[] stackFrames = stackTrace.GetFrames();
            string moreInfo = string.Empty;
            foreach(StackFrame stack in stackFrames)
            {
                moreInfo = moreInfo + "\n" + stack.GetMethod().Name;
            }
            moreInfo = "More Description:-" + moreInfo;
            Collection<SqlParameter> sqlParameters = new Collection<SqlParameter>();
            sqlParameters.Add(new SqlParameter("@ErrorDesc", ErrorMessage));
            sqlParameters.Add(new SqlParameter("@MoreInfo", moreInfo));
            sqlParameters.Add(new SqlParameter("@UserName", UserName));
            sqlParameters.Add(new SqlParameter("@ActionResultName", MethodName));
            sqlParameters.Add(new SqlParameter("@ControllerName", ControllerName));
            using (MYSQLDataProvider mysql = new MYSQLDataProvider())
            {
               int i= (int)mysql.CallProcedureWithListParm("InsertErrorLog", sqlParameters, MYSQLDataProvider.ReturnType.Integer);
            }
        }
    }
}