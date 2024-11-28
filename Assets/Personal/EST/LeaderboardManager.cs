using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI; // UI를 업데이트하기 위한 네임스페이스

public class LeaderboardManager : MonoBehaviour
{
   

    // 순위표를 표시할 텍스트 UI
    public Text leaderboardText;

    // 점수 데이터를 저장할 클래스 정의
    [System.Serializable]
    public class ScoreData
    {
        public string playerName; // 플레이어 이름
        public int score;         // 플레이어 점수
    }

    // 서버로부터 받아올 순위표 데이터를 저장할 리스트 정의
    [System.Serializable]
    public class LeaderboardData
    {
        public List<ScoreData> leaderboard = new List<ScoreData>(); // 순위표 데이터 리스트
    }

    // 점수를 서버에 제출하는 메서드
    public IEnumerator SubmitScore(string playerName, int score)
    {
        // 점수 데이터를 JSON 형식으로 변환
        ScoreData scoreData = new ScoreData { playerName = playerName, score = score };
        string jsonData = JsonUtility.ToJson(scoreData);

        // POST 요청 생성
        using (UnityWebRequest request = UnityWebRequest.Post($"{serverUrl}/leaderboard", jsonData))
        {
            // JSON 데이터를 HTTP 요청 본문에 포함
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json"); // Content-Type 설정

            // 요청 전송
            yield return request.SendWebRequest();

            // 요청 결과 확인
            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError($"점수 제출 오류: {request.error}"); // 오류 로그 출력
            }
            else
            {
                Debug.Log("점수 제출 성공!"); // 성공 로그 출력
            }
        }
    }

    // 서버에서 순위표 데이터를 가져오는 메서드
    public IEnumerator FetchLeaderboard()
    {
        using (UnityWebRequest request = UnityWebRequest.Get($"{serverUrl}/leaderboard"))
        {
            // 요청 전송
            yield return request.SendWebRequest();

            // 요청 결과 확인
            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError($"순위표 가져오기 오류: {request.error}"); // 오류 로그 출력
            }
            else
            {
                // 서버에서 받은 JSON 데이터를 순위표 데이터로 변환
                string jsonResult = request.downloadHandler.text;
                LeaderboardData leaderboard = JsonUtility.FromJson<LeaderboardData>($"{{\"leaderboard\":{jsonResult}}}");

                // 순위표 텍스트 UI 업데이트
                UpdateLeaderboardUI(leaderboard);
            }
        }
    }

    // 순위표 UI를 업데이트하는 메서드
    private void UpdateLeaderboardUI(LeaderboardData leaderboard)
    {
        leaderboardText.text = ""; // 기존 텍스트 초기화

        // 순위표 데이터를 UI에 추가
        foreach (var scoreData in leaderboard.leaderboard)
        {
            leaderboardText.text += $"{scoreData.playerName}: {scoreData.score}\n"; // 이름과 점수 표시
        }
    }

    // 테스트용 메서드: 점수 제출 및 순위표 가져오기
    public void TestLeaderboard()
    {
        StartCoroutine(SubmitScore("Player1", Random.Range(10, 100))); // 점수 제출
        StartCoroutine(FetchLeaderboard()); // 순위표 가져오기
    }
}
