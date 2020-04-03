using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject bomb;
    public float power;
    public float radius;
    public float upForce;

    private void FixedUpdate()
    {
        if (bomb == enabled)
        {
            Invoke("Explode", 3);
        }
    }
    void Explode()
    {
        Vector3 explosionPosition = bomb.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rbe = hit.GetComponent<Rigidbody>();
            if (rbe != null)
            {
                rbe.AddExplosionForce(power, explosionPosition, radius, upForce, ForceMode.Impulse);
            }
        }
    }
}
