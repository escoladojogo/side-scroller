using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueFrogController : MonoBehaviour
{
    public FrogController frogController;
    public int lives = 3;
    public GameObject explosion;
    public SpriteRenderer spriteRenderer;
    public float xJumpForce = 100;
    public int score;

    EnemyTools enemyTools = new EnemyTools(10f);
    GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Jumped()
    {
        float xForce = 0;

        if (enemyTools.IsPlayerClose(transform.position.x))
        {
            if (enemyTools.IsPlayerLeft(transform.position.x))
            {
                xForce = -xJumpForce;
                spriteRenderer.flipX = false;
            }
            else
            {
                xForce = xJumpForce;
                spriteRenderer.flipX = true;
            }
        }

        frogController.rigidBody.AddForce(new Vector2(xForce, 0));
    }

    public void Die()
    {
        lives--;
        StartCoroutine(ShowDamage());

        if (lives > 0)
        {
            return;
        }

        player.SendMessage("AddScore", score);
        Instantiate(explosion, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

    IEnumerator ShowDamage()
    {
        Color old = spriteRenderer.color;
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = old;
    }

    public GameObject GetPlayer()
    {
        return player;
    }
}
