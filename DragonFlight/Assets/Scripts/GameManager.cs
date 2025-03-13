using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //싱글톤
    //어디에서나 접근 할 수 있도록 static(정적)으로 자기자신을 저장해서 싱글톤이라는 디자인패턴을 
    //사용해본다.
    public static GameManager instance;
    public Text scoreText;   //점수를 표시하는 Text객체를 에디터에서 받아옵니다.
    public Text StartText;   //게임 시작 전 3, 2, 1
    public Text BossComing;  //보스 나오는 표시

    int score = 0;  //점수를 관리합니다.

    private void Awake()
    {
        if(instance == null)   //정적으로 자신을 체크합니다. null인지
        {
            instance = this;   //자기자신을 저장한다.
        }
    }

    void Start()
    {
        StartCoroutine("StartGame");
        StartCoroutine("BossSign");
    }

    IEnumerator StartGame()
    {
        int i = 3;

        while(i>0)
        {
            StartText.text = i.ToString();

            yield return new WaitForSeconds(1);

            i--;

            if(i == 0)
            {
                StartText.gameObject.SetActive(false);  //UI감추기
            }
        }
    }

    IEnumerator BossSign()
    {
        int i = 3;

        yield return new WaitForSeconds(31);

        while (i>0)
        {
            BossComing.text = "BOSS";

            yield return new WaitForSeconds(1f);

            BossComing.text = " ";

            yield return new WaitForSeconds(1f);

            i--;

            if(i == 0)
            {
                BossComing.gameObject.SetActive(false);
            }
        }
    }


    public void AddScore(int num)
    {
        score += num; //점수를 더해줍니다.
        scoreText.text = "Score : " + score;   //텍스트에 반영합니다.
    }


}
