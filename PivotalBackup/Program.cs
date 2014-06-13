using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using PivotalTrackerDotNet;
using PivotalTrackerDotNet.Domain;

namespace PivotalBackup {
    class Program {
        static readonly string PivotalAuthToken = GetPivotalAuthToken();
        private static StoryService myStoryService;

        static void Main(string[] args) {
            myStoryService = new StoryService(GetPivotalAuthToken());
            var projectsToBackup = GetProjectsToBackup();

            // serialize http://james.newtonking.com/json/help/index.html
        }

       static string GetPivotalAuthToken() {
            return File.ReadAllText("token.txt"); ;
        }

        static Project GetProject(int projectId) {
            return (new ProjectService(PivotalAuthToken).GetProjects().Single(p => p.Id == projectId));
        }

        private static IEnumerable<int> GetProjectsToBackupIds() {
            // http://stacktoheap.com/blog/2013/01/20/using-typeconverters-to-get-appsettings-in-net/
            return new List<int>() {
                Convert.ToInt32(ConfigurationManager.AppSettings["myWorkBacklogID"]),
                Convert.ToInt32(ConfigurationManager.AppSettings["homeBacklogID"])
            };
        }

        //private void GetAndBackupStories(int projectId) {
        //    var stories = storyService.GetAllStories(projectId, 6, 0);
        //    foreach (var story in stories) {
        //        var foo = story.ToJson();
        //        var tasks = storyService.GetTasksForStory(projectId, story);

        //    }
        //}

        private static IEnumerable<Project> GetProjectsToBackup() {
            var projectToBackupIds = GetProjectsToBackupIds();
            return projectToBackupIds.Select(GetProject).ToList();
        }

        //public void CreateBackup() {
        //    var projectToBackupIds = GetProjectsToBackupIds();
        //    foreach (var projectToBackupId in projectToBackupIds) {
        //        this.GetAndBackupStories(projectToBackupId);
        //    }


        //    return this.View("CreateBackup");
        //}
    }
}
