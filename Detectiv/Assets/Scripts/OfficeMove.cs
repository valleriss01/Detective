using System.Collections;
using System.Collections.Generic;
using UnityEditor.TerrainTools;
using UnityEngine;

public class OfficeMove : MonoBehaviour
{
    public GameObject Hero;
    public float speed = 1.0f;
    public Joystick joystick;
    public Rect area;
    public GameObject LocationPanel;

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.name == "Location")
        {
            LocationPanel.SetActive(true);
            Debug.Log("нужный триггер");
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Location")
        {
            LocationPanel.SetActive(false);
        }
    }

    public void AnimationController()
    {
        float moveHorizontal = joystick.Horizontal;
        float moveVertical = joystick.Vertical;

        if (moveHorizontal != 0 || moveVertical != 0)
        {
            Hero.GetComponent<Animator>().Play("RunForward");
        }
        else
        {
            Hero.GetComponent<Animator>().Play("Idle");
        }
    }

    public void JoyStickMove()
    {
        float moveHorizontal = joystick.Horizontal;
        float moveVertical = joystick.Vertical;

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical).normalized; // Нормализация вектора

        Vector3 newPosition = Hero.transform.position + transform.TransformDirection(movement) * speed * Time.deltaTime;

        Hero.transform.position = newPosition;
    }

    private void Rotation()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Input.mousePosition;

            if (area.Contains(mousePosition))
            {
                float mouseX = Input.GetAxis("Mouse X");

                Hero.transform.Rotate(0, mouseX * speed * Time.deltaTime * 200f, 0);
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
        JoyStickMove();
        AnimationController();
        Rotation();
    }
}