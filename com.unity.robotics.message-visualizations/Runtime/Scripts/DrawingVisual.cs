using RosMessageTypes.Std;
using System;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;
using UnityEngine;

namespace Unity.Robotics.MessageVisualizers
{
    public class DrawingVisual<T> : IVisual
        where T : Message
    {
        public T message { get; private set; }
        public MessageMetadata meta { get; private set; }

        BasicDrawing m_BasicDrawing;
        Action m_GUIAction;
        DrawingVisualFactory<T> m_Factory;

        public DrawingVisual(DrawingVisualFactory<T> factory)
        {
            m_Factory = factory;
        }

        public void NewMessage(Message message, MessageMetadata meta)
        {
            if (!MessageVisualizationUtils.AssertMessageType<T>(message, meta))
                return;

            this.message = (T)message;
            this.meta = meta;
            m_GUIAction = null;
        }

        public bool hasDrawing => m_BasicDrawing != null;
        public bool hasAction => m_GUIAction != null;

        public void OnGUI()
        {
            if (m_GUIAction == null)
            {
                m_GUIAction = m_Factory.CreateGUI(message, meta);
            }
            m_GUIAction();
        }

        public void DeleteDrawing()
        {
            if (m_BasicDrawing != null)
            {
                m_BasicDrawing.Destroy();
            }

            m_BasicDrawing = null;
        }

        public void CreateDrawing()
        {
            if (m_BasicDrawing == null)
            {
                m_BasicDrawing = BasicDrawingManager.CreateDrawing();
            }
            else
            {
                m_BasicDrawing.Clear();
            }

            m_Factory.Draw(m_BasicDrawing, message, meta);
        }
    }
}
