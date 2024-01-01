using System;
using System.IO;
using UnityEngine;
using Object = UnityEngine.Object;

namespace GT.Hotfix
{
    public static class CameraUtility
    {
        public static RenderTexture SetCameraRender(Camera camera, int width = 1024, int height = 2018)
        {
            var rt = RenderTexture.GetTemporary(width, height, 16, RenderTextureFormat.ARGB32,RenderTextureReadWrite.sRGB);

            camera.targetTexture = rt;
            camera.Render();

            return rt;
        }
        
        public static void SaveCameraRender(Camera camera, string saverPath)
        {
            var rt = camera.targetTexture;
            camera.Render();
            SaveRenderTexture(rt, saverPath);

            // RenderTexture.ReleaseTemporary(rt);
        }
        
        /// <summary>
        /// 保存相机渲染图片到本地
        /// </summary>
        /// <param name="camera"></param>
        /// <param name="saverPath"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public static void SaveCameraRender(Camera camera, string saverPath, int width, int height)
        {
            var rt = RenderTexture.GetTemporary(width, height, 16, RenderTextureFormat.ARGB32,RenderTextureReadWrite.sRGB);

            camera.targetTexture = rt;
            camera.Render();
            SaveRenderTexture(rt, saverPath);

            RenderTexture.ReleaseTemporary(rt);
        }

        /// <summary>
        /// 保存RenderTexture渲染图片到本地
        /// </summary>
        /// <param name="rt"></param>
        /// <param name="savePath"></param>
        public static void SaveRenderTexture(RenderTexture rt, string savePath)
        {
            RenderTexture active = RenderTexture.active;
            RenderTexture.active = rt;
            
            Texture2D png = new Texture2D(rt.width, rt.height, TextureFormat.ARGB32, false);
            png.ReadPixels(new Rect(0, 0, rt.width, rt.height), 0, 0);
            png.Apply();

            RenderTexture.active = active;

            byte[] bytes = png.EncodeToPNG();
            FileStream fs = File.Open(savePath, FileMode.Create);
            BinaryWriter writer = new BinaryWriter(fs);
            writer.Write(bytes);
            writer.Flush();
            writer.Close();
            fs.Close();
            Object.Destroy(png);

            Debug.Log("保存成功！" + savePath);
        }


        public static Sprite ToSprite(this Texture2D tex2d)
        {
            return Sprite.Create(tex2d, new Rect(0, 0, tex2d.width, tex2d.height), new Vector2(0.5f, 0.5f));
        }
    }
}