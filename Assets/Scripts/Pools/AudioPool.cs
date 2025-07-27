using UnityEngine;

public class AudioPool : ObjectPool<PlaySoundThenDisable>
{
    public void PlaySound(AudioDataSO data)
    {
        var sound = GetObject();
        data.SetData(sound.AudioSource);
        sound.gameObject.SetActive(true);
    }
}

