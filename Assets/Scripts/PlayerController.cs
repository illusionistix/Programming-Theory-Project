using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        //moveSpeed = 5f;
    }

    private void MoveAround()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed * horizontalInput);        
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed * verticalInput);
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveAround();
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
