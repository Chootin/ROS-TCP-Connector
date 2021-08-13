using RosMessageTypes.Std;
using System;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;
using UnityEngine;

namespace Unity.Robotics.MessageVisualizers
{
    public abstract class DrawingVisualFactory<T> : MonoBehaviour, IVisualFactory, IPriority
        where T : Message
    {
        [SerializeField]
        string m_Topic;
        public string Topic { get => m_Topic; set => m_Topic = value; }

        public virtual void Start()
        {
            if (string.IsNullOrEmpty(m_Topic))
            {
                VisualFactoryRegistry.RegisterTypeVisualizer<T>(this, Priority);
            }
            else
            {
                VisualFactoryRegistry.RegisterTopicVisualizer(m_Topic, this, Priority);
            }
        }

        public int Priority { get; set; }

        public bool CanShowDrawing => true;

        public virtual IVisual CreateVisual()
        {
            return new DrawingVisual<T>(this);
        }

        public Color SelectColor(Color userColor, MessageMetadata meta)
        {
            return MessageVisualizationUtils.SelectColor(userColor, meta);
        }

        public string SelectLabel(string userLabel, MessageMetadata meta)
        {
            return MessageVisualizationUtils.SelectLabel(userLabel, meta);
        }

        public virtual void Draw(BasicDrawing drawing, T message, MessageMetadata meta) { }

        public virtual Action CreateGUI(T message, MessageMetadata meta)
        {
            return MessageVisualizationUtils.CreateDefaultGUI(message, meta);
        }
    }
}
