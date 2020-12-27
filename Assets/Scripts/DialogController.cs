using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{
    public string[] lines;

    public Sprite[] sprites;

    private bool canActivate = true, isActive = false;
    private TypeText tT;
    private GameObject transitionPanel, window;
    private Image image;
    private int count = 0;

    [SerializeField] private AudioSource mainAudioSource;

    private void Start()
    {
        tT = TypeText.Instance;

        transitionPanel = GameObject.Find("Canvas/Transition");
        window = GameObject.Find("Window");
        image = GameObject.Find("Canvas/Image").GetComponent<Image>();

        transitionPanel.SetActive(false);
    }

    private void Update()
    {
        if (canActivate && Input.GetKeyDown(KeyCode.E) && !isActive)
        {
            tT.startDialog(lines);
            isActive = true;
        }
        else if (canActivate && isActive && Input.GetKeyDown(KeyCode.E))
        {
            if (tT.IsTyping())
            {
                tT.QuickSkip();
                Debug.Log("Skipped");
            }
            else
            {
                isActive = tT.UpdateText();
            }
        }

        if (isActive && Input.GetKeyDown(KeyCode.Escape))
        {
            isActive = false;
            tT.closeDialog();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            transitionPanel.SetActive(true);
            transitionPanel.GetComponent<Animator>().SetTrigger("PlayTransition");

            if(window != null)
            {
                //Invoke("killWindow", 2f);
            }

            count++;
            Invoke("changeImage", 2f);
        }
    }

    private void killWindow()
    {
        Destroy(window);
    }

    private void changeImage()
    {
        if (count >= sprites.Length)
        {
            image.sprite = null;
        }
        else
        {
            image.sprite = sprites[count];
        }

        tT.clearText();
    }

    private void playSound(AudioClip clip)
    {
        mainAudioSource.PlayOneShot(clip);
    }


}
