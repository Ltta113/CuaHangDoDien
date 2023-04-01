using CuaHangDoDien.Models.DBConection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Data.Entity.Infrastructure;

namespace CuaHangDoDien.DAO
{
    public class Account_DAO
    {
        private readonly CuaHangDienMayEntities db = null;
        public Account_DAO() 
        {
            db = new CuaHangDienMayEntities();
        }
        public Account getAcc(string username)
        {
            Account acc = db.Accounts.FirstOrDefault(x => x.Username == username && x.Quyen == 0);
            return acc;
        }

    }
}