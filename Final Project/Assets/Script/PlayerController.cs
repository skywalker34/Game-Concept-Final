using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public Rigidbody playerRigidbody;
    public Transform mainCamera;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Animator animator;

    public float speed = 10f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    bool isDead = false;




    void Update()
    {
        if (isDead) return;

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + mainCamera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0, angle, 0);

            Vector3 moveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            controller.Move(moveDirection * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 20f;
        }
        else
        {
            speed = 10f;
        }

        if (Input.GetMouseButtonDown(0))
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + mainCamera.eulerAngles.y;
            transform.rotation = Quaternion.Euler(0, targetAngle, 0);
        }

        animator.SetFloat("Speed", direction.magnitude);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            animator.SetBool("isDead", true);
            isDead = true;
        }
    }
}
