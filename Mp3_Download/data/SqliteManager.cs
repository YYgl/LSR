using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace data
{
    class SqliteManager
    {
        SQLiteConnection db_connection;

        public SqliteManager()
        {
            db_connection = new SQLiteConnection("Data Source=LSR.sqlite;Version=3;");

            db_connection.Open();
        }

        public List<string> getWord()
        {
            List<string> list = new List<string>();
            // 构造sql语句
            string sql = string.Format("SELECT Word " +
                                       "FROM Cet6;");

            // 执行sql语句
            SQLiteCommand command = new SQLiteCommand(sql, db_connection);
            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string word = reader["Word"].ToString();
                list.Add(word);
            }
            return list;
        }
    }
}
