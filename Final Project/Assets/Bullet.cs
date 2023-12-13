using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10000f;

    public Vector3 target { get; set; }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, target) < 0.01f)
        {
            Destroy(gameObject);
        }
    }

    //private void OnCollisionEnter(Collision other)
    //{
    //    Destroy(gameObject);
    //}
}
