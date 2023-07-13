namespace Utility.Audio
{
    public interface IGetAudioVolume
    {
        /// <summary>マスターボリューム取得</summary>
        float GetMasterVolume();
        /// <summary>BGMのボリューム取得</summary>
        float GetBGMVolume();
        /// <summary>SEのボリューム取得</summary>
        float GetSEVolume();
    }
}