//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.Std
{
    public class MInt16 : Message
    {
        public const string RosMessageName = "std_msgs/Int16";

        public short data;

        public MInt16()
        {
            this.data = 0;
        }

        public MInt16(short data)
        {
            this.data = data;
        }
        public override List<byte[]> SerializationStatements()
        {
            var listOfSerializations = new List<byte[]>();
            listOfSerializations.Add(BitConverter.GetBytes(this.data));

            return listOfSerializations;
        }

        public override int Deserialize(byte[] data, int offset)
        {
            this.data = BitConverter.ToInt16(data, offset);
            offset += 2;

            return offset;
        }

        public override string ToString()
        {
            return "MInt16: " +
            "\ndata: " + data.ToString();
        }
    }
}