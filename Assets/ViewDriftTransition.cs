using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewDriftTransition : MonoBehaviour
{
    public float amplitude = 0.1f;  // 呼吸幅度
    public float speed = 1.0f;     // 呼吸速度
    public float frequency = 1.0f; // 呼吸频率
    
    private Vector3 initialPosition;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        // 使用正弦函数来模拟呼吸效果
        float breath = Mathf.Sin(Time.time * speed * frequency) * amplitude;
        
        // 应用呼吸效果到相机的位置
        transform.localPosition = initialPosition + new Vector3(0, breath, 0);
    }
}
