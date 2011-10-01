using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Strokes.Core;
using Strokes.BasicAchievements;
using Strokes.BasicAchievements.Achievements;

namespace AchievementLocalizor
{
    class Program
    {
        static void Main(string[] args)
        {
            var types = GetTypesWith<AchievementDescriptionAttribute>(false);

            var xml = new StringBuilder();

            foreach (var type in types)
            {
                var attributes = type.GetCustomAttributes(typeof(AchievementDescriptionAttribute), false)
                                     .Cast<AchievementDescriptionAttribute>();
                var attribute = attributes.FirstOrDefault();
                if (attribute != null)
                {
                    //var name = "<data name=\"{0}Name\" xml:space=\"preserve\">\r\n" +
                    //"    <value>{1}</value>\r\n" +
                    //"</data>\r\n";

                    //var desc = "<data name=\"{0}Description\" xml:space=\"preserve\">\r\n" +
                    //"    <value>{1}</value>\r\n" +
                    //"</data>\r\n";

                    //xml.AppendFormat(name, type.Name, attribute.AchievementTitle);
                    //xml.AppendFormat(desc, type.Name, attribute.AchievementDescription);

                    var csharp = "[AchievementDescription(\"@{0}Name\",\r\n" +
                                 "        AchievementDescription = \"@{0}Description\",\r\n" +
                                 "        AchievementCategory = \"{1}\"";

                    if (string.IsNullOrEmpty(attribute.Image) == false)
                    {
                        csharp += "\r\n    Image=\"" + attribute.Image + "\"";
                    }

                    csharp += ")]\r\n\r\n";

                    xml.AppendFormat(csharp, type.Name, attribute.AchievementCategoryIdentifier);
                }
            }
            
            System.IO.File.WriteAllText("output.cs", xml.ToString());

            Console.WriteLine("Done!");
            Console.Read();
        }

        static IEnumerable<Type> GetTypesWith<TAttribute>(bool inherit)
            where TAttribute : Attribute
        {
            return 
                from type in Assembly.GetAssembly(typeof(DeclareInitArrayAchievement)).GetTypes()
                where type.IsDefined(typeof(TAttribute), inherit)
                select type;
        }
    }
}
