using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 50f;
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(Vector3.up, Random.Range(-90f, 90f));
    }

    // Update is called once per frame
    void Update()
    {
        RotateCoin();
    }

    //ABSTRACTION
    private void RotateCoin()
    {
        transform.Rotate(Vector3.up, Time.deltaTime * rotationSpeed, Space.Self);
    }
}
