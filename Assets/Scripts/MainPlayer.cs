using System.Collections;
using System.Collections.Generic;
using GT.Hotfix;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MainPlayer : MonoBehaviour
{
    private static MainPlayer _instance;
    public static MainPlayer Instance => _instance;
    
    public CameraObject m_CameraObject;
    public GameObject m_Scissors;
    public Rose m_CurrentRose;
    public XRDirectInteractor m_DirectInteractor;
    
    void Awake()
    {
        _instance = this;
        m_DirectInteractor.selectEntered.AddListener(OnSelectEnter);
    }

    private void OnSelectEnter(SelectEnterEventArgs arg0)
    {
        var select = arg0.interactableObject;
        var rose = select.transform.GetComponent<Rose>();
        m_CurrentRose = rose;
    }

    /// <summary>
    /// 拍照
    /// </summary>
    public void TakePhoto()
    {
        m_CameraObject.SaveCameraTexture();
    }

    public void SwitchCropping()
    {
        m_Scissors.SetActive(!m_Scissors.activeSelf);
    }

    public void ChangeColor(Color clor)
    {
        m_CurrentRose?.ChangeColor(clor);
    }

    public void TakeRose(GameObject rose)
    {
        m_CurrentRose = rose.GetComponent<Rose>();
    }
}