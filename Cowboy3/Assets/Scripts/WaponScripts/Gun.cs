using UnityEngine.Events;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public UnityEvent OnGunShoot;
    public UnityEvent OnReload;
    public float fireCooldown;
    public float reloadTime;
    public int maxAmmo;
    private int currentAmmo;
    public bool automatic;
    public float currentCooldown;
    private bool isReloading;
    public AudioSource reloadSource;
    public AudioClip reloadClip;
    public AudioSource shootSource;
    public AudioClip shootClip;
    public Animator animShoot;


    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = maxAmmo;
        currentCooldown = fireCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (isReloading)
        {
            // Handle reloading
            return;
        }

        if (automatic)
        {
            if (Input.GetMouseButton(0))
            {
                Shoot();
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                animShoot.SetTrigger("Shoot");
                animShoot.ResetTrigger("Idle");
                Shoot();
               
            }
        }

        // Handle cooldown
        currentCooldown -= Time.deltaTime;

        // Handle reload input
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }

    void Shoot()
    {
        if (currentCooldown <= 0f && currentAmmo > 0)
        {
            OnGunShoot?.Invoke();
            currentCooldown = fireCooldown;
            currentAmmo--;
            if (currentAmmo == 0)
            {
                Reload();
            }
        }
    }

    void Reload()
    {
        if (currentAmmo < maxAmmo)
        {
            isReloading = true;
            OnReload?.Invoke();
            // You can play reload animation or sound here if needed
            
            reloadSource.PlayOneShot(reloadClip);
            // Reset ammo after reloadTime
            Invoke("FinishReload", reloadTime);
        }
    }

    void FinishReload()
    {
        currentAmmo = maxAmmo;
        isReloading = false;
    }
}

