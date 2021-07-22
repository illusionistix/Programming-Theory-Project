using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : Items
{
    public override void MoveItem()
    {
        float speed = -50f;
        transform.Rotate(Vector3.up, Time.deltaTime * speed);
    }
}
