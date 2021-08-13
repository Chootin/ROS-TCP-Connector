using System;
using RosMessageTypes.Geometry;
using Unity.Robotics.MessageVisualizers;
using Unity.Robotics.ROSTCPConnector.ROSGeometry;
using UnityEngine;

public class DefaultVisualizerPose : DrawingVisualFactory<PoseMsg>
{
    [SerializeField]
    float m_Size = 0.1f;
    [SerializeField]
    [Tooltip("If ticked, draw the axis lines for Unity coordinates. Otherwise, draw the axis lines for ROS coordinates (FLU).")]
    bool m_DrawUnityAxes;

    public override void Draw(BasicDrawing drawing, PoseMsg message, MessageMetadata meta)
    {
        Draw<FLU>(message, drawing, m_Size, m_DrawUnityAxes);
    }

    public static void Draw<C>(PoseMsg message, BasicDrawing drawing, float size = 0.1f, bool drawUnityAxes = false)
        where C : ICoordinateSpace, new()
    {
        MessageVisualizationUtils.DrawAxisVectors<C>(
            drawing,
            new Vector3Msg(message.position.x, message.position.y, message.position.z),
            message.orientation,
            size,
            drawUnityAxes
        );
    }

    public override Action CreateGUI(PoseMsg message, MessageMetadata meta)
    {
        return () =>
        {
            message.GUI();
        };
    }
}
