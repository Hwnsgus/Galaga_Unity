)
🚀 Galaga Style_Unity
Unity와 C#을 활용하여 개발한 2D 종스크롤 슈팅 게임입니다.

📸 In-Game Screenshots
<div align="center"> <img width="307" height="517" alt="스크린샷 2026-01-07 164019" src="https://github.com/user-attachments/assets/749bb9eb-a44e-4310-a568-8a5576cbe088" alt="Gameplay" width="600" /> </div>

🧩 System Architecture (UML)
본 프로젝트는 각 클래스가 단일 책임 원칙(SRP)을 준수하도록 설계되었습니다.

Player System: 플레이어의 입력 처리 및 공격 로직 담당

Enemy System: 적 생성(Spawner)과 개별 적의 추적 AI(Controller) 분리

Environment: 무한 스크롤 배경 처리를 통한 공간감 구현

✨ Key Features & Implementation Logic
1. 추적형 적 AI (Homing Enemy AI)
단순한 직선 이동이 아닌, 플레이어의 위치를 실시간으로 계산하여 추적하는 로직을 구현했습니다.

Logic: (Target Position - Current Position).normalized 공식을 사용하여 방향 벡터를 계산.

Code Snippet:

C#

// EnemyController.cs
Vector3 direction = (player.position - transform.position).normalized;
transform.Translate(direction * speed * Time.deltaTime);

2. 코루틴 기반 적 생성 시스템 (Coroutine Spawner)
Update문에서 불필요한 연산을 반복하는 것을 방지하기 위해 Coroutine을 사용했습니다.

Feature: Random.Range를 활용하여 생성 주기와 X좌표 위치를 무작위화, 단조로움을 탈피했습니다.

Code Snippet:

C#

// EnemySpawner.cs
IEnumerator SpawnEnemyRoutine() {
    while (true) {
        float waitTime = Random.Range(minSpawnTime, maxSpawnTime);
        yield return new WaitForSecondsRealtime(waitTime);
        //적 생성 로직 ...
    }
}

3. 무한 스크롤 배경 (Infinite Scrolling Background)
플레이어가 계속해서 우주를 비행하는 듯한 시각적 효과를 최적화된 방식으로 구현했습니다.

Logic: 배경이 화면 하단(-height)을 벗어나면, 즉시 위쪽(height * 2)으로 좌표를 재설정하여 리소스를 재사용합니다.

4. 물리 충돌 처리 (Physics & Collision)
· OnTriggerEnter2D 이벤트를 활용하여 투사체, 적, 플레이어 간의 상호작용(파괴, 피격)을 처리했습니다.

🎮 How to Play
· 이동: 키보드 방향키 (←, →, ↑, ↓) 또는 WASD
· 공격: Space 바 (누르고 있으면 연속 발사 가능)
· 목표: 끊임없이 생성되어 쫓아오는 적들을 피하거나 처치하여 생존하고 점수를 갱신해보세요

🚀 Future Improvements (Refactoring Plan)

· Score System: UI 매니저를 추가하여 점수 및 최고 기록 저장 기능 구현.
· Sound Manager: 오디오 소스를 관리하는 별도 매니저 클래스 도입.
