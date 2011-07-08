using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using EnvDTE;
using Microsoft.VisualStudio.Shell.Interop;

namespace Strokes.VSX.Trackers
{
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

                return Path.Combine(new[] {
                                      projectFolder,
                                      outputPath
                                  });
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Gets all files within the passed solution that has been changed since the passed DateTime
        /// </summary>
        /// <param name="solution">Solution containing files</param>
        /// <param name="since">DateTime to limit to</param>
        /// <returns></returns>
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
                    if (item.Name.EndsWith(".cs"))
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

        private static List<string> GetDirtyFiles(string path, ProjectItem item)
        {
            var result = new List<string>();
            foreach (ProjectItem itm in item.ProjectItems)
            {
                if (itm.Name.EndsWith(".cs"))
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
