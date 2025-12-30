// PlayerController.cs
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 15.0f;
    public GameObject bulletPrefab; // 인스펙터에서 총알 프리팹 연결
    public Transform firePoint;     // 총알이 나갈 위치 (플레이어 머리 끝)

    // 공격 속도 조절 변수
    public float fireRate = 0.3f; // 0.15초마다 발사 (숫자가 클수록 느리게 나감)
    private float nextFireTime = 0.0f; // 다음 발사 가능 시간을 저장할 변수

    void Update()
    {
        // 1. 플레이어 이동 (화살표 키)
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        transform.Translate(new Vector2(h, v) * moveSpeed * Time.deltaTime);

        // 2. 총알 발사 (스페이스바)
        if (Input.GetKey(KeyCode.Space) && Time.time >= nextFireTime)
        {
            // 다음 발사 시간 갱신 (현재 시간 + 쿨타임)
            nextFireTime = Time.time + fireRate;

            Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        }
    }
}