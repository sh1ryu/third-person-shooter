using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballCaster : MonoBehaviour
{
    public Fireball FireballPrefab;
    public Transform FireballSourceTransform;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(FireballPrefab, FireballSourceTransform.position, FireballSourceTransform.rotation);
        }
    }
}
