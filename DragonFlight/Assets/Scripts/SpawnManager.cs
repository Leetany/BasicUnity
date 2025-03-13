using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject MiddleEnemy1;
    public GameObject MiddleEnemy2;
    public GameObject Boss;

    //적을 생성하는 함수
    void SpawnEnemy()
    {
        float randomX = Random.Range(-2f, 2f); //적이 나타날 x좌표를 랜덤으로 생성하기

        //적을 생성한다. randomX 랜덤한 x값
        Instantiate(Enemy, new Vector3(randomX, transform.position.y), Quaternion.identity);
    }

    void SpawnMiddleEnemy1()
    {
        float randomX = Random.Range(-2f, 2f);

        Instantiate(MiddleEnemy1, new Vector3(randomX, transform.position.y), Quaternion.identity);
    }
    void SpawnMiddleEnemy2()
    {
        float randomX = Random.Range(-2f, 2f);

        Instantiate(MiddleEnemy2, new Vector3(randomX, transform.position.y), Quaternion.identity);
    }

    void SpawnBoss()
    {
        Instantiate(Boss, new Vector3(0, 8), Quaternion.identity);
    }

    void Start()
    {
        //SpawnEnemy  1  0.5f 
        InvokeRepeating("SpawnEnemy", 3, 0.5f);
        InvokeRepeating("SpawnMiddleEnemy1", 7, 5f);
        InvokeRepeating("SpawnMiddleEnemy2", 10, 5f);
        Invoke("SpawnBoss", 34f);
        Invoke("StopRepeating", 30f);
    }

    void StopRepeating()
    {
        CancelInvoke("SpawnEnemy");
        CancelInvoke("SpawnMiddleEnemy1");
        CancelInvoke("SpawnMiddleEnemy2");
    }
    
    void Update()
    {
        
    }
}
