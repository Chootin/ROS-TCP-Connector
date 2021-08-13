using RosMessageTypes.Std;
using System;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;
using UnityEngine;

namespace Unity.Robotics.MessageVisualizers
{
    public abstract class TextureVisualFactory<T> : MonoBehaviour, IVisualFactory, IPriority
        where T : Message
    {
        [SerializeField]
        protected string m_Topic;

        public virtual void Start()
        {
            if (m_Topic == "")
            {
                VisualFactoryRegistry.RegisterTypeVisualizer<T>(this, Priority);
            }
            else
            {
                VisualFactoryRegistry.RegisterTopicVisualizer(m_Topic, this, Priority);
            }
        }

        public int Priority { get; set; }
        public bool CanShowDrawing => false;

        public IVisual CreateVisual()
        {
            return new TextureVisual<T>(this);
        }

        public abstract Texture2D CreateTexture(T message);

        public virtual Action CreateGUI(T message, MessageMetadata meta, Texture2D tex)
        {
            return MessageVisualizationUtils.CreateDefaultGUI(message, meta);
        }
    }
}
