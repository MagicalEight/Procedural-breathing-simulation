using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ViewDriftRotation : MonoBehaviour
{
    // 以下为开放配置参数
    public float pbs_ads_stand_pitch_limit = 0.0f;    // Pitch 轴最大上下呼吸幅度，用角度表示，此次呼吸 pitch 轴旋转量的极限值
    public float pbs_ads_stand_yaw_limit = 0.70f;      // Yaw 轴最大左右呼吸幅度，用角度表示，此次呼吸 yaw 轴旋转量的极限值
    
    // 以下为非开放配置参数
    public float pbs_ads_pitch_speed = 0.70f;   // Pitch 轴呼吸速度
    public float pbs_ads_yaw_speed = 0.0f;     // Yaw 轴呼吸速度
    public float pbs_frequency = 2.0f;    // 呼吸频率，值越大相机完成一次完整旋转周期时间越短，单位时间旋转量越大
    
    private Quaternion initialRotation;
    
    void Start()
    {
        Time.timeScale = 1.0f ;
        initialRotation = transform.localRotation;
    }
    
    void Update()
    {
        // 使用正弦函数来模拟呼吸效果，yaw 轴变化速度默认是 pitch 轴 1/2，安全网设计，不影响最终值
        float breathPitch = Mathf.Sin(Time.time * pbs_ads_pitch_speed * pbs_frequency) * pbs_ads_stand_pitch_limit;
        float breathYaw = Mathf.Sin(Time.time * pbs_ads_yaw_speed * pbs_frequency * 0.5f ) * pbs_ads_stand_yaw_limit;

        // 创建旋转角度，围绕相机的局部 Y 轴旋转
        Quaternion rotation = Quaternion.Euler(breathPitch, breathYaw, 0);

        // 应用旋转效果到相机的局部旋转
        transform.localRotation = initialRotation * rotation;
    }
}
