using UnityEngine;

[RequireComponent(typeof(Jump), typeof(ChangLane), typeof(CharacterController))]
public class MoveForward : MonoBehaviour
{
    CharacterController Controller;
    [SerializeField] float m_Speed = 5f;
    Animator Anim;

    void Awake()
    {
        Controller = GetComponent<CharacterController>();
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = new Vector3(0, 0, 1);

        Controller.Move(forward * m_Speed * Time.deltaTime);
        if (transform.position.z > 0)
        {
            Anim.SetBool("IsRun?", true);
        }
        else
        {
            Anim.SetBool("IsRun?", false);
        }

    }

    void consoleDebug()
    {
        
    }
}
