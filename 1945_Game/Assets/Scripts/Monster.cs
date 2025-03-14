using UnityEngine;

public class Monster : MonoBehaviour
{
    public float Speed = 3;
    public float Delay = 1f;
    public Transform ms1;
    public Transform ms2;
    public GameObject bullet;
    public GameObject item;


    void Start()
    {
        //한번 함수 호출
        Invoke("CreateBullet", Delay);
    }

    
    void Update()
    {
        //아래 방향으로 움직여라
        transform.Translate(Vector3.down * Speed * Time.deltaTime);
    }

    void CreateBullet()
    {
        Instantiate(bullet, ms1.position, Quaternion.identity);
        Instantiate(bullet, ms2.position, Quaternion.identity);

        //재귀 호출
        //아니면 Coroutine 쓰면 됨 update에 넣으면 어캐되는거지
        Invoke("CreateBullet", Delay);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    //미사일에 따른 데미지 입는 함수
    public void Damage(int attack)
    {
        ItemDrop();
        Destroy(gameObject);
    }

    public void ItemDrop()
    {
        //아이템 생성
        Instantiate(item, transform.position, Quaternion.identity);
    }
}
