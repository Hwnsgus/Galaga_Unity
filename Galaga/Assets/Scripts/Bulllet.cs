// Bullet.cs (총알 자체의 이동 로직)
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10.0f;

    void Update()
    {
        // 위로 날아감
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        // 메모리 관리를 위해 2초 뒤 자동 삭제
        Destroy(gameObject, 2.0f);
    }
}