using System.Collections.Generic;
using UnityEngine;

class Recorder : MonoBehaviour
{
    [SerializeField]
    RecordedObjectData LogData;
    [SerializeField]
    int frameInterval = 4;

    int frameCount = 0;

    bool isLogging = false;
    public bool IsLogging => isLogging;
    GameObject loggingObject;
    RecordedObjectData loadedData;
    Animator animator;

    bool isLoaded = false;
    public bool IsLoaded => isLoaded;
    int initIndex = 0;
    int currentIndex;
    GameObject applyObject;
    Animator targetAnimator;

    private void FixedUpdate()
    {
        frameCount += 1;

        if (isLogging)
        {
            // 指定したフレーム毎に座標と向きとアニメーションを保存
            if (frameCount % frameInterval == 0)
            {
                // 座標
                Vector3 position = loggingObject.transform.position;
                // 向き
                float direction = loggingObject.transform.localScale.x;
                // アニメーションの名前
                AnimatorClipInfo[] clipInfo = targetAnimator.GetCurrentAnimatorClipInfo(0);
                string animationName = clipInfo[0].clip.name;

                ObjectData objectDate = new ObjectData(position, direction, animationName);
                FrameData frame = new FrameData(frameCount, objectDate);
                LogData.frames.Add(frame);
            }
        }

        if (isLoaded)
        {
            if (currentIndex > loadedData.frames.Count) return;

            ObjectData objectDate = loadedData.frames[currentIndex].objectData;

            // 座標を適用
            applyObject.transform.localPosition = objectDate.position;
            // 向き
            applyObject.transform.localScale =
                new Vector3(objectDate.direction,
                            applyObject.transform.localScale.y,
                            applyObject.transform.localScale.z);
            // アニメーションを設定
            AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
            string clipName = clipInfo[0].clip.name;
            // 同じアニメーションの時は変えない
            if (objectDate.animationName != clipName)
            {
                animator.CrossFadeInFixedTime(objectDate.animationName, 0);
            }

            // 最後まで読み込んだら終了
            if (currentIndex == loadedData.frames.Count - 1) return;
            // 次の保存フレームの時間まで待機
            if (frameCount <= loadedData.frames[currentIndex + 1].frameCount) return;
            currentIndex++;
        }
    }

    public void StartRecord(GameObject target)
    {
        LogData = new RecordedObjectData();
        loggingObject = target;
        targetAnimator = loggingObject.GetComponent<Animator>();

        FrameData frame = new FrameData();
        frame.frameCount = frameCount;

        ObjectData pose = new ObjectData();
        // 座標の保存
        pose.position = loggingObject.transform.position;
        // アニメーションの名前を保存
        AnimatorClipInfo[] clipInfo = targetAnimator.GetCurrentAnimatorClipInfo(0);
        string clipName = clipInfo[0].clip.name;
        pose.animationName = clipName;

        frame.objectData = pose;
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
        // データの読み込み
        RecordedObjectData data = JsonFileManager.Load();
        loadedData = data;

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