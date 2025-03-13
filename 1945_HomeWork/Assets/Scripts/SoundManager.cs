using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //이 친구는 싱글톤 연습해보자
    //사운드는 여기서 다 해주니 싱글톤으로 해주는게 좋을 듯

    public static SoundManager instance; //자기자신을 변수로 쓸걸?

    AudioSource myAudio;    //AudioSource 컴포넌트 변수 담아야지

    public AudioClip SoundBullet;  //처음 총알 소리
    public AudioClip MonsterDie;

    private void Awake()
    {
        if(SoundManager.instance == null)      //인스턴스 있는지 검사
        {
            SoundManager.instance = this;      //자기자신 담아야함.
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        myAudio = GetComponent<AudioSource>();  
    }

    public void PlayBulletSound()
    {
        myAudio.PlayOneShot(SoundBullet);
    }

    public void PlayMonsterDie()
    {
        myAudio.PlayOneShot(MonsterDie);
    }
}
