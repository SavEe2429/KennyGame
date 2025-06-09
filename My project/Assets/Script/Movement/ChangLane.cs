using UnityEngine;

[RequireComponent(typeof(Jump), typeof(MoveForward), typeof(CharacterController))]
public class ChangLane : MonoBehaviour
{
    CharacterController Controller;
    Animator Anim;

    // lane varible
    [SerializeField] int m_currentLane = 0; // left = -1 , center = 0 , right = 1
    [SerializeField] int m_laneDistance = 1;

    void Awake()
    {
        Controller = GetComponent<CharacterController>();
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log($"input : {Input.GetAxis("Horizontal")}");
        // Debug.Log($"m_currentLane : {m_currentLane}");
        if (Input.GetKeyDown(KeyCode.D) && m_currentLane < 1)
        {
            m_currentLane++;
            // Debug.Log($"++");
        }
        if (Input.GetKeyDown(KeyCode.A) && m_currentLane > -1)
        {
            m_currentLane--;
            // Debug.Log($"--");
        }


        Vector3 targetPos = new Vector3(m_currentLane * m_laneDistance, transform.position.y, transform.position.z);

        // Vector3 moveTo = Vector3.forward * m_Speed;

        Vector3 newPos = Vector3.MoveTowards(transform.position, targetPos, 10f * Time.deltaTime);

        Vector3 moveDir = new Vector3(newPos.x - transform.position.x, 0, 0);

        Controller.Move(moveDir);

    }

}
