using System.Collections;
using System.Collections.Generic;
using UnityEditor.TerrainTools;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float speed = 1.0f;
    public Rect area;
    public Transform CameraLev;

    private void Rotation()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Input.mousePosition;

            if (area.Contains(mousePosition))
            {
                float mouseY = Input.GetAxis("Mouse Y");

                float currentX = CameraLev.localEulerAngles.x;
                currentX = (currentX > 180) ? currentX - 360 : currentX;

                float newX = Mathf.Clamp(currentX - mouseY * speed * Time.deltaTime * 20f, -80f, 80f);

                CameraLev.localEulerAngles = new Vector3(newX, CameraLev.localEulerAngles.y, 0);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        area = new Rect(Screen.width / 2, 0, Screen.width / 2, Screen.height);
    }

    // Update is called once per frame
    void Update()
    {
        Rotation();
    }
}