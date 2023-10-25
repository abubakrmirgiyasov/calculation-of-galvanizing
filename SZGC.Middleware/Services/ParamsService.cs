using System.IO;
using System.Xml.Linq;
using SZGC.Infrastructure.Cryptography;
using SZGC.Middleware.Constants;
using SZGC.Middleware.Services.Interfaces;

namespace SZGC.Middleware.Services
{
    public class ParamsService : IParamsService
    {
        public void Load()
        {
            if (File.Exists(FilePath.AUTH_PATH))
            {
                XDocument doc = XDocument.Load(FilePath.AUTH_PATH);
                XElement root = doc.Root;

                Params.RefreshToken = new RFC().Encrypt(root.Element("RefreshToken").Value, root.Element("Salt").Value);
            }
        }

        public void Save(string token, string salt = null)
        {
            XDocument doc;
            XElement root;

            if (!File.Exists(FilePath.AUTH_PATH))
            {
                if (!Directory.Exists(FilePath.PATH))
                {
                    Directory.CreateDirectory(FilePath.PATH);
                }

                doc = new XDocument();

                root = new XElement("Root");

                root.Add(new XElement("RefreshToken"));
                root.Add(new XElement("Salt"));
            }
            else
            {
                doc = XDocument.Load(FilePath.AUTH_PATH);
                root = doc.Root;
            }

            if (salt != null)
            {
                root.Element("Salt").SetValue(salt);
            }

            Params.RefreshToken = new RFC().Encrypt(token, root.Element("Salt").Value);

            root.Element("RefreshToken").SetValue(token);

            doc.Save(FilePath.AUTH_PATH);
        }
    }
}
