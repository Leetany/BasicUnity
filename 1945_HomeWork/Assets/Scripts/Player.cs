using UnityEngine;

public class Player : MonoBehaviour
{
    //스피드
    public float moveSpeed = 5f;
    //프로그래밍으로 화면 못나가게 하기
    //private Vector2 minBounds;
    //private Vector2 maxBounds;

    Animator ani;  //애니메이터를 가져올 변수

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

            transform.Translate(moveX, moveY, 0);

        //프로그래밍으로 화면 못나가게 하기
        //Vector3 newPosition = transform.position + new Vector3(moveX, moveY, 0);

        //newPosition.x = Mathf.Clamp(newPosition.x, minBounds.x, maxBounds.x);
        //newPosition.y = Mathf.Clamp(newPosition.y, minBounds.y, maxBounds.y);

        //transform.position = newPosition;
    }
}
