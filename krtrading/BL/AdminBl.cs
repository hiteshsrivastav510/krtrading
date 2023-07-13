using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using krtrading.DataLayer;
using krtrading.AdminModel;
using krtrading.AccountModel;
using System.Data;
using System.Collections;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace krtrading.BL
{
    public class AdminBl
    {
        Encript enc = new Encript();
        public BannerData BannerData()
        {
            BannerData model=new BannerData();
            List<BannerList> objlst = new List<BannerList>();
            DataTable dt=new DataTable();
            Collection<SqlParameter> sqlParameters = new Collection<SqlParameter>();
            sqlParameters.Add(new SqlParameter("@Action", "BindData"));
            using (MYSQLDataProvider mysql = new MYSQLDataProvider())
            {
                dt = (DataTable)mysql.CallProcedureWithListParm("BannerData", sqlParameters, MYSQLDataProvider.ReturnType.DataTable);
            }
            if(dt!=null && dt.Rows.Count>0)
            {
                foreach(DataRow dr in dt.Rows)
                {
                    BannerList obj = new BannerList();
                    obj.Id = Convert.IsDBNull(dr["id"]) ? default(int) : Convert.ToInt32(dr["id"]);
                    obj.TotalRecord = Convert.IsDBNull(dr["TotalRecord"]) ? default(int) : Convert.ToInt32(dr["TotalRecord"]);
                    obj.BannerImg = Convert.IsDBNull(dr["BannerImg"]) ? default(string) : Convert.ToString(dr["BannerImg"]);
                    obj.EncryptedId = enc.Encrypt(Convert.ToString(obj.Id));
                    objlst.Add(obj);
                }
            }
            model.objLst= objlst;
            return model;
        }
        public int AddBanner(string BannerImg)
        {
            int i = 0;
            Collection<SqlParameter> sqlParameters = new Collection<SqlParameter>();
            sqlParameters.Add(new SqlParameter("@BannerImg", BannerImg));
            sqlParameters.Add(new SqlParameter("@Action", "Insert"));
            using (MYSQLDataProvider mysql = new MYSQLDataProvider())
            {
                i = (int)mysql.CallProcedureWithListParm("BannerData", sqlParameters, MYSQLDataProvider.ReturnType.Integer);
            }
            return i;
        }
        public int DeleteUpDownBanner(int Id,string Action)
        {
            int i = 0;
            Collection<SqlParameter> sqlParameters = new Collection<SqlParameter>();
            sqlParameters.Add(new SqlParameter("@BannerId", Id));
            sqlParameters.Add(new SqlParameter("@Action", Action));
            using (MYSQLDataProvider mysql = new MYSQLDataProvider())
            {
                i = (int)mysql.CallProcedureWithListParm("BannerData", sqlParameters, MYSQLDataProvider.ReturnType.Integer);
            }
            return i;
        }
    }
}