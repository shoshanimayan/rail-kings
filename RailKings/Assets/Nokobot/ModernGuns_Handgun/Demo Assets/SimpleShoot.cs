using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.UI;
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
    private int ammo;
    public Text ammoCount;
    public float shotPower = 100f;
    private void Awake()
    {
        ammo = 5;
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
        if (triggerDown && !previousDown &&!head.colliding && ammo > 0)
        {
            GetComponent<Animator>().SetTrigger("Fire");
        }
        previousDown = triggerDown;
    }

    void Reload() {
        ammo = 5;
        ammoCount.text = ammo.ToString();

    }
    void Shoot()
    {
        if (ammo > 0)
        {
            GameObject tempFlash;
            Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation).GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);
            ammo--;
            ammoCount.text = ammo.ToString();
            tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);
        }
    }

    void CasingRelease()
    {
         GameObject casing;
        casing = Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation) as GameObject;
        casing.GetComponent<Rigidbody>().AddExplosionForce(550f, (casingExitLocation.position - casingExitLocation.right * 0.3f - casingExitLocation.up * 0.6f), 1f);
        casing.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(10f, 1000f)), ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag=="reload") {
            Reload();
            Debug.Log("reload");
        }
    }
}
