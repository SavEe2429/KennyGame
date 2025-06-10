using UnityEngine;

public class ControlPanel : MonoBehaviour
{
    public GameObject panel;
    public bool isPause;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePanel();
        }
    }
    void TogglePanel()
    {
        isPause = panel.activeSelf;
        Debug.Log($"isPause before : {isPause}");
        panel.SetActive(!isPause);

        Time.timeScale = isPause ? 1f : 0f;
    }
}
