using UnityEngine;

public class Enemy : MappedObject
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.gameObject.GetComponent<Player>();
        if (player)
        {
            player.Die();
        }
    }
}
