﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[AddComponentMenu("Nokobot/Modern Guns/Simple Shoot")]
public class SimpleShoot : MonoBehaviour
{
    [Header("Prefab Refrences")]
    public GameObject bulletPrefab;
    public GameObject casingPrefab;
    public GameObject muzzleFlashPrefab;

    [Header("Location Refrences")]
    [SerializeField] private Animator gunAnimator;
    [SerializeField] private Transform barrelLocation;
    [SerializeField] private Transform casingExitLocation;

    [Header("Settings")]
    [Tooltip("Specify time to destory the casing object")] [SerializeField] private float destroyTimer = 2f;
    [Tooltip("Bullet Speed")] [SerializeField] private float shotPower = 1000f;//was 200 before
    [Tooltip("Casing Ejection Speed")] [SerializeField] private float ejectPower = 1500f;

    [SerializeField] Transform gunAim;
    [SerializeField] LineRenderer lineRenderer;

    public GameObject lastFiredBullet;

    public GameObject testObj;

    void Start()
    {
        if (barrelLocation == null)
            barrelLocation = transform;

        //if (gunAnimator == null)
        //    gunAnimator = GetComponentInChildren<Animator>();
    }

    void FixedUpdate()
    {

        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            Shoot();
        }
        //If you want a different input, change it here
        //if (Input.GetButtonDown("Fire1"))
        //{
        //    //Calls animation on the gun that has the relevant animation events that will fire
        //    gunAnimator.SetTrigger("Fire");
        //}
    }


    //This function creates the bullet behavior
    void Shoot()
    {


        //if (muzzleFlashPrefab)
        //{
        //    //Create the muzzle flash
        //    GameObject tempFlash;
        //    tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);

        //    //Destroy the muzzle flash effect
        //    Destroy(tempFlash, destroyTimer);
        //}

        ////cancels if there's no bullet prefeb
        //if (!bulletPrefab)
        //{ return; }

        //// Create a bullet and add force on it in direction of the barrel
        //Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation).GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);

        GameObject tempFlash;

        this.GetComponent<Animator>().Play("Fire");

        Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation).GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);

        tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);

        RaycastHit hitInfo;

        //bool hasHit = Physics.Raycast(barrelLocation.position, barrelLocation.forward, out hitInfo, 100);

        if (Physics.Raycast(barrelLocation.position, barrelLocation.forward, out hitInfo))
        {
            Debug.Log(hitInfo.transform.name);
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, barrelLocation.transform.GetComponentInParent<Transform>().position);
            lineRenderer.SetPosition(1, hitInfo.transform.position);
        }
        else
        {
            //lineRenderer.enabled = false;
        }
        //if (line)
        //{

        //    GameObject liner = Instantiate(line);
        //    liner.GetComponent<LineRenderer>().SetPositions(new Vector3[] {barrelLocation.position, hasHit ? hitInfo.point :
        //    barrelLocation.position + barrelLocation.forward * 100});
        //    Destroy(liner, 0.5f);

        //}
            


    }

    //This function creates a casing at the ejection slot
    void CasingRelease()
    {
        //Cancels function if ejection slot hasn't been set or there's no casing
        if (!casingExitLocation || !casingPrefab)
        { return; }

        //Create the casing
        GameObject tempCasing;
        tempCasing = Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation) as GameObject;
        //Add force on casing to push it out
        tempCasing.GetComponent<Rigidbody>().AddExplosionForce(Random.Range(ejectPower * 0.7f, ejectPower), (casingExitLocation.position - casingExitLocation.right * 0.3f - casingExitLocation.up * 0.6f), 1f);
        //Add torque to make casing spin in random direction
        tempCasing.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(100f, 1000f)), ForceMode.Impulse);

        //Destroy casing after X seconds
        Destroy(tempCasing, destroyTimer);
    }

    private void OnDrawGizmos()
    {
        //Gizmos.DrawLine(barrelLocation.position, testObj.transform.position);
    }

}
