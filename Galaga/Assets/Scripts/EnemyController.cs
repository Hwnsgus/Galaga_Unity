using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 3.0f;
    private Transform player;

    void Start()
    {
        // 게임 시작 시 "Player"라는 이름의 오브젝트를 찾아서 타겟으로 설정
        GameObject playerObj = GameObject.Find("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
    }

    void Update()
    {
        // 플레이어가 살아있다면 플레이어 쪽으로 이동
        if (player != null)
        {
            // 방향 = (목표 위치 - 내 위치).정규화
            Vector3 direction = (player.position - transform.position).normalized;

            // 그 방향으로 이동
            transform.Translate(direction * speed * Time.deltaTime);
        }
        else


        {
            // 플레이어가 없으면(죽었으면) 그냥 아래로 직진
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }

        // [수정된 부분] 
        // 1. 카메라의 현재 Y 위치를 가져옵니다.
        float cameraY = Camera.main.transform.position.y;
        // 2. 카메라의 세로 절반 크기(Size)를 가져옵니다.
        float cameraHeight = Camera.main.orthographicSize;

        // 3. 정확한 화면 아래쪽 끝 좌표 계산 (카메라 위치 - 절반 크기)
        float bottomEdge = cameraY - cameraHeight;

        // 4. 화면 아래 끝보다 2.0f만큼 더 내려가면 삭제
        if (transform.position.y < bottomEdge - 2.0f)
        {
            Destroy(gameObject);
        }
    }

    // [충돌 감지 함수 추가]
    void OnTriggerEnter2D(Collider2D other)
    {
        // 1. 총알에 맞았을 때
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject); // 총알 삭제
            Destroy(gameObject);       // 적(나 자신) 삭제
        }

        // 2. 플레이어와 부딪혔을 때
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject); // 플레이어 삭제
            Destroy(gameObject);       // 적(나 자신) 삭제

            // (선택) 게임 오버 연출이나 Time.timeScale = 0; 등을 여기에 추가
            Debug.Log("게임 오버!");
        }
    }
}

    //// (선택사항) 플레이어와 부딪히면 적 삭제
    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.CompareTag("Player") || other.CompareTag("Bullet"))
    //    {
    //        // 여기에 폭발 효과 등을 넣을 수 있습니다.
    //        Destroy(gameObject); // 일단 적 삭제
    //    }
    //}