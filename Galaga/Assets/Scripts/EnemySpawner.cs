using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 60.0f; // 1분 (테스트할 땐 1초로 줄여서 하세요!)

    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
    }

    IEnumerator SpawnEnemyRoutine()
    {
        while (true)
        {
            // 1. 카메라의 현재 크기를 기준으로 화면 밖 좌표 계산
            // Camera.main.orthographicSize는 화면 세로 절반 크기입니다.
            float verticalLimit = Camera.main.orthographicSize;
            float horizontalLimit = verticalLimit * Camera.main.aspect; // 가로 크기 계산

            // 2. 화면 위쪽 밖(Y)에서 생성
            float spawnY = verticalLimit + 2.0f;

            // 3. 좌우(X) 랜덤 위치 (화면 폭 내에서)
            float spawnX = Random.Range(-horizontalLimit, horizontalLimit);

            Vector3 spawnPos = new Vector3(spawnX, spawnY, 0);

            // 4. 적 생성
            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);

            // 5. 지정된 시간(60초)만큼 대기
            yield return new WaitForSecondsRealtime(spawnInterval);
        }
    }
}