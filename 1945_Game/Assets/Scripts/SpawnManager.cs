﻿using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnManager : MonoBehaviour
{
    public float ss = -2;   //몬스터 생성 x값 처음
    public float es = 2;    //몬스터 생성 y값 끝
    public float StartTime = 1;  //시작
    public float SpawnStop = 10;  //스폰끝나는 시간
    public GameObject monster;
    public GameObject monster2;
    public GameObject Boss;

    bool swi = true;
    bool swi2 = true;

    [SerializeField]
    GameObject textBossWarning;

    private void Awake()
    {
        textBossWarning.SetActive(false);

        PoolManager.Instance.CreatePool(monster, 10);
    }
    void Start()
    {
        StartCoroutine(RandomSpawn());
        Invoke("Stop", SpawnStop);
    }
    
    //코루틴으로 랜덤하게 생성하기
    IEnumerator RandomSpawn()
    {
        while(swi)
        {
            //1초마다
            yield return new WaitForSeconds(StartTime);
            //x값 랜덤
            float x = Random.Range(ss, es);
            //y값은 자기자신 값
            Vector2 r = new Vector2(x, transform.position.y);
            Instantiate(monster, r, Quaternion.identity);
            //GameObject Enemy = PoolManager.Instance.Get(monster);
            //Enemy.transform.position = r;
        }
    }

    //코루틴으로 랜덤하게 생성하기
    IEnumerator RandomSpawn2()
    {
        while (swi2)
        {
            //1초마다
            yield return new WaitForSeconds(StartTime+2);
            //x값 랜덤
            float x = Random.Range(ss, es);
            //y값은 자기자신 값
            Vector2 r = new Vector2(x, transform.position.y);
            Instantiate(monster2, r, Quaternion.identity);
        }
    }

    void Stop()
    {
        swi = false;
        StopCoroutine("RandomSpawn");
        //두번째 몬스터 코루틴
        StartCoroutine(RandomSpawn2());

        Invoke("Stop2", SpawnStop + 20);
    }

    void Stop2()
    {
        swi2 = false;
        StopCoroutine("RandomSpawn2");
        textBossWarning.SetActive(true);
        StartCoroutine(Shake());
        //보스
        Vector3 targetpos = new Vector3(0, 2.97f, 0);
        GameObject go = Instantiate(Boss, targetpos, Quaternion.identity);
    }

    IEnumerator Shake()
    {
        yield return new WaitForSeconds(0.2f);
        CameraShake.instance.CameraShakeShow();
        yield return new WaitForSeconds(0.2f);
        CameraShake.instance.CameraShakeShow();
        yield return new WaitForSeconds(0.2f);
        CameraShake.instance.CameraShakeShow();
    }
}
