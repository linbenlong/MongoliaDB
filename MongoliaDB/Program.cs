using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using NLog;

namespace MongoliaDB
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User { Name = "linbenlong"};
            //  MongoDBDao.SaveUser(user);
            //List<User> users = new List<MongoliaDB.User>();
            //users.Add(new User { Name = "liyuguo", Age = 22 });
            //users.Add(new User { Name = "zhaozhenwei", Age = 21 });
            //users.Add(new User { Name = "lixiaolong", Age = 23 });
            //users.Add(new User { Name = "zhaojunjie", Age = 23 });
            //MongoDBDao.SaveUsers(users);
            //List<User> users = MongoDBDao.Query();
            //foreach (var li in users)
            //{
            //    Console.WriteLine(li.Name);
            //}
            Logger logger = LogManager.GetCurrentClassLogger();
            string msg = "NLogMongoDB测试19211";
            logger.Debug(msg);
            List<LogModel> logs = MongoDBDao.QueryLog(msg);
            foreach (var li in logs)
            {
                Console.WriteLine(li.Message);
            }
            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff"));
            Console.ReadLine();
        }
       
    }
}
