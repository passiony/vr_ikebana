using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rose : MonoBehaviour
{
    public MeshRenderer m_Mesh;
    public Color[] m_Colors;
    
    void Start()
    {
        RandomColor();
    }

    public void ChangeColor(Color clor)
    {
        m_Mesh.material.color = clor;
    }

    public void RandomColor()
    {
        var index = Random.Range(0, m_Colors.Length);
        m_Mesh.material.color = m_Colors[index];
    }
}
