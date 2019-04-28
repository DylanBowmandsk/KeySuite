using Microsoft.VisualStudio.TestTools.UnitTesting;
using KeySuite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using KeySuiteTests;

namespace KeySuite.Tests
{
    [TestClass()]
    public class DatabaseUtilsTests
    {

        [TestMethod()]
        public void refreshTest()
        {
            
            Assert.IsTrue(TestingUtils.refresh());
        }

        [TestMethod()]
        public void insertValidKey1()
        {
            int response = TestingUtils.insertEntry(new Key("SKDU12-123KJD-123-AFJEY",
                "Half Life",
                "Valve",
                "Steam",
                "https://store.steampowered.com/app/70/HalfLife/",
                "https://www.g2a.com/en-gb/half-life-steam-key-global-i10000032793003",
                "Global"));
            Assert.AreEqual(1, response);
        }

        [TestMethod()]
        public void insertValidKey2()
        {
            int response = TestingUtils.insertEntry(new Key("344U12-AWDJD-163-AFDDEY",
                "Stellaris",
                "Paradox Interactive",
                "Steam",
                "https://store.steampowered.com/app/281990/Stellaris/",
                "https://www.g2a.com/en-gb/stellaris-steam-key-global-i10000015386006",
                "Global"));
            Assert.AreEqual(1, response);
        }

        [TestMethod()]
        public void insertValidKey3()
        {
            int response = TestingUtils.insertEntry(new Key("86FG12-1VDEJD-123-AF3RY",
                "Grand Theft Auto 5",
                "Rockstar",
                "Steam",
                "https://store.steampowered.com/app/271590/Grand_Theft_Auto_V/",
                "https://www.g2a.com/en-gb/grand-theft-auto-v-rockstar-key-global-i10000000788017",
                "Global"));
            Assert.AreEqual(1, response);
        }

        [TestMethod()]
        public void insertValidKeyNullable1()
        {
            int response = TestingUtils.insertEntry(new Key("SVDSW2-1264JD-123-AFEWQ",
                "Counter Strike: Global Offensive",
                "Valve",
                "Steam",
                "",
                "",
                "Global"));
            Assert.AreEqual(1, response);
        }

        [TestMethod()]
        public void insertValidKeyNullable2()
        {
            int response = TestingUtils.insertEntry(new Key("SFRE2-BDFRJD-123-AFEWQ",
                "Final Fantasy XV",
                "Valve",
                "Steam",
                "",
                "",
                "Global"));
            Assert.AreEqual(1, response);
        }

        [TestMethod()]
        public void insertRepeatKey1()
        {
            int response = TestingUtils.insertEntry(new Key("SKDU12-123KJD-123-AFJEY",
                "RESIDENT EVIL 2",
                "Capcom",
                "Steam",
                "https://store.steampowered.com/app/883710/RESIDENT_EVIL_2__BIOHAZARD_RE2/",
                "https://www.g2a.com/en-gb/resident-evil-2-biohazard-re2-steam-key-global-i10000171870007",
                "Global"));
            Assert.AreEqual(0, response);
        }

        [TestMethod()]
        public void insertRepeatKey2()
        {
            int response = TestingUtils.insertEntry(new Key("SVDSW2-1264JD-123-AFEWQ",
                "Mortal Kombat 11",
                "Warner Bros",
                "Steam",
                "https://store.steampowered.com/app/976310/Mortal_Kombat11/",
                "https://www.g2a.com/en-gb/mortal-kombat-11-steam-key-global-i10000176931005",
                "Global"));
            Assert.AreEqual(0, response);
        }

        [TestMethod()]
        public void search1()
        {
            Assert.AreNotEqual(0, TestingUtils.searchTable("Counter Strike: Global Offensive", "product"));
        }

        [TestMethod()]
        public void search2()
        {
            Assert.AreNotEqual(0, TestingUtils.searchTable("SVDSW2-1264JD-123-AFEWQ", "cdkey"));
        }

        [TestMethod()]
        public void search3()
        {
            Assert.AreNotEqual(0, TestingUtils.searchTable("Steam", "distributor"));
        }

        [TestMethod()]
        public void search4()
        {
            Assert.AreNotEqual(0, TestingUtils.searchTable("Global", "region"));
        }

        [TestMethod()]
        public void search5()
        {
            Assert.AreNotEqual(0, TestingUtils.searchTable("https://store.steampowered.com/app/281990/Stellaris/", "steam_url"));
        }

        [TestMethod()]
        public void deleteAll()
        {
            Assert.AreNotEqual(0, TestingUtils.deleteAll());
        }

        [TestMethod()]
        public void modifyEntry1()
        {
            Key key = new Key("344U12-AWDJD-163-AFDDEY",
                "Stellaris",
                "Modified Interactive",
                "Steam",
                "https://store.steampowered.com/app/281990/Stellaris/",
                "https://www.g2a.com/en-gb/stellaris-steam-key-global-i10000015386006",
                "Global");
            Assert.AreNotEqual(0, TestingUtils.modifyEntry(key, key.cdkey));
        }

        [TestMethod()]
        public void modifyEntry2()
        {
            Key key = new Key("SFRE2-BDFRJD-123-AFEWQ",
                "Final Fantasy XV",
                "Valve",
                "Steam",
                "",
                "",
                "Global");
            Assert.AreNotEqual(0, TestingUtils.modifyEntry(key, key.cdkey));

        }

        [TestMethod()]
        public void deleteEntry1()
        {
            Assert.AreNotEqual(0,TestingUtils.deleteEntry("344U12-AWDJD-163-AFDDEY"));
        }

        [TestMethod()]
        public void deleteEntry2()
        {

            Assert.AreNotEqual(0, TestingUtils.deleteEntry("SVDSW2-1264JD-123-AFEWQ"));

        }

        [TestMethod()]
        public void deleteEntry3()
        {

            Assert.AreNotEqual(0, TestingUtils.deleteEntry("SKDU12-123KJD-123-AFJEY"));

        }
    }
}