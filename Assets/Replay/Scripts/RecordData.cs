using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class RecordedObjectsData
{
    public List<FrameData> frames;
}

[Serializable]
public struct FrameData
{
    public int frameTime;
    public ObjectPoseData objectPose;
}

[Serializable]
public struct ObjectPoseData
{
    public Vector3 position;
    public float direction;
    public string animationName;
}