using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace RustyBoffin.HarmonySite.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IConnection connection = new DummyConnection();
            HSSession session = new HSSession(connection);
            DummyObject1 d1 = session.GetValue<DummyObject1>(1);
            Assert.AreEqual(d1.Number, 42);
            Assert.AreEqual(d1.Text, "Hello");
            Assert.AreEqual(d1.Bool, true);
            Assert.AreEqual(d1.Date, DateTime.Parse("2020-02-19"));
            Assert.AreEqual(d1.Dummy2.Number, 37);
            Assert.AreEqual(d1.Dummy2.Text, "World");
            Assert.AreEqual(d1.Dummy2.Bool, false);
            Assert.AreEqual(d1.Dummy2.Date, DateTime.Parse("1961-02-19"));
            Assert.AreEqual(d1.Dummy2.Dummy1, d1);
            Assert.AreEqual(d1.Colour.ToArgb(), Color.CornflowerBlue.ToArgb());
            DummyObject2 d2 = d1.DummyList.FirstOrDefault();
            Assert.AreEqual(d2, d1.Dummy2);
            Assert.AreEqual(d1.NumberList.Count(), 3);
        }
    }

    internal class DummyConnection : IConnection
    {
        public DummyConnection()
        {
        }

        public async Task<Dictionary<int, Dictionary<string, string>>> QueryAsync(string table, string filter, int id)
        {
            Dictionary<int, Dictionary<string, string>> result = new Dictionary<int, Dictionary<string, string>>();
            Dictionary<string, string> data = null;
            if (table == "table1")
                data = DummyObject1.Data;
            if (table == "table2")
                data = DummyObject2.Data;

            if (filter == "")
                result.Add(id, data);
            else
            {
                string s = data[filter];
                string sid = id.ToString();
                if (s == sid)
                    result.Add(id, data);
            }
            return result;
        }

        public Dictionary<int, Dictionary<string, string>> Query(string table, string filter, int id)
        {
            return QueryAsync(table, filter, id).GetAwaiter().GetResult();
        }
    }

    [HSTable("table1")]
    public class DummyObject1: HSObject
    {
        public int Number => GetValue(() => Number);
        public string Text => GetValue(() => Text);
        public bool Bool => GetValue(() => Bool);
        public DateTime Date => GetValue(() => Date);
        public Color Colour => GetValue(() => Colour);
        public DummyObject2 Dummy2 => GetValue(() => Dummy2);
        public HSCollection<int> NumberList => GetValues(() => NumberList);
        [HSFilter(nameof(DummyObject2.Dummy1))]
        public HSCollection<DummyObject2> DummyList => GetValues(() => DummyList);

        internal DummyObject1(HSSession session)
            : base(session)
        {
        }

        static internal Dictionary<string, string> Data = new Dictionary<string, string>()
        {
            {"id","1"},
            {"Number","42"},
            {"Text","Hello"},
            {"Bool","Yes"},
            {"Date","2020-02-19"},
            {"Colour","#6495ED"}, // cornflowerblue
            {"Dummy2","1"},
            {"NumberList", "1 2 3" },
            {"stamp","2018-07-16 00:46:57"},
        };
    }

    [HSTable("table2")]
    public  class DummyObject2 : HSObject
    {
        public int Number => GetValue(() => Number);
        public string Text => GetValue(() => Text);
        public bool Bool => GetValue(() => Bool);
        public DateTime Date => GetValue(() => Date);
        public DummyObject1 Dummy1 => GetValue(() => Dummy1);

        static internal Dictionary<string, string> Data = new Dictionary<string, string>()
        {
            {"id","1"},
            {"Number","37"},
            {"Text","World"},
            {"Bool","No"},
            {"Date","1961-02-19"},
            {"Dummy1","1"},
            {"stamp","2018-07-16 00:46:57"},
        };

        internal DummyObject2(HSSession session)
            : base(session)
        {

        }
    }
}
