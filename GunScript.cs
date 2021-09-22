using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GunScript : MonoBehaviour
{
    public static GunScript instance;
    
    private void Awake()
    {
        instance = this;
    }

    public float damage = 10;
    public float range = 100f;
    public float fireRate = 15f;

    public int maxAmmo = 10;
    private int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;

    private float nextTimeToFire = 0f;

    public Animator animator;

    private void Start()
    {
        currentAmmo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        if (isReloading)
        {
            return;
        }

        if(currentAmmo <= 0 || Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    
    public void Execute()
    {
        if (Input.GetButton("Fire1"))
        {
            Debug.Log("You just used the InputHandler to shoot");  
            Shoot();
        }
    }
    

    public void Damage(int amount)
    {
        damage = damage + amount;
        Debug.Log("TestDMG" + amount);
    }


    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading");

        animator.SetBool("Reloading", true);

        yield return new WaitForSeconds(reloadTime);

        animator.SetBool("Reloading", false);


        currentAmmo = maxAmmo;
        isReloading = false;
    }

    void Shoot()
    {
        
        muzzleFlash.Play();

        currentAmmo--;

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

           Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);         
            }
        }
    }

}
