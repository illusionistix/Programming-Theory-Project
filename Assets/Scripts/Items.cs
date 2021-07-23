using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    protected float speed = -10f;

    //POLYMORPHISM
    public virtual void MoveItem()
    {
        transform.Rotate(Vector3.up, Time.deltaTime * speed);
    }

    private void Update()
    {
        MoveItem();
    }
}
