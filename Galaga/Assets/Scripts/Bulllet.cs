using UnityEngine;

public class Bullet : MonoBehaviour
{
    //탄환 속도
    public float speed = 50.0f;

    void Update()
    {
        // 1. 위로 날아감
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        // 2. 화면 밖으로 나가면 삭제 (위치 기준)
        // 화면 세로 크기(Size)가 5라면, 위쪽 끝은 y=5 
        if (transform.position.y > 170.0f)
        {
            Destroy(gameObject);
        }
    }
}