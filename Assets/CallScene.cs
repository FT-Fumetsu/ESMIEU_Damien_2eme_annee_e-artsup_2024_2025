using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CallScene : MonoBehaviour
{
    [SerializeField] private string _uiScene;
    void Start()
    {
        SceneManager.LoadScene(_uiScene, LoadSceneMode.Additive);
    }
}
