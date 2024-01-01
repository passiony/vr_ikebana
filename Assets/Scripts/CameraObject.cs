using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace GT.Hotfix
{
    public class CameraObject : MonoBehaviour
    {
        private Camera m_RtCamera;
        private GameObject m_RtBeijing;
        private Image m_RtImage;
        private RawImage m_RawImage;

        protected void Awake()
        {
            m_RtCamera = transform.Find("Capture").GetComponent<Camera>();
            // m_RtBeijing = transform.Find("RT_Beijing").gameObject;
            // m_RtImage = transform.Find("RT_Beijing/RT_Image").GetComponent<Image>();
            // m_RawImage = gameObject.GetComponent<RawImage>();
            var rt = CameraUtility.SetCameraRender(m_RtCamera);
            // m_RawImage.texture = rt;
        }

        void OnEnable()
        {
            // m_RtCamera.gameObject.SetActive(true);
            // m_RtBeijing.gameObject.SetActive(false);
            // m_RtImage.transform.localScale = Vector2.one;
        }

        public void SaveCameraTexture()
        {
            if (m_RtCamera == null)
            {
                Debug.LogError("找不到RenderCemera");
                return;
            }

            var random = Random.Range(0, 100000);
            var savepath = Application.persistentDataPath + $"/CameraRender{random}.png";
            CameraUtility.SaveCameraRender(m_RtCamera, savepath);
        }

    }
}