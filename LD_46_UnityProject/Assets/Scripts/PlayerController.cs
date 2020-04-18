using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 1;
    [SerializeField]
    private float jumpForce = 2;
    [SerializeField]
    private float fallMultiplier = 2.5f;
    [SerializeField]
    private float lowJumpMultiplier = 2f;
    [SerializeField]
    private float jumpWait;
    [SerializeField]
    private LayerMask groundLayer;

    [SerializeField]
    private Transform visual;
    private Animator animator;
    private new Rigidbody rigidbody;
    private bool isJumping = false;
    private bool isJumpButtonPressed = false;
    private Quaternion defaultRotation;
    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        defaultRotation = visual.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
        isJumpButtonPressed = Input.GetButtonDown("Jump");
        Vector3 inputVector = new Vector3(h, 0, v);
        transform.position += inputVector.normalized * speed * Time.deltaTime;
        visual.LookAt(transform.position + inputVector);
        animator.SetFloat("Speed", inputVector.magnitude);
        if (isJumpButtonPressed&&CheckGround())
        {
            StartCoroutine(Jump());
            
        }
        if (rigidbody.velocity.y < 0)
        {
            rigidbody.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (!Input.GetButton("Jump") && rigidbody.velocity.y > 0)
        {
            rigidbody.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

    }

    private bool CheckGround()
    {
        Ray groundCheckRay = new Ray(transform.position+Vector3.up*0.1f, transform.up * -1);
        RaycastHit hit;
        Physics.Raycast(groundCheckRay, out hit, 0.15f, groundLayer);
        if (hit.collider != null)
        {
            return true;
        }
        else
            return false;
    }

    private IEnumerator Jump()
    {
        animator.SetTrigger("Jump");
        yield return new WaitForSeconds(jumpWait);
        rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
       
    }
}
