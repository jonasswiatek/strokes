using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TemplateWizard;
using System.Windows.Forms;
using EnvDTE;
using VSLangProj80;

namespace Strokes.VsTemplate.Wizard
{
    public class ChallengeWizard : IWizard
    {
        private const string ChallengeAssemblyName = "Strokes.Challenges";
        private string _challengeAssemblyLocation;
        public void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {
            var assemblyLocation = GetType().Assembly.Location;
            var assemblyPath = Path.GetDirectoryName(assemblyLocation);
            if (string.IsNullOrEmpty(assemblyPath))
                return;

            var dir = new DirectoryInfo(assemblyPath);
            while(dir != null && !dir.GetFiles().Any(a => a.Name == ChallengeAssemblyName + ".dll"))
            {
                dir = dir.Parent;
            }

            if (dir == null)
                return;

            _challengeAssemblyLocation = Path.Combine(dir.FullName, ChallengeAssemblyName + ".dll");
            replacementsDictionary["$challengeassemblylocation$"] = _challengeAssemblyLocation;
        }

        public void ProjectFinishedGenerating(Project project)
        {
        }

        public void ProjectItemFinishedGenerating(ProjectItem projectItem)
        {
            var vsProject = projectItem.ContainingProject.Object as VSProject2;
            if (vsProject != null && vsProject.References.Find(ChallengeAssemblyName) == null)
            {
                vsProject.References.Add(_challengeAssemblyLocation);
            }
        }

        public bool ShouldAddProjectItem(string filePath)
        {
            return true;
        }

        public void BeforeOpeningFile(ProjectItem projectItem)
        {
        }

        public void RunFinished()
        {
        }
    }
}