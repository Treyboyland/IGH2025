using System.Collections;
using UnityEngine;

public class PlaySoundThenDisable : MonoBehaviour
{
    [SerializeField]
    AudioSource audioSource;

    public AudioSource AudioSource { get => audioSource; }


    void OnEnable()
    {
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(PlayThenDisable());
        }
    }

    IEnumerator PlayThenDisable()
    {
        audioSource.Play();
        while (audioSource.isPlaying)
        {
            yield return null;
        }

        gameObject.SetActive(false);
    }
}
