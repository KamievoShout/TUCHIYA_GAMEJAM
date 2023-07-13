namespace Utility.Audio
{
    public interface IPlayAudio
    {
        /// <summary>SE再生 </summary>
        /// <param name="name">クリップ名</param>
        /// <param name="volume">ボリューム0～1</param>
        void PlaySE(string name, float volume = 1);

        /// <summary>BGM再生</summary>
        /// <param name="name">クリップ名</param>
        void PlayBGM(string name);

        /// <summary>BGM再生</summary>
        /// <param name="name">クリップ名</param>
        /// <param name="time">フェードにかかる時間</param>
        void PlayBGMFade(string name, float time);
    }
}