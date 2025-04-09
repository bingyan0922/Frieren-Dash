using UnityEngine;

public class GroundMove : MonoBehaviour
{
    public static float speed = 5f;   // 宣告一個靜態變數來控制移動速度
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(-speed * Time.deltaTime, 0f, 0f);  //地面持續向左移動

        if (transform.position.x < -25f)  //當地面移動到 x 座標 -25 以左時自動刪除
        {
            Destroy(gameObject);
        }
    }
}
