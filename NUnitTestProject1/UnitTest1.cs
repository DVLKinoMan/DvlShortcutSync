using DvlShortcutSync.Domain;
using NUnit.Framework;

namespace NUnitTestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            FoldersWorker.Sync2Folders(@"F:\Films", @"C:\Users\DVL_KinoMan\Desktop\New folder");
        }
    }
}