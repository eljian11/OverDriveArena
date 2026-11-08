using System;
using Project.Scripts.Environment.Reworked.Room;
using UnityEngine;
using UnityEngine.UIElements;

namespace Project.Scripts.TestScripts
{
    public sealed class ItemUI : MonoBehaviour
    {
        [SerializeField] private TextMesh _itemNameText;
        [SerializeField] private Button _itemButton;
        [SerializeField] private RoomItemData _itemData;
        
        public Action<RoomItemData> OnItemSelected;

        private void OnEnable()
        {
            if (this._itemButton != null)
            {
                this._itemButton.clickable.clicked += OnItemButtonClicked;
            }
        }
        
        private void OnDisable()
        {
            if (this._itemButton != null)
            {
                this._itemButton.clickable.clicked -= OnItemButtonClicked;
            }
        }

        private void OnItemButtonClicked()
        {
            this.OnItemSelected?.Invoke(this._itemData);
        }

        public void Initialize(RoomItemData itemData)
        {
            if (itemData == null)
            {
                Debug.LogError("ItemData is null.");
                return;
            }
            
            this._itemData = itemData;

            if (this._itemNameText != null)
            {
                this._itemNameText.text = itemData.itemName;
            }
        }
    }
}