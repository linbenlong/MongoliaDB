﻿using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoliaDB
{
    public class User
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
    public class User_Q
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
