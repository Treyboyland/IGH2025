using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioDataSO-", menuName = "Scriptable Objects/AudioDataSO")]
public class AudioDataSO : ScriptableObject
{
    [SerializeField]
    List<AudioClip> clips;

    [SerializeField]
    Vector2 volumeRange;

    [SerializeField]
    Vector2 pitchRange;

    public void SetData(AudioSource source)
    {
        source.clip = clips.GetRandomItem();
        source.pitch = pitchRange.Randomize();
        source.volume = volumeRange.Randomize();
    }
}
