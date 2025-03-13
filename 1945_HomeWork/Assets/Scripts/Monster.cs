using UnityEngine;

public class Monster : MonoBehaviour
{
    public float moveSpeed = 1f;
    void Start()
    {
        
    }

    
    void Update()
    {
        float distanceY = moveSpeed * Time.deltaTime;
        transform.Translate(0, -distanceY, 0);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
