using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using PivotalTrackerDotNet.Domain;

namespace PivotalBackup.Test {
    [TestFixture]
    public class BackupDataTests {
        private BackupData ed;
        private Project p;

        [SetUp]
        public void SetUp() {
            p = new Project();
            ed = new BackupData(p);
        }
    }
}
