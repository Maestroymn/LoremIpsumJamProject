using UnityEngine;
using UnityEngine.UI;

public class TypeText : MonoBehaviour
{

	private static TypeText instance;

	public static TypeText Instance
	{
		get
		{
			if (instance == null)
			{
				Debug.LogError("TextTyper is null!");
			}
			return instance;
		}
	}
	[Header("Settings")]
	[SerializeField] private float typeSpeed = 0.05f;
	[SerializeField] private float startDelay = 0.3f;
	[SerializeField] private float volumeVariation = 0.1f;

	[Header("Components")]
	[SerializeField] private AudioSource mainAudioSource;

	private bool typing = false;
	private int counter = 0;
	private Text dialogText;
	public string[] dialogLines;
	private int currentLine = 0, totalLineCount = 0;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}

		if (!mainAudioSource)
		{
			Debug.Log("No AudioSource has been set. Set one if you wish you use audio features.");
		}
	}

	private void Start()
	{

		dialogText = GetComponentInChildren<Text>();

		counter = 0;

		closeDialog();
	}

	public void startDialog(string[] newLines)
	{
		dialogText.text = "";
		dialogLines = newLines;
		totalLineCount = dialogLines.Length;
		currentLine = 0;
		counter = 0;

		StartTyping();
	}

	public void StartTyping()
	{
		if (!typing)
		{
			InvokeRepeating("Type", startDelay, typeSpeed);
		}
		else
		{
			Debug.LogWarning(gameObject.name + " : Is already typing!");
		}
	}

	public void StopTyping()
	{
		counter = 0;
		typing = false;
		CancelInvoke("Type");
	}

	public bool UpdateText()
	{
		if (currentLine < totalLineCount - 1)
		{
			if (typing)
			{
				StopTyping();
			}
			dialogText.text = "";
			updateDialogLine();
			StartTyping();
			return true;
		}
		else
		{
			closeDialog();
			return false;
		}
	}

	public void QuickSkip()
	{
		if (typing)
		{
			StopTyping();
			dialogText.text = dialogLines[currentLine];
		}
	}

	private void Type()
	{
		typing = true;
		dialogText.text = dialogText.text + dialogLines[currentLine][counter];
		Debug.Log(currentLine);
		counter++;

		if (mainAudioSource)
		{
			mainAudioSource.Play();
			RandomiseVolume();
		}

		if (counter == dialogLines[currentLine].Length)
		{
			typing = false;
			CancelInvoke("Type");
		}
	}

	private void RandomiseVolume()
	{
		mainAudioSource.volume = Random.Range(1 - volumeVariation, volumeVariation + 1);
	}

	public void updateDialogLine()
	{
		StopTyping();
		currentLine++;
	}

	public void closeDialog()
	{
		StopTyping();
	}

	public void clearText()
    {
		StopTyping();
		dialogText.text = "";
	}

	public bool IsTyping() { return typing; }
}