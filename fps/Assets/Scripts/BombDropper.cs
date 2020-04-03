using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDropper : MonoBehaviour
{
    public GameObject bomb;
    public float radius = 10.0f;
    public float spawnTime = 5.0f;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("DropBombs", spawnTime, spawnTime);
    }

    public void DropBombs()
    {
        Instantiate(bomb, Random.insideUnitSphere * radius + transform.position, Random.rotation);
    }
}
