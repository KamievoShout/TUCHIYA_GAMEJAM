using System;
using UnityEngine;

namespace Utility.Audio
{
    public class AudioDatas : ScriptableObject
    {
        [SerializeField] AudioData[] datas = null;

        public AudioData[] Clips => datas;

        public AudioData GetData(string dataName)
        {
            foreach (AudioData d in datas)
            {
                if (d.Name.Equals(dataName))
                    return d;
            }
            Debug.Log("[" + dataName + "]というオーディオデータは存在しません");
            return null;
        }
    }

    [Serializable]
    public class AudioData
    {
        [SerializeField] string name = null;
        [SerializeField] AudioClip clip = null;

        public string Name => name;
        public AudioClip Clip => clip;
    }
}