using UnityEngine;
using System.Collections;

public class DialoguePlayer : MonoBehaviour
{
    public DialogueConversation conversation = null;
    public TextMesh displayMesh = null;
    public Transform ModelTransfrom;

    public int lineIndex = -1;

    void Start()
    {
        nextLine();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            nextLine();
        }
    }

    private void nextLine()
    {
        lineIndex++;
        if (conversation != null && conversation.Lines != null && conversation.Lines.Count > lineIndex)
        {
            if (displayMesh != null)
            {
                displayMesh.text = conversation.Lines[lineIndex].Speaker + ": " + conversation.Lines[lineIndex].Text;
            }

            if (ModelTransfrom != null)
            {
                int childCount = ModelTransfrom.childCount;
                for (int i = 0; i < childCount; i ++)
                {
                    DestroyImmediate(ModelTransfrom.GetChild(i).gameObject);
                }
                GameObject o = Instantiate(conversation.Lines[lineIndex].obj);
                o.transform.parent = ModelTransfrom;
                o.transform.localPosition = Vector3.zero;
            }
        }
    }

}
