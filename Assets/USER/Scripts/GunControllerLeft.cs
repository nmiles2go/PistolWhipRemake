using UnityEngine;

public class GunControllerLeft : MonoBehaviour
{
    public float range = 1000f;

    public Transform barrelLocation;
    public GameObject bulletPrefab;

    public GameObject muzzleFlash;
    public float shotPower = 100000f;
    public GameObject line;

    public int maxAmmo = 10;
    public int currentAmmo;
    public RaycastHit hitInfo;

    public AudioSource source;

    public AudioSource fire;
    public AudioSource reload;
    public AudioSource empty;

    [SerializeField] public bool isFired = false;

    bool checkAmmo = true;

    ////Making this script a singleton
    //public static GunController gunControllerInstance;

    //private void Awake()
    //{
    //    gunControllerInstance = this;
    //}

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
        {
            if (currentAmmo > 0)
            {
                shoot();
            }
            else
                empty.Play();

        }
        if (Vector3.Angle(transform.up, Vector3.up) > 100 && currentAmmo < maxAmmo)
        {
            Reload();
        }

    }

    void shoot()
    {

        fire.Play();
        Instantiate(muzzleFlash, barrelLocation.position, barrelLocation.rotation);
        GameObject gb = Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation);
        gb.GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);
        currentAmmo--;

        bool hasHit = Physics.Raycast(barrelLocation.transform.position, barrelLocation.transform.forward, out hitInfo, range);



        if (hitInfo.collider.gameObject.tag == "Target")
        {
            Destroy(hitInfo.collider.gameObject);
            Destroy(gb);
        }
        //Debug.Log(hitInfo.transform.name);

        //var temp1 = this;
    }

    void Reload()
    {
        currentAmmo = maxAmmo;
        reload.Play();
    }




}


