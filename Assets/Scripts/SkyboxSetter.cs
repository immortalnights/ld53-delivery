using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Skybox))]
public class SkyboxSetter : MonoBehaviour
{
    [SerializeField]
    List<Material> skyboxMaterials;

    Skybox skybox;

    void Awake()
    {
        skybox = GetComponent<Skybox>();
    }

    void OnEnable()
    {
        ChangeSkybox(0);
    }

    void ChangeSkybox(int index)
    {
        if (skybox != null && index <= skyboxMaterials.Count) {
            skybox.material = skyboxMaterials[index];
        }
    }
}
