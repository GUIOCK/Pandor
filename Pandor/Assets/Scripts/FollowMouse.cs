using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    [SerializeField]
    private float speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.mousePosition.x < 0.1 * Screen.width || Input.GetAxis("Horizontal") < 0)
        {
            MoveTo(Vector3.left);
        }
        if(Input.mousePosition.x > 0.9 * Screen.width || Input.GetAxis("Horizontal") > 0)
        {
            MoveTo(Vector3.right);
        }
        if(Input.mousePosition.y < 0.1 * Screen.height || Input.GetAxis("Vertical") < 0)
        {
            MoveTo(Vector3.back);
        }
        if(Input.mousePosition.y > 0.9 * Screen.height || Input.GetAxis("Vertical") > 0)
        {
            MoveTo(Vector3.forward);
        }
    }

    void MoveTo(Vector3 direction)
    {
        transform.Translate(direction * Time.deltaTime * speed, Space.World);
    }
}
