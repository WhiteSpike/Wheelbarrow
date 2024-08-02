using CustomItemBehaviourLibrary.AbstractItems;
using UnityEngine;
using UnityEngine.InputSystem;
using Wheelbarrow.Input;
using Wheelbarrow.Misc;

namespace Wheelbarrow.Behaviour
{
    internal class WheelbarrowBehaviour : ContainerBehaviour
    {
        private GameObject wheel;
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

        public override void Start()
        {
            base.Start();
            wheel = GameObject.Find("lgu_wheelbarrow_wheel");
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
        }

        public override void Update()
        {
            base.Update();
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

        protected override string[] SetupWheelbarrowTooltips()
        {
            string controlBind = IngameKeybinds.Instance.WheelbarrowKey.GetBindingDisplayString();
            return [$"Drop all items: [{controlBind}]"];
        }
    }
}
