using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class screenExit : MonoBehaviour
{
    public string exitDirection;
    public string newScene;
    public GameObject trans;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Sina>() != null)
        {
            GameObject transition = Instantiate < GameObject >(trans, transform.position, Quaternion.identity);
            
            if (exitDirection == "left")
            {
                transition.transform.position = new Vector3(27f,0f,0f);
            }
            else if (exitDirection == "right")
            {
                transition.transform.position = new Vector3(-27f, 0f, 0f);
            }
            else if (exitDirection == "up")
            {

            }
            else if (exitDirection == "down")
            {

            }
            // trans.SetActive(true);
            StartCoroutine(loadBuffer());

        }
    }

    IEnumerator loadBuffer()
    {
        for (int i = 0; i < 17; i++)
        {
            yield return null;
        }
        SinaManager.Instance.currScreen = newScene;
        SinaManager.Instance.screenExit = exitDirection;
        SceneManager.LoadScene(newScene);
    }
}
