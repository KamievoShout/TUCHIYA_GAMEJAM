using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class RecordedObjectData
{
    public List<FrameData> frames;

    public RecordedObjectData()
    {
        frames = new List<FrameData>();
    }
}

[Serializable]
public struct FrameData
{
    public int frameCount;
    public ObjectData objectData;

    public FrameData(int frameCount,ObjectData objectData)
    {
        this.frameCount = frameCount;
        this.objectData = objectData;
    }
}

[Serializable]
public struct ObjectData
{
    public Vector3 position;
    public float direction;
    public string animationName;

    public ObjectData(Vector3 position, float direction, string animationName)
    {
        this.position = position;
        this.direction = direction;
        this.animationName = animationName;
    }
}