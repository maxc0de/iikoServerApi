using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace iikoAPIServer.Helpers
{
  public static class XmlStorageHelper
  {
    public static void WriteToXmlFile<T>(string filePath, T objectToWrite, bool append = false) where T : new()
    {
      TextWriter textWriter1 = (TextWriter) null;
      try
      {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof (T));
        textWriter1 = (TextWriter) new StreamWriter(filePath, append);
        TextWriter textWriter2 = textWriter1;
        // ISSUE: variable of a boxed type
        xmlSerializer.Serialize(textWriter2, objectToWrite);
      }
      finally
      {
        textWriter1?.Close();
      }
    }

    public static T ReadFromXmlFile<T>(string filePath) where T : new()
    {
      TextReader textReader1 = (TextReader) null;
      try
      {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof (T));
        textReader1 = (TextReader) new StreamReader(filePath);
        TextReader textReader2 = textReader1;
        return (T) xmlSerializer.Deserialize(textReader2);
      }
      finally
      {
        textReader1?.Close();
      }
    }

    public static T ReadFromXmlString<T>(string filePath) where T : new()
    {
            XmlSerializer formatter = new XmlSerializer(typeof(T));

            T asd;
            using (Stream fs = new MemoryStream(Encoding.UTF8.GetBytes(filePath)))
            {
                asd = (T)formatter.Deserialize(fs);
            }

            return asd;
        }
    }
}
