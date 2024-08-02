using BepInEx;
using BepInEx.Logging;
using Wheelbarrow.Behaviour;
using Wheelbarrow.Misc;
using HarmonyLib;
using LethalLib.Modules;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;
using CustomItemBehaviourLibrary.Misc;
using Wheelbarrow.Input;
using Wheelbarrow.Compat;
namespace Wheelbarrow
{
    [BepInPlugin(Metadata.GUID,Metadata.NAME,Metadata.VERSION)]
    [BepInDependency("com.sigurd.csync")]
    [BepInDependency("evaisa.lethallib")]
    public class Plugin : BaseUnityPlugin
    {
        internal static readonly Harmony harmony = new(Metadata.GUID);
        internal static readonly ManualLogSource mls = BepInEx.Logging.Logger.CreateLogSource(Metadata.NAME);
        internal static readonly List<AudioClip> wheelsNoise = [];

        public new static PluginConfig Config;

        void Awake()
        {
            Config = new PluginConfig(base.Config);

            string assetDir = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "wheelbarrow");
            AssetBundle bundle = AssetBundle.LoadFromFile(assetDir);
            string root = "Assets/Wheelbarrow/";

            Item wheelbarrowItem = ScriptableObject.CreateInstance<Item>();
            wheelbarrowItem.name = "WheelbarrowItemProperties";
            wheelbarrowItem.allowDroppingAheadOfPlayer = Config.DROP_AHEAD_PLAYER;
            wheelbarrowItem.canBeGrabbedBeforeGameStart = Config.GRABBED_BEFORE_START;
            wheelbarrowItem.canBeInspected = false;
            wheelbarrowItem.creditsWorth = Config.PRICE;
            wheelbarrowItem.floorYOffset = -90;
            wheelbarrowItem.restingRotation = new Vector3(0f, 0f, 0f);
            wheelbarrowItem.rotationOffset = new Vector3(0f, 0f, 0f);
            wheelbarrowItem.positionOffset = new Vector3(0f, -0.7f, 1.4f);
            wheelbarrowItem.verticalOffset = 0.3f;
            wheelbarrowItem.weight = 0.99f + (Config.WEIGHT / 100f);
            wheelbarrowItem.twoHanded = true;
            wheelbarrowItem.itemIcon = bundle.LoadAsset<Sprite>(root + "Icon.png");
            wheelbarrowItem.spawnPrefab = bundle.LoadAsset<GameObject>(root + "Wheelbarrow.prefab");
            wheelbarrowItem.dropSFX = bundle.LoadAsset<AudioClip>(root + "Drop.ogg");
            wheelbarrowItem.grabSFX = bundle.LoadAsset<AudioClip>(root + "Grab.ogg");
            wheelbarrowItem.pocketSFX = bundle.LoadAsset<AudioClip>(root + "Pocket.ogg");
            wheelbarrowItem.throwSFX = bundle.LoadAsset<AudioClip>(root + "Throw.ogg");
            mls.LogDebug(wheelsNoise.Count);
            wheelsNoise.Add(bundle.TryLoadAudioClipAsset(root + "Wheelbarrow_Move_1.mp3"));
            wheelsNoise.Add(bundle.TryLoadAudioClipAsset(root + "Wheelbarrow_Move_2.ogg"));
            wheelsNoise.Add(bundle.TryLoadAudioClipAsset(root + "Wheelbarrow_Move_3.ogg"));
            wheelsNoise.Add(bundle.TryLoadAudioClipAsset(root + "Wheelbarrow_Move_4.ogg"));
            mls.LogDebug(wheelsNoise.Count);
            wheelbarrowItem.highestSalePercentage = Config.HIGHEST_SALE_PERCENTAGE;
            wheelbarrowItem.itemName = WheelbarrowBehaviour.ITEM_NAME;
            wheelbarrowItem.itemSpawnsOnGround = true;
            wheelbarrowItem.isConductiveMetal = Config.CONDUCTIVE;
            wheelbarrowItem.requiresBattery = false;
            wheelbarrowItem.batteryUsage = 0f;
            wheelbarrowItem.twoHandedAnimation = true;
            wheelbarrowItem.grabAnim = "HoldJetpack";

            WheelbarrowBehaviour grabbableObject = wheelbarrowItem.spawnPrefab.AddComponent<WheelbarrowBehaviour>();
            grabbableObject.itemProperties = wheelbarrowItem;
            grabbableObject.grabbable = true;
            grabbableObject.grabbableToEnemies = true;
            NetworkPrefabs.RegisterNetworkPrefab(wheelbarrowItem.spawnPrefab);

            TerminalNode infoNode = SetupInfoNode();
            Items.RegisterShopItem(shopItem: wheelbarrowItem, itemInfo: infoNode, price: wheelbarrowItem.creditsWorth);
            InputUtilsCompat.Init();
            harmony.PatchAll(typeof(Keybinds));

            mls.LogInfo($"{Metadata.NAME} {Metadata.VERSION} has been loaded successfully.");
        }
        internal static TerminalNode SetupInfoNode()
        {
            TerminalNode infoNode = ScriptableObject.CreateInstance<TerminalNode>();
            infoNode.displayText += GetDisplayInfo() + "\n";
            infoNode.clearPreviousText = true;
            return infoNode;
        }
        public static string GetDisplayInfo()
        {
            return $"A portable container which has a maximum capacity of {Config.MAXIMUM_AMOUNT_ITEMS.Value}" +
                $" and reduces the effective weight of the inserted items by {Config.WEIGHT_REDUCTION_MULTIPLIER.Value * 100} %.\n" +
                $"It weighs {Config.WEIGHT.Value} lbs";
        }
    }   
}
