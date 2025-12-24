using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float speed = 2.0f;
    public float height = 10.0f; // 배경 이미지의 세로 높이

    void Update()
    {
        // 1. 아래로 이동
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // 2. 화면 아래로 사라지면 다시 위로 올림 (위치 리셋)
        if (transform.position.y < -height)
        {
            transform.position += new Vector3(0, height * 2, 0);
        }
    }
}