using UnityEngine;
using UnityEngine.EventSystems;


public class Resume : MonoBehaviour, IPointerClickHandler
{
    ControlPanel panel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        panel = GetComponentInParent<ControlPanel>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        panel.panel.SetActive(false);
        Time.timeScale = 1f;
    }
}
