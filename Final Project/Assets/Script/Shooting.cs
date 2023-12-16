using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Animator animator;
    public Transform playerTransform;
    public Transform cameraTransform;
    public Transform shootingPoint;
    public GameObject bulletPrefab;

    private float lastShotTime;

    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("isShooting", true);
            Shoot();
            lastShotTime = Time.time;
        }

        if (Time.time - lastShotTime > 1)
        {
            animator.SetBool("isShooting", false);
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
        Bullet bulletControl = bullet.GetComponent<Bullet>();
        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, Mathf.Infinity))
        {
            bulletControl.target = hit.point;
        }
        else
        {
            bulletControl.target = cameraTransform.position + cameraTransform.forward;
        }

    }
}
