
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;

namespace ToDoList.Models.Models
{
    public class DataContext:DbContext
    {

        public DataContext()
        {
          string path= HttpContext.Current.ApplicationInstance.Server.MapPath("~/App_Data")+ "\\TaskData.mdf";
            //Database.Connection.ConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = ""C:\Users\PC011\Desktop\test\ToDoList\ToDoList.Models\App_Data\TaskData.mdf""; Integrated Security = True";
            Database.Connection.ConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = "+path+"; Integrated Security = True";

        }
        public DbSet<Task> Tasks{ get; set; }
    }
}