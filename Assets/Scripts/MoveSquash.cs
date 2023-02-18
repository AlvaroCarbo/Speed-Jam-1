using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSquash : MonoBehaviour
{
    public float speed = 10f;
    public float minYPosition = 0;
    public float maxYPosition = 5f;
    
    private bool _goingDown = true;
    
    // Update is called once per frame
    void Update()
    {
        var position = transform.position;
        if (_goingDown)
        {
            position.y -= speed * Time.deltaTime;
            if (position.y <= minYPosition)
            {
                _goingDown = false;
            }
        }
        else
        {
            position.y += speed * Time.deltaTime;
            if (position.y >= maxYPosition)
            {
                _goingDown = true;
            }
        }
        transform.position = position;
    }
}
