using Unity.VisualScripting;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    public float moveSpeed = 1.3f;
    public static int life;

    void Start()
    {
        life = 20;
    }
    void Update()
    {
        float distanceY = moveSpeed * Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position, new Vector3(0, 3), distanceY);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);  //객체를 삭제한다.
    }
}
