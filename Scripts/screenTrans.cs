using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class screenTrans : MonoBehaviour //Yeets an arrow across the screen
{
    public int direction;
    private bool transitioned = false; //pog
    public Rigidbody2D Rigidbody;
    public SpriteRenderer srend;
    private int killtimer;
    public string newScene;
    public string exitDirection;
    private Camera cam;
    public bool thatOneFeckingEntrance = false;

    // 0 is Right to Left
    // 1 DtU
    // 2 LtR
    // 3 UtD
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        killtimer = 0; //so it doesn't stay loaded forever
        switch (direction) //which direction it flies
        {
            case 0:
                srend.flipX = false;
                transform.position = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, cam.pixelHeight/2, 0f));
                transform.position = new Vector3(transform.position.x+28, transform.position.y, 0f);
                Rigidbody.velocity = new Vector2(-100f, 0f);

                break;

            case 1:
                transform.position = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth/2, 0f, 0f));
                transform.position = new Vector3(transform.position.x, transform.position.y-10f, 0f);
                Debug.Log("Up");
               // transform.Rotate.z = 270f;
                Rigidbody.velocity = new Vector2(00f, 56f);
                break;

            case 2:
                srend.flipX = true;
                transform.position = cam.ScreenToWorldPoint(new Vector3(0f, cam.pixelHeight / 2, 0f));
                transform.position = new Vector3(transform.position.x-28, transform.position.y , 0f);
                Rigidbody.velocity = new Vector2(100f, 0f);
                break;

            case 3:
                srend.flipY = true;
                transform.position = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth / 2, cam.pixelHeight, 0f));
                transform.position = new Vector3(transform.position.x, transform.position.y + 10f, 0f);
                Debug.Log("Up");
                // transform.Rotate.z = 270f;
                Rigidbody.velocity = new Vector2(00f, -56f);
                break;
            case 4:
                transform.position = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth / 2, 0f, 0f));
                transform.position = new Vector3(transform.position.x, transform.position.y - 10f, 0f);
                Debug.Log("Up");
                // transform.Rotate.z = 270f;
                Rigidbody.velocity = new Vector2(00f, 56f);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!transitioned)
        {
            switch (direction) //which direction it flies
            {
                case 0:
                    if (transform.position.x < 2)
                    {
                        Debug.Log("Trans");
                        SinaManager.Instance.currScreen = newScene;
                        SinaManager.Instance.screenExit = exitDirection;
                        Rigidbody.velocity = new Vector2(0f, 0f);
                        SceneManager.LoadScene(newScene);
                        StartCoroutine(bufferFrame());
                        Rigidbody.velocity = new Vector2(-100f, 0f);
                        transitioned = true;

                    }
                    break;

                case 1:
                    if (transform.position.y > -2)
                    {
                        SinaManager.Instance.currScreen = newScene;
                        SinaManager.Instance.screenExit = exitDirection;
                        Debug.Log("Trans");
                        Rigidbody.velocity = new Vector2(0f, 0f);
                        SceneManager.LoadScene(newScene);
                        StartCoroutine(bufferFrame());
                        Rigidbody.velocity = new Vector2(00f, 56f);
                        transitioned = true;

                    }
                    break;

                case 2:
                    if (transform.position.x > -2)
                    {
                        SinaManager.Instance.currScreen = newScene;
                        SinaManager.Instance.screenExit = exitDirection;
                        Debug.Log("Trans");
                        Rigidbody.velocity = new Vector2(0f, 0f);
                        SceneManager.LoadScene(newScene);
                        StartCoroutine(bufferFrame());
                        Rigidbody.velocity = new Vector2(100f, 0f);
                        transitioned = true;

                    }
                    break;

                case 3:
                    if (transform.position.y < 2)
                    {
                        SinaManager.Instance.currScreen = newScene;
                        SinaManager.Instance.screenExit = exitDirection;
                        Debug.Log("Trans");
                        Rigidbody.velocity = new Vector2(0f, 0f);
                        SceneManager.LoadScene(newScene);
                        StartCoroutine(bufferFrame());
                        Rigidbody.velocity = new Vector2(00f, -56f);
                        transitioned = true;

                    }
                    break;
                case 4:
                    if (transform.position.y > -12)
                    {
                        SinaManager.Instance.currScreen = newScene;
                        SinaManager.Instance.screenExit = exitDirection;
                        Debug.Log("Trans");
                        Rigidbody.velocity = new Vector2(0f, 0f);
                        SceneManager.LoadScene(newScene);
                        StartCoroutine(bufferFrame());
                        Rigidbody.velocity = new Vector2(00f, 56f);
                        transitioned = true;

                    }
                    break;
            } 
        }
        killtimer += 1;
        if (killtimer > 120) //dies after 2 seconds
        {
            Destroy(gameObject);
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject); //so it stays 
    }

    IEnumerator bufferFrame ()
    {
        yield return null;
       
        Debug.Log("BufferMa");
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        transform.position = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth / 2f, cam.pixelHeight / 2f, 0f));
        transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
        if (thatOneFeckingEntrance)
        {
            transform.position = new Vector3(transform.position.x, -5.43f, 0f);

        }
    }
}
