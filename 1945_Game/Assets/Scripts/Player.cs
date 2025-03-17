using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    //스피드
    public float moveSpeed = 5f;
    //프로그래밍으로 화면 못나가게 하기
    //private Vector2 minBounds;
    //private Vector2 maxBounds;

    Animator ani;  //애니메이터를 가져올 변수

    public GameObject[] bullet;  //총알 추후 4개 배열로 만들 예정
    public Transform pos = null;    //발사 위치?

    

    public int power = 0;

    [SerializeField]
    private GameObject powerup;  //private 인스펙터에서 사용하는 방법

    //레이저
    public GameObject lazer;
    public float gValue = 0;

    void Start()
    {
        //프로그래밍으로 화면 못나가게 하기
        //Camera cam = Camera.main;
        //Vector3 bottomLeft = cam.ViewportToWorldPoint(new Vector3(0, 0, 0));
        //Vector3 topRight = cam.ViewportToWorldPoint(new Vector3(1, 1, 0));

        //minBounds = new Vector2(bottomLeft.x, bottomLeft.y);
        //maxBounds = new Vector2(topRight.x, topRight.y);

        ani = GetComponent<Animator>();
    }


    void Update()
    {
        //방향키에 따른 움직임
        float moveX = moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        float moveY = moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");

        // -1 ~ 0 ~ 1 정도 GetAxis 범위
        if (Input.GetAxis("Horizontal") <= -0.5f)
            ani.SetBool("left", true);
        else
            ani.SetBool("left", false);

        if (Input.GetAxis("Horizontal") >= 0.5f)
            ani.SetBool("right", true);
        else
            ani.SetBool("right", false);

        if (Input.GetAxis("Vertical") >= 0.5f)
            ani.SetBool("up", true);
        else
            ani.SetBool("up", false);
        
        //스페이스바
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //프리팹 위치 방향 넣고 생성
            Instantiate(bullet[power], pos.position, Quaternion.identity);
        }
        else if(Input.GetKey(KeyCode.Space))
        {
            gValue += Time.deltaTime;

            if(gValue >=1)
            {
                GameObject go = Instantiate(lazer, pos.position, Quaternion.identity);
                Destroy(go, 2);
                gValue = 0;
            }
        }
        else
        {
            gValue -= Time.deltaTime;

            if(gValue <= 0)
            {
                gValue = 0;
            }
        }



            transform.Translate(moveX, moveY, 0);

        //캐릭터의 월드 좌표를 뷰 포트 좌표계로 변환해준다.
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        viewPos.x = Mathf.Clamp01(viewPos.x);
        viewPos.y = Mathf.Clamp01(viewPos.y);
        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);
        transform.position = worldPos;

        //프로그래밍으로 화면 못나가게 하기
        //Vector3 newPosition = transform.position + new Vector3(moveX, moveY, 0);

        //newPosition.x = Mathf.Clamp(newPosition.x, minBounds.x, maxBounds.x);
        //newPosition.y = Mathf.Clamp(newPosition.y, minBounds.y, maxBounds.y);

        //transform.position = newPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Item"))
        {
            power += 1;
            if (power >= 3)
            {
                power = 3;
            }
            else
            {
                //파워업
                GameObject go = Instantiate(powerup, transform.position, Quaternion.identity);
                Destroy(go, 1);
            }

            //아이템 먹은 처리
            Destroy(collision.gameObject);
        }
    }

}
