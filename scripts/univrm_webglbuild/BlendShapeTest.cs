using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRM;

public class BlendShapeTest : MonoBehaviour
{
    [SerializeField]
    VRMBlendShapeProxy m_proxy;

    [SerializeField]
    Text m_textUI;

    BlendShapePreset[] Shapes =
    {
        BlendShapePreset.A,
        BlendShapePreset.I,
        BlendShapePreset.U,
        BlendShapePreset.E,
        BlendShapePreset.O,
        BlendShapePreset.Blink,
        BlendShapePreset.Joy,
        BlendShapePreset.Angry,
        BlendShapePreset.Sorrow,
        BlendShapePreset.Fun,
    };

    void Update()
    {
        const float valueChangeIntervalSec = 2.0f;
        var time = Time.realtimeSinceStartup;
        var presetIndex = (int)(time / valueChangeIntervalSec) % Shapes.Length;

        var value = (time % valueChangeIntervalSec) / valueChangeIntervalSec; // 0 - 1
        if(value >= 0.5f)
        {
            value = 1.0f - value;
        }
        value *= 2;

        m_proxy.ImmediatelySetValue(BlendShapeKey.CreateFromPreset(Shapes[presetIndex]), value);

        if(m_textUI != null)
        {
            m_textUI.text = Shapes[presetIndex].ToString();
        }
    }
}
