using UnityEngine;

public class VectorStudy : MonoBehaviour
{
    //public Vector2 v2 = new Vector2(10, 10);
    //public Vector3 v3 = new Vector3(1, 1, 1);
    //public Vector4 v4 = new Vector4(1.0f, 0.5f, 0.0f, 1.0f);   //�� ǥ���� �� ���

    void Start()
    {
        /*Vector3 a = new Vector3(1, 1, 0);
        Vector3 b = new Vector3(2, 0, 0);

        Vector3 c = a + b;

        Debug.Log("Vector" + c);

        Debug.Log("���� : " + c.magnitude);*/

        //����ȭ normalize
        //������ ũ�⸦ 1�� ����� ���⸸ ����
        Vector3 a = new Vector3(3, 0, 0);

        Vector3 normalizedVector = a.normalized;

        Debug.Log("1�� ���� ���⸸ �����ϴ� ����ȭ " + normalizedVector);


    }

    
    void Update()
    {
        
    }
}
