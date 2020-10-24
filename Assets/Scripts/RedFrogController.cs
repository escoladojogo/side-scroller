using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedFrogController : MonoBehaviour
{
    public GameObject fireball;
    public float waitToShoot = 2.0f;

    float secondsPassed = 0;

    void Update()
    {
        secondsPassed += Time.deltaTime;

        if (secondsPassed >= waitToShoot)
        {
            Instantiate(fireball, this.transform.position, Quaternion.identity);
            secondsPassed = 0;
        }
    }
}
