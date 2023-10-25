using System.IO;
using System.Xml.Linq;

namespace SZGC.Middleware.Constants.Routes
{
    public class BaseUrl
    {
        public string LoadBaseUrl()
        {
            if (File.Exists(FilePath.BASE_URL_PATH))
            {
                XDocument doc = XDocument.Load(FilePath.BASE_URL_PATH);
                XElement root = doc.Root;
                return root.Element("BaseUrl").Value;
            }
            else
            {
                if (!Directory.Exists(FilePath.BASE_URL_PATH))
                {
                    Directory.CreateDirectory(FilePath.PATH);
                }

                XDocument doc = new XDocument();

                XElement root = new XElement("Root");

                root.Add(new XElement("BaseUrl"));

                root.Element("BaseUrl").SetValue("https://localhost:44323/");

                doc.Save(FilePath.BASE_URL_PATH);

                return root.Element("BaseUrl").Value;
            }
        }
    }
}
