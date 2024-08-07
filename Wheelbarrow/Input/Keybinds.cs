﻿using GameNetcodeStuff;
using HarmonyLib;
using UnityEngine.InputSystem;
using Wheelbarrow.Behaviour;
using Wheelbarrow.Compat;
using static UnityEngine.InputSystem.InputAction;

namespace Wheelbarrow.Input
{
    /// <summary>
    /// Class used to initialize the keybinds on game boot
    /// </summary>
    [HarmonyPatch]
    internal static class Keybinds
    {
        /// <summary>
        /// Asset used to store all the input bindings defined for our controls
        /// </summary>
        public static InputActionAsset Asset;

        public static InputActionMap ActionMap;

        /// <summary>
        /// Input binding used to trigger the drop all items in the wheelbarrow action
        /// </summary>
        public static InputAction WheelbarrowAction;

        public static PlayerControllerB localPlayerController => StartOfRound.Instance?.localPlayerController;

        /// <summary>
        /// Initializes the related assets with the control bindings
        /// </summary>
        [HarmonyPatch(typeof(PreInitSceneScript), "Awake")]
        [HarmonyPrefix]
        public static void AddToKeybindMenu()
        {
            Asset = InputUtilsCompat.Asset;
            ActionMap = Asset.actionMaps[0];
            WheelbarrowAction = InputUtilsCompat.WheelbarrowKey;
        }
        /// <summary>
        /// Turn on relevant control bindings when starting a game
        /// </summary>
        [HarmonyPatch(typeof(StartOfRound), "OnEnable")]
        [HarmonyPostfix]
        public static void OnEnable()
        {
            Asset.Enable();
            WheelbarrowAction.performed += OnWheelbarrowActionPerformed;
        }

        /// <summary>
        /// Turn off relevant control bindings when exiting a game
        /// </summary>
        [HarmonyPatch(typeof(StartOfRound), "OnDisable")]
        [HarmonyPostfix]
        public static void OnDisable()
        {
            Asset.Disable();
            WheelbarrowAction.performed -= OnWheelbarrowActionPerformed;
        }
        /// <summary>
        /// Function performed when triggering the "Drop all items in Wheelbarrow" control binding
        /// </summary>
        /// <param name="context">Context which triggered this function</param>
        private static void OnWheelbarrowActionPerformed(CallbackContext context)
        {
            if (localPlayerController == null || !localPlayerController.isPlayerControlled || (localPlayerController.IsServer && !localPlayerController.isHostPlayerObject))
            {
                return;
            }

            if (!localPlayerController.currentlyHeldObjectServer) return;
            WheelbarrowBehaviour wheelbarrow = localPlayerController.currentlyHeldObjectServer.GetComponent<WheelbarrowBehaviour>();
            if (!wheelbarrow) return;

            wheelbarrow.UpdateContainerDrop();
        }
    }
}
