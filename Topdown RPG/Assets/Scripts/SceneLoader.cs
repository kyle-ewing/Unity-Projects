using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader {

    private class LoadingMonoBehavior : MonoBehaviour { }
    private static Action _onLoaderCallback;

    public enum Scene {
        Loading,
        MainMenu 
    }


    
    // public static void Load(int sceneIndex) {
    //     _onLoaderCallback = () => {
    //         GameObject loadingGameObject = new GameObject("Loading Game Object");
    //         loadingGameObject.AddComponent<LoadingMonoBehavior>().StartCoroutine(LoadSceneAsync(sceneIndex));
    //     };
    //     
    //     SceneManager.LoadScene(Scene.Loading.ToString());
    // }
    //
    // public static void Load(SceneAsset scene) {
    //     _onLoaderCallback = () => {
    //         GameObject loadingGameObject = new GameObject("Loading Game Object");
    //         loadingGameObject.AddComponent<LoadingMonoBehavior>().StartCoroutine(LoadSceneAsync(scene));
    //     };
    //     
    //     SceneManager.LoadScene(Scene.Loading.ToString());
    // }

    private static IEnumerator LoadSceneAsync(int sceneIndex) {
        yield return null;

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Single);

        while (!asyncOperation.isDone) {
            yield return null;
        }
    }
    
    private static IEnumerator LoadSceneAsync(Scene scene) {
        yield return null;
        
        Debug.Log(scene);
        
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(scene.ToString(), LoadSceneMode.Single);

        while (!asyncOperation.isDone) {
            yield return null;
        }
    }

    public static void LoaderCallback() {
        if (_onLoaderCallback != null) {
            _onLoaderCallback();
            _onLoaderCallback = null;
        }
    }
    
}


