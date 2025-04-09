using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;        // 剛體組件，用於處理物理移動
    Animator anim;         // 動畫控制器組件，用於控制角色動畫
    SpriteRenderer spr;    // 精靈渲染器組件，用於控制角色是否要轉向
    public float speed = 5f; // 玩家移動速度
    public float jump = 5f;  // 玩家跳躍力度   
    float movement;         // 玩家移動的方向
    bool isGrounded = false; // 檢查玩家是否在地面上
    public GameObject gameover; // 遊戲結束UI的引用
    public bool isDead = false; // 追蹤玩家是否死亡

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();    // 獲取動畫控制器組件
        spr = GetComponent<SpriteRenderer>(); // 獲取精靈渲染器組件
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            isGrounded = true;              // 設置接地狀態為真
            anim.SetBool("jump", false);    // 關閉跳躍動畫
            transform.SetParent(other.transform); // 將主角設為地面的子物件
        }
        else if (other.CompareTag("Deathline")) // 碰到死亡線時
        {
            gameover.SetActive(true);       // 顯示遊戲結束UI
            isDead = true;                  // 設置死亡狀態為真
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            isGrounded = false;             // 設置接地狀態為假
            transform.SetParent(null);      // 解除主角與地面的父子關係              
        }
    }

    void Update()
    {
        if (isDead && Input.anyKeyDown)    // 如果玩家死亡且按下任意鍵
        {
            SceneManager.LoadScene("SampleScene"); // 重新載入遊戲場景
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.RightArrow)){ // 檢測右箭頭鍵，向右移動
            movement = speed;
            anim.SetBool("run", true);      // 播放奔跑動畫
            spr.flipX = false;              // 將精靈朝向右邊
        }
        else if (Input.GetKey(KeyCode.LeftArrow)) { // 檢測左箭頭鍵，向左移動
            movement = -speed;
            anim.SetBool("run", true);      // 播放奔跑動畫
            spr.flipX = true;               // 將精靈朝向左邊
        }
        else {
            movement = 0f;                  // 沒有按方向鍵時停止移動
            anim.SetBool("run", false);     // 停止奔跑動畫
        }
        rb.linearVelocityX = movement;     // 設置水平移動速度
        if (Input.GetKey(KeyCode.Space) && isGrounded == true) { // 按下空格鍵且在地面上時
            rb.linearVelocity = new Vector2(movement, jump); // 執行跳躍
            anim.SetBool("jump", true);     // 播放跳躍動畫
        }     
    }
}