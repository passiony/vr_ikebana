using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSetting : MonoBehaviour
{
    [SerializeField] private Button m_CloseBtn;
    [SerializeField] private GameObject m_ColorMenu;

    private void Start()
    {
        m_CloseBtn.onClick.AddListener(OnCloseClick);
    }

    private void OnCloseClick()
    {
        gameObject.SetActive(false);
    }

    void OnEnable()
    {
        var rose = MainPlayer.Instance.m_CurrentRose;
        if (!rose)
        {
            return;
        }

        for (int i = 2; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        
        foreach (var color in rose.m_Colors)
        {
            var btn = GameObject.Instantiate(m_ColorMenu, transform);
            btn.SetActive(true);
            btn.GetComponent<Image>().color = color;
            btn.GetComponent<Button>().onClick.AddListener(() =>
            {
                OnMenuClick(color);
            });
        }
    }

    private void OnMenuClick(Color color)
    {
        MainPlayer.Instance.ChangeColor(color);
    }
    
}
