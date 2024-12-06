# ShootingBoogie
- (2024-2) HSU 고급모바일프로그래밍 Final Project
- Cross Flatform Mobile Application
- 2D Shooting Game
<br>

#### ⬇️ Click IMG to play with youtube ⬇️

[![ShootingBoogie](http://img.youtube.com/vi/FwppFrsJ_so/0.jpg)](https://youtu.be/FwppFrsJ_so?t=0s)
<br>
<br>
<br>

## 1. 사용 기술
<img src="https://img.shields.io/badge/unity-%23000000.svg?style=for-the-badge&logo=unity&logoColor=white"/> <img src="https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white"/>
<br>
- Target Flatform: Android, IOS (Cross Flatform)
- 뒤끝 Backend Service
- Editor Version: 2022.3.21f1 LTS
<br>
<br>

## 2. 플레이 목표
플레이어는 적의 공격을 피하면서 최대한 많은 적을 처치하는 것이 목표입니다.
<br>
<br>

## 3. 기능 설명
### <로그인 & 회원가입> 
#### - 메인화면, 로그인
![image](https://github.com/user-attachments/assets/8f6920b6-8c40-4bea-ac7a-fb796f84c62b)
<br>
학번, 비밀번호 입력 후 <로그인&플레이> 버튼을 누르면 로그인과 동시에 게임이 시작됩니다.<br>
학번 혹은 비밀번호가 틀린 경우 팝업 창을 통해 사용자에게 오류를 알려주며 게임은 실행되지 않습니다.<br>
<br>
<br>

#### - 회원가입
![image](https://github.com/user-attachments/assets/afe06226-478f-4273-9211-70651446738a)
<br>
사용자 이름, 학번, 비밀번호를 입력한 후 <회원가입> 버튼을 누르면 회원가입을 진행합니다.<br>
올바르지 않은 값을 입력할 경우 팝업 창을 통해 사용자에게 메시지와 함께 오류를 알려줍니다.<br>
회원가입에 성공한 경우 <로그인으로> 버튼을 눌러 로그인 화면으로 이동한 다음 ID, Password를 입력해 게임을 실행합니다.<br>
<br>
<br>

### <게임 플레이>
#### - 이동, 공격
![image](https://github.com/user-attachments/assets/949f6a16-0e45-4ada-8345-724786028d80)
<br>
왼쪽 하단 조이스틱을 통해 캐릭터를 자유롭게 이동시킬 수 있습니다.<br>
화면 밖으로 이동을 시도하면 캐릭터 위치를 Clamping 하여 화면을 벗어나지 못하게 합니다.<br>
오른쪽 하단 공격 버튼을 눌러 캐릭터의 전방으로 총알을 발사하여 공격합니다.<br>
적 오브젝트에 피격 시 폭발 효과를 발생시키고 적을 제거합니다.<br>
피격 효과는 Sound Effects와 Visual Effects로 구성되어 있습니다.<br>
<br>
<br>

#### - 적 오브젝트 생성, 점수 기록
![image](https://github.com/user-attachments/assets/6921a82c-1454-400c-ac1f-bdcc2682305c)
<br>
일정한 시간에 맞춰 화면의 우측 랜덤한 위치에서 새로운 캐릭터(Enemy)가 생성됩니다.<br>
생성된 캐릭터는 플레이어를 향해 이동합니다.<br>
<br>

게임 화면 상단에는 점수를 표시합니다.<br>
왼쪽은 현재 점수를 나타내며 적을 처치하면 점수가 증가하고 실시간으로 반영합니다.<br>
오른쪽은 서버에 저장된 개인 최고 점수를 가져와 표시합니다.<br>
<br>
<br>

#### - 게임 종료, 점수 기록
![image](https://github.com/user-attachments/assets/0bd48e64-408b-4f63-9b8e-861c0bab74da)
<br>
플레이어가 적과 충돌하면 게임이 종료됩니다.<br>
게임 종료 시 화면에 플레이 점수와 개인 최고 점수를 표시하며<br>
<다시하기>, <종료> 버튼을 눌러 다음 동작을 선택할 수 있습니다.<br>
<br>

#### (최고 점수 갱신 예시 이미지) <br>

![image](https://github.com/user-attachments/assets/5238fa8f-5e02-4884-9453-daaefff390d3)
<br>
이번 플레이를 통해 개인 최고 점수를 갱신하면 오른쪽 상상부기 이미지 패널을 통해 사용자에게 알려줍니다.<br>
한 게임이 종료되면 서버에 데이터를 전송합니다.<br>
<br>
<br>

### <서버 연동>
#### - 유저 정보 저장
![image](https://github.com/user-attachments/assets/bbd980ae-a29c-417f-b717-723046b7bfaa)
<br>
회원가입 시에 등록한 정보를 '뒤끝 Backend' 서버에 저장합니다.<br>
ID, UID, 가입일, 최근 접속일, 접속 환경(OS, 기기 등) 다양한 정보를 Database에 저장합니다.<br>
<br>
<br>

#### - 게임 기록 저장
![image](https://github.com/user-attachments/assets/e2032486-e4bc-4674-a546-7b0302e758f1)
<br>
게임이 종료되면 플레이어 정보와 함께 게임의 기록을 서버에 저장합니다.<br>
정보는 {이름, 최고점수, 점수}로 구성된 데이터 형식으로 Database Schema에 맞게 서버에 전송되고, 저장됩니다.<br>
<br>
<br>

## 4. 서버 관련 코드 설명
### <Auth>
#### - 회원 가입
![image](https://github.com/user-attachments/assets/5107ed44-9722-4062-95fd-b4d53085e699)
<br>
회원 가입 시에 등록한 정보를 Backend 서버에 전송합니다.<br>
<br>
<br>

#### - 예외 처리
![image](https://github.com/user-attachments/assets/ce4f326c-f4b8-4b24-ae1e-496f19be3344)
<br>
사용할 수 없는 ID이거나 서버 오류 등 회원가입 시 발생할 수 있는 다양한 에러 상황을 분류하여 사용자에게 알려줍니다.<br>
<br>
<br>

### <Data>
#### - Data Fetching
![image](https://github.com/user-attachments/assets/40c36187-3843-4819-9d68-a11cab8929c9)
<br>
게임이 시작되면 서버에 저장된 플레이어의 데이터를 Json 형식으로 가져오고 Parsing을 통해 개인 최고 점수를 불러옵니다.
<br>
<br>

#### - Data Transmission
![image](https://github.com/user-attachments/assets/a7e3d33a-59ef-4390-b2c7-d726d623ba24)
<br>
게임이 종료되면 서버의 Database 형식에 맞추어 생성한 data 자료형에<br>
사용자의 정보와 점수를 저장하고 서버에 저장합니다.<br>
<br>
<br>


