using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float moveSpeed = 5.0f;
    float jumpForce = 5.0f;

    public Rigidbody playerRb;
    public Animator playerAnim;

    bool isOnPlayPlane = false;

    public GameObject ParentCube;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            playerAnim.SetBool("isMove", true);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            playerAnim.SetBool("isMove", true);
        }
        
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            playerAnim.SetBool("isMove", false);
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
            transform.rotation = Quaternion.Euler(0, -90, 0);
            playerAnim.SetBool("isMove", true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
            transform.rotation = Quaternion.Euler(0, 90, 0);
            playerAnim.SetBool("isMove", true);
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            playerAnim.SetBool("isMove", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnim.SetTrigger("trigFlip");
            isOnPlayPlane = false;
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            playerAnim.SetTrigger("trigDeath");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("PlayPlane"))
        {
            isOnPlayPlane = true;
        }
    }
}
