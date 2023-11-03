using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public GunController gunControllerScript;

    private void Awake()
    {
        gunControllerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<GunController>();
    }

    private void Update()
    {
        if (gunControllerScript.hitInfo.collider)
        {
            //GunController.gunControllerInstance.isFired = false;
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject, 5.0f);
        }

        //var temp2 = this;
    }

}
