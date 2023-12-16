using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 50;

    public Vector3 target { get; set; }

    void Update()
    {
        Vector3 direction = (target - transform.position).normalized;
        transform.position = transform.position + direction * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
