using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float Speed;
    public float Lifetime;

    private void Start()
    {
        Invoke("DestroyFirball", Lifetime);
    }

    void FixedUpdate()
    {
        MoveFixedUpdate();
    }

    private void MoveFixedUpdate()
    {
        transform.position += transform.forward * Speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        DestroyFirball();
    }

    private void DestroyFirball()
    {
        Destroy(gameObject);
    }
}
