using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

namespace Reminder
{
    public class EventReader
    {
        public static List<EventClass> DeserializeFromXML()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(List<EventClass>));
            TextReader textReader = new StreamReader(@".\event.xml");
            List<EventClass> elist;
            elist = (List<EventClass>)deserializer.Deserialize(textReader);
            textReader.Close();

            return elist;
        }
    }
}
