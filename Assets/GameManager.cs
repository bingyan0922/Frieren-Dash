using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject ground;      // 地面物件的引用
    public GameObject player;      // 玩家物件的引用
    public GameObject groundMaker; // 地面生成器物件的引用
    public GameObject gameTitle;   // 遊戲標題物件的引用
    bool gameStarted = false;     // 追蹤遊戲是否已開始
    public AudioManager musicPlayer; // 音樂管理器的引用
    float distance = 0f;          // 記錄玩家移動的距離
    public TextMeshProUGUI score; // 遊戲中顯示分數的文字UI
    public TextMeshProUGUI finalScore; // 遊戲結束時顯示最終分數的文字UI
    float finalDistance = 0f;     // 儲存最終移動距離
    public PlayerMovement playerMovement; // 玩家移動腳本的引用
    bool isGameOver = false;      // 追蹤遊戲是否結束    

    void Start()
    {
        musicPlayer.PlayTitle();   // 遊戲開始時播放標題畫面音樂
    }

    void Update()
    {
        if (gameStarted == false && Input.GetKeyDown(KeyCode.Return)) // 檢查是否按下Enter鍵且遊戲尚未開始
        {
            StartGame();          // 開始遊戲
        }
        if (gameStarted)
        {
            distance += GroundMove.speed * Time.deltaTime; // 計算移動距離
            score.text = $"{distance:F0} m";               // 更新分數顯示，四捨五入到整數
        }
        if (playerMovement.isDead && !isGameOver) // 檢查玩家是否死亡且遊戲尚未結束
        {
            GameOver();           // 執行遊戲結束
        }
    }

    void StartGame()
    {
        gameStarted = true;
        score.gameObject.SetActive(true);   // 顯示分數UI        
        ground.SetActive(true);             // 啟用地面物件
        player.SetActive(true);             // 啟用玩家物件
        groundMaker.SetActive(true);        // 啟用地面生成器
        gameTitle.SetActive(false);         // 隱藏遊戲標題
        musicPlayer.StopAudio();            // 停止當前播放的音樂
        musicPlayer.Playbgm();              // 播放遊戲背景音樂
    }

    void GameOver()
    {
        isGameOver = true;
        finalDistance = distance;           // 儲存最終距離
        score.gameObject.SetActive(false);  // 隱藏遊戲中的分數顯示
        finalScore.gameObject.SetActive(true); // 顯示最終分數UI
        finalScore.text = $"{finalDistance:F0} m"; // 更新最終分數顯示
    }
}