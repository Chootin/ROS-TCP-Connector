﻿using RosMessageTypes.Std;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Robotics.MessageVisualizers;
using UnityEngine;

public class DefaultVisualizerTime : BasicVisualizer<MTime>
{
    public override Action CreateGUI(MTime message, MessageMetadata meta, DebugDraw.Drawing drawing) => () =>
    {
        message.GUI();
    };
}