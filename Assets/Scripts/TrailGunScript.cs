using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailGunScript : MonoBehaviour
{

    public int primaryDamage = 34;
    public float primaryRange = 100f;
    public float fireRate = 2f;
    
    public int ammoCount;
    public int maxAmmoCount = 3;
    public bool reloading = false;
    public float reloadTime;
    public ammoCounter ammoCounter;

    public Camera playerCam;
    public GameObject impactEffect;

    public float nextTimeToFire = 0f;

    void OnEnable()
    {
        ammoCount = maxAmmoCount;
        reloading = false;
    }

    private void Start()
    {
        ammoCounter.SetMaxAmmo(maxAmmoCount);
        ammoCounter.SetAmmo(ammoCount);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && reloading != true && ammoCount > 0f)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.R) && ammoCount != maxAmmoCount && reloading != true)
        {
            StartCoroutine("Reload");
            return;
        }

        if (ammoCount <= 0f)
        {
            StartCoroutine("Reload");
            return;
        }

    }

    void Shoot()
    {
        Debug.Log("bang bang");
        ammoCount -= 1;

        ammoCounter.SetAmmo(ammoCount);

        RaycastHit hit;
        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, primaryRange)) 
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if(target != null)
            {
                target.TakeDamage(primaryDamage);
            }

            GameObject impactGameObject = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));

            Destroy(impactGameObject, 4f);
        }

    }

    IEnumerator Reload()
    {
        Debug.Log("relaoding");
        reloading = true;

        yield return new WaitForSeconds(reloadTime);

        ammoCount = maxAmmoCount;
        ammoCounter.SetAmmo(ammoCount);
        reloading = false;
        StopCoroutine ("Reload");
        Debug.Log("done reloading");
    }
}
