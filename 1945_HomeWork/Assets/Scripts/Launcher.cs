using UnityEngine;

public class Launcher : MonoBehaviour
{
    public GameObject bullet;

    void Start()
    {
        
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            InvokeRepeating("Shoot", 0f, 0.1f);
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke("Shoot");
        }
    }

    void Shoot()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
        SoundManager.instance.PlayBulletSound();
    }
}
