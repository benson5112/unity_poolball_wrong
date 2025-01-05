using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class cameracontroller : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;

    public float speed = 12.0f;
    public float forceSpd = 9.0f;

    public float distance = 6.0f;
    public float xSpeed = 120.0f;
    public float ySpeed = 120.0f;

    public float yMinLimit = 0f;
    public float yMaxLimit = 80f;
    public float distanceMin = 0.5f;
    public float distanceMax = 15f;

    private Rigidbody rb;
    private float movementX;
    private float movementY;

    float x = 0.0f;
    float y = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;

        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(Input.GetMouseButton(0))
        {
            x += Input.GetAxis("Mouse X") * xSpeed * distance * 0.02f;
            y += Input.GetAxis("Mouse Y") * ySpeed * distance * 0.02f;
            y = ClampAngle(y, yMinLimit, yMaxLimit);
            Quaternion rotation = Quaternion.Euler(y, x, 0);
            distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * 5,
                                    distanceMin, distanceMax);
            Vector3 negDistance = new Vector3(0.0f, 2f, -distance);
            offset = rotation * negDistance;
            transform.rotation = rotation;
        }

        transform.position = player.transform.position + offset;
    }

    public static float ClampAngle (float angle, float min, float max)
    {
        if(angle < -360f) angle += 360f;
        if(angle > -360f) angle -= 360f;
        return Mathf.Clamp(angle, min, max);
    }
}