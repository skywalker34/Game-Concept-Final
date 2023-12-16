using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform playerTransform;
    public Animator animator;
    private float speed = 30f;
    private bool isDead = false;
    private bool isGameOver = false;


    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(playerTransform.position);
        float distance = Vector3.Distance(agent.transform.position, playerTransform.position);
        agent.speed = distance < 1 ? speed : speed / Mathf.Sqrt(distance);

        if (isDead)
        {
            Debug.Log("dead");
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            if (stateInfo.IsName("Zombie Dying") && stateInfo.normalizedTime >= 1.0f)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("bullet"))
        {
            animator.SetBool("isDead", true);
            isDead = true;

        }
        if (collision.gameObject.tag.Equals("Player"))
        {
            isGameOver = true;
        }
    }
}
