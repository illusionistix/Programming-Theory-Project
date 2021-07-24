using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 100f;

    private Animator playerAnim;

    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
    }

    //ABSTRACTION
    private void MovePlayer()
    {
        float verticalInput = Input.GetAxis("Vertical");

        if (verticalInput > Mathf.Epsilon)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed * verticalInput);
            playerAnim.SetBool("idle_b", false);
        }
        else if (verticalInput < 0 - Mathf.Epsilon) 
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed * verticalInput);
            playerAnim.SetBool("idle_b", false);
            playerAnim.SetBool("retreating_b", true);
        }
        else
        {
            playerAnim.SetBool("idle_b", true);
            playerAnim.SetBool("retreating_b", false);
        }
    }

    //ABSTRACTION
    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        RotatePlayer();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            MainManager.Instance.score += 10;
            Destroy(collision.gameObject);
        }
    }
}
