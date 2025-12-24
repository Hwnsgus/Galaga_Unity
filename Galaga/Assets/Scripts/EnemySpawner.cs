using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float height = 10.0f; // 배경 높이를 기준으로 설정
    public float spawnInterval = 1.5f; // 적 생성 간격을 1.5초로 늘림

    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
    }

    IEnumerator SpawnEnemyRoutine()
    {
        while (true)
        {
            // 1. 화면 밖 상단에서 랜덤한 X 위치 계산
            float randomX = Random.Range(-3.5f, 3.5f);
            // height 값(10)에 여유분을 더해 화면 밖에서 생성되도록 설정
            Vector3 spawnPos = new Vector3(randomX, height + 2.0f, 0);

            // 2. 적 생성
            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);

            // 3. 지정된 시간만큼 대기
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}