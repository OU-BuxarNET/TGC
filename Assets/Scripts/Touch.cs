using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour
{
    #region ================================= PRIVATE FIELDS

    private readonly float _speed = 0.1f;
    private Vector2 _startPos;

    #endregion

    #region ============================== PRIVATE METHODS

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    _startPos = touch.position;
                    break;

                case TouchPhase.Moved:
                    var dir = touch.position - _startPos;
                    var pos = transform.position + new Vector3(transform.position.x, transform.position.y, dir.y);
                    transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * _speed);
                    break;
            }
        }
    }

    #endregion
}
