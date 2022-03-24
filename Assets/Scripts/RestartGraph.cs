using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartGraph : MonoBehaviour
{

    
    public SystemsGraph Graph;
    public GameObject sceneGraphAsset;

    void Start()
    {
        sceneGraphAsset = FindObjectOfType<GraphController>().gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ResetGraph()
    {
        Destroy(sceneGraphAsset.GetComponent<GraphController>());
        sceneGraphAsset.AddComponent<GraphController>().Graph = Graph;

        //sceneGraphAsset.SetActive(false);

    }
}
