using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewDriftRotation : MonoBehaviour
{
    // 以下为开放配置参数
    public float rotationAmplitudePitch = 0.50f;    // Pitch 轴最大上下呼吸幅度，用角度表示，此次呼吸 pitch 轴旋转量的极限值
    public float rotationAmplitudeYaw = 0.50f;      // Yaw 轴最大左右呼吸幅度，用角度表示，此次呼吸 yaw 轴旋转量的极限值
    
    // 以下为非开放配置参数
    public float rotationSpeedPitch = 2.0f;   // Pitch 轴呼吸速度
    public float rotationSpeedYaw = 2.0f;     // Yaw 轴呼吸速度
    public float rotationFrequency = 2.5f;    // 呼吸频率，值越大相机完成一次完整旋转周期时间越短，单位时间旋转量越大
    
    private Quaternion initialRotation;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0.3f ;
        initialRotation = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        // 使用正弦函数来模拟呼吸效果，yaw 轴变化速度默认是 pitch 轴 1/2，安全网设计，不影响最终值
        float breathPitch = Mathf.Sin(Time.time * rotationSpeedPitch * rotationFrequency) * rotationAmplitudePitch;
        float breathYaw = Mathf.Sin(Time.time * rotationSpeedYaw * rotationFrequency * 0.5f ) * rotationAmplitudeYaw;

        // 创建旋转角度，围绕相机的局部 Y 轴旋转
        Quaternion rotation = Quaternion.Euler(breathPitch, breathYaw, 0);

        // 应用旋转效果到相机的局部旋转
        transform.localRotation = initialRotation * rotation;
    }
}
