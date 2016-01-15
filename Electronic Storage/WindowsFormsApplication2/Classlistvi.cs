using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.IO;



namespace WindowsFormsApplication2
{
    public class Classlistvi
    {
        public string MyConnect = "datasource=83.212.120.81;port=3306;DATABASE=ML;username=Nikos;password=test123";
        public string[,] table = new string[10000, 7];
        public string[,] stortable = new string[10000, 4];
        public string[,] pertable = new string[10000, 6];
        public int perlen = 0;
        public int storlen = 0;
        public int len = 0;
        byte[] ImageData;
        
        public int data()
        {
            int res=1;
            MySqlConnection connection = new MySqlConnection(MyConnect);
            try
            {

                int i = 0;

                connection.Open();
                //Open connection
                if (connection.State == ConnectionState.Open)
                {
              
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM `storage` ", connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        table[i, 0] = dataReader.GetString("ElectronicID");
                        table[i, 1] = dataReader.GetString("name");
                        table[i, 2] = dataReader.GetString("Prise");
                        table[i, 3] = dataReader.GetString("Code");
                        table[i, 5] = dataReader.GetString("Thesh");
                        table[i, 6] = dataReader.GetString("Available");
                        i++;
                        res = 0;
                    }
                    len = i;
                }
                else {

                    System.Windows.Forms.MessageBox.Show("connect error");
                    res= 1;
                    
                }



            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

                connection.Close();


            }

            return res;

        }

        public int store()
        {
            int res = 1;
            MySqlConnection connection = new MySqlConnection(MyConnect);
            try
            {

                int i = 0;

                connection.Open();
                //Open connection
                if (connection.State == ConnectionState.Open)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM `Store-information` ", connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        stortable[i, 0] = dataReader.GetString("storname");
                        stortable[i, 1] = dataReader.GetString("storspace");
                        stortable[i, 2] = dataReader.GetString("storitems");
                        stortable[i, 3] = dataReader.GetString("storcode");
                        res = 0;
                        i++;
                    }
                    storlen = i;
                }
                else {

                    System.Windows.Forms.MessageBox.Show("connect error");
                    res = 1;
                }



            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

                connection.Close();


            }
            return res;
        }

        public void storinsert(int val, string pos)
        {
            for (int i = 0; i < storlen; i++)
            {
                if (stortable[i, 0].Equals(pos) & val > (int.Parse(stortable[i, 2])))
                {
                    MySqlConnection conn = new MySqlConnection(MyConnect);
                    MySqlCommand cmd;
                    conn.Open();
                    try
                    {
                        cmd = conn.CreateCommand();
                        cmd.CommandText = "UPDATE `Store-information`SET `storspace` = @sv WHERE `storname` = @sp";
                        cmd.Parameters.AddWithValue("@sv", val);
                        cmd.Parameters.AddWithValue("@sp", pos);
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    finally
                    {
                        conn.Close();
                    }
                    stortable[i, 1] = val.ToString();
                    break;
                }
            }

        }

        public int log()
        {
            MySqlConnection connection = new MySqlConnection(MyConnect);
            int res = 1;
            try
            {

                int i = 0;

                connection.Open();
                //Open connection
                if (connection.State == ConnectionState.Open)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM `persons` ", connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        pertable[i, 0] = dataReader.GetString("Uid");
                        pertable[i, 1] = dataReader.GetString("Name");
                        pertable[i, 2] = dataReader.GetString("Lastname");
                        pertable[i, 3] = dataReader.GetString("Username");
                        pertable[i, 4] = dataReader.GetString("Upassword");
                        pertable[i, 5] = dataReader.GetString("Admin");
                        res = 0;
                        i++;
                    }
                    perlen = i;
                }
                else {

                    System.Windows.Forms.MessageBox.Show("connect error");
                    res = 1;
                }



            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

                connection.Close();


            }
            return res;

        }

        public void objmov(int val, string pos)
        {
            data();
            store();
            int h = 0;
            int y = 0;
            int t = 0;
            for (int i = 0; i < len; i++)
            {
                if (int.Parse(table[i, 3]).Equals(val))
                {
                    for (int j = 0; j < storlen; j++)
                    {
                        if (stortable[j, 0].Equals(pos))
                        {
                            if ((int.Parse(stortable[j, 2]) + int.Parse(table[i, 6])) > 0 & (int.Parse(stortable[j, 2]) + int.Parse(table[i, 6])) < (int.Parse(stortable[j, 1])))
                            {
                                h = (int.Parse(stortable[j, 2]) + int.Parse(table[i, 6]));

                                MySqlConnection conn = new MySqlConnection(MyConnect);
                                MySqlCommand cmd;
                                conn.Open();
                                try
                                {
                                    cmd = conn.CreateCommand();
                                    cmd.CommandText = "UPDATE `storage`SET `Thesh` = @sv WHERE `Code` = @sp";
                                    cmd.Parameters.AddWithValue("@sv", pos);
                                    cmd.Parameters.AddWithValue("@sp", val);
                                    cmd.ExecuteNonQuery();
                                    cmd = conn.CreateCommand();
                                    cmd.CommandText = "UPDATE `Store-information`SET `storitems` = @sv WHERE `storname` = @sp";
                                    cmd.Parameters.AddWithValue("@sv", h);
                                    cmd.Parameters.AddWithValue("@sp", stortable[j, 0]);
                                    cmd.ExecuteNonQuery();
                                    t = 1;
                                }
                                catch (Exception)
                                {
                                    throw;
                                }
                                finally
                                {
                                    conn.Close();
                                }
                            }
                        }
                        if (stortable[j, 0].Equals(table[i, 5]) & t == 1)
                        {
                            y = (int.Parse(stortable[j, 2]) - int.Parse(table[i, 6]));
                            MySqlConnection conn = new MySqlConnection(MyConnect);
                            MySqlCommand cmd;
                            conn.Open();
                            try
                            {
                                cmd = conn.CreateCommand();
                                cmd.CommandText = "UPDATE `Store-information`SET `storitems` = @sv WHERE `storname` = @sp";
                                cmd.Parameters.AddWithValue("@sv", y);
                                cmd.Parameters.AddWithValue("@sp", stortable[j, 0]);
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception)
                            {
                                throw;
                            }
                            finally
                            {
                                conn.Close();
                            }
                            break;
                        }
                    }
                }
            }

        }

        public void objpri(int val, int pos)
        {
            MySqlConnection conn = new MySqlConnection(MyConnect);
            MySqlCommand cmd;
            conn.Open();
            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE `storage`SET `Prise` = @sv WHERE `Code` = @sp";
                cmd.Parameters.AddWithValue("@sv", pos);
                cmd.Parameters.AddWithValue("@sp", val);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

        }

        public void addobj(int val, int pos)
        {
            data();
            store();
            int h = 0;
            for (int i = 0; i < len; i++)
            {
                if (int.Parse(table[i, 3]).Equals(val))
                {
                    for (int j = 0; j < storlen; j++)
                    {
                        if (stortable[j, 0].Equals(table[i, 5]))
                        {
                            if ((int.Parse(stortable[j, 2]) - int.Parse(table[i, 6]) + pos) > 0 & (int.Parse(stortable[j, 2]) - int.Parse(table[i, 6]) + pos) < (int.Parse(stortable[j, 1])))
                            {
                                h = int.Parse(stortable[j, 2]) - int.Parse(table[i, 6]) + pos;
                                MySqlConnection conn = new MySqlConnection(MyConnect);
                                MySqlCommand cmd;
                                conn.Open();
                                try
                                {
                                    cmd = conn.CreateCommand();
                                    cmd.CommandText = "UPDATE `storage`SET `Available` = @sv WHERE `Code` = @sp";
                                    cmd.Parameters.AddWithValue("@sv", pos);
                                    cmd.Parameters.AddWithValue("@sp", val);
                                    cmd.ExecuteNonQuery();
                                    stortable[j, 2] = h.ToString();
                                    cmd = conn.CreateCommand();
                                    cmd.CommandText = "UPDATE `Store-information`SET `storitems` = @sv WHERE `storname` = @sp";
                                    cmd.Parameters.AddWithValue("@sv", stortable[j, 2]);
                                    cmd.Parameters.AddWithValue("@sp", stortable[j, 0]);
                                    cmd.ExecuteNonQuery();

                                }
                                catch (Exception)
                                {
                                    throw;
                                }
                                finally
                                {
                                    conn.Close();
                                }

                                break;
                            }
                        }
                    }
                }
            }
        }

        public int scan()
        {
            int res = 1;
            data();
            store();
            int j = 0;
            int h = 0;
            stortable[0, 2] = 0.ToString();
            stortable[1, 2] = 0.ToString();
            stortable[2, 2] = 0.ToString();
            stortable[3, 2] = 0.ToString();
            stortable[4, 2] = 0.ToString();

            for (int i = 0; i < len; i++)
            {
                if (table[i, 5].Equals(stortable[0, 0]))
                {
                    j = (int.Parse(stortable[0, 2]) + int.Parse(table[i, 6]));
                    stortable[0, 2] = j.ToString();
                }
                else if (table[i, 5].Equals(stortable[1, 0]))
                {
                    j = (int.Parse(stortable[1, 2]) + int.Parse(table[i, 6]));
                    stortable[1, 2] = j.ToString();
                }
                else if (table[i, 5].Equals(stortable[2, 0]))
                {
                    j = (int.Parse(stortable[2, 2]) + int.Parse(table[i, 6]));
                    stortable[2, 2] = j.ToString();
                }
                else if (table[i, 5].Equals(stortable[3, 0]))
                {
                    j = (int.Parse(stortable[3, 2]) + int.Parse(table[i, 6]));
                    stortable[3, 2] = j.ToString();
                }

                h = (int.Parse(stortable[4, 2]) + int.Parse(table[i, 6]));
                stortable[4, 2] = h.ToString();

            }
            for (int i = 0; i < storlen; i++)
            {
                MySqlConnection conn = new MySqlConnection(MyConnect);
                MySqlCommand cmd;
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    try
                    {
                        cmd = conn.CreateCommand();
                        cmd.CommandText = "UPDATE `Store-information`SET `storitems` = @sv WHERE `storname` = @sp";
                        cmd.Parameters.AddWithValue("@sv", stortable[i, 2]);
                        cmd.Parameters.AddWithValue("@sp", stortable[i, 0]);
                        cmd.ExecuteNonQuery();
                        res = 0;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
                else {
                    res = 1;
                }
            }
            return res;
        }

        public void addnewobj(string txtBox2Txt, string txtBox3Txt, string txtBox4Txt, string cmbBox1Text , string txtBox6Txt, string label7Txt)
        {

            FileStream fs;
            BinaryReader br;
            MySqlConnection conn = new MySqlConnection(MyConnect);
            MySqlCommand cmd;

            try
            {
                string FileName = txtBox4Txt;
                fs = new FileStream(FileName, FileMode.Open, FileAccess.Read);
                br = new BinaryReader(fs);
                ImageData = br.ReadBytes((int)fs.Length);
                br.Close();
                fs.Close();


                cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO `storage`( `Name`, `Prise`, `Foto`,`Thesh`,`Code`,`Available`) VALUES (@name,@prise,@foto,@thesh,@code,@available)";
                cmd.Parameters.AddWithValue("@name", txtBox2Txt);
                cmd.Parameters.AddWithValue("@prise", txtBox3Txt);
                cmd.Parameters.Add("@foto", MySqlDbType.Blob);
                cmd.Parameters.AddWithValue("@thesh", cmbBox1Text);
                cmd.Parameters.AddWithValue("@code", label7Txt);
                cmd.Parameters.AddWithValue("@available", txtBox6Txt);
                cmd.Parameters["@foto"].Value = ImageData;
                conn.Open();
                int RowsAffected = cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();

                }
            }
        }

        public void deleteitems(string tecode)
        {

            //diagrafi proiontos
            MySqlConnection conn = new MySqlConnection(MyConnect);
            MySqlCommand cmd;
            conn.Open();
            try
            {

                cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM `storage` WHERE Code = @code";
                cmd.Parameters.AddWithValue("@code", tecode);
                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

                conn.Close();
            }
        }

    }
}
//Nikolas Papazian 41785