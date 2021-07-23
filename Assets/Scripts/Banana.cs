using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//INHERITANCE
public class Banana : Items
{
    //POLYMORPHISM
    public override void MoveItem()
    {
        float speed = -50f;
        transform.Rotate(Vector3.up, Time.deltaTime * speed);
    }
}
