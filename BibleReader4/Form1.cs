using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BibleReader4
{
    public partial class Form1 : Form
    {
        TheArtOfDev.HtmlRenderer.WinForms.HtmlPanel htmlPanel = new TheArtOfDev.HtmlRenderer.WinForms.HtmlPanel();

        List<string> booklist = new List<string>(); // initialize list of all the books in bible
        List<int> chapterlist = new List<int>(); // initialize list of the last chapter in each books

        string[] booklistmienthai = new string[] { "ทิน เต่ย โต้ว","ธ้วด อี^ยิบ","เล^วี","ซ้าว เมี่ยน","หฑั่ม เล์ย-หลัด","โย^ซู^วา","ต้ม เจียน",
                                                    "ลู^เท","1 ซา^มู^เอน","2 ซา^มู^เอน","1 ฮู่ง โต้ว","2 ฮู่ง โต้ว",
                                                    "1 ฒุ่น ต่อย โต้ว","2 ฒุ่น ต่อย โต้ว","เอ^สะ^ลา","เน^หะ^มี","เอ^เซ^เท",
                                                    "โย้บ","สีง ฑูง","ธง-เม่ง หว่า","ก๊อง เสย หฒั่ง","ซา^โล^มอน เญย ฑูง","อิ^สะ^ยา",
                                                    "เย^เล^มี","หน่าน ฒี่ง ฑูง","เอ^เส^เคน","ดา^นี^เอน","โฮ^เซ^ยา","โย^เอน","อา^โม้ด","โอ^บา^ดี","โย^นา",
                                                    "มี^คา","นา^ฮูม","ฮา^บา^กุก","เส^ฟัน^ยา","ฮัก^ไก",
                                                    "เส^คา^ลิ^ยา","มา^ลา^คี","มัด^ทาย","มา^โค","ลู^กา","โย^ฮัน","กง-โฒ่",
                                                    "โล^มา","1 โค^ลิน^โท","2 โค^ลิน^โท","กา^ลา^เทีย","เอ^เฟ^โซ","ฟี^ลิบ^พอย",
                                                    "โค^โล^สี","1 เท^สะ^โล^นิ^กา","2 เท^สะ^โล^นิ^กา","1 ทิ^โม^ไท",
                                                    "2 ทิ^โม^ไท","ทิ^ตัด","ฟี^เล^โมน","ฮิบ^ลู","ยา^กอบ","1 ปี^เต",
                                                    "2 ปี^เต","1 โย^ฮัน","2 โย^ฮัน","3 โย^ฮัน","ยิว^ดา","หล่าว ย่าง"};

        string[] booklistmienroman = new string[] {"Tin Deic Douh","Cuotv I^yipv","Lewi","Saauv Mienh","Nzamc Leiz-Latc",
                "Yo^su^waa","Domh Jien","Lu^te","1 Saa^mu^en","2 Saa^mu^en","1 Hungh Douh",
                "2 Hungh Douh","1 Zunh Doic Douh","2 Zunh Doic Douh","E^saa^laa","Ne^haa^mi",
                "E^se^te","Yopv","Singx Nzung","Cong-Mengh Waac","Gorngv Seix Zaangc","Saa^lo^morn Nyei Nzung",
                "I^saa^yaa","Ye^le^mi","Naanc Zingh Nzung","E^se^ken","Ndaa^ni^en",
                "Ho^se^yaa","Yo^en","Aamotv","O^mbaa^ndi","Yonaa","Mikaa","Naa^hum",
                "Haa^mbaa^gukc","Se^fan^yaa","Hakv^gai","Se^kaa^li^yaa","Maa^laa^ki",
                "Matv^taai","Maako","Lugaa","Yo^han","Gong-Zoh","Lomaa",
                "1 Ko^lin^to","2 Ko^lin^to","Gaa^laa^tie","E^fe^so","Fi^lipv^poi","Ko^lo^si",
                "1 Te^saa^lo^ni^gaa","2 Te^saa^lo^ni^gaa",
                "1 Ti^mo^tai","2 Ti^mo^tai","Tidatc","Fi^le^mon","Hipv^lu","Yaagorpc",
                "1 Bide","2 Bide","1 Yo^han","2 Yo^han","3 Yo^han","Yiu^ndaa","Laauc Yaangh"};


        string[] booklistmienlao = new string[] {"ທິນ ເຕີ່ຍ ໂຕ້ວ","ທສວດ ອີ^ຢິ໊ບ","ເລ^ວີ","ຊ້າວ ມ່ຽນ","ດສ່ຳ ເລີ໌ຍ-ຫລັດ","ໂຢ^ຊູ^ວາ",
                        "ຕົ້ມ ຈຽນ","ລູ^ເທ","1 ຊາ^ມູ^ເອນ","2 ຊາ^ມູ^ເອນ","1 ຮູ່ງ ໂຕ້ວ","2 ຮູ່ງ ໂຕ້ວ",
                        "1 ຕສຸ້ນ ຕ່ອຍ ໂຕ້ວ","2 ຕສຸ້ນ ຕ່ອຍ ໂຕ້ວ","ເອ^ສະ^ລາ","ເນ^ຫະ^ມີ","ເອ^ເຊ^ເທ",
                        "ໂຢ໊ບ","ສີງ ດສູງ","ທສົງ-ເມ່ງ ຫວ່າ","ກ໊ອງ ເສີຍ ຕສັ່ງ","ຊາ^ໂລ^ມອນ ເຍີຍ ດສູງ","ອິ^ສະ^ຢາ",
                        "ເຢ^ເລ^ມີ","ໜ່ານ ຕສີ້ງ ດສູງ","ເອ^ເສ^ເຄນ","ດາ^ນີ^ເອນ",
                        "ໂຮ^ເຊ^ຢາ","ໂຢ^ເອນ","ອາ^ມົດ","ໂອ^ບາ^ດີ","ໂຢ^ນາ","ມີ^ຄາ",
                        "ນາ^ຮູມ","ຮາ^ບາ^ກຸກ","ເສ^ຟັນ^ຢາ","ຮັກ^ໄກ","ເສ^ຄາ^ລິ^ຢາ","ມາ^ລາ^ຄີ","ມັດ^ທາຍ",
                        "ມາ^ໂຄ","ລູ^ກາ","ໂຢ^ຮັນ","ກົງ-ໂຕສ້","ໂລ^ມາ","1 ໂຄ^ລິນ^ໂທ","2 ໂຄ^ລິນ^ໂທ",
                        "ກາ^ລາ^ເທຍ","ເອ^ເຟ^ໂຊ","ຟີ^ລິບ^ພອຍ","ໂຄ^ໂລ^ສີ","1 ເທ^ສະ^ໂລ^ນິ^ກາ","2 ເທ^ສະ^ໂລ^ນິ^ກາ",
                        "1 ທິ^ໂມ^ໄທ","2 ທິ^ໂມ^ໄທ","ທິ^ຕັດ","ຟີ^ເລ^ມົນ","ຮິບ^ລູ","ຢາ^ກອບ",
                        "1 ປີ^ເຕ","2 ປີ^ເຕ","1 ໂຢ^ຮັນ","2 ໂຢ^ຮັນ","3 ໂຢ^ຮັນ","ຢິວ^ດາ","ຫລ່າວ ຢ້າງ"};

        string bibleversion = "ThaiMien";
        string testament = "OT";
        int booksnumber = 1;
        string booksname = "Genesis";
        string filepath = @"mienbible\WorldEnglishBible\OT\Genesis\1.htm";
        string textfromfile2 = "";
        string chapter = "1.htm";
        int selectedchapter = 1;
        int numberbook = 66; // total book in bible

        string fullpath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"mienbible\WorldEnglishBible\OT\Genesis\1.htm");

        public Form1()
        {
            InitializeComponent();

            filepath = @"mienbible\startpage.html";
            fullpath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filepath);

            string textfromfile = System.IO.File.ReadAllText(fullpath);
            //string textfromfile = System.IO.File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"mienbible\startpage.html"));
            htmlPanel.Text =textfromfile;
            
            htmlPanel.Dock = DockStyle.Fill;
            Controls.Add(htmlPanel);
            


        }

        private void Form1_Load(object sender, EventArgs e)
        {

            booklist.Add("Genesis");
            chapterlist.Add(50);

            booklist.Add("Exodus");
            chapterlist.Add(40);

            booklist.Add("Leviticus");
            chapterlist.Add(27);

            booklist.Add("Numbers");
            chapterlist.Add(36);

            booklist.Add("Deuteronomy");
            chapterlist.Add(34);

            booklist.Add("Joshua");
            chapterlist.Add(24);

            booklist.Add("Judges");
            chapterlist.Add(21);

            booklist.Add("Ruth");
            chapterlist.Add(4);

            booklist.Add("1Samuel");
            chapterlist.Add(31);

            booklist.Add("2Samuel");
            chapterlist.Add(24);

            booklist.Add("1Kings");
            chapterlist.Add(22);

            booklist.Add("2Kings");
            chapterlist.Add(25);

            booklist.Add("1Chronicles");
            chapterlist.Add(29);

            booklist.Add("2Chronicles");
            chapterlist.Add(36);

            booklist.Add("Ezra");
            chapterlist.Add(10);

            booklist.Add("Nehemiah");
            chapterlist.Add(13);

            booklist.Add("Esther");
            chapterlist.Add(10);

            booklist.Add("Job");
            chapterlist.Add(42);

            booklist.Add("Psalms");
            chapterlist.Add(150);

            booklist.Add("Proverbs");
            chapterlist.Add(31);

            booklist.Add("Ecclesiastes");
            chapterlist.Add(12);

            booklist.Add("SongOfSolomon");
            chapterlist.Add(8);

            booklist.Add("Isaiah");
            chapterlist.Add(66);

            booklist.Add("Jeremiah");
            chapterlist.Add(52);

            booklist.Add("Lamentations");
            chapterlist.Add(5);

            booklist.Add("Ezekiel");
            chapterlist.Add(48);

            booklist.Add("Daniel");
            chapterlist.Add(12);

            booklist.Add("Hosea");
            chapterlist.Add(14);

            booklist.Add("Joel");
            chapterlist.Add(3);

            booklist.Add("Amos");
            chapterlist.Add(9);

            booklist.Add("Obadiah");
            chapterlist.Add(1);

            booklist.Add("Jonah");
            chapterlist.Add(4);

            booklist.Add("Micah");
            chapterlist.Add(7);

            booklist.Add("Nahum");
            chapterlist.Add(3);

            booklist.Add("Habakkuk");
            chapterlist.Add(3);

            booklist.Add("Zephaniah");
            chapterlist.Add(3);

            booklist.Add("Haggai");
            chapterlist.Add(2);

            booklist.Add("Zechariah");
            chapterlist.Add(14);

            booklist.Add("Malachi");
            chapterlist.Add(4);

            //************************************** NEW TESTAMENT*************************************************//



            booklist.Add("Matthew");
            chapterlist.Add(28);

            booklist.Add("Mark");
            chapterlist.Add(16);

            booklist.Add("Luke");
            chapterlist.Add(24);

            booklist.Add("John");
            chapterlist.Add(21);


            booklist.Add("Acts");
            chapterlist.Add(28);

            booklist.Add("Romans");
            chapterlist.Add(16);

            booklist.Add("1Corinthians");
            chapterlist.Add(16);


            booklist.Add("2Corinthians");
            chapterlist.Add(13);

            booklist.Add("Galatians");
            chapterlist.Add(6);

            booklist.Add("Ephesians");
            chapterlist.Add(6);

            booklist.Add("Philippians");
            chapterlist.Add(4);

            booklist.Add("Colossians");
            chapterlist.Add(4);

            booklist.Add("1Thessalonians");
            chapterlist.Add(5);

            booklist.Add("2Thessalonians");
            chapterlist.Add(3);


            booklist.Add("1Timothy");
            chapterlist.Add(6);

            booklist.Add("2Timothy");
            chapterlist.Add(4);

            booklist.Add("Titus");
            chapterlist.Add(3);


            booklist.Add("Philemon");
            chapterlist.Add(1);

            booklist.Add("Hebrews");
            chapterlist.Add(13);

            booklist.Add("James");
            chapterlist.Add(5);


            booklist.Add("1Peter");
            chapterlist.Add(5);


            booklist.Add("2Peter");
            chapterlist.Add(3);


            booklist.Add("1John");
            chapterlist.Add(5);

            booklist.Add("2John");
            chapterlist.Add(1);

            booklist.Add("3John");
            chapterlist.Add(1);

            booklist.Add("Jude");
            chapterlist.Add(1);

            booklist.Add("Revelation");
            chapterlist.Add(22);



            //*****************************************************************************************************//
            //*****************************************************************************************************//


            numberbook = booklist.Count;
           

         
            

            filepath = @"mienbible\" + bibleversion + @"\" + testament + @"\"
                                 + booksname + @"\" + chapter;
            fullpath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filepath);


        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            toolStripComboBox2.Items.Clear();
            
            if (toolStripComboBox1.SelectedItem == "World English Bible")
            {
                
                for (int ctr = 0; ctr < numberbook; ctr++)
                {
                    toolStripComboBox2.Items.Add(booklist[ctr]);
                }


                bibleversion = "WorldEnglishBible";
                filepath = @"mienbible\" + bibleversion + @"\" + testament + @"\"
                                + booksname + @"\" + chapter;
                fullpath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filepath);

                textfromfile2 = System.IO.File.ReadAllText(fullpath);
                htmlPanel.Text = textfromfile2;
                
            }
            

            if (toolStripComboBox1.SelectedItem == "Mienh nyei siang-Lomaa nzaangc")
            {
                for (int ctr = 0; ctr < numberbook; ctr++)
                {
                    toolStripComboBox2.Items.Add(booklistmienroman[ctr]);
                }
                bibleversion = "MienNewRoman";
                filepath = @"mienbible\" + bibleversion + @"\" + testament + @"\"
                                + booksname + @"\" + chapter;
                fullpath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filepath);

                textfromfile2 = System.IO.File.ReadAllText(fullpath);
                htmlPanel.Text = textfromfile2;
                
            }

            if (toolStripComboBox1.SelectedItem == "เมี่ยน เญย จั๋น-ไท้ หฑั่ง - Mienh nyei Janx-Taiv nzaangc")
            {
                for (int ctr = 0; ctr < numberbook; ctr++)
                {
                    toolStripComboBox2.Items.Add(booklistmienthai[ctr]);
                }


                bibleversion = "ThaiMien";
                filepath = @"mienbible\" + bibleversion + @"\" + testament + @"\"
                                + booksname + @"\" + chapter;
                fullpath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filepath);

                textfromfile2 = System.IO.File.ReadAllText(fullpath);
                htmlPanel.Text = textfromfile2;
                
            }

            if (toolStripComboBox1.SelectedItem == "ມ່ຽນ ເຍີຍ ຈັ໋ນ-ເລ້າ ດສັ່ງ - Mienh nyei Janx-Lauv nzaangc")
            {

                for (int ctr = 0; ctr < numberbook; ctr++)
                {
                    toolStripComboBox2.Items.Add(booklistmienlao[ctr]);
                }
                bibleversion = "MienLao";
                filepath = @"mienbible\" + bibleversion + @"\" + testament + @"\"
                                + booksname + @"\" + chapter;
                fullpath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filepath);

                textfromfile2 = System.IO.File.ReadAllText(fullpath);
                htmlPanel.Text = textfromfile2;
                
            }

        }

        private void toolStripComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // get the selected books
            booksnumber = toolStripComboBox2.SelectedIndex;
            if (booksnumber >= 39) { testament = "NT"; }
            if (booksnumber < 39) { testament = "OT"; }
            booksname = booklist[booksnumber];

            //create combobox 3 which is the chapter
            int numberchapter = chapterlist[booksnumber];
            toolStripComboBox3.Items.Clear();
            for (int chap = 1; chap <= numberchapter; chap++)
            {
                toolStripComboBox3.Items.Add(chap);
            }

            //update display
            chapter = "1.htm";
            filepath = @"mienbible\" + bibleversion + @"\" + testament + @"\"
                                + booksname + @"\" + chapter;
            fullpath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filepath);

            toolStripComboBox3.Text = "";

            textfromfile2 = System.IO.File.ReadAllText(fullpath);

            htmlPanel.Text = textfromfile2;

        }

        private void toolStripComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //get selected chapter
            selectedchapter = 1+(toolStripComboBox3.SelectedIndex);
            chapter = selectedchapter + ".htm" ;

            //update display
            filepath = @"mienbible\" + bibleversion + @"\" + testament + @"\"
                                + booksname + @"\" + chapter;
            fullpath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filepath);

            textfromfile2 = System.IO.File.ReadAllText(fullpath);

            htmlPanel.Text = textfromfile2;
        }
    }
}
