using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonCreater : MonoBehaviour {

    [SerializeField]
    private Text hoverText;

	public void CreateButton(GameObject buttonPrefab, GameObject parent, UnityAction callback)
    {
        GameObject button = Instantiate(buttonPrefab, parent.transform);
        button.GetComponent<Button>().onClick.AddListener(callback);
    }

    public void CreateSkinButton(GameObject buttonPrefab, GameObject parent,
                                Sprite sprite, UnityAction<Sprite> callback,
                                string name)
    {
        GameObject button = Instantiate(buttonPrefab, parent.transform);
        button.GetComponent<Button>().onClick.AddListener(delegate { callback(sprite); });
        button.GetComponent<Image>().sprite = sprite;
        button.GetComponentInChildren<Text>().text = "";

        EventTrigger trigger = button.GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter;
        entry.callback.AddListener(delegate { OnButtonHover(name); });
        trigger.triggers.Add(entry);

        entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerExit;
        entry.callback.AddListener(delegate { OnButtonLeave(); } );
        trigger.triggers.Add(entry);
    }

    private void OnButtonHover(string name)
    {
        hoverText.text = name;
    }

    private void OnButtonLeave()
    {
        hoverText.text = "";
    }
}
