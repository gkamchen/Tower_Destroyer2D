using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Net.Sockets;
using System.Reflection;

namespace Base
{
    public class Message
    {
        private IDictionary<string, object> payloadMap;

        private Message(IDictionary<string, object> payloadMap)
        {
            this.payloadMap = payloadMap;
        }

        public int GetInt32(string propertyName)
        {
            return (int)this.payloadMap[propertyName];
        }

        public string GetString(string propertyName)
        {
            return (string)this.payloadMap[propertyName];
        }

        public static byte[] Serialize(dynamic payload)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                BinaryWriter binaryWriter = new BinaryWriter(memoryStream);

                PropertyInfo[] payloadProperties = payload.GetType().GetProperties() as PropertyInfo[];

                if (payloadProperties != null)
                {
                    binaryWriter.Write(payloadProperties.Length);

                    foreach (PropertyInfo payloadProperty in payloadProperties)
                    {
                        binaryWriter.Write(payloadProperty.PropertyType.Name);
                        binaryWriter.Write(payloadProperty.Name);
                        binaryWriter.Write(payloadProperty.GetValue(payload));
                    }
                }

                return memoryStream.ToArray();
            }
        }

        public static Message Deserialize(NetworkStream networkStream)
        {
            BinaryReader binaryReader = new BinaryReader(networkStream);

            int propertiesLength = binaryReader.ReadInt32();

            string propertyType;
            string propertyName;

            var payload = new ExpandoObject() as IDictionary<string, object>;

            for (int i = 0; i < propertiesLength; i++)
            {
                propertyType = binaryReader.ReadString();
                propertyName = binaryReader.ReadString();

                switch (propertyType)
                {
                    case "Int32":
                        payload.Add(propertyName, binaryReader.ReadInt32());
                        break;
                    case "String":
                        payload.Add(propertyName, binaryReader.ReadString());
                        break;
                }
            }

            return new Message(payload);
        }
    }
}
