using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    public float shootingDistance = 3f;
    public float shootingInterval = 1.5f;
    public float chasingDistance = 10f;
    public float chasingInterval = 3f;

    public Transform target;
    public GameObject bulletPrefab;

    private float chasingTimer;
    private float shootingTimer;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        if (target == null)
        {
            target = GameObject.Find("Player").transform;
        }

        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // Shooting logic.
        shootingTimer -= Time.deltaTime;
        if (shootingTimer <= 0 && Vector3.Distance(target.position, this.transform.position) <= shootingDistance)
        {
            shootingTimer = shootingInterval;

            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.position = transform.position + new Vector3(0, 1, 0);
            bullet.transform.forward = (target.position - transform.position).normalized;
        }

        // Chasing logic.
        chasingTimer -= Time.deltaTime;
        if (chasingTimer <= 0 && Vector3.Distance(target.position, this.transform.position) <= chasingDistance)
        {
            chasingTimer = chasingInterval;

            agent.SetDestination(target.position);
        }
    }
}
