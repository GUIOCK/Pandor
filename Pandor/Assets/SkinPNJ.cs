using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinPNJ : MonoBehaviour
{
    GameObject skin;
    // Start is called before the first frame update
    void Start()
    {
        skin = GetSkin();
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        skin.SetActive(true);

    }

    private GameObject GetSkin()
    {
        List<GameObject> skins = new List<GameObject>();
        for (int i = 0; i < transform.childCount; i++)
        {
            skins.Add(transform.GetChild(i).gameObject);
        }
        skins.RemoveAt(skins.Count - 1);
        return skins[Random.Range(0, skins.Count)];
    }

    private void IsVisible (bool isVisible)
    {
        skin.GetComponent<SkinnedMeshRenderer>().enabled = isVisible;
    }
}
