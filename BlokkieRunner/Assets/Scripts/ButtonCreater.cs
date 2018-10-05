using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonCreater : MonoBehaviour {

	public void CreateButton(GameObject buttonPrefab, GameObject parent, UnityAction callback)
    {
        GameObject button = Instantiate(buttonPrefab, parent.transform);
        button.GetComponent<Button>().onClick.AddListener(callback);
    }

    public void CreateSkinButton(GameObject buttonPrefab, GameObject parent,
                                Sprite sprite, UnityAction<Sprite> callback)
    {
        GameObject button = Instantiate(buttonPrefab, parent.transform);
        button.GetComponent<Button>().onClick.AddListener(delegate { callback(sprite); });
        button.GetComponent<Image>().sprite = sprite;
        button.GetComponentInChildren<Text>().text = "";
        //button.AddComponent<EventTrigger>().OnPointerEnter();
    }
}
