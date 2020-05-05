using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class SimpleShoot : MonoBehaviour
{
    public XRController hand;
    private InputDevice controller;
    public GameObject bulletPrefab;
    public GameObject casingPrefab;
    public GameObject muzzleFlashPrefab;
    public Transform barrelLocation;
    public Transform casingExitLocation;
    public AbleToShoot head;
    bool triggerDown;
    bool previousDown;

    public float shotPower = 100f;
    private void Awake()
    {
        triggerDown = false;
        previousDown = false;
    }
    void Start()
    {
        if (barrelLocation == null)
            barrelLocation = transform;
    }

    void Update()
    {

        controller = InputDevices.GetDeviceAtXRNode(hand.controllerNode);
     



        controller.TryGetFeatureValue(CommonUsages.triggerButton, out triggerDown);
        if (triggerDown && !previousDown &&!head.colliding )
        {
            GetComponent<Animator>().SetTrigger("Fire");
           //Shoot();


        }
        previousDown = triggerDown;
       
        
    }

    void Shoot()
    {
        //  GameObject bullet;
        //  bullet = Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation);
        // bullet.GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);

        GameObject tempFlash;
       Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation).GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);
       tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);

       // Destroy(tempFlash, 0.5f);
        //  Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation).GetComponent<Rigidbody>().AddForce(casingExitLocation.right * 100f);
       
    }

    void CasingRelease()
    {
         GameObject casing;
        casing = Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation) as GameObject;
        casing.GetComponent<Rigidbody>().AddExplosionForce(550f, (casingExitLocation.position - casingExitLocation.right * 0.3f - casingExitLocation.up * 0.6f), 1f);
        casing.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(10f, 1000f)), ForceMode.Impulse);
    }


}
