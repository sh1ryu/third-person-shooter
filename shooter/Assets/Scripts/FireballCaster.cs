using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballCaster : MonoBehaviour
{
    public float damage = 10;

    public Fireball FireballPrefab;
    public Transform FireballSourceTransform;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var fireball = Instantiate(FireballPrefab, FireballSourceTransform.position, FireballSourceTransform.rotation);
            fireball.damage = damage;
        }
    }
}
