using UnityEditor.SceneTemplate;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;

    Animator ani;

    public GameObject[] bullet;
    public Transform pos = null;

    public int power = 0;

    [SerializeField]
    private GameObject powerup;

    void Start()
    {
        ani = GetComponent<Animator>();
    }

    
    void Update()
    {
        float moveX = moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        float moveY = moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");

        if (Input.GetAxis("Horizontal") <= -0.3f)
            ani.SetBool("left", true);
        else
            ani.SetBool("left", false);

        if (Input.GetAxis("Horizontal") >= 0.3f)
            ani.SetBool("right", true);
        else
            ani.SetBool("right", false);

        if (Input.GetAxis("Vertical") >= 0.3f)
            ani.SetBool("up", true);
        else
            ani.SetBool("up", false);

        transform.Translate(moveX, moveY, 0);
    }
}
