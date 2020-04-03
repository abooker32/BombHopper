using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float speed;
    private GameObject character;
    public Rigidbody rb;
    public float jumpForce;
    private string moveInputAxis = "Vertical";
    private string turnInputAxis = "Horizontal";
    private bool stunned = false;
    private LevelManager levMan;
    public float groundDistance = 0.5f;
    public LayerMask ground;
    public Animator anim;

    public float rotationRate = 360;

    // Start is called before the first frame update
    void Start()
    {
        levMan = GameObject.Find("ManagerHolder").GetComponent<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveAxis = Input.GetAxis(moveInputAxis);
        float turnAxis = Input.GetAxis(turnInputAxis);

        ApplyInput(moveAxis, turnAxis);
        

        if (Input.GetKeyDown(KeyCode.Space) && stunned != true && Grounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            //anim.SetBool("Grounded", false);
        }

        anim.SetBool("Grounded", Grounded());

        anim.SetFloat("MoveSpeed", speed);
    }

    private bool Grounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, groundDistance, ground);
    }

    private void ApplyInput(float moveInput, float turnInput)
    {
        if (stunned != true)
        {
            Move(moveInput);
            Turn(turnInput);
        }
    }

    private void Move(float input)
    {
        transform.Translate(Vector3.forward * input * (speed * Time.deltaTime));
    }

    private void Turn(float input)
    {
        transform.Rotate(0, input * (rotationRate * Time.deltaTime), 0);
    }

    public void Stun()
    {
        stunned = true;
        Invoke("Unstun", 3);
    }

    public void Unstun()
    {
        stunned = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DBox"))
        {
            levMan.EndGame();
        }    
    }
}
