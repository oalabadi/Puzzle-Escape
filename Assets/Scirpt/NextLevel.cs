using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public Animator transition;
    public TextMeshProUGUI transitionText;
    public float transitionTime = 1f;

    private void Start()
    {
        if (transition == null) 
            transition = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            LoadScene();
        }
    }

    public void LoadScene()
    {
        if (SceneManager.GetActiveScene().buildIndex + 1 < SceneManager.sceneCountInBuildSettings)
            StartCoroutine(LoadNextScene(SceneManager.GetActiveScene().buildIndex + 1));
        else
            Debug.Log("Scene [" + (SceneManager.GetActiveScene().buildIndex + 1) + "] was not found!");
    }

    private IEnumerator LoadNextScene(int levelIndex)
    {
        transitionText.SetText("LEVEL - " + (levelIndex + 1));

        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
