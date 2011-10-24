using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Strokes.GUI.ViewModels
{
    public class LocalizationViewModel
    {
        public ObservableCollection<CultureInfoDto> AvailableCultures { get; set; }

        public LocalizationViewModel()
        {
            AvailableCultures = new ObservableCollection<CultureInfoDto>();
            AvailableCultures.Add(new CultureInfoDto()
                                      {
                                          CultureKey = string.Empty,
                                          DisplayName = "Default (English)"
                                      });

            var assembly = GetType().Assembly;
            var path = Path.GetDirectoryName(assembly.Location);

            foreach (var dir in Directory.GetDirectories(path))
            {
                try
                {
                    var dirinfo = new DirectoryInfo(dir);
                    var tCulture = CultureInfo.GetCultureInfo(dirinfo.Name);

                    AvailableCultures.Add(new CultureInfoDto
                                              {
                                                  DisplayName = tCulture.DisplayName,
                                                  CultureKey = tCulture.Name
                                              });
                }
                catch
                {
                    //Ignored. This will throw when we traverse into a directory that doesn't contain actual culture infos.
                }
            }
        }
    }

    public class CultureInfoDto
    {
        public string DisplayName { get; set; }
        public string CultureKey { get; set; }
    }
}
