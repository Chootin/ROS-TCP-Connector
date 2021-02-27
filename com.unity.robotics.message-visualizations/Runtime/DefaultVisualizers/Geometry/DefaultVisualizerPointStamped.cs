﻿using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;
using Unity.Robotics.ROSTCPConnector.ROSGeometry;
using UnityEngine;
using RosMessageTypes.Geometry;

namespace Unity.Robotics.MessageVisualizers
{
    public class DefaultVisualizerPointStamped : BasicVisualizer<MPointStamped>
    {
        [SerializeField]
        float m_Radius = 0.01f;

        public override void Draw(DebugDraw.Drawing drawing, MPointStamped message, MessageMetadata meta, Color color, string label)
        {
            MessageVisualizations.Draw<FLU>(drawing, message.point, color, label, m_Radius);
        }

        public override Action CreateGUI(MPointStamped message, MessageMetadata meta, DebugDraw.Drawing drawing) => () =>
        {
            MessageVisualizations.GUI(message.header);
            MessageVisualizations.GUI(message.point);
        };
    }
}