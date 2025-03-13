using UnityEngine;

public class MiddleEnemy : MonoBehaviour
{
    public float moveSpeed = 1.3f;
    public static int life;

    void Start()
    {
        life = 2;
    }

    
    void Update()
    {
        //움직일 거리
        float distanceY = moveSpeed * Time.deltaTime;
        //움직임 반영
        transform.Translate(0, -distanceY, 0);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);  //객체를 삭제한다.
    }


}
