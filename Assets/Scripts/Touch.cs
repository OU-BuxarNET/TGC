using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour
{
    private readonly float speed = 15.1f;
    private bool move = false;
    private Vector3 target;
    private Vector2 startPos;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startPos = touch.position;
                    break;

                case TouchPhase.Moved:
                    var dir = touch.position - startPos;
                    var pos = transform.position + new Vector3(transform.position.x, transform.position.y, dir.y);
                    transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * speed);
                    break;
            }
        }

    }
}
