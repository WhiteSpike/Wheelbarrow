using System.Collections.Generic;
using CustomItemBehaviourLibrary.AbstractItems;
using GameNetcodeStuff;
using UnityEngine;
using UnityEngine.InputSystem;
using Wheelbarrow.Input;
using Wheelbarrow.Misc;

namespace Wheelbarrow.Behaviour
{
    internal class WheelbarrowBehaviour : ContainerBehaviour
    {
        private GameObject wheel;
        private RoundManager _roundManager;
        private bool _isLootRegistered;
        private List<GrabbableObject> _itemsCache = new List<GrabbableObject>();
        internal const string ITEM_NAME = "Wheelbarrow";
        internal const string ITEM_DESCRIPTION = "Allows carrying multiple items";
        protected bool KeepScanNode
        {
            get
            {
                return Plugin.Config.SCAN_NODE;
            }
        }
        
        public string GetDisplayInfo()
        {
            return $"A portable container which has a maximum capacity of {Plugin.Config.MAXIMUM_AMOUNT_ITEMS.Value}" +
                $" and reduces the effective weight of the inserted items by {Plugin.Config.WEIGHT_REDUCTION_MULTIPLIER.Value * 100} %.\n" +
                $"It weighs {Plugin.Config.WEIGHT.Value} lbs";
        }

        protected override bool ShowDepositPrompts()
        {
            PlayerControllerB player = GameNetworkManager.Instance.localPlayerController;
            return player.isHoldingObject && playerHeldBy != player;
        }

        public override void Start()
        { 
            base.Start();

            Transform[] allChildren = GetComponentsInChildren<Transform>(true);
            foreach (Transform children in allChildren)
            {
                if (children.name == "lgu_wheelbarrow_wheel")
                {
                    wheel = children.gameObject;
                    break;
                }
            }

            if (wheel == null) 
                Plugin.mls.LogError($"[{ITEM_NAME}] Could not find wheel object!");
            
            PluginConfig config = Plugin.Config;
            maximumAmountItems = config.MAXIMUM_AMOUNT_ITEMS.Value;
            weightReduceMultiplier = config.WEIGHT_REDUCTION_MULTIPLIER.Value;
            restriction = config.RESTRICTION_MODE;
            maximumWeightAllowed = config.MAXIMUM_WEIGHT_ALLOWED.Value;
            noiseRange = config.NOISE_RANGE.Value;
            sloppiness = config.MOVEMENT_SLOPPY.Value;
            lookSensitivityDrawback = config.LOOK_SENSITIVITY_DRAWBACK.Value;
            playSounds = config.PLAY_NOISE.Value;
            wheelsClip = Plugin.wheelsNoise.ToArray();
            _roundManager = RoundManager.Instance;
            if (itemProperties.isScrap && scrapValue <= 0)
            {
                System.Random random = new System.Random(StartOfRound.Instance.randomMapSeed + 105);
                SetScrapValue(random.Next(config.MINIMUM_VALUE.Value, config.MAXIMUM_VALUE.Value));
            }
            if (!KeepScanNode) Destroy(gameObject.GetComponentInChildren<ScanNodeProperties>());
        }

        public override void Update()
        {
            bool hasItems = inWheelBarrow();
            
            base.Update();
 
            if (hasItems && playerHeldBy != null && playerHeldBy.isInHangarShipRoom && !_isLootRegistered) RegistryInShip();            
            
            if (!hasItems || !isInShipRoom) _isLootRegistered = false;
            
            if (!(isHeld && playerHeldBy.thisController.velocity.magnitude > 0f)) return;
            
            wheel.transform.Rotate(Time.deltaTime, 0f, 0f, Space.Self);
            wheel.transform.rotation.Set(wheel.transform.rotation.x % 360, wheel.transform.rotation.y, wheel.transform.rotation.z, wheel.transform.rotation.w);
        }

        protected override void SetupScanNodeProperties()
        {
            ScanNodeProperties scanNodeProperties = GetComponentInChildren<ScanNodeProperties>();
            if (scanNodeProperties != null) Tools.ChangeScanNode(ref scanNodeProperties, (Tools.NodeType)scanNodeProperties.nodeType, header: ITEM_NAME, subText: ITEM_DESCRIPTION);
            else Tools.AddGeneralScanNode(objectToAddScanNode: gameObject, header: ITEM_NAME, subText: ITEM_DESCRIPTION);
        }

        protected override string[] SetupContainerTooltips()
        {
            string controlBind = IngameKeybinds.Instance.WheelbarrowKey.GetBindingDisplayString();
            return [$"Drop all items: [{controlBind}]"];
        }
        
        
        protected bool inWheelBarrow()
        {
            GetComponentsInChildren<GrabbableObject>(false, _itemsCache);

            foreach (GrabbableObject component in _itemsCache)
            {
                if (component != null && component != this) return true;
            }
            
            return false;
        }
        
        protected void RegistryInShip()
        {
            GetComponentsInChildren<GrabbableObject>(false, _itemsCache);
            foreach (GrabbableObject component in _itemsCache)
            {
                if (component == null || component == this) continue;
                
                _roundManager.CollectNewScrapForThisRound(component);
            }
            _isLootRegistered = true;
        }
    }
}