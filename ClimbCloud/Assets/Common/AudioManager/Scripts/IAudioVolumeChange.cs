namespace Utility.Audio
{
    public interface IAudioVolumeChange
    {
        /// <summary>�}�X�^�[�{�����[���ύX</summary>
        void ChangeMasterVolume(float vol);
        /// <summary>BGM�̃{�����[���ύX</summary>
        void ChangeBGMVolume(float vol);
        /// <summary>SE�̃{�����[���ύX</summary>
        void ChangeSEVolume(float vol);
    }
}