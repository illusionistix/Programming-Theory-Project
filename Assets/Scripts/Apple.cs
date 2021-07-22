using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : Items
{
    public override void MoveItem()
    {
        float speed = -20f;
        transform.Rotate(Vector3.up, Time.deltaTime * speed);
    }
}
