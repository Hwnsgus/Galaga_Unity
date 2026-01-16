using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    [Header("스폰 시간 설정 (최소 ~ 최대)")]
    public float minSpawnTime = 1.0f; // 최소 대기 시간
    public float maxSpawnTime = 3.0f; // 최대 대기 시간

    [Header("위치 설정")]
    public float xMargin = 30.0f; // 생성시 좌우 여유 공간

    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
    }

    IEnumerator SpawnEnemyRoutine()
    {
        while (true)
        {
            // 1. 랜덤한 시간만큼 대기
            float waitTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSecondsRealtime(waitTime);

            // -------------------------------------------------------

            // 2. 카메라 정보 가져오기
            float camSize = Camera.main.orthographicSize;
            float camAspect = Camera.main.aspect;

            float halfWidth = camSize * camAspect;

            // 3. 스폰 위치 계산
            Vector3 camPos = Camera.main.transform.position;

            float minX = camPos.x - halfWidth + xMargin;
            float maxX = camPos.x + halfWidth - xMargin;

            float spawnX = Random.Range(minX, maxX);
            float spawnY = camPos.y + camSize + 50.0f;

            // 4. 적 생성
            Vector3 spawnPos = new Vector3(spawnX, spawnY, 0);
            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);

        }
    }
}