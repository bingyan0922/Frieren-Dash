using UnityEngine;

public class GroundMaker : MonoBehaviour
{
    public GameObject[] prefabs;  // 用陣列儲存地面的 Prefab
    public float offsetMin = -1f; // 最小偏移值
    public float offsetMax = 3f;  // 最大偏移值
    int groundCount = 0;         // 記錄已生成的地面數量

    void Start()
    {
        InvokeRepeating("MakeGrounds", 1f, 2f);  // 遊戲開始 1 秒後開始生成地面，之後每 2 秒重複一次
    }

    void MakeGrounds()
    {
        int number = Random.Range(0,3); // 隨機選擇 0-2 之間的一個數字，用來決定使用哪個地面 prefab
        // 生成新的地面物件，生成地面的位置會在 X 軸上加上一個隨機偏移量
        Instantiate(prefabs[number], 
            transform.position + new Vector3(Random.Range(offsetMin, offsetMax), 0, 0),
            transform.rotation);
        groundCount++;           // 地面計數加一        
        if (groundCount % 10 == 0)  // 每生成 10 個地面，地面移動速度增加 50%
        {
            GroundMove.speed *= 1.5f;
        }
    }
}