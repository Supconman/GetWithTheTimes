using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance { get; private set; }

    private DialogueData currentDialogue;
    private DialogueNode currentNode;
    private int currentNodeId;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartDialogue(DialogueData dialogueData)
    {
        currentDialogue = dialogueData;
        currentNodeId = dialogueData.startNodeId;
        currentNode = dialogueData.GetNode(currentNodeId);

        if (currentNode != null)
        {
            DialogueUIController.Instance.DisplayNode(currentNode);
        }
    }

    public void SelectChoice(int choiceIndex)
    {
        if (currentNode == null || choiceIndex < 0 || choiceIndex >= currentNode.choices.Count)
            return;

        DialogueChoice choice = currentNode.choices[choiceIndex];
        currentNodeId = choice.nextNodeId;
        currentNode = currentDialogue.GetNode(currentNodeId);

        if (currentNode != null)
        {
            if (currentNode.isEndNode)
            {
                DialogueUIController.Instance.DisplayNode(currentNode);
                DialogueUIController.Instance.ShowEndButton();
            }
            else
            {
                DialogueUIController.Instance.DisplayNode(currentNode);
            }
        }
    }

    public void EndDialogue()
    {
        currentDialogue = null;
        currentNode = null;
        DialogueUIController.Instance.HideDialoguePanel();
    }

    public DialogueNode GetCurrentNode()
    {
        return currentNode;
    }
}
