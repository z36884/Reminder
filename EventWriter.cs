using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

namespace Reminder
{
    class EventWriter
    {
        public static void SerializeToXML(List<EventClass> e)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<EventClass>));
            TextWriter textWriter = new StreamWriter(@".\event.xml");
            serializer.Serialize(textWriter, e);
            textWriter.Close();
        }
    }
}
