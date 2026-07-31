using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueChoice
{
    public string choiceText;
    public int nextNodeId;
}

[System.Serializable]
public class DialogueNode
{
    public int id;
    public string speakerName;
    public string dialogueText;
    public List<DialogueChoice> choices = new List<DialogueChoice>();
    public bool isEndNode; // true if dialogue ends here
}

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue/Dialogue Data")]
public class DialogueData : ScriptableObject
{
    public string dialogueId;
    public List<DialogueNode> nodes = new List<DialogueNode>();
    public int startNodeId = 0;

    public DialogueNode GetNode(int nodeId)
    {
        foreach (var node in nodes)
        {
            if (node.id == nodeId)
                return node;
        }
        return null;
    }
}
