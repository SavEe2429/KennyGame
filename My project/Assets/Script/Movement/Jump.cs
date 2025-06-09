using UnityEngine;

[RequireComponent(typeof(MoveForward), typeof(ChangLane), typeof(CharacterController))]
public class Jump : MonoBehaviour
{
    
    [Header("Properties")] 
    [Tooltip("แรงกระโดด")]  [SerializeField] float jumpForce = 3f;
    [Tooltip("แรงโน้มถ่วง")]  [SerializeField] float gravity = -50;
    [Tooltip("ระยะที่ต้องการเช็ค")]  [SerializeField] float rayDistance = 0.4f;
    [Tooltip("กระโดดตามจำนวนที่ใส่")]  [SerializeField] int jumpLimit = 1;
    int jumpCount;

    [Header("GameObject")]
    [Tooltip("วัตถุที่ต้องการให้เช็คพื้น")]
    [SerializeField] Transform groundCheck;

    [Header("LayerMask")]
    [Tooltip("layer ที่ต้องการให้แตะกัน")]
    [SerializeField] LayerMask groundMask;

    CharacterController controller;
    bool isGround;
    Vector3 MoveY;
    Animator Anim;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        Anim = GetComponent<Animator>();
    }

    void Update()
    {
        
        isGround = Physics.CheckSphere(groundCheck.position, rayDistance, groundMask);

        if (isGround && MoveY.y < 0) // อยู่ที่พื้น
        {
            MoveY.y = -2f;
            jumpCount = 0;
            Anim.SetBool("IsFall?", false);
        }
        else if (!isGround && MoveY.y < 0)
        {
            Anim.SetBool("IsFall?", true);
        }

        if ((isGround && Input.GetKeyDown(KeyCode.Space)) || (jumpCount < jumpLimit && Input.GetKeyDown(KeyCode.Space))) // กระโดด
        {
            MoveY.y = Mathf.Sqrt(-2f * gravity * jumpForce);
            jumpCount++;
            Anim.SetTrigger("IsJump?");
            
        }

        MoveY.y += gravity * Time.deltaTime; // เพิ่มแรงโน้มถ่วง

        controller.Move(MoveY * Time.deltaTime); //ใช้งาน

    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck == null) return;

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheck.position, rayDistance);
    }
}
