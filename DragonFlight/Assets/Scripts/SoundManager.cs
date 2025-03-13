using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //싱글톤 
    public static SoundManager instance; // 자기자신을 변수로 담기

    AudioSource myAudio; //AudioSource 컴포넌트를 변수로 담는다.

    public AudioClip SoundBullet; //재생할 소리
    public AudioClip soundDie;    //죽는 소리

    private void Awake()
    {
        if(SoundManager.instance == null)  //인스턴스있는지 검사
        {
            SoundManager.instance = this;  //자기자신을 담는다.
        }
    }


    void Start()
    {
        myAudio = GetComponent<AudioSource>();  //AudioSource 컴포넌트 가져오기
    }

    public void PlayBulletSound()
    {
        myAudio.PlayOneShot(SoundBullet);
    }
    
    public void SoundDie()
    {
        myAudio.PlayOneShot(soundDie);  //몬스터 죽음 사운드
    }
}
