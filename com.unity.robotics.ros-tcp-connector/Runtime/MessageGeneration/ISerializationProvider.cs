using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.Robotics.ROSTCPConnector.MessageGeneration
{
    public interface ISerializationProvider
    {
        IMessageSerializer CreateSerializer();
        IMessageDeserializer CreateDeserializer();
    }
}
