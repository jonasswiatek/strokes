using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Strokes.Data
{
    public abstract class AppDataXmlFileRepositoryBase<T> 
        where T : class
    {
        protected string StorageDirectory = "Strokes for Visual Studio";
        protected string StorageFile;

        protected AppDataXmlFileRepositoryBase(string storageFile)
        {
            StorageFile = storageFile;
        }

        private string GetStorageFile()
        {
            var userDataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var appDir = Path.Combine(userDataDir, StorageDirectory);

            if (!Directory.Exists(appDir))
                Directory.CreateDirectory(appDir);

            return Path.Combine(appDir, StorageFile);
        }

        protected T Load()
        {
            var filename = GetStorageFile();

            if (!File.Exists(filename))
                return default(T);

            using (var file = File.Open(filename, FileMode.OpenOrCreate))
            {
                if (file.Length <= 0)
                    return default(T);

                var serializer = new XmlSerializer(typeof(T));
                var data = (T)serializer.Deserialize(file);

                return data;
            }
        }

        protected void Save(T data)
        {
            var filename = GetStorageFile();

            using (var file = File.Open(filename, FileMode.Create))
            {
                var serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(file, data);
            }
        }

        protected void Erase()
        {
            var filename = GetStorageFile();

            if (File.Exists(filename))
                File.Delete(filename);
        }
    }
}
