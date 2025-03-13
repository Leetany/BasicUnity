using UnityEngine;
using UnityEngine.UI;

public class GameManger : MonoBehaviour
{
    //얘도 싱글톤

    public static GameManger instance;
    public Text scoreText;

    int score = 0;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void AddScore(int num)
    {
        score += num;
        scoreText.text = "Score : " + score;
    }
}
