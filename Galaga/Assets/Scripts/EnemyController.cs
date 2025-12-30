using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 3.0f;
    private Transform playerTarget;

    void Start()
    {
        // 게임 시작 시 "Player"라는 이름의 오브젝트를 찾아서 타겟으로 설정
        GameObject playerObj = GameObject.Find("Player");
        if (playerObj != null)
        {
            playerTarget = playerObj.transform;
        }
    }

    void Update()
    {
        // 플레이어가 살아있다면 플레이어 쪽으로 이동
        if (playerTarget != null)
        {
            // 방향 = (목표 위치 - 내 위치).정규화
            Vector3 direction = (playerTarget.position - transform.position).normalized;

            // 그 방향으로 이동
            transform.Translate(direction * speed * Time.deltaTime);
        }
        else
        {
            // 플레이어가 없으면(죽었으면) 그냥 아래로 직진
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }

        // 화면 아래로 멀리 사라지면 삭제 (메모리 정리)
        if (transform.position.y < -15.0f)
        {
            Destroy(gameObject);
        }
    }

    // (선택사항) 플레이어와 부딪히면 적 삭제
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Bullet"))
        {
            // 여기에 폭발 효과 등을 넣을 수 있습니다.
            Destroy(gameObject); // 일단 적 삭제
        }
    }
}