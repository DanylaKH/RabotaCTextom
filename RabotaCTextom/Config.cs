using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RabotaCTextom
{
    class Config
    {
        public string path = "C:\\Users\\admin\\Documents\\test.txt";
        public string dbConnect = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\admin\\Desktop\\RabotaCTextom\\RabotaCTextom\\DatabaseTest.mdf;Integrated Security=True";
        public string queryString = "SELECT Items FROM TestTable";
    }
}
