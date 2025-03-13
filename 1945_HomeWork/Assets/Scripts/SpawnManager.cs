using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject Enemy;


    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0, 0.1f);
    }

    
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        float randomX = Random.Range(-2.5f, 2.5f);

        Instantiate(Enemy, new Vector3(randomX, transform.position.y), Quaternion.identity);
    }


}
