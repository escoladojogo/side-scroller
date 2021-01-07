using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathController : MonoBehaviour
{
    public GameObject explosion;
    public int score;

    void Die(GameObject player)
    {
        player.SendMessage("AddScore", score);
        Instantiate(explosion, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

    void SelfDestroy()
    {
        Destroy(this.gameObject);
    }
}
