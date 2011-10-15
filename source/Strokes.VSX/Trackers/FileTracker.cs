using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using EnvDTE;
using Microsoft.VisualStudio.Shell.Interop;

namespace Strokes.VSX.Trackers
{
    /// <summary>
    /// File Tracker for tracking file changes.
    /// </summary>
    public class FileTracker
    {
        /// <summary>
        /// Gets a projects build output directory 
        /// </summary>
        /// <param name="project">Project to determine output directory of</param>
        /// <returns></returns>
        public static string GetProjectOutputDirectory(Project project)
        {
            try
            {
                var projectFolder = Path.GetDirectoryName(project.FileName);
                var outputPath = (string)project.ConfigurationManager.ActiveConfiguration.Properties.Item("OutputPath").Value;
                var assemblyFileName = (string)project.Properties.Item("AssemblyName").Value;

                return Path.Combine(new[] { projectFolder, outputPath });
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Gets all files within the passed solution that has been changed since the passed DateTime.
        /// </summary>
        /// <param name="solution">Solution containing files</param>
        /// <param name="since">DateTime to limit to</param>
        /// <returns>A list of all changed files.</returns>
        public static List<string> GetChangedFiles(Solution solution, DateTime since)
        {
            var allFiles = new List<string>();
            foreach (Project project in solution.Projects)
            {
                if (string.IsNullOrEmpty(project.FileName))
                    continue;

                var rootPath = Path.GetDirectoryName(project.FileName);

                foreach (ProjectItem item in project.ProjectItems)
                {
                    if (item.Name.EndsWith(".cs") && !item.Name.EndsWith("AssemblyInfo.cs"))
                    {
                        allFiles.Add(Path.Combine(rootPath, item.Name));
                    }
                    else
                    {
                        allFiles.AddRange(GetDirtyFiles(Path.Combine(rootPath, item.Name), item));
                    }
                }
            }

            return allFiles.Where(a => File.GetLastWriteTime(a) > since).ToList();
        }

        public static List<string> GetFiles(Solution solution)
        {
            return GetChangedFiles(solution, DateTime.MinValue);
        }

        /// <summary>
        /// Gets the dirty files.
        /// </summary>
        /// <param name="path">The files path.</param>
        /// <param name="item">The Visual Studio project item.</param>
        /// <returns>A list of dirty files.</returns>
        private static List<string> GetDirtyFiles(string path, ProjectItem item)
        {
            var result = new List<string>();

            foreach (ProjectItem itm in item.ProjectItems)
            {
                if (itm.Name.EndsWith(".cs") && !itm.Name.EndsWith("AssemblyInfo.cs"))
                {
                    result.Add(Path.Combine(path, itm.Name));
                }
                else
                {
                    result.AddRange(GetDirtyFiles(Path.Combine(path, itm.Name), itm));
                }
            }

            return result;
        }
    }
}
