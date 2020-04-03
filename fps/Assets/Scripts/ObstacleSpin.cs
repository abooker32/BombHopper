using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpin : MonoBehaviour
{
    public float rotSpeed;
    public bool clockwise;
    public GameObject obstacle;
    private LevelManager lMan;

    // Start is called before the first frame update
    void Start()
    {
        lMan = GameObject.Find("ManagerHolder").GetComponent<LevelManager>();

        if (!clockwise)
        {
            rotSpeed *= -1;
        }

        if (lMan.difficulty == 2)
        {
            InvokeRepeating("SwitchTimer", 10, 10);
        }
        else if (lMan.difficulty == 3)
        {
            InvokeRepeating("SwitchTimer", 5, 5);
            rotSpeed *= 1.5f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        obstacle.transform.Rotate(Vector3.up * (rotSpeed * Time.deltaTime));
    }

    private void SwitchTimer()
    {
        int chance = Random.Range(0, 100);
        Debug.Log(chance);

        if (chance >= 50)
        {
            rotSpeed *= -1;
            if (rotSpeed < 0)
            {
                clockwise = false;
            }
            else if (rotSpeed > 0)
            {
                clockwise = true;
            }

            Debug.Log("reversed");
        }

    }
}
