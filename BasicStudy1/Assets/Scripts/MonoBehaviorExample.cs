using UnityEngine;

public class MonoBehaviorExample : MonoBehaviour
{
    
    void Start()
    {
        Debug.Log("Start : 게임이 시작될 때 호출됩니다.");
    }

    
    void Update()
    {
        Debug.Log("Update : 프레임마다 호출됩니다.");
    }

    private void FixedUpdate()
    {
        Debug.Log("fixedupdate : 물리 연산에 사용됩니다.");
    }

    //ctrl+shift+m
}
