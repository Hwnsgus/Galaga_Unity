# 🚀 Galaga Style_Unity 
> **Unity와 C#을 활용하여 개발한 2D 종스크롤 슈팅 게임입니다.** >

<br>

## 📸 In-Game Screenshots

<div align="center">
  <img src="스크린샷 2026-01-07 164019" src="https://github.com/user-attachments/assets/749bb9eb-a44e-4310-a568-8a5576cbe088" alt="Gameplay" alt="Gameplay" width="600" />
</div>

<br>

## 🛠 Tech Stack

| Category | Technology |
| :--- | :--- |
| **Engine** | Unity 2022.x (2D) |
| **Language** | C# |
| **IDE** | Visual Studio |
| **Version Control** | Git / GitHub |

<br>

## 🧩 System Architecture (UML)

본 프로젝트는 각 클래스가 **단일 책임 원칙(SRP)**을 준수하도록 설계되어, 기능 간의 결합도를 낮추고 유지보수성을 높였습니다.

![UML Diagram](https://via.placeholder.com/600x400?text=UML+Diagram+Image)

* **Player System:** 플레이어의 이동 및 투사체 발사 로직 담당
* **Enemy System:** 적 생성기(Spawner)와 개별 적의 추적 AI(Controller)로 역할 분리
* **Environment:** 무한 스크롤 배경 처리를 통한 공간감 구현

<br>

## ✨ Key Features & Implementation Logic

### 1. 추적형 적 AI (Homing Enemy AI)
단순한 직선 이동이 아닌, 플레이어의 실시간 위치를 계산하여 추적하는 로직을 구현했습니다.
* **Logic:** `(Target Position - Current Position).normalized` 공식을 사용하여 방향 벡터를 계산하고 해당 방향으로 이동시킵니다.
* **Code Snippet:**
```csharp
// EnemyController.cs
// 플레이어 방향 벡터 계산 및 정규화
//Vector3 direction = (player.position - transform.position).normalized;
//transform.Translate(direction * speed * Time.deltaTime);

<br>

## 🎮 How to Play
### · 이동: 키보드 방향키 (←, →, ↑, ↓) 또는 WASD
### · 공격: Space 바 (누르고 있으면 연속 발사 가능)
### · 목표: 끊임없이 생성되어 쫓아오는 적들을 피하거나 처치하여 생존하고 점수를 갱신해보세요

## 🚀 Future Improvements (Refactoring Plan)

### · Score System: UI 매니저를 추가하여 점수 및 최고 기록 저장 기능 구현.
### · Sound Manager: 오디오 소스를 관리하는 별도 매니저 클래스 도입.

