using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Diagnostics;
using System.Threading;
using ServiceStack.OrmLite;

namespace HookFromV2
{
    public static class DBUtils
    {
        static string connectionString = @"Data Source=|DataDirectory|\Scripts\SQLite\DatabaseLite.sqlite;Version=3;PRAGMA journal_mode=WAL;";
        //static string connectionString = "Data Source=DatabaseLite.sqlite;Version=3;PRAGMA journal_mode=WAL;";
        static SQLiteConnection con;
        static SQLiteCommand sqlComm;

        static OrmLiteConnectionFactory dbFactory = new OrmLiteConnectionFactory(connectionString, SqliteDialect.Provider);

        static List<string> queList = new List<string>();
       
        static public bool isWriting
        { get;  set; } = false;



        public static void OpenConection()
        {

            Guid guid = Guid.NewGuid();
            string uniqID = guid.ToString();
            queList.Add(uniqID);
           
            while (queList[0] != uniqID)
            {
                 Thread.Sleep(5);
            }
            
            con = new SQLiteConnection(connectionString);
            con.Open();
            /* Wraping like a transaction */
            sqlComm = new SQLiteCommand("begin", con);
            sqlComm.ExecuteNonQuery();

        }

        public static void CloseConnection()
        {
           
            sqlComm = new SQLiteCommand("end", con);
            sqlComm.ExecuteNonQuery();
            con.Close();
            queList.RemoveAt(0);
        }

        public static int ExecuteScalar(string query)
        {
            SQLiteCommand command = new SQLiteCommand(query, con);
            int count = 0;
            try
            {
                if (!Convert.IsDBNull(command.ExecuteScalar()))
                {
                    count = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return count;
        }
        public static void ExecuteQueries(string query)
        {
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        static public List<ProgramExe> ReadPrograms()
        {
            string query = "SELECT * FROM Programs";
            SQLiteCommand command = new SQLiteCommand(query, con);
            List<ProgramExe> list = new List<ProgramExe>();
            try
            {

                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int id = Convert.ToInt16(reader["id"]);
                    string name = reader["name"].ToString();
                    string exe = reader["exe"].ToString();
                    bool filter = Convert.ToBoolean(reader["filter"]);
                    ProgramExe prog = new ProgramExe(id, name, exe, filter);
                    list.Add(prog);

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            list = list.OrderBy(o => o._name).ToList();
            return list;

        }

        

        public static List<double> AllInputsTypingSpeed(string query, int multiplier)
        {
            SQLiteCommand command = new SQLiteCommand(query, con);

            SQLiteDataReader reader = command.ExecuteReader();
            List<int> numbaList = new List<int>();
            List<double> doubleList = new List<double>();
            
            int end = multiplier;
      
            int i = 0;

            while (reader.Read())
            {
                int delay = Convert.ToInt32(reader["timestamp"]);
                if (delay > 9)
                {
                    if (i == multiplier)
                    {
                        doubleList.Add(Math.Round((double)1000 / numbaList.Average(), 2));
                        numbaList.Clear();
                        i = -1;
                    }
                    numbaList.Add(Convert.ToInt32(reader["timestamp"]));
                    i++;
                }
            }
            reader.Close();
            return doubleList;
        }

        public static List<MistakesObject> ReadMistakesORM(string where)
        {
            List<MistakesObject> mistList = new List<MistakesObject>();

            try
            {
                bool newItemAdded = true;

                string connectionString = "Data Source=DatabaseLite.sqlite;Version=3;PRAGMA journal_mode=WAL;";

                OrmLiteConnectionFactory dbFactory = new OrmLiteConnectionFactory(connectionString, SqliteDialect.Provider);

                //DateTime test = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                
                using (IDbConnection db = dbFactory.OpenDbConnection())
                {
                    //var filteredData = db.TABLE.Where(t => t.DATE > startDate && t.DATE < endDate);

                    //var rows = db.From<Heatmap>().Where(x => x.date.CompareTo("2018-05-05 00:00:00") >= 0 && x.date.CompareTo("2018-06-21 23:59:59") <= 0);
                    //var rows = db.From<Heatmap>().Where(x => x.program_id == 12);
                    Stopwatch st = new Stopwatch();
                    st.Start();
                    var rowT = db.Select<Models.Mistakes>().Where(x => x.datetime.CompareTo("2018-05-15 00:00:00") >= 0 && x.datetime.CompareTo("2018-06-21 23:59:59") <= 0);
                    int swInt = (int)st.ElapsedMilliseconds;
                    st.Stop();


                 /*   foreach (var item in rowT)
                    {
                        if (item.deleted == deleted && item.replacedValue == replaced)
                        {
                            item.replacedTimes++;
                            item.finalWord.Add(final);
                            newItemAdded = false;
                            break;

                        }
                        *
                    }*/
                }

                


                /*   foreach (var item in mistList)
               {
                   if (item.deletedValue == deleted && item.replacedValue == replaced)
                   {
                       item.replacedTimes++;
                       item.finalWord.Add(final);
                       newItemAdded = false;
                       break;

                   }

               }
               if (newItemAdded)
               {
                   MistakesObject val = new MistakesObject(deleted, replaced);
                   val.finalWord.Add(final);
                   mistList.Add(val);
               }*/
            }
            catch (Exception ex)
            {

                throw;
            }

            mistList = mistList.OrderByDescending(o => o.replacedTimes).ToList();
            return mistList;
        }

        public static List<MistakesObject> ReadMistakes(string query)
        {
            List<MistakesObject> mistList = new List<MistakesObject>();
            SQLiteCommand command = new SQLiteCommand(query, con);


            try
            {

                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string deleted = reader["deleted"].ToString();
                    string replaced = reader["replaced_with"].ToString();
                    string final = reader["final_word"].ToString();
                    bool newItemAdded = true;

                    foreach (var item in mistList)
                    {
                        if (item.deletedValue == deleted && item.replacedValue == replaced)
                        {
                            item.replacedTimes++;
                            item.finalWord.Add(final);
                            newItemAdded = false;
                            break;

                        }

                    }
                    if (newItemAdded)
                    {
                        MistakesObject val = new MistakesObject(deleted, replaced);
                        val.finalWord.Add(final);
                        mistList.Add(val);
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                //If an exception occurs, write it to the console
                MessageBox.Show(ex.ToString());
            }
            // Sort dictionary for the sake of performance
            mistList = mistList.OrderByDescending(o => o.replacedTimes).ToList();
            return mistList;
        }

        public static List<KeyValuePair<string, int>> ReadWords(string query)
        {
            /*Stopwatch st = new Stopwatch();
            st.Start();
            string connectionString = "Data Source=DatabaseLite.sqlite;Version=3;PRAGMA journal_mode=WAL;";
            OrmLiteConnectionFactory dbFactory = new OrmLiteConnectionFactory(connectionString, SqliteDialect.Provider);

            Dictionary<string, int> dict = new Dictionary<string, int>();
            using (IDbConnection db = dbFactory.OpenDbConnection())
            {
                var rowT = db.Select<Models.Mistakes>().Where(x => x.datetime.CompareTo("2018-05-15 00:00:00") >= 0 && x.datetime.CompareTo("2018-06-21 23:59:59") <= 0);
                foreach (var item in rowT)
                {
                    if (dict.ContainsKey(item.final_word))
                    {
                        dict[item.final_word]++;
                    }
                    else
                    {
                        dict.Add(item.final_word, 1);
                    }
                }
            }
            var myList = dict.ToList();

            myList.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));
            st.Stop();
            int test = (int)st.ElapsedMilliseconds;
            return myList; */
            OpenConection();
            Stopwatch st = new Stopwatch();
            st.Start();
              Dictionary<string, int> dict = new Dictionary<string, int>();
              SQLiteCommand command = new SQLiteCommand(query, con);
              try
              {
                  SQLiteDataReader reader = command.ExecuteReader();
                  while (reader.Read())
                  {
                      string final = reader["final_word"].ToString();

                      if (dict.ContainsKey(final))
                      {
                          dict[final]++;
                      }
                      else
                      {
                          dict.Add(final, 1);
                      }

                  }
                  reader.Close();
              }
              catch (Exception ex)
              {
                  MessageBox.Show(ex.ToString());
              }

              var myList = dict.ToList();

              myList.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));
            st.Stop();
            CloseConnection();
            int test = (int)st.ElapsedMilliseconds;

            return myList;
        }

        public static int GetExeID(Process p)
        {
            string exe = "";
            string exeName = "";
            int exeID = 0;

            try
            {
                exe = p.MainModule.ModuleName.ToString().ToLower();

            }
            catch (Exception)
            {

                exe = "unknown";
            }

            string query = string.Format("SELECT * FROM programs WHERE exe = '{0}'", exe);

            SQLiteDataReader myReader = null;
            SQLiteCommand myCommand = new SQLiteCommand(query, con);

            myReader = myCommand.ExecuteReader();
            myReader.Read();

            if (myReader.HasRows)
            {
                myReader.Close();

            }
            else
            {
                myReader.Close();

                try
                {
                    exeName = p.MainModule.FileVersionInfo.FileDescription.ToString();
                }
                catch (Exception)
                {
                    exeName = "";
                }
                query = string.Format("INSERT INTO Programs ([exe],[name], [filter]) VALUES  ('{0}','{1}',1)", exe, exeName);
                SQLiteCommand cmd = new SQLiteCommand(query, con);
                cmd.ExecuteNonQuery();

            }
            if (exe != "unknown")
            {
                query = string.Format(@"SELECT ID FROM Programs WHERE exe = '{0}'", exe);
                myCommand = new SQLiteCommand(query, con);
                myReader = myCommand.ExecuteReader();
                myReader.Read();
                exeID = Convert.ToInt16(myReader["Id"]);
                myReader.Close();
            }
            return exeID;
        }
    }
}
