using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoliaDB
{
    //数据访问层
    public class MongoDBDao
    {
        private static object objLock = new object();
        private static IMongoDatabase mongo;
        private static IMongoDatabase Instance
        {
            get
            {
                if (mongo == null)
                {
                    lock (objLock)//防止多线程构造
                    {
                        string connctionString = "mongodb://56ctmlog:56ctmloglong@127.0.0.1:27017/Logging";
                        MongoClient client = new MongoClient(connctionString);
                        mongo = client.GetDatabase("Logging");
                    }
                }
                return mongo;
            }
        }

        /// <summary>
        /// 保存记录
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static void SaveUser(User info)
        {
            if (info != null)
            {
                try
                {
                    IMongoCollection<User> collection = Instance.GetCollection<User>("test");
                    collection.InsertOne(info);
                    Console.WriteLine("write:  " + info.ToJson());//在插入操作时有必要输出log以备后用或使用mongodb的日志存储
                    Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + info.ToJson());

                }
            }

        }
        public static void SaveUsers(List<User> info)
        {
            if (info != null)
            {
                try
                {
                    IMongoCollection<User> collection = Instance.GetCollection<User>("test");
                    collection.InsertMany(info);
                    Console.WriteLine("write:  " + info.ToJson());//在插入操作时有必要输出log以备后用或使用mongodb的日志存储
                    Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + info.ToJson());

                }
            }

        }
        public static List<User> Query()
        {

            /// return Instance.GetCollection<User>("test").Aggregate().Match(x => x.Name == "linbenlong").ToList<User>();
            return Instance.GetCollection<User>("test").Find(x => x.Name == "linbenlong").ToList<User>();

        }
        public static List<LogModel> QueryLog(string msg)
        {

            /// return Instance.GetCollection<User>("test").Aggregate().Match(x => x.Name == "linbenlong").ToList<User>();
            return Instance.GetCollection<LogModel>("NLog").Find(x => x.Message == msg).ToList<LogModel>();

        }
    }
}
