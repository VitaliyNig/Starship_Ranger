using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class СharacterController : MonoBehaviour
{
    private Vector3 lastPosition;

    private void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Moved)
            {
                Vector3 touchPos2D = Input.mousePosition;
                touchPos2D.z = -Camera.main.transform.position.z;
                Vector3 touchPos3D = Camera.main.ScreenToWorldPoint(touchPos2D);

                Vector3 starshipPosition = this.transform.position;
                starshipPosition.x = touchPos3D.x;
                this.transform.position = Vector3.Lerp(this.transform.position, starshipPosition, 0.5f);

                if (lastPosition.x > this.transform.position.x)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 20f), 1f);
                }
                else if (lastPosition.x < this.transform.position.x)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, -20f), 1f);
                }
                lastPosition = this.transform.position;
            }
        }

        if (lastPosition.x == this.transform.position.x)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0f), 0.2f);
        }
    }
}
