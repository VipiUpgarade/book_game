using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Odbc;
using System.Configuration;
using System.Data;
using System.Data.OleDb;

namespace ExWin
{
    class Game
    {
        int loc_id = 1;

        OleDbConnection GetConn()
        {
            string s = ConfigurationManager.AppSettings["conn"];
            return new OleDbConnection(s);
        }

        public Game(int startloc)
        {
            loc_id = startloc;
        }

        public string GetDesc()
        {
            using (var conn = GetConn())
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand("select desc from location where id = " + loc_id, conn);
                return (string)cmd.ExecuteScalar();
            }
        }

        public string[] GetActions()
        {
            using (var conn = GetConn())
            {
                conn.Open();

                OleDbCommand cmd = new OleDbCommand("select desc from transition where local_id = " + loc_id, conn);
                DataTable table = new DataTable();
                table.Load(cmd.ExecuteReader());

                List<string> list = new List<string>();
                for (int i = 0; i < table.Rows.Count; i++)
                    list.Add((string)table.Rows[i][0]);

                return list.ToArray();
            }
        }

        public void DoAction(int num)
        {
            using (var conn = GetConn())
            {
                conn.Open();

                OleDbCommand cmd = new OleDbCommand("select target_id from transition where local_id = " + loc_id, conn);

                DataTable table = new DataTable();
                table.Load(cmd.ExecuteReader());

                loc_id = (int)table.Rows[num][0];
            }

        }
    }
}
