using System.Collections.Generic;
using UnityEngine;

class Recorder : MonoBehaviour
{
    [SerializeField]
    RecordedObjectsData LogData;
    [SerializeField]
    int frameInterval = 4;

    bool isLogging = false;
    public bool IsLogging => isLogging;
    GameObject loggingObject;
    RecordedObjectsData loadedData;
    Animator animator;

    bool isLoaded = false;
    public bool IsLoaded => isLoaded;
    int initIndex = 0;
    int currentIndex;
    GameObject applyObject;
    Animator targetAnimator;

    int frameCount = 0;


    private void FixedUpdate()
    {
        frameCount += 1;

        if (isLogging)
        {
            if (frameCount % frameInterval == 0)
            {
                FrameData frame = new FrameData();
                frame.frameTime = frameCount;

                ObjectPoseData pose = new ObjectPoseData();
                // 座標の保存
                pose.position = loggingObject.transform.position;
                // 向き
                pose.direction = loggingObject.transform.localScale.x;
                // アニメーションの名前を保存
                AnimatorClipInfo[] clipInfo = targetAnimator.GetCurrentAnimatorClipInfo(0);
                string clipName = clipInfo[0].clip.name;
                pose.animationName = clipName;

                frame.objectPose = pose;
                LogData.frames.Add(frame);
            }
        }

        if (isLoaded)
        {
            if (currentIndex > loadedData.frames.Count) return;

            ObjectPoseData pose = loadedData.frames[currentIndex].objectPose;
            // 座標を適用
            applyObject.transform.localPosition = pose.position;
            // 向き
            applyObject.transform.localScale =
                new Vector3(pose.direction,
                            applyObject.transform.localScale.y,
                            applyObject.transform.localScale.z);
            // アニメーションを設定
            AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
            string clipName = clipInfo[0].clip.name;
            if (pose.animationName != clipName)
            {
                animator.CrossFadeInFixedTime(pose.animationName, 0);
            }
            // 最後まで読み込んだら終了
            if (currentIndex == loadedData.frames.Count - 1) return;

            if (frameCount <= loadedData.frames[currentIndex + 1].frameTime) return;
            currentIndex++;
        }

    }

    public void StartRecord(GameObject target)
    {
        LogData = new RecordedObjectsData();
        LogData.frames = new List<FrameData>();
        loggingObject = target;
        targetAnimator = loggingObject.GetComponent<Animator>();

        FrameData frame = new FrameData();
        frame.frameTime = frameCount;

        ObjectPoseData pose = new ObjectPoseData();
        // 座標の保存
        pose.position = loggingObject.transform.position;
        // アニメーションの名前を保存
        AnimatorClipInfo[] clipInfo = targetAnimator.GetCurrentAnimatorClipInfo(0);
        string clipName = clipInfo[0].clip.name;
        pose.animationName = clipName;

        frame.objectPose = pose;
        LogData.frames.Add(frame);

        isLogging = true;
    }

    public void EndRecord()
    {
        isLogging = false;
        JsonFileManager.Save(LogData);
    }

    public void StartLoadLog(GameObject targetObject)
    {
        RecordedObjectsData data = JsonFileManager.Load();
        loadedData = data;
        Debug.Log($"{loadedData}:{targetObject}");
        targetObject.SetActive(loadedData.frames.Count != 0);
        if (loadedData.frames.Count == 0) return;
        applyObject = targetObject;
        currentIndex = initIndex;
        animator = applyObject.GetComponent<Animator>();
        isLoaded = true;
    }

    public void StopLoadLog()
    {
        isLoaded = false;
    }
}