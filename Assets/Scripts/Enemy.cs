using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(Vector3.up, -90f);
    }

    //ABSTRACTION
    private void MoveEnemy()
    {      
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    //ABSTRACTION
    private void UpdateRotation()
    {
        if (transform.position.x < -12f)
        {
            transform.Rotate(Vector3.up, 180f);
        }
        else if (transform.position.x > 12f)
        {
            transform.Rotate(Vector3.up, -180f);
        }
    }

    // Update is called once per frame
    void Update()
    {        
        MoveEnemy();
        UpdateRotation();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            MainManager.Instance.energy -= 10f;
        }
    }
}
