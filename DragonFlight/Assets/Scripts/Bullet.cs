using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 0.45f;
    public GameObject explosion;
    public GameObject explosionBoss;


    void Start()
    {
        Singleton.instance.PrintMessage();
    }

    
    void Update()
    {
        //Y축 이동
        transform.Translate(0, moveSpeed * Time.deltaTime, 0);
    }

    private void OnBecameInvisible()
    {
        //미사일이 화면 밖으로 나갔으면
        //미사일 지우기
        Destroy(gameObject);
    }


    //2D충돌 트리거이벤트
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //미사일과 적이 부딪혔다
        //if (collision.gameObject.tag == "Enemy")
        if (collision.gameObject.CompareTag("Enemy"))    //이게 더 안전함 (이거는 GC가 안 먹는다 하네요)
        {
            //폭발 이펙트 생성
            Instantiate(explosion, transform.position, Quaternion.identity);
            //죽음사운드
            SoundManager.instance.SoundDie();  //적 죽음 사운드
            //점수올려주기
            GameManager.instance.AddScore(10);


            //적 지우기
            Destroy(collision.gameObject);
            //총알 지우기 자기자신(gameObject)
            Destroy(gameObject);
        }

        if(collision.gameObject.CompareTag("MiddleEnemy"))
        {
            MiddleEnemy.life--;
            Debug.Log(MiddleEnemy.life);
            if(MiddleEnemy.life <= 0)
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                SoundManager.instance.SoundDie();
                GameManager.instance.AddScore(100);
                Destroy(collision.gameObject);
            }
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Boss"))
        {
            BossEnemy.life--;
            Debug.Log(BossEnemy.life);
            if (BossEnemy.life <= 0)
            {
                Instantiate(explosionBoss, transform.position, Quaternion.identity);
                SoundManager.instance.SoundDie();
                GameManager.instance.AddScore(100);
                Destroy(collision.gameObject);
            }
            Destroy(gameObject);
        }
    }

}
