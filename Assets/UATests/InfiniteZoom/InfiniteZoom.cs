using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteZoom : MonoBehaviour
{
    public List<Transform> sectionPrefabs;
    public float sectionSpacing = 5;
    public float scaleFactor = 0.1f;
    private List<Transform> activeSections = new List<Transform>();

    void Start()
    {
        transform.LookAt(Vector3.zero);
    }
    void AddRandomSection()
    {
        int index = Random.Range(0, sectionPrefabs.Count);
        var clone = Instantiate(sectionPrefabs[index]);
        clone.parent = transform;
        clone.localPosition = Vector3.forward * (10-activeSections.Count) * sectionSpacing;
        if (activeSections.Count > 0)
            clone.localScale = activeSections[activeSections.Count-1].localScale * scaleFactor;
        activeSections.Add(clone);
    }

    void Update()
    {
        while (activeSections.Count < 10)
            AddRandomSection();
        float scale = Mathf.Pow(2, Time.deltaTime*3);
        for (int i = activeSections.Count - 1; i >= 0; i--)
        {
            activeSections[i].localScale *= scale;
            if (activeSections[i].localScale.x > 1000)
            {
                Destroy(activeSections[i].gameObject);
                activeSections.RemoveAt(i);
                for (int n = activeSections.Count - 1; n >= 0; n--)
                {
                    activeSections[n].localPosition += Vector3.forward * sectionSpacing;
                }
            }
        }
    }
}
