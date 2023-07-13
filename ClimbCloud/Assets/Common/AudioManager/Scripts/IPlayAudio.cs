namespace Utility.Audio
{
    public interface IPlayAudio
    {
        /// <summary>SE�Đ� </summary>
        /// <param name="name">�N���b�v��</param>
        /// <param name="volume">�{�����[��0�`1</param>
        void PlaySE(string name, float volume = 1);

        /// <summary>BGM�Đ�</summary>
        /// <param name="name">�N���b�v��</param>
        void PlayBGM(string name);

        /// <summary>BGM�Đ�</summary>
        /// <param name="name">�N���b�v��</param>
        /// <param name="time">�t�F�[�h�ɂ����鎞��</param>
        void PlayBGMFade(string name, float time);
    }
}