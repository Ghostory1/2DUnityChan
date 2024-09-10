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
        //원래 그냥 Instantiate 써도되지만 지금 Instantiate을 오버로딩 하기에 Object.Instantiate임을 명시에해야함, 명시안하면 재귀적으로 부르려할꺼임
        return Object.Instantiate(prefab,parent);
    }

    public void Destroy(GameObject go)
    {
        if (go == null)
            return;
        Object.Destroy(go);
    }
}
