namespace Utility.Audio
{
    public interface IAudioVolumeChange
    {
        /// <summary>マスターボリューム変更</summary>
        void ChangeMasterVolume(float vol);
        /// <summary>BGMのボリューム変更</summary>
        void ChangeBGMVolume(float vol);
        /// <summary>SEのボリューム変更</summary>
        void ChangeSEVolume(float vol);
    }
}