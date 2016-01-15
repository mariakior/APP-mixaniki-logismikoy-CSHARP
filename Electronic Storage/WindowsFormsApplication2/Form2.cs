using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Threading;
using System.IO;

namespace WindowsFormsApplication2
{
    public partial class Form2 : Form
    {
        public Classlistvi dedomena = new Classlistvi();
        public string MyConnect = "SERVER=83.212.120.81;port=3306;DATABASE=ML;UID=Nikos;PASSWORD=test123";

        public Form2()
        {
            InitializeComponent();
            listView1.Columns.Add("Id", +50, HorizontalAlignment.Left);
            listView1.Columns.Add("Name", +100, HorizontalAlignment.Left);
            listView1.Columns.Add("PRICE", +100, HorizontalAlignment.Left);
            listView1.Columns.Add("CODE", +100, HorizontalAlignment.Left);
            listView1.Columns.Add("POSITION", +100, HorizontalAlignment.Left);
            listView1.Columns.Add("AVAILABLE", +100, HorizontalAlignment.Left);

            
            listView3.Columns.Add("UID", +50, HorizontalAlignment.Left);
            listView3.Columns.Add("NAME", +100, HorizontalAlignment.Left);
            listView3.Columns.Add("LASTNAME", +100, HorizontalAlignment.Left);
            listView3.Columns.Add("USERNAME", +100, HorizontalAlignment.Left);
            
           
            label25.Visible = false;
            label25.SendToBack();
            label25.Size = new System.Drawing.Size(50, 50);
            dedomena.scan();
            dedomena.store();
            dedomena.log();

        }

        private void tableintialazi()
        {
            dedomena.data();
            dedomena.store();
            dedomena.log();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            

        }

        private void button2_Click(object sender, EventArgs e)
        {

            OpenFileDialog fil = new OpenFileDialog();
            fil.Filter = "JPG |*.jpg| PNG |*.png| All files (*.*)|*.*";

            if (fil.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Visible = true;
                textBox4.Text = fil.FileName;
                pictureBox1.ImageLocation = fil.FileName;
             }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int i, g=-1;
            if (textBox2.Text != "" & textBox3.Text != "" & textBox4.Text != "" & comboBox1.Text != "" & textBox6.Text != "" & label7.Text != "PRES HERE" )
            {              
                for (i = 0;i<dedomena.storlen;i++)
                if (dedomena.stortable[i, 0].Equals(comboBox1.Text) && (int.Parse(dedomena.stortable[i, 1]) - int.Parse(dedomena.stortable[i, 2]))> int.Parse(textBox6.Text))
                {
                     label25.Visible = true;
                        label25.Size = new System.Drawing.Size(797, 450);
                        label25.BringToFront();
                        dedomena.addnewobj(textBox2.Text, textBox3.Text, textBox4.Text, comboBox1.Text, textBox6.Text, label7.Text);
                        MessageBox.Show("you added a new item ");
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox6.Text = "";
                        comboBox1.Text = "";
                        pictureBox1.Visible = false;
                        label7.Text = "PRES HERE";
                        tableintialazi();
                        label25.SendToBack();
                        label25.Size = new System.Drawing.Size(50, 50);
                        dedomena.scan();
                        label25.Visible = false;
                        g = 1;
                        break;
                        
                }
                else
                {
                        g = 0; 
                }
            }
            else
            {
                MessageBox.Show("ERROR SYNTAX");
            }
            if (g ==0)
            {
                MessageBox.Show("TOO MANY OBJECTS");
            }
        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {   

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            //edo sindeetai to barcode scanner

            dedomena.len++;
            if (comboBox1.Text == "A1")
            {
                label7.Text = ("11" + Convert.ToString(dedomena.len));
            }
            else if (comboBox1.Text == "A2")
            {
                label7.Text = ("12" + Convert.ToString(dedomena.len));
            }
            else if (comboBox1.Text == "B1")
            {
                label7.Text = ("21" + Convert.ToString(dedomena.len));
            }
            else if (comboBox1.Text == "B2")
            {
                label7.Text = ("22" + Convert.ToString(dedomena.len));
            }
            else
            {
                label7.Text = "PRESS HERE";
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            pictureBox2.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
           
            int i = 0;
            if (textBox7.Text != "" & textBox8.Text != "" & textBox9.Text != "")
            {

                do
                {
                    label25.Size = new System.Drawing.Size(797, 450);
                    label25.Visible = true;
                    label25.BringToFront();

                    if (textBox7.Text == dedomena.table[i, 0] & textBox8.Text == dedomena.table[i, 1] & textBox9.Text == dedomena.table[i, 3])
                    {
                        //diagrafi proiontos apo ton kodiko toy
                            dedomena.deleteitems(textBox9.Text);
                          
                            
                            MessageBox.Show("you deleted a item ");
                            textBox7.Text = "";
                            textBox8.Text = "";
                            textBox9.Text = "";
                            pictureBox2.Visible = false;
                            tableintialazi();
                            label25.Size = new System.Drawing.Size(50, 50);
                       
                        break;

                    }
                    i++;
                } while (i < dedomena.len);
            }
            dedomena.scan();
            label25.SendToBack();
            label25.Visible = false;
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            int i = 0;
            do
            {
                if (dedomena.stortable[i, 0] == "storvali" & textBox10.Text != "")
                {

                    int u = int.Parse(textBox10.Text);
                    int y = int.Parse(dedomena.stortable[i, 1]);
                    y = y + u;
                    dedomena.storinsert(y,dedomena.stortable[i, 0]);
                    textBox10.Text = "";

                }
                i++;
            } while (i < dedomena.storlen);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int i = 0;
            do
            {
                if (dedomena.stortable[i, 0] == "storvali" & textBox10.Text != "")
                {

                    int u = int.Parse(textBox10.Text);
                    int y = int.Parse(dedomena.stortable[i, 1]);
                    y = y - u;
                    dedomena.storinsert(y,dedomena.stortable[i, 0]);
                    textBox10.Text = "";
                    break;
                }
                i++;
            } while (i < dedomena.storlen);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int i = 0;
            tableintialazi();

            if (tabPage2 == tabControl1.SelectedTab)
            {
                float j, k;
                float h;
                int sub = 0;
                do
                {
                    if (dedomena.stortable[i, 0] == "storvali")
                    {
                        label19.Text = dedomena.stortable[i, 1];
                        float.TryParse(dedomena.stortable[i, 1], out j);
                        float.TryParse(dedomena.stortable[i, 2], out k);
                        h = (k / j) * 100;
                        progressBar1.Value = Convert.ToInt32(h);
                    }
                    else if (dedomena.stortable[i, 0] == "A1")
                    {
                        label13.Text =dedomena.stortable[i, 1];
                        float.TryParse(dedomena.stortable[i, 1], out j);
                        float.TryParse(dedomena.stortable[i, 2], out k);
                        h = (k / j) * 100;
                        progressBar2.Value = Convert.ToInt32(h);
                        sub = sub + int.Parse(dedomena.stortable[i, 1]);
                    }
                    else if (dedomena.stortable[i, 0] == "A2")
                    {
                        label20.Text =dedomena.stortable[i, 1];
                        float.TryParse(dedomena.stortable[i, 1], out j);
                        float.TryParse(dedomena.stortable[i, 2], out k);
                        h = (k / j) * 100;
                        progressBar3.Value = Convert.ToInt32(h);
                        sub = sub + int.Parse(dedomena.stortable[i, 1]);
                    }
                    else if (dedomena.stortable[i, 0] == "B1")
                    {
                        label21.Text =dedomena.stortable[i, 1];
                        float.TryParse(dedomena.stortable[i, 1], out j);
                        float.TryParse(dedomena.stortable[i, 2], out k);
                        h = (k / j) * 100;
                        progressBar4.Value = Convert.ToInt32(h);
                        sub = sub + int.Parse(dedomena.stortable[i, 1]);
                    }
                    else if (dedomena.stortable[i, 0] == "B2")
                    {
                        label22.Text =dedomena.stortable[i, 1];
                        float.TryParse(dedomena.stortable[i, 1], out j);
                        float.TryParse(dedomena.stortable[i, 2], out k);
                        h = (k / j) * 100;
                        progressBar5.Value = Convert.ToInt32(h);
                        sub = sub + int.Parse(dedomena.stortable[i, 1]);
                    }
                    label24.Text = Convert.ToString( sub);
                    i++;
                } while (i < dedomena.storlen);
            }

            if (tabPage1 == tabControl1.SelectedTab || tabPage4 == tabControl1.SelectedTab || tabPage6 == tabControl1.SelectedTab)
            {
                listView1.Clear();
                listView1.Columns.Add("Id", +50, HorizontalAlignment.Left);
                listView1.Columns.Add("Name", +100, HorizontalAlignment.Left);
                listView1.Columns.Add("PRICE", +100, HorizontalAlignment.Left);
                listView1.Columns.Add("CODE", +100, HorizontalAlignment.Left);
                
                listView1.Columns.Add("POSITION", +100, HorizontalAlignment.Left);
                listView1.Columns.Add("AVAILABLE", +100, HorizontalAlignment.Left);

                listView2.Clear();
                listView2.Columns.Add("Id", +50, HorizontalAlignment.Left);
                listView2.Columns.Add("Name", +100, HorizontalAlignment.Left);
                listView2.Columns.Add("PRICE", +100, HorizontalAlignment.Left);
                listView2.Columns.Add("CODE", +100, HorizontalAlignment.Left);
               
                listView2.Columns.Add("POSITION", +100, HorizontalAlignment.Left);
                listView2.Columns.Add("AVALIABLE", +100, HorizontalAlignment.Left);

                listView3.Clear();
                listView3.Columns.Add("UID", +50, HorizontalAlignment.Left);
                listView3.Columns.Add("NAME", +100, HorizontalAlignment.Left);
                listView3.Columns.Add("LASTNAME", +100, HorizontalAlignment.Left);
                listView3.Columns.Add("USERNAME", +100, HorizontalAlignment.Left);
                // emfanish proionton


                i = 0;

                do
                {
                    if (tabPage1 == tabControl1.SelectedTab)
                    {

                        ListViewItem lvl = new ListViewItem(dedomena.table[i, 0]);
                        lvl.SubItems.Add(dedomena.table[i, 1]);
                        lvl.SubItems.Add(dedomena.table[i, 2]);
                        lvl.SubItems.Add(dedomena.table[i, 3]);
                        
                        lvl.SubItems.Add(dedomena.table[i, 5]);
                        lvl.SubItems.Add(dedomena.table[i, 6]);
                        listView1.Items.Add(lvl);
                    }
                    if (tabPage4 == tabControl1.SelectedTab)
                    {
                        ListViewItem lvl2 = new ListViewItem(dedomena.table[i, 0]);
                        lvl2.SubItems.Add(dedomena.table[i, 1]);
                        lvl2.SubItems.Add(dedomena.table[i, 2]);
                        lvl2.SubItems.Add(dedomena.table[i, 3]);
                       
                        lvl2.SubItems.Add(dedomena.table[i, 5]);
                        lvl2.SubItems.Add(dedomena.table[i, 6]);
                        listView2.Items.Add(lvl2);



                        if (textBox7.Text == dedomena.table[i, 0] & textBox8.Text == dedomena.table[i, 1] & textBox9.Text == dedomena.table[i, 3] & pictureBox2.Visible != true)
                        {
                            pictureBox2.Visible = true;
                            MySqlConnection conn = new MySqlConnection(MyConnect);
                            MySqlCommand cmd ;
                            MySqlDataAdapter da;
                            string qery = "SELECT Foto FROM `storage` where ElectronicID ='" + dedomena.table[i, 0] + "'";
                            cmd = new MySqlCommand(qery, conn);
                            da = new MySqlDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            byte[] img = (byte[])dt.Rows[0][0];
                            MemoryStream ms = new MemoryStream(img);
                            pictureBox2.Image = Image.FromStream(ms);
                            da.Dispose();
                            //pictureBox2.ImageLocation = dedomena.table[i, 4];
                        }

                    }
                    i++;
                } while (i < dedomena.len );
                i = 0;
                do
                {
                    if (tabPage6 == tabControl1.SelectedTab)
                    {
                        ListViewItem lvl3 = new ListViewItem(dedomena.pertable[i, 0]);
                        lvl3.SubItems.Add(dedomena.pertable[i, 1]);
                        lvl3.SubItems.Add(dedomena.pertable[i, 2]);
                        lvl3.SubItems.Add(dedomena.pertable[i, 3]);
                        listView3.Items.Add(lvl3);
                    }
                    i++;
                } while (i < dedomena.perlen );


            }
           

        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            
            int i = 0;
            do
            {
                if (dedomena.stortable[i, 0] == "A1" & textBox11.Text != "")
                {

                    int u = int.Parse(textBox11.Text);
                    int y = int.Parse(dedomena.stortable[i, 1]);
                    y = y - u;
                    dedomena.storinsert(y,dedomena.stortable[i, 0]);
                    textBox11.Text = "";
                    break;
                }
                i++;
            } while (i < dedomena.storlen);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            
            int i = 0;
            do
            {
                if (dedomena.stortable[i, 0] == "A2" & textBox12.Text != "")
                {

                    int u = int.Parse(textBox12.Text);
                    int y = int.Parse(dedomena.stortable[i, 1]);
                    y = y - u;
                    dedomena.storinsert(y,dedomena.stortable[i, 0]);
                    textBox12.Text = "";
                    break;
                }
                i++;
            } while (i < dedomena.storlen);
        }

        private void button14_Click(object sender, EventArgs e)
        {
           
            int i = 0;
            do
            {
                if (dedomena.stortable[i, 0] == "B1" && textBox13.Text != "")
                {

                    int u = int.Parse(textBox13.Text);
                    int y = int.Parse(dedomena.stortable[i, 1]);
                    y = y - u;
                    dedomena.storinsert(y,dedomena.stortable[i, 0]);
                    textBox13.Text = "";
                    break;
                }
                i++;
            } while (i < dedomena.storlen);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            
            int i = 0;
            do
            {
                if (dedomena.stortable[i, 0] == "B2" & textBox14.Text != "")
                {

                    int u = int.Parse(textBox14.Text);
                    int y = int.Parse(dedomena.stortable[i, 1]);
                    y = y - u;
                    dedomena.storinsert(y,dedomena.stortable[i, 0]);
                    textBox14.Text = "";
                    break;
                }
                i++;
            } while (i < dedomena.storlen);
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            
            int i = 0;
            do
            {
                if (dedomena.stortable[i, 0] == "A1" && textBox11.Text != "")
                {

                    int u = int.Parse(textBox11.Text);
                    int y = int.Parse(dedomena.stortable[i, 1]);
                    y = y + u;
                    dedomena.storinsert(y,dedomena.stortable[i, 0]);
                    textBox11.Text = "";
                    break;
                }
                i++;
            } while (i < dedomena.storlen);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            

            int i = 0;
            do
            {
                if (dedomena.stortable[i, 0] == "A2" && textBox12.Text != "")
                {

                    int u = int.Parse(textBox12.Text);
                    int y = int.Parse(dedomena.stortable[i, 1]);
                    y = y + u;
                    dedomena.storinsert(y,dedomena.stortable[i, 0]);
                    textBox12.Text = "";
                    break;
                }
                i++;
            } while (i < dedomena.storlen);
        }

        private void button15_Click(object sender, EventArgs e)
        {
           

            int i = 0;
            do
            {
                if (dedomena.stortable[i, 0] == "B1" & textBox13.Text != "")
                {

                    int u = int.Parse(textBox13.Text);
                    int y = int.Parse(dedomena.stortable[i, 1]);
                    y = y + u;
                    dedomena.storinsert(y,dedomena.stortable[i, 0]);
                    textBox13.Text = "";
                    break;
                }
                i++;
            } while (i < dedomena.storlen);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            
            int i = 0;
            do
            {
                if (dedomena.stortable[i, 0] == "B2" & textBox14.Text != "")
                {

                    int u = int.Parse(textBox14.Text);
                    int y = int.Parse(dedomena.stortable[i, 1]);
                    y = y + u;
                    dedomena.storinsert(y,dedomena.stortable[i, 0]);
                    textBox14.Text = "";
                    break;
                }
                i++;
            } while (i < dedomena.storlen);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i ;
            int j = -1;
            if (textBox1.Text != "")
            {
                for(i = 0;i< dedomena.len;i++)
                {
                    if (dedomena.table[i, 1] == textBox1.Text || dedomena.table[i, 3] == textBox1.Text)
                    {
                        j = i;
                        textBox1.Text = "FIND !!!";
                        break;
                    }
                }
                if(j!=-1)
                {
                    panel1.Size = new System.Drawing.Size(794, 361);
                    panel1.Visible = true;
                    panel1.Enabled = true;
                    label30.Text = dedomena.table[j, 1];
                    label31.Text = dedomena.table[j, 2];
                    label32.Text = dedomena.table[j, 3];
                    label33.Text = dedomena.table[j, 6];
                    label35.Text = dedomena.table[j, 5];

                    MySqlConnection conn = new MySqlConnection(MyConnect);
                    MySqlCommand cmd;
                    MySqlDataAdapter da;
                    string qery = "SELECT Foto FROM `storage` where ElectronicID ='" + dedomena.table[i, 0] + "'";
                    cmd = new MySqlCommand(qery, conn);
                    da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    byte[] img = (byte[])dt.Rows[0][0];
                    MemoryStream ms = new MemoryStream(img);
                    pictureBox4.Image = Image.FromStream(ms);
                    da.Dispose();
                    
                    
                }
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel1.Enabled = false;
            textBox1.Text = "";
        }

        private void label35_Click(object sender, EventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            int p = 0;
            if(textBox5.Text !="" & textBox15.Text != "" & textBox17.Text != "" & textBox18.Text != "" & textBox19.Text != "")
            {
                for(int s=0;s<dedomena.perlen;s++)
                {
                    if (textBox5.Text == dedomena.pertable[s,1] & textBox15.Text == dedomena.pertable[s, 2] & textBox17.Text == dedomena.pertable[s, 3] )
                    {
                        p = 1;
                        textBox5.Text = "";
                        textBox15.Text = "";
                        textBox17.Text = "";
                        textBox18.Text = "";
                        textBox19.Text = "";
                        checkBox1.Checked = false;
                        break;
                    }
                }
                if (textBox18.Text.Equals(textBox19.Text) & p == 0)
                {
                    int A = 0;
                    MySqlConnection conn = new MySqlConnection(MyConnect);
                    MySqlCommand cmd;
                    conn.Open();
                    try
                    {


                        cmd = conn.CreateCommand();
                        cmd.CommandText = "INSERT INTO `persons`( `Name`, `Lastname`, `Username`,`Upassword`,`Admin`) VALUES ( @name,@Lname,@Uname,@Upass,@Adm)";
                        //cmd.Parameters.AddWithValue("@uid", );
                        cmd.Parameters.AddWithValue("@name", textBox5.Text);
                        cmd.Parameters.AddWithValue("@Lname", textBox15.Text);
                        cmd.Parameters.AddWithValue("@Uname", textBox17.Text);
                        cmd.Parameters.AddWithValue("@Upass", textBox18.Text);
                        if (checkBox1.Checked == true) { A = 1; } else { A = 0; }
                        cmd.Parameters.AddWithValue("@Adm", A);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("You added a new staff ");
                        textBox5.Text = "";
                        textBox15.Text = "";
                        textBox17.Text = "";
                        textBox18.Text = "";
                        textBox19.Text = "";
                        checkBox1.Checked = false;


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
                else if(p==1)
                {
                    MessageBox.Show("EXISTING USER");
                }
                else
                {
                    MessageBox.Show("THE PASSWORD IS NOT CORRECT");
                }
            }
        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = 0;
         
           foreach (ListViewItem item in listView3.Items)
           {
             if (item.Selected == true)
             {
                  textBox20.Text = dedomena.pertable[i, 0];
                  textBox16.Text = dedomena.pertable[i, 1];
                  textBox21.Text = dedomena.pertable[i, 2];
                  textBox22.Text = dedomena.pertable[i, 3];
             }
             i++;
          }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            int i = 0;
            if (textBox20.Text != "" & textBox16.Text != "" & textBox21.Text != "" & textBox22.Text != "")
            {

                do
                {
                    if (textBox20.Text == dedomena.pertable[i, 0] & textBox16.Text == dedomena.pertable[i, 1] & textBox21.Text == dedomena.pertable[i, 2] & textBox22.Text == dedomena.pertable[i, 3])
                    {
                        //diagrafi proiontos
                        MySqlConnection conn = new MySqlConnection(MyConnect);
                        MySqlCommand cmd;
                        conn.Open();
                        try
                        {


                            cmd = conn.CreateCommand();
                            cmd.CommandText = "DELETE FROM `persons` WHERE Uid = @uid";
                            cmd.Parameters.AddWithValue("@uid", textBox20.Text);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("You deleted a person ");
                            textBox20.Text = "";
                            textBox16.Text = "";
                            textBox21.Text = "";
                            textBox22.Text = "";
                            tableintialazi();

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
                    i++;
                } while (i < dedomena.perlen);
            }

        }

        private void progressBar1_Click_1(object sender, EventArgs e)
        {

        }

        private void button19_Click(object sender, EventArgs e)
        {
            //EDO EKTIPONETE O KODIKOS SE AFTOKOLITO KAI KOLIETE STA IPOLIPA ANTIKIMENA TOY IDIOY IDIOU IDOYS
        }
    }
}
//Nikolas Papazian 41785