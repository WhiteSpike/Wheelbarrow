using BepInEx.Configuration;
using CSync.Extensions;
using CSync.Lib;
using Wheelbarrow.Behaviour;
using Wheelbarrow.Util;
using System.Runtime.Serialization;
using CustomItemBehaviourLibrary.AbstractItems;

namespace Wheelbarrow.Misc
{
    [DataContract]
    public class PluginConfig : SyncedConfig2<PluginConfig>
    {
        [field: SyncedEntryField] public SyncedEntry<bool> SCAN_NODE { get; set; }
        [field: SyncedEntryField] public SyncedEntry<int> PRICE { get; set; }
        [field: SyncedEntryField] public SyncedEntry<int> WEIGHT { get; set; }
        [field: SyncedEntryField] public SyncedEntry<bool> DROP_AHEAD_PLAYER { get; set; }
        [field: SyncedEntryField] public SyncedEntry<bool> GRABBED_BEFORE_START { get; set; }
        [field: SyncedEntryField] public SyncedEntry<bool> CONDUCTIVE { get; set; }
        [field: SyncedEntryField] public SyncedEntry<int> HIGHEST_SALE_PERCENTAGE { get; set; }
        [field: SyncedEntryField] public SyncedEntry<ContainerBehaviour.Restrictions> RESTRICTION_MODE { get; set; }
        [field: SyncedEntryField] public SyncedEntry<int> MAXIMUM_AMOUNT_ITEMS { get; set; }
        [field: SyncedEntryField] public SyncedEntry<float> MAXIMUM_WEIGHT_ALLOWED { get; set; }
        [field: SyncedEntryField] public SyncedEntry<float> WEIGHT_REDUCTION_MULTIPLIER { get; set; }
        [field: SyncedEntryField] public SyncedEntry<float> LOOK_SENSITIVITY_DRAWBACK { get; set; }
        [field: SyncedEntryField] public SyncedEntry<float> MOVEMENT_SLOPPY { get; set; }
        [field: SyncedEntryField] public SyncedEntry<float> NOISE_RANGE { get; set; }
        [field: SyncedEntryField] public SyncedEntry<bool> PLAY_NOISE { get; set; }
        [field: SyncedEntryField] public SyncedEntry<bool> SCRAP {  get; set; }
        [field: SyncedEntryField] public SyncedEntry<int> MINIMUM_VALUE { get; set; }
        [field: SyncedEntryField] public SyncedEntry<int> MAXIMUM_VALUE { get; set; }
        [field: SyncedEntryField] public SyncedEntry<float> RARITY { get; set; }
        public PluginConfig(ConfigFile cfg) : base(Metadata.GUID)
        {
            string topSection = WheelbarrowBehaviour.ITEM_NAME;

            PRICE = cfg.BindSyncedEntry(topSection, Constants.WHEELBARROW_PRICE_KEY, Constants.WHEELBARROW_PRICE_DEFAULT, Constants.WHEELBARROW_PRICE_DESCRIPTION);
            WEIGHT = cfg.BindSyncedEntry(topSection, Constants.WHEELBARROW_WEIGHT_KEY, Constants.WHEELBARROW_WEIGHT_DEFAULT, Constants.WHEELBARROW_WEIGHT_DESCRIPTION);
            SCAN_NODE = cfg.BindSyncedEntry(topSection, Constants.WHEELBARROW_SCAN_NODE_KEY, Constants.ITEM_SCAN_NODE_DEFAULT, Constants.ITEM_SCAN_NODE_DESCRIPTION);
            DROP_AHEAD_PLAYER = cfg.BindSyncedEntry(topSection, Constants.WHEELBARROW_DROP_AHEAD_PLAYER_KEY, Constants.WHEELBARROW_DROP_AHEAD_PLAYER_DEFAULT, Constants.WHEELBARROW_DROP_AHEAD_PLAYER_DESCRIPTION);
            CONDUCTIVE = cfg.BindSyncedEntry(topSection, Constants.WHEELBARROW_CONDUCTIVE_KEY, Constants.WHEELBARROW_CONDUCTIVE_DEFAULT, Constants.WHEELBARROW_CONDUCTIVE_DESCRIPTION);
            GRABBED_BEFORE_START = cfg.BindSyncedEntry(topSection, Constants.WHEELBARROW_GRABBED_BEFORE_START_KEY, Constants.WHEELBARROW_GRABBED_BEFORE_START_DEFAULT, Constants.WHEELBARROW_GRABBED_BEFORE_START_DESCRIPTION);
            HIGHEST_SALE_PERCENTAGE = cfg.BindSyncedEntry(topSection, Constants.WHEELBARROW_HIGHEST_SALE_PERCENTAGE_KEY, Constants.WHEELBARROW_HIGHEST_SALE_PERCENTAGE_DEFAULT, Constants.WHEELBARROW_HIGHEST_SALE_PERCENTAGE_DESCRIPTION);
            RESTRICTION_MODE = cfg.BindSyncedEntry(topSection, Constants.WHEELBARROW_RESTRICTION_MODE_KEY, Constants.WHEELBARROW_RESTRICTION_MODE_DEFAULT, Constants.WHEELBARROW_RESTRICTION_MODE_DESCRIPTION);
            MAXIMUM_WEIGHT_ALLOWED = cfg.BindSyncedEntry(topSection, Constants.WHEELBARROW_MAXIMUM_WEIGHT_ALLOWED_KEY, Constants.WHEELBARROW_MAXIMUM_WEIGHT_ALLOWED_DEFAULT, Constants.WHEELBARROW_MAXIMUM_WEIGHT_ALLOWED_DESCRIPTION);
            MAXIMUM_AMOUNT_ITEMS = cfg.BindSyncedEntry(topSection, Constants.WHEELBARROW_MAXIMUM_AMOUNT_ITEMS_KEY, Constants.WHEELBARROW_MAXIMUM_AMOUNT_ITEMS_DEFAULT, Constants.WHEELBARROW_MAXIMUM_AMOUNT_ITEMS_DESCRIPTION);
            WEIGHT_REDUCTION_MULTIPLIER = cfg.BindSyncedEntry(topSection, Constants.WHEELBARROW_WEIGHT_REDUCTION_MULTIPLIER_KEY, Constants.WHEELBARROW_WEIGHT_REDUCTION_MULTIPLIER_DEFAULT, Constants.WHEELBARROW_WEIGHT_REDUCTION_MUTLIPLIER_DESCRIPTION);
            NOISE_RANGE = cfg.BindSyncedEntry(topSection, Constants.WHEELBARROW_NOISE_RANGE_KEY, Constants.WHEELBARROW_NOISE_RANGE_DEFAULT, Constants.WHEELBARROW_NOISE_RANGE_DESCRIPTION);
            LOOK_SENSITIVITY_DRAWBACK = cfg.BindSyncedEntry(topSection, Constants.WHEELBARROW_LOOK_SENSITIVITY_DRAWBACK_KEY, Constants.WHEELBARROW_LOOK_SENSITIVITY_DRAWBACK_DEFAULT, Constants.WHEELBARROW_LOOK_SENSITIVITY_DRAWBACK_DESCRIPTION);
            MOVEMENT_SLOPPY = cfg.BindSyncedEntry(topSection, Constants.WHEELBARROW_MOVEMENT_SLOPPY_KEY, Constants.WHEELBARROW_MOVEMENT_SLOPPY_DEFAULT, Constants.WHEELBARROW_MOVEMENT_SLOPPY_DESCRIPTION);
            PLAY_NOISE = cfg.BindSyncedEntry(topSection, Constants.WHEELBARROW_PLAY_NOISE_KEY, Constants.WHEELBARROW_PLAY_NOISE_DEFAULT, Constants.WHEELBARROW_PLAY_NOISE_DESCRIPTION);
            SCRAP = cfg.BindSyncedEntry(topSection, Constants.WHEELBARROW_SCRAP_KEY, Constants.WHEELBARROW_SCRAP_DEFAULT, Constants.WHEELBARROW_SCRAP_DESCRIPTION);
            MINIMUM_VALUE = cfg.BindSyncedEntry(topSection, Constants.WHEELBARROW_MINIMUM_VALUE_KEY, Constants.WHEELBARROW_MINIMUM_VALUE_DEFAULT, Constants.WHEELBARROW_MINIMUM_VALUE_DESCRIPTION);
            MAXIMUM_VALUE = cfg.BindSyncedEntry(topSection, Constants.WHEELBARROW_MAXIMUM_VALUE_KEY, Constants.WHEELBARROW_MAXIMUM_VALUE_DEFAULT, Constants.WHEELBARROW_MAXIMUM_VALUE_DESCRIPTION);
            RARITY = cfg.BindSyncedEntry(topSection, Constants.WHEELBARROW_RARITY_KEY, Constants.WHEELBARROW_RARITY_DEFAULT, Constants.WHEELBARROW_RARITY_DESCRIPTION);

            ConfigManager.Register(this);
        }
    }
}
