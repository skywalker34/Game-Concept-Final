using UnityEngine;
using UnityEngine.SceneManagement;

public class Shooting : MonoBehaviour
{
    public Animator animator;
    public Transform playerTransform;
    public Transform cameraTransform;
    public Transform shootingPoint;
    public GameObject bulletPrefab;
    public ReloadBar reloadBar;

    private float lastShotTime;
    private int currentPower;

    void Update()
    {
        if (PauseMenu.isPaused) return;
        if (GameOver.isGameOver) return;
        currentPower = reloadBar.GetPower();
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("isShooting", true);
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            if (currentScene == (int)Scene.LevelOne && currentPower - 1 >= 0)
            {
                Shoot();
                reloadBar.SetPower(currentPower - 1);
            }
            else if (currentScene == (int)Scene.LevelTwo && currentPower - 1 >= 0)
            {
                Shoot();
                reloadBar.SetPower(currentPower - 1);
            }
            else if (currentScene == (int)Scene.LevelThree && currentPower - 1 >= 0)
            {
                Shoot();
                reloadBar.SetPower(currentPower - 1);
            }
            else if (currentScene == (int)Scene.NewGamePlus)
            {
                Shoot();
            }
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
