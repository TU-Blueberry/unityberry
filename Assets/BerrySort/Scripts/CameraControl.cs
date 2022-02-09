using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public Camera camera;
    public int fovMax;
    public int fovMin;

    public float moveSpeed = 0.5f;

    public float correctiveSpeed = 2f;
    public float scrollSpeed = 10f;

    public Vector3 lastPosition;
    public Vector3 delta;
    public float mouseSensitivity = 0.01f;

    public Vector3 moveRange = new Vector3();
    public Vector3 maxRange = new Vector3();
    public Vector3 minRange = new Vector3();

    public Vector3 initialPosition = new Vector3();

    public Vector3 lastPos = new Vector3();

    public Vector3 curPos = new Vector3();


    void Start()
    {
        this.initialPosition = this.camera.gameObject.transform.position;
        Debug.Log(this.initialPosition);
        this.maxRange.x = this.initialPosition.x + moveRange.x;
        this.maxRange.y = this.initialPosition.y + moveRange.y;
        this.maxRange.z = this.initialPosition.z + moveRange.z;

        this.minRange.x = this.initialPosition.x - moveRange.x;
        this.minRange.y = this.initialPosition.y - moveRange.y;
        this.minRange.z = this.initialPosition.z - moveRange.z;
        this.lastPos = this.initialPosition;

        //this.maxRange = new Vector3(this.initialPosition.x + maxRange.x, this.initialPosition.y + maxRange.y, this.initialPosition.z + maxRange.z);
    }

    void Update()
    {

        this.lastPos = this.curPos;
        this.curPos = camera.gameObject.transform.position;
        if (Input.GetMouseButtonDown(0))
        {
            lastPosition = Input.mousePosition;
        }


        if (this.curPos.x > this.maxRange.x)
        {
            camera.gameObject.transform.Translate(-correctiveSpeed, 0, 0);
        }

        if (this.curPos.y > this.maxRange.y)
        {

            camera.gameObject.transform.Translate(0, -correctiveSpeed, 0);
        }

        /*         if (this.curPos.z > Mathf.Abs(this.initialPosition.z) + this.maxRange.z)
                {
                    camera.gameObject.transform.position = new Vector3(this.curPos.x, this.curPos.y, Mathf.Abs(this.initialPosition.z) + this.maxRange.z);
                } */

        if (this.curPos.x < this.minRange.x)
        {
            camera.gameObject.transform.Translate(correctiveSpeed, 0, 0);
        }

        if (this.curPos.y < this.minRange.y)
        {
            camera.gameObject.transform.Translate(0, correctiveSpeed, 0);
        }

        /*             if (this.curPos.z < -Mathf.Abs(this.initialPosition.z) - this.maxRange.z)
                    {
                        camera.gameObject.transform.position = new Vector3(this.curPos.x, this.curPos.y, -Mathf.Abs(this.initialPosition.z) - this.maxRange.z);
                    } */
        if (Input.GetMouseButton(0))
        {
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