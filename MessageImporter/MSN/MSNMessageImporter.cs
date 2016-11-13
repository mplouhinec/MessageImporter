using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MessageImporter.MSN
{
    public static class MSNMessageImporter
    {

        public static IList<Message> LoadMessagesFromFile(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException("path");

            if (!File.Exists(path))
                throw new FileNotFoundException("File not found", "path");

            XElement rootElement = XElement.Load(path);
            IEnumerable<Message> messagesXML = from el in rootElement.Elements("Message")
                                               select new Message()
                                               {
                                                   Sender = el.Element("From").Element("User").Attribute("FriendlyName").Value,
                                                   Recipient = el.Element("To").Element("User").Attribute("FriendlyName").Value,
                                                   Date = DateTime.Parse(el.Attribute("DateTime").Value),
                                                   Content = el.Element("Text").Value
                                               };

            return messagesXML.ToList();

        }

        public static IList<Message> LoadMessagesFromFiles(string[] files)
        {
            if (files == null)
                throw new ArgumentNullException("files");

            IList<Message> messages = new List<Message>();

            foreach(var file in files)
            {
                var messagesOfFile = LoadMessagesFromFile(file);
                foreach(var message in messagesOfFile)
                {
                    messages.Add(message);
                }
            }

            return messages;
        }

    }
}
