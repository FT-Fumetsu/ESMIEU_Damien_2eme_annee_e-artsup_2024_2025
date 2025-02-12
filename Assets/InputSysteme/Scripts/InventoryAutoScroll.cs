using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Menu
{
    public class ScrollViewBehaviour : MonoBehaviour
    {
        [SerializeField] private ScrollRect _scrollRect;
        [SerializeField] private RectTransform _inventoryContentList;

        private void Update()
        {
            for (int i = 0; i < _inventoryContentList.childCount; i++)
            {
                GameObject item = _inventoryContentList.GetChild(i).gameObject;
                if (EventSystem.current.currentSelectedGameObject == item)
                {
                    float normalizedPosition = 1 - (float)i / (_inventoryContentList.childCount - 1);
                    _scrollRect.verticalNormalizedPosition = normalizedPosition;
                    break;
                }
            }
        }
    }
}
