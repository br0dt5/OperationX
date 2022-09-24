using UnityEngine;

public class ShootingMechanic : MonoBehaviour
{
    public GameObject gunObject;
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.position = gunObject.transform.position + gunObject.transform.forward;
            bullet.transform.forward = gunObject.transform.forward;
        }
    }
}
