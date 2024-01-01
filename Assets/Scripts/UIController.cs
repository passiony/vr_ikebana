using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private Button m_ColorBtn;
    [SerializeField]
    private Button m_CropptingBtn;
    [SerializeField]
    private Button m_PhotoBtn; 
    [SerializeField]
    private GameObject m_ColorSetting;
    
    void Start()
    {
        m_ColorBtn.onClick.AddListener(OnColorChange);
        m_CropptingBtn.onClick.AddListener(OnCropSwitch);
        m_PhotoBtn.onClick.AddListener(OnPhotoClick);
    }

    private void OnPhotoClick()
    {
        MainPlayer.Instance.TakePhoto();
    }

    private void OnCropSwitch()
    {
        MainPlayer.Instance.SwitchCropping();
    }

    private void OnColorChange()
    {
        m_ColorSetting.SetActive(true);
    }

}
