using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    [Header("스폰 시간 설정 (최소 ~ 최대)")]
    public float minSpawnTime = 1.0f; // 최소 대기 시간
    public float maxSpawnTime = 3.0f; // 최대 대기 시간

    public float xMargin = 30.0f;
    public float spawnInterval = 1.0f; //

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

            // 1. 카메라 정보 가져오기
            float camSize = Camera.main.orthographicSize; // 300
            float camAspect = Camera.main.aspect;         // 화면 비율 (예: 9/16)

            // 카메라의 가로 절반 너비 계산
            float halfWidth = camSize * camAspect;

            // 2. 카메라의 현재 중심 위치 가져오기 (X: 114, Y: -130)
            Vector3 camPos = Camera.main.transform.position;
            // 3. X 위치 랜덤 계산 (마진 적용)
            // 기존: -limit ~ limit (완전 끝까지)
            // 변경: (-limit + 여백) ~ (limit - 여백) -> 화면 안쪽으로 조금 들어옴
            float minX = camPos.x - halfWidth + xMargin;
            float maxX = camPos.x + halfWidth - xMargin;

            float spawnX = Random.Range(minX, maxX);

            // 4. Y 위치 (화면 위쪽 밖)
            float spawnY = camPos.y + camSize + 50.0f;

            // 5. 적 생성
            Vector3 spawnPos = new Vector3(spawnX, spawnY, 0);
            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
            yield return new WaitForSecondsRealtime(spawnInterval);
        }
    }
}