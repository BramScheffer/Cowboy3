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
    public AudioSource gunShoot;
    public AudioSource gunReload;
    public Animator mAnimator;



    // Start is called before the first frame update
    void Start()
    {

        currentAmmo = maxAmmo;
        currentCooldown = fireCooldown;
        mAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //als hij niet gepaused is maar wel aan het reloaden is, dan begint de computer het script weer te lezen aan het begin
        if (!PauseMenu.isPaused)
        {
            if (isReloading)
            {
                // Handelt reloading
                return;
            }

            if (automatic)
            {
                if (Input.GetMouseButton(0))
                {
                    Shoot();
                    gunShoot.Play();

                }
            }
            else
            {
                if (Input.GetMouseButtonDown(0))
                {
;
                    Shoot();
                    gunShoot.Play();

                }
            }

            // Hendelt de cooldown
            currentCooldown -= Time.deltaTime;

            // als je op R klikt word de reload component geladen
            if (Input.GetKeyDown(KeyCode.R))
            {
                Reload();
            }
        }
        
    }

    void Shoot()
    {
        //als de cooldown kleiner is of 0 is en de current ammo is meer dan 0, kan je schieten
        if (currentCooldown <= 0f && currentAmmo > 0)
        {
            OnGunShoot?.Invoke();
            currentCooldown = fireCooldown;
            //hiermee gaat er 1 bullet van de current ammo
            currentAmmo--;
            mAnimator.SetTrigger("Shoot");
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
            gunReload.Play();
            mAnimator.SetTrigger("Reload");
            // Reset de ammo na reloadTime
            Invoke("FinishReload", reloadTime);
        }
    }

    void FinishReload()
    {
        currentAmmo = maxAmmo;
        isReloading = false;
    }
}

