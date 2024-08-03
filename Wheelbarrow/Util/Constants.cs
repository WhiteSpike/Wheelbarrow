using CustomItemBehaviourLibrary.AbstractItems;
using Wheelbarrow.Behaviour;
namespace Wheelbarrow.Util
{
    internal static class Constants
    {
        internal const string ITEM_SCAN_NODE_KEY_FORMAT = "Enable scan node of {0}";
        internal const bool ITEM_SCAN_NODE_DEFAULT = true;
        internal const string ITEM_SCAN_NODE_DESCRIPTION = "Shows a scan node on the item when scanning";

        internal const string WHEELBARROW_PRICE_KEY = $"{WheelbarrowBehaviour.ITEM_NAME} price";
        internal const int WHEELBARROW_PRICE_DEFAULT = 500;
        internal const string WHEELBARROW_PRICE_DESCRIPTION = $"Price for {WheelbarrowBehaviour.ITEM_NAME}.";

        internal const string WHEELBARROW_WEIGHT_KEY = "Item weight";
        internal const int WHEELBARROW_WEIGHT_DEFAULT = 15;
        internal const string WHEELBARROW_WEIGHT_DESCRIPTION = "Weight (in lbs)";

        internal const string WHEELBARROW_CONDUCTIVE_KEY = "Conductive";
        internal const bool WHEELBARROW_CONDUCTIVE_DEFAULT = true;
        internal const string WHEELBARROW_CONDUCTIVE_DESCRIPTION = "Wether it attracts lightning to the item or not. (Or other mechanics that rely on item being conductive)";

        internal const string WHEELBARROW_DROP_AHEAD_PLAYER_KEY = "Drop ahead of player when dropping";
        internal const bool WHEELBARROW_DROP_AHEAD_PLAYER_DEFAULT = true;
        internal const string WHEELBARROW_DROP_AHEAD_PLAYER_DESCRIPTION = "If on, the item will drop infront of the player. Otherwise, drops underneath them and slightly infront.";

        internal const string WHEELBARROW_GRABBED_BEFORE_START_KEY = "Grabbable before game start";
        internal const bool WHEELBARROW_GRABBED_BEFORE_START_DEFAULT = true;
        internal const string WHEELBARROW_GRABBED_BEFORE_START_DESCRIPTION = "Allows wether the item can be grabbed before hand or not";

        internal const string WHEELBARROW_HIGHEST_SALE_PERCENTAGE_KEY = "Highest Sale Percentage";
        internal const int WHEELBARROW_HIGHEST_SALE_PERCENTAGE_DEFAULT = 50;
        internal const string WHEELBARROW_HIGHEST_SALE_PERCENTAGE_DESCRIPTION = "Maximum percentage of sale allowed when this item is selected for a sale.";

        internal const string WHEELBARROW_RESTRICTION_MODE_KEY = $"Restrictions on the {WheelbarrowBehaviour.ITEM_NAME} Item";
        internal const ContainerBehaviour.Restrictions WHEELBARROW_RESTRICTION_MODE_DEFAULT = WheelbarrowBehaviour.Restrictions.ItemCount;
        internal const string WHEELBARROW_RESTRICTION_MODE_DESCRIPTION = $"Restriction applied when trying to insert an item on the {WheelbarrowBehaviour.ITEM_NAME}.\n" +
                                                                        "Supported values: None, ItemCount, TotalWeight, All";

        internal const string WHEELBARROW_MAXIMUM_WEIGHT_ALLOWED_KEY = $"Maximum amount of weight for {WheelbarrowBehaviour.ITEM_NAME}";
        internal const float WHEELBARROW_MAXIMUM_WEIGHT_ALLOWED_DEFAULT = 100f;
        internal const string WHEELBARROW_MAXIMUM_WEIGHT_ALLOWED_DESCRIPTION = $"How much weight (in lbs and after weight reduction multiplier is applied on the stored items) a {WheelbarrowBehaviour.ITEM_NAME} can carry in items before it is considered full.";

        internal const string WHEELBARROW_MAXIMUM_AMOUNT_ITEMS_KEY = $"Maximum amount of items for {WheelbarrowBehaviour.ITEM_NAME}";
        internal const int WHEELBARROW_MAXIMUM_AMOUNT_ITEMS_DEFAULT = 4;
        internal const string WHEELBARROW_MAXIMUM_AMOUNT_ITEMS_DESCRIPTION = $"Amount of items allowed before the {WheelbarrowBehaviour.ITEM_NAME} is considered full";

        internal const string WHEELBARROW_MINIMUM_VALUE_KEY = $"Minimum scrap value of {WheelbarrowBehaviour.ITEM_NAME}";
        internal const int WHEELBARROW_MINIMUM_VALUE_DEFAULT = 50;
        internal const string WHEELBARROW_MINIMUM_VALUE_DESCRIPTION = "Lower boundary of the scrap's possible value";

        internal const string WHEELBARROW_RARITY_KEY = $"Spawn Chance of the {WheelbarrowBehaviour.ITEM_NAME} Item";
        internal const float WHEELBARROW_RARITY_DEFAULT = 0.1f;
        internal const string WHEELBARROW_RARITY_DESCRIPTION = $"How likely it is for a {WheelbarrowBehaviour.ITEM_NAME} item to spawn when landing on a moon. (0.1 = 10%)";

        internal const string WHEELBARROW_MAXIMUM_VALUE_KEY = $"Maximum scrap value of {WheelbarrowBehaviour.ITEM_NAME}";
        internal const int WHEELBARROW_MAXIMUM_VALUE_DEFAULT = 100;
        internal const string WHEELBARROW_MAXIMUM_VALUE_DESCRIPTION = "Higher boundary of the scrap's possible value";

        internal const string WHEELBARROW_WEIGHT_REDUCTION_MULTIPLIER_KEY = $"Weight reduction multiplier for {WheelbarrowBehaviour.ITEM_NAME}";
        internal const float WHEELBARROW_WEIGHT_REDUCTION_MULTIPLIER_DEFAULT = 0.7f;
        internal const string WHEELBARROW_WEIGHT_REDUCTION_MUTLIPLIER_DESCRIPTION = $"How much an item's weight will be ignored to the {WheelbarrowBehaviour.ITEM_NAME}'s total weight";

        internal const string WHEELBARROW_NOISE_RANGE_KEY = $"Noise range of the {WheelbarrowBehaviour.ITEM_NAME} Item";
        internal const float WHEELBARROW_NOISE_RANGE_DEFAULT = 14f;
        internal const string WHEELBARROW_NOISE_RANGE_DESCRIPTION = $"How far the {WheelbarrowBehaviour.ITEM_NAME} sound propagates to nearby enemies when in movement";

        internal const string WHEELBARROW_LOOK_SENSITIVITY_DRAWBACK_KEY = $"Look sensitivity drawback of the {WheelbarrowBehaviour.ITEM_NAME} Item";
        internal const float WHEELBARROW_LOOK_SENSITIVITY_DRAWBACK_DEFAULT = 0.4f;
        internal const string WHEELBARROW_LOOK_SENSITIVITY_DRAWBACK_DESCRIPTION = $"Value multiplied on the player's look sensitivity when moving with the {WheelbarrowBehaviour.ITEM_NAME} Item";

        internal const string WHEELBARROW_MOVEMENT_SLOPPY_KEY = $"Sloppiness of the {WheelbarrowBehaviour.ITEM_NAME} Item";
        internal const float WHEELBARROW_MOVEMENT_SLOPPY_DEFAULT = 5f;
        internal const string WHEELBARROW_MOVEMENT_SLOPPY_DESCRIPTION = $"Value multiplied on the player's movement to give the feeling of drifting while carrying the {WheelbarrowBehaviour.ITEM_NAME} Item";

        internal const string WHEELBARROW_PLAY_NOISE_KEY = $"Plays noises for players with {WheelbarrowBehaviour.ITEM_NAME} Item";
        internal const bool WHEELBARROW_PLAY_NOISE_DEFAULT = true;
        internal const string WHEELBARROW_PLAY_NOISE_DESCRIPTION = "If false, it will just not play the sounds, it will still attract monsters to noise";

        internal const string WHEELBARROW_SCRAP_KEY = $"Scrap Item";
        internal const bool WHEELBARROW_SCRAP_DEFAULT = false;
        internal const string WHEELBARROW_SCRAP_DESCRIPTION = "If true, it will be considered as a scrap item and spawn inside the facility. Otherwise, it will be bought from the store";

        internal const string DROP_ALL_ITEMS_WHEELBARROW_KEYBIND_NAME = "Drop all items from wheelbarrow";
        internal const string DROP_ALL_ITEMS_WHEELBARROW_DEFAULT_KEYBIND = "<Mouse>/middleButton";

        internal static readonly string WHEELBARROW_SCAN_NODE_KEY = string.Format(ITEM_SCAN_NODE_KEY_FORMAT, WheelbarrowBehaviour.ITEM_NAME);
    }
}
