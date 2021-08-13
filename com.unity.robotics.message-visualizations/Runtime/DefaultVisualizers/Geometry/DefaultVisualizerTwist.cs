using System;
using RosMessageTypes.Geometry;
using Unity.Robotics.ROSTCPConnector.ROSGeometry;
using UnityEngine;

namespace Unity.Robotics.MessageVisualizers
{
    public class DefaultVisualizerTwist : DrawingVisualFactory<TwistMsg>
    {
        public float thickness = 0.01f;
        public float lengthScale = 1.0f;
        public float sphereRadius = 1.0f;
        public GameObject origin;
        [SerializeField]
        Color m_Color;

        public override void Draw(BasicDrawing drawing, TwistMsg message, MessageMetadata meta)
        {
            var orig = origin == null ? Vector3.zero : origin.transform.position;
            Draw<FLU>(message, drawing, SelectColor(m_Color, meta), orig, lengthScale, sphereRadius, thickness);
        }

        public static void Draw<C>(TwistMsg message, BasicDrawing drawing, Color color, Vector3 origin, float lengthScale = 1, float sphereRadius = 1, float thickness = 0.01f) where C : ICoordinateSpace, new()
        {
            drawing.DrawArrow(origin, origin + message.linear.From<C>() * lengthScale, color, thickness);
            MessageVisualizationUtils.DrawAngularVelocityArrow(drawing, message.angular.From<C>(), origin, color, sphereRadius, thickness);
        }

        public override Action CreateGUI(TwistMsg message, MessageMetadata meta) => () =>
        {
            message.GUI();
        };
    }
}
