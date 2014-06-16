using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PivotalTrackerDotNet.Domain;

namespace PivotalBackup {
    public class BackupData {
        public string BackupFilePath { get; set;  }
        public List<Story> Stories { get; set; }
        public Project Project { get; set; }

        public BackupData(Project project) {
            Project = project;
        }

        public void SetBackupFilePath() {
            var sanitisedName = Project.Name.Replace(" ", "_");
            var formattedDate = DateTime.Now;
            BackupFilePath = String.Format(@"D:\temp\pivotalBackup\{0}{1}.json", sanitisedName, formattedDate);
        }
    }
}
