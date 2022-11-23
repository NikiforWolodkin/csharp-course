using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lab_13
{
    public interface ISerialize<T>
    {
        void SerializeBinary(T obj);
        void SerializeSOAP(T obj);
        void SerializeJSON(T obj);
        void SerializeXML(T obj);
        T Deserialize();
    }

    public class Serializer<T> : ISerialize<T>
    {
        public string SerializationPath { get; set; }
        private Formats _format { get; set; }
        private IFormatter _formatter { get; set; }
        private XmlSerializer _XMLSerializer { get; set; }
        private XmlSerializer _SOAPSerializer { get; set; }

        public Serializer(string serializationPath)
        {
            SerializationPath = serializationPath;

            _format = Formats.None;

            _formatter = new BinaryFormatter();

            _XMLSerializer = new XmlSerializer(typeof(T));

            XmlTypeMapping typeMapping = new SoapReflectionImporter().ImportTypeMapping(typeof(T));
            _SOAPSerializer = new XmlSerializer(typeMapping);
        }

        enum Formats
        {
            None,
            Binary,
            SOAP,
            JSON,
            XML
        }

        void ISerialize<T>.SerializeBinary(T obj)
        {
            using (FileStream fstream = new FileStream(SerializationPath, FileMode.OpenOrCreate))
            {
                _formatter.Serialize(fstream, obj);
            }
            _format = Formats.Binary;
        }

        void ISerialize<T>.SerializeSOAP(T obj)
        {
            using (FileStream fstream = new FileStream(SerializationPath, FileMode.OpenOrCreate))
            {
                _SOAPSerializer.Serialize(fstream, obj);
            }
            _format = Formats.SOAP;
        }

        void ISerialize<T>.SerializeJSON(T obj)
        {
            string json = JsonSerializer.Serialize(obj);
            File.WriteAllText(SerializationPath, json);
            _format = Formats.JSON;
        }

        void ISerialize<T>.SerializeXML(T obj)
        {
            using (FileStream fstream = new FileStream(SerializationPath, FileMode.OpenOrCreate))
            {
                _XMLSerializer.Serialize(fstream, obj);
            }
            _format = Formats.XML;
        }

        T ISerialize<T>.Deserialize()
        {
            switch (_format)
            {
                case Formats.Binary:
                    using (FileStream fstream = new FileStream(SerializationPath, FileMode.OpenOrCreate))
                    {
                        return (T)_formatter.Deserialize(fstream);
                    }
                    break;
                case Formats.SOAP:
                    using (FileStream fstream = new FileStream(SerializationPath, FileMode.OpenOrCreate))
                    {
                        return (T)_SOAPSerializer.Deserialize(fstream);
                    }
                    break;
                case Formats.JSON:
                    return JsonSerializer.Deserialize<T>(File.ReadAllText(SerializationPath));
                    break;
                case Formats.XML:
                    using (FileStream fstream = new FileStream(SerializationPath, FileMode.OpenOrCreate))
                    {
                        return (T)_XMLSerializer.Deserialize(fstream);
                    }
                    break;
            }

            return default(T);
        }
    }
}
