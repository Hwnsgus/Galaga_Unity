using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    [Header("스폰 시간 설정 (최소 ~ 최대)")]
    public float minSpawnTime = 1.0f; // 최소 대기 시간
    public float maxSpawnTime = 3.0f; // 최대 대기 시간

    [Header("위치 설정")]
    public float xMargin = 0.5f; // 화면 끝에서 얼마나 띄울지 (여백)

    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
    }

    IEnumerator SpawnEnemyRoutine()
    {
        while (true)
        {
            // 1. 대기 시간부터 먼저 가짐 (게임 시작하자마자 쏟아지는 것 방지)
            // 최소~최대 사이의 랜덤한 시간만큼 기다림
            float waitTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSecondsRealtime(waitTime);

            // -------------------------------------------------------

            // 2. 화면 크기 계산
            float verticalLimit = Camera.main.orthographicSize;
            // 화면 가로 절반 크기
            float horizontalLimit = verticalLimit * Camera.main.aspect;

            // 3. X 위치 랜덤 계산 (마진 적용)
            // 기존: -limit ~ limit (완전 끝까지)
            // 변경: (-limit + 여백) ~ (limit - 여백) -> 화면 안쪽으로 조금 들어옴
            float minX = -horizontalLimit + xMargin;
            float maxX = horizontalLimit - xMargin;
            float spawnX = Random.Range(minX, maxX);

            // 4. Y 위치 (화면 위쪽 밖)
            float spawnY = verticalLimit + 2.0f;

            // 5. 적 생성
            Vector3 spawnPos = new Vector3(spawnX, spawnY, 0);
            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        }
    }
}