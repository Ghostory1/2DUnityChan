using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{ 
    public T Load<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
    }

    public GameObject Instantiate(string path,Transform parent = null)
    {
        GameObject prefab = Load<GameObject>($"Prefabs/{path}");
        if(prefab ==null)
        {
            Debug.Log($"Failed to load prefab : {path}");
            return null;
        }
        //���� �׳� Instantiate �ᵵ������ ���� Instantiate�� �����ε� �ϱ⿡ Object.Instantiate���� ���ÿ��ؾ���, ���þ��ϸ� ��������� �θ����Ҳ���
        return Object.Instantiate(prefab,parent);
    }

    public void Destroy(GameObject go)
    {
        if (go == null)
            return;
        Object.Destroy(go);
    }
}