using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class DialogueUIController : MonoBehaviour
{
    public static DialogueUIController Instance { get; private set; }

    public GameObject dialoguePanel;
    public Text speakerText;
    public Text dialogueText;
    public Transform choiceButtonContainer;
    public Button choiceButtonPrefab;
    public Button endButton;

    private readonly List<Button> activeChoiceButtons = new List<Button>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        HideDialoguePanel();
    }

    public void DisplayNode(DialogueNode node)
    {
        if (node == null)
        {
            HideDialoguePanel();
            return;
        }

        dialoguePanel.SetActive(true);
        speakerText.text = node.speakerName;
        dialogueText.text = node.dialogueText;

        ClearChoices();

        if (node.choices != null && node.choices.Count > 0)
        {
            endButton.gameObject.SetActive(false);

            for (int i = 0; i < node.choices.Count; i++)
            {
                int index = i;
                Button button = Instantiate(choiceButtonPrefab, choiceButtonContainer);
                button.gameObject.SetActive(true);
                button.GetComponentInChildren<Text>().text = node.choices[i].choiceText;
                button.onClick.AddListener(() => OnChoiceSelected(index));
                activeChoiceButtons.Add(button);
            }
        }
        else
        {
            ClearChoices();
            endButton.gameObject.SetActive(node.isEndNode);
        }
    }

    public void ShowEndButton()
    {
        if (endButton != null)
        {
            endButton.gameObject.SetActive(true);
        }
    }

    public void HideDialoguePanel()
    {
        if (dialoguePanel != null)
        {
            dialoguePanel.SetActive(false);
        }

        ClearChoices();
    }

    private void ClearChoices()
    {
        foreach (Button button in activeChoiceButtons)
        {
            if (button != null)
            {
                button.onClick.RemoveAllListeners();
                Destroy(button.gameObject);
            }
        }

        activeChoiceButtons.Clear();
    }

    private void OnChoiceSelected(int index)
    {
        DialogueManager.Instance.SelectChoice(index);
    }
}