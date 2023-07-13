using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace krtrading.AdminModel
{
    public class BannerData
    {
        public List<BannerList> objLst { get; set; }
    }
    public class BannerList
    {
        public int Id { get; set; }
        public string EncryptedId { get; set; }
        public string BannerImg { get; set; }
        public int TotalRecord { get; set; }
    }
    
}