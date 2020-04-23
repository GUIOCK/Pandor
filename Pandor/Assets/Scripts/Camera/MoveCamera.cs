using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 1;
    [SerializeField]
    private float deadZone = 0.8f;
    [SerializeField]
    private float zoomSpeed = 1;
    [SerializeField]
    private int upperZoom = 40;
    [SerializeField]
    private int lowerZoom = 5;
    [SerializeField]
    private int horizontalBorder = 50;
    [SerializeField]
    private int verticalBorder = 50;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.mousePosition.x < 0.1 * Screen.width || (Input.GetAxis("Horizontal") < 0 && Input.GetAxis("Horizontal") > deadZone))
        {
            transform.position = MoveTo(Vector3.left);
        }
        if(Input.mousePosition.x > 0.9 * Screen.width || (Input.GetAxis("Horizontal") > 0 && Input.GetAxis("Horizontal") < deadZone))
        {
            transform.position = MoveTo(Vector3.right);
        }
        if (Input.mousePosition.y < 0.1 * Screen.height || (Input.GetAxis("Vertical") < 0 && Input.GetAxis("Vertical") > deadZone))
        {
            transform.position = MoveTo(Vector3.back);
        }
        if(Input.mousePosition.y > 0.9 * Screen.height || (Input.GetAxis("Vertical") > 0 && Input.GetAxis("Vertical") < deadZone))
        {
            transform.position = MoveTo(Vector3.forward);
        }
        if (Input.mouseScrollDelta.y != 0) //Si il y a un scroll de souris, pour éviter de faire les calculs à chaque frame
        {
            transform.position = Zoom(Input.mouseScrollDelta.y);
        }
    }

    Vector3 MoveTo(Vector3 direction)
    {
        Vector3 nextPosition = transform.position + direction * moveSpeed * Time.deltaTime;
        if(Mathf.Abs(nextPosition.x) < horizontalBorder && Mathf.Abs(nextPosition.z) < verticalBorder)
        {
            return nextPosition;
        }
        return transform.position;
    }

    Vector3 Zoom(float direction)
    {
        Vector3 nextZoom = transform.position + transform.forward * direction * zoomSpeed;
        if (nextZoom.y < upperZoom && nextZoom.y > lowerZoom)
        {
            return nextZoom;
        }
        return transform.position;
    }
}
