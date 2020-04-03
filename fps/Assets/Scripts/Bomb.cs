using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float power = 10.0f;
    public float radius = 5.0f;
    public float upForce = 1.0f;
    public ParticleSystem exEffect;

    private void Start()
    {
        Invoke("Explode", 3);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Invoke("Explode", 3);
    }

    void Explode()
    {
        Vector3 explosionPosition = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rbe = hit.GetComponent<Rigidbody>();
            if (rbe != null)
            {
                rbe.AddExplosionForce(power, explosionPosition, radius, upForce, ForceMode.Impulse);
                var mc = rbe.GetComponentInParent<Character>();

                if (mc != null)
                {
                    mc.Stun();
                }
            }
        }

        Instantiate(exEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
