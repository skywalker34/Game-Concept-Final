using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Animator animator;
    public Transform playerTransform;
    public Transform cameraTransform;
    public Transform shootingPoint;
    public GameObject bulletPrefab;
    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
            animator.SetBool("isShooting", true);
        }
        else
        {
            animator.SetBool("isShooting", false);
        }
        Debug.DrawRay(shootingPoint.position, cameraTransform.forward * 500);
    }

    void Shoot()
    {
        RaycastHit hit;
        GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, Quaternion.identity);
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
