using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public Camera camera;
    public int fovMax;
    public int fovMin;

    public float moveSpeed = 0.5f;
    public float scrollSpeed = 10f;

    public Vector3 lastPosition;
    public Vector3 delta;
    public float mouseSensitivity = 0.0001f;


    public Vector3 maxRange = new Vector3(10, 10, 10);
    public Vector3 initialPosition = new Vector3();

    public Vector3 curPos = new Vector3();

    void start()
    {
        this.initialPosition = this.camera.gameObject.transform.position;
        this.maxRange.x = this.initialPosition.x + maxRange.x;
        this.maxRange.y = this.initialPosition.y + maxRange.y;
        this.maxRange.z = this.initialPosition.z + maxRange.z;
    }
    void Update()
    {
        this.curPos = camera.gameObject.transform.position;
        if (Input.GetMouseButtonDown(0))
        {
            lastPosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            if (this.curPos.x > this.maxRange.x)
            {
                camera.gameObject.transform.position = new Vector3(this.maxRange.x, this.curPos.y, this.curPos.z);
            }

            if (this.curPos.y > this.maxRange.y)
            {
                camera.gameObject.transform.position = new Vector3(this.curPos.x, this.maxRange.y, this.curPos.z);
            }

            if (this.curPos.z > this.maxRange.z)
            {
                camera.gameObject.transform.position = new Vector3(this.curPos.x, this.curPos.y, this.maxRange.z);
            }

            if (this.curPos.x < -this.maxRange.x)
            {
                camera.gameObject.transform.position = new Vector3(-this.maxRange.x, this.curPos.y, this.curPos.z);
            }

            if (this.curPos.y < -this.maxRange.y)
            {
                camera.gameObject.transform.position = new Vector3(this.curPos.x, -this.maxRange.y, this.curPos.z);
            }

            if (this.curPos.z < -this.maxRange.z)
            {
                camera.gameObject.transform.position = new Vector3(this.curPos.x, this.curPos.y, -this.maxRange.z);
            }

            delta = Input.mousePosition - lastPosition;
            //transform.Translate(delta.x * mouseSensitivity, delta.y * mouseSensitivity, 0);
            camera.gameObject.transform.Translate(delta.x * mouseSensitivity, delta.y * mouseSensitivity, 0);
            lastPosition = Input.mousePosition;

        }

        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            // transform.position += scrollSpeed * new Vector3(0, -Input.GetAxis("Mouse ScrollWheel"), 0) * Time.deltaTime;
            //camera.fieldOfView = camera.fieldOfView - 1;
            if (camera.fieldOfView > fovMax)
            {
                camera.fieldOfView = fovMax;
            }

            if (camera.fieldOfView < fovMin)
            {
                camera.fieldOfView = fovMin;
            }
            camera.fieldOfView = camera.fieldOfView + moveSpeed * Input.GetAxisRaw("Mouse ScrollWheel") * scrollSpeed;
        }
    }

}