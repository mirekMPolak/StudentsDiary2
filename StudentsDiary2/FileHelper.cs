using System.IO;
using System.Xml.Serialization;

namespace StudentsDiary
{
    public class FileHelper<T> where T : new()
    {
        
        private readonly string _filePath;

        public FileHelper(string filePath)
        {
            _filePath = filePath;
        }
        
        public void SerializeToFile(T collectionName)
        {
            var serializer = new XmlSerializer(typeof(T));

            using (var streamWriter = new StreamWriter(_filePath))
            {
                serializer.Serialize(streamWriter, collectionName);
                streamWriter.Close();
            }
        }

        public T DeserializeFromFile()
        {
            if (!File.Exists(_filePath))
            {
                return new T();
            }
            var serializer = new XmlSerializer(typeof(T));

            using (var streamReader = new StreamReader(_filePath))
            {
                var collectionName = (T)serializer.Deserialize(streamReader);
                streamReader.Close();
                return collectionName;
            }
        }
    }
}
