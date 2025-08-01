using System;
using System.Collections;
using UnityEngine;

public class DisableParticleAfterPlay : MonoBehaviour
{
    [SerializeField]
    ParticleSystem particle;

    void OnEnable()
    {
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(WaitThenDisable());
        }
    }

    private IEnumerator WaitThenDisable()
    {
        particle.Play();
        while (particle.isPlaying || particle.isEmitting || particle.particleCount != 0)
        {
            yield return null;
        }

        gameObject.SetActive(false);
    }
}
