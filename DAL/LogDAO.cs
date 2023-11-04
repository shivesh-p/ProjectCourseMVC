﻿using DTO;
using System;
using System.Web;

namespace DAL
{
    public class LogDAO:DbContextPost
    {
        public static void AddLog(int ProcessType, string TableName, int ProcessID)
        {
            Log_Table log = new Log_Table();
            log.UserID = UserStatic.UserID;
            log.ProcessType = ProcessType;
            log.ProcessID = ProcessID;
            log.ProcessCategoryType = TableName;
            log.ProcessDate = DateTime.Now;
            log.IPAdress = HttpContext.Current.Request.UserHostAddress;
            db.Log_Table.Add(log);
            db.SaveChanges();
        }
    }
}
