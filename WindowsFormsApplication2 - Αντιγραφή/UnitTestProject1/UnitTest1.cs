using WindowsFormsApplication2;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

//using System.IO;

namespace WindowsFormsApplication2.Tests
{

    [TestClass()]
    public class UnitTest1
    {
        [TestMethod()]
        public void dataTest()
        {
            Classlistvi dataretes = new Classlistvi();

            Assert.ReferenceEquals(1, dataretes.data());
        }

        [TestMethod()]
        public void storeTest()
        {
            Classlistvi dataretes = new Classlistvi();
            Assert.ReferenceEquals(1, dataretes.store());
        }

        [TestMethod()]
        public void logTest()
        {
            Classlistvi dataretes = new Classlistvi();
            Assert.ReferenceEquals(1, dataretes.log());
        }

        [TestMethod()]
        public void scanTest()
        {
            Classlistvi dataretes = new Classlistvi();
            Assert.ReferenceEquals(1, dataretes.scan());
        }


        [TestMethod()]
        public void storinsertTest()
        {
            int corect = 1;
            Classlistvi dataretes = new Classlistvi();
            dataretes.storinsert(1000, "A2");
            dataretes.store();
            for (int i = 0; i < dataretes.storlen; i++)
            {
                if (dataretes.stortable[i, 0] == "A2" & dataretes.stortable[i, 1] == "1000")
                {
                    corect = 0;
                }
            }

            Assert.ReferenceEquals(0, corect);
        }

        [TestMethod()]
        public void addnewobjTest()
        {
            int corect = 1;
            string name = "nikolas";
            string price = "1";
            string foto = "C:/Users/strike xXx/Desktop/mixaniki/018510-glossy-black-3d-button-icon-symbols-shapes-power-button.png";
            string thesh = "A2";
            string code = "100";
            string avalable = "1";
            Classlistvi dataretes = new Classlistvi();
            dataretes.addnewobj(name, price, foto, thesh, avalable, code);
            dataretes.data();
            for (int i = 0; i < dataretes.len; i++)
            {
                if (dataretes.table[i, 1] == name & dataretes.table[i, 2] == price & dataretes.table[i, 3] == foto & dataretes.table[i, 4] == thesh & dataretes.table[i, 5] == code & dataretes.table[i, 6] == avalable)
                {
                    corect = 0;
                    //dataretes.deleteitems(dataretes.table[i, 0]);
                    break;
                }
            }
            dataretes.deleteitems(code);

            Assert.ReferenceEquals(0, corect);
        }

        [TestMethod()]
        public void addobjTest()
        {
            Classlistvi dataretes = new Classlistvi();
            dataretes.store();
            int corect = 1;
            string code = "100";
            int vali = 30;
            string name = "nikolas";
            string price = "1";
            string foto = "C:/Users/strike xXx/Desktop/mixaniki/018510-glossy-black-3d-button-icon-symbols-shapes-power-button.png";
            string thesh = "A2";
            string avalable = "1";
            dataretes.addnewobj(name, price, foto, thesh, avalable, code);
            dataretes.addobj(int.Parse(code), vali);
            dataretes.store();
            for (int i = 0; i < dataretes.len; i++)
            {
                if (dataretes.table[i, 5] == code & int.Parse(dataretes.table[i, 6]) == vali + 1)
                {
                    corect = 0;
                    break;
                }
            }
            dataretes.deleteitems(code);
            Assert.ReferenceEquals(0, corect);
        }

        [TestMethod()]
        public void objpriTest()
        {
            Classlistvi dataretes = new Classlistvi();
            dataretes.store();
            int corect = 1;
            string code = "100";
            int vali = 30;
            string name = "nikolas";
            string price = "1";
            string foto = "C:/Users/strike xXx/Desktop/mixaniki/018510-glossy-black-3d-button-icon-symbols-shapes-power-button.png";
            string thesh = "A2";
            string avalable = "1";
            dataretes.addnewobj(name, price, foto, thesh, avalable, code);
            dataretes.objpri(int.Parse(code), vali);
            dataretes.store();
            for (int i = 0; i < dataretes.len; i++)
            {
                if (dataretes.table[i, 5] == code & int.Parse(dataretes.table[i, 2]) == vali)
                {
                    corect = 0;
                    break;
                }
            }
            dataretes.deleteitems(code);
            Assert.ReferenceEquals(0, corect);
        }

        [TestMethod()]
        public void storinsertTest1()
        {
            Classlistvi dataretes = new Classlistvi();
            int corect = 1;
            dataretes.store();
            string name = dataretes.stortable[2, 0];
            string vali = dataretes.stortable[2, 1];

            dataretes.storinsert(1993, name);
            dataretes.store();
            if (dataretes.stortable[2, 0] == name & vali == dataretes.stortable[2, 1])
            {
                corect = 0;
            }
            dataretes.storinsert(int.Parse(vali) , name);
            dataretes.store();
            Assert.ReferenceEquals(0, corect);
        }
    }
}


