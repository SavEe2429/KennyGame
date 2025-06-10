using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(ControlPanel))]
public class ClickDetection : MonoBehaviour
{

    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject()) //ตรวจจับว่าคลิกบน UI
        {
            Debug.Log("กำลังคลิกอยู่บน UI!");
        }
    }
}