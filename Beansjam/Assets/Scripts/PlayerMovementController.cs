using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public string HorizontalAxisName;

    public string VerticalAxisName;

    public float Speed = 10;

    private void FixedUpdate()
    {
        var horizontalInput = Input.GetAxisRaw(HorizontalAxisName);
        var verticalInput = Input.GetAxisRaw(VerticalAxisName);

        var directionVector = new Vector2(horizontalInput, verticalInput);

        GetComponent<Rigidbody2D>().velocity = directionVector.normalized * Speed;
    }
}
