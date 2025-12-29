using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 50.0f;

    void Update()
    {
        // 1. 위로 날아감
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        // 2. 화면 밖으로 나가면 삭제 (위치 기준)
        // 화면 세로 크기(Size)가 5라면, 위쪽 끝은 y=5입니다. 
        // 여유 있게 6.0f 정도 넘어가면 삭제되도록 합니다.
        if (transform.position.y > 170.0f)
        {
            Destroy(gameObject);
        }
    }
}