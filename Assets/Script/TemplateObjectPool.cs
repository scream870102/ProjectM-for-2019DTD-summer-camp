using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class TemplateObjectPool : MonoBehaviour {
    public GameObject pooledObject;
    public int pooledAmount;
    public bool willGrow;
    List<GameObject> poolObjects;
    void Start ( ) {
        poolObjects = new List<GameObject> ( );
        for (int i = 0; i < pooledAmount; i++) {
            GameObject obj = (GameObject) Instantiate (pooledObject);
            obj.SetActive (false);
            poolObjects.Add (obj);
        }
    }

    public GameObject GetPooledObject ( ) {
        for (int i = 0; i < poolObjects.Count; i++) {
            if (!poolObjects [i].activeInHierarchy)
                return poolObjects [i];
        }
        if (willGrow) {
            GameObject obj = (GameObject) Instantiate (pooledObject);
            poolObjects.Add (obj);
            return obj;
        }
        return null;
    }
}
