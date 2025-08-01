using UnityEngine;

public class ParticlePool : ObjectPool<DisableParticleAfterPlay>
{
    public void SpawnParticle(Vector3 position)
    {
        var obj = GetObject();
        obj.transform.position = position;
        obj.gameObject.SetActive(true);
    }
}

