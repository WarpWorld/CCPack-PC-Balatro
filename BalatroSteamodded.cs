using ConnectorLib.SimpleTCP;
using CrowdControl.Common;
using JetBrains.Annotations;
using ConnectorType = CrowdControl.Common.ConnectorType;

namespace CrowdControl.Games.Packs.BalatroSteamodded;

[UsedImplicitly]
public class BalatroSteamodded : SimpleTCPPack<SimpleTCPServerConnector>
{
    public override string Host => "127.0.0.1";

    public override ushort Port => 58430;

    public BalatroSteamodded(UserRecord player, Func<CrowdControlBlock, bool> responseHandler, Action<object> statusUpdateHandler) : base(player, responseHandler, statusUpdateHandler) { }

    public override Game Game { get; } = new("BalatroSteamodded", "BalatroSteamodded", "PC", ConnectorType.SimpleTCPServerConnector);
    
    public override EffectList Effects { get; } = new List<Effect>
    {
        new("Give $5", "addMoney_5") { Category = "Money" },
        new("Give $25", "addMoney_25") { Category = "Money" },
        new("Give $100", "addMoney_100") { Category = "Money" },
        new("Take $5", "addMoney_-5") { Category = "Money" },
        new("Take $25", "addMoney_-25") { Category = "Money" },
        new("Take $100", "addMoney_-100") { Category = "Money" },

        new("Take all Chips", "addChips_0") { Category = "Chips" },
        new("Take 10% of Blind", "addChips_-10") { Category = "Chips" },
        new("Take 25% of Blind", "addChips_-25") { Category = "Chips" },
        new("Give 10% of Blind", "addChips_10") { Category = "Chips" },
        new("Give 25% of Blind", "addChips_25") { Category = "Chips" },
        new("Complete Blind", "addChips_100") { Category = "Chips" },

        new("Reduce Blind by 25%", "addBlind_-25") { Category = "Blind" },
        new("Halve Blind", "addBlind_-50") { Category = "Blind" },
        new("Increase Blind by 25%", "addBlind_25") { Category = "Blind" },
        new("Double Blind", "addBlind_100") { Category = "Blind" },

        new("Give Extra Hand", "addHands_1") { Category = "Hands / Discards" },
        new("Give Extra Discard", "addDiscards_1") { Category = "Hands / Discards" },
        new("Take Hand", "addHands_-1") { Category = "Hands / Discards" },
        new("Take Discard", "addDiscards_-1") { Category = "Hands / Discards" },

        new("Randomize Hand", "randomizeHand") { Category = new[] { "Hand", "Card Suits", "Card Values" } },

        new("Cycle Hand Up", "cycleHand_1") { Category = new[] { "Hand", "Card Values" } },
        new("Cycle Hand Down", "cycleHand_-1") { Category = new[] { "Hand", "Card Values" } },
        new("Cycle Hand Up 4", "cycleHand_4") { Category = new[] { "Hand", "Card Values" } },
        new("Cycle Hand Down 4", "cycleHand_-4") { Category = new[] { "Hand", "Card Values" } },
        new("Boost Hand", "boostHand_1") { Category = new[] { "Hand", "Card Values" } },
        new("Reduce Hand", "boostHand_-1") { Category = new[] { "Hand", "Card Values" } },
        new("Boost Hand by 4", "boostHand_4") { Category = new[] { "Hand", "Card Values" } },
        new("Reduce Hand by  4", "boostHand_-4") { Category = new[] { "Hand", "Card Values" } },
        new("Randomize Hand Values", "randomizeValue") { Category = new[] { "Hand", "Card Values" } },

        new("Cycle Random Card Up", "rand_cycleHand_1") { Category = new[] { "Single Card", "Card Values" } },
        new("Cycle Random Card Down", "rand_cycleHand_-1") { Category = new[] { "Single Card", "Card Values" } },
        new("Cycle Random Card Up 4", "rand_cycleHand_4") { Category = new[] { "Single Card", "Card Values" } },
        new("Cycle Random Card Down 4", "rand_cycleHand_-4") { Category = new[] { "Single Card", "Card Values" } },
        new("Boost Random Card", "rand_boostHand_1") { Category = new[] { "Single Card", "Card Values" } },
        new("Reduce Random Card", "rand_boostHand_-1") { Category = new[] { "Single Card", "Card Values" } },
        new("Boost Random Card by 4", "rand_boostHand_4") { Category = new[] { "Single Card", "Card Values" } },
        new("Reduce Random Card by 4", "rand_boostHand_-4") { Category = new[] { "Single Card", "Card Values" } },
        new("Randomize Random Card Value", "rand_randomizeValue") { Category = new[] { "Single Card", "Card Values" } },


        new("Change Hand to Diamonds", "setHandSuit_Diamonds") { Category = new[] { "Hand", "Card Suits" } },
        new("Change Hand to Clubs", "setHandSuit_Clubs") { Category = new[] { "Hand", "Card Suits" } },
        new("Change Hand to Hearts", "setHandSuit_Hearts") { Category = new[] { "Hand", "Card Suits" } },
        new("Change Hand to Spades", "setHandSuit_Spades") { Category = new[] { "Hand", "Card Suits" } },
        new("Cycle Hand Suit", "cycleHandSuit") { Category = new[] { "Hand", "Card Suits" } },
        new("Randomize Hand Suits", "randomizeSuit") { Category = new[] { "Hand", "Card Suits" } },

        new("Change Random Card to Diamonds", "rand_setHandSuit_Diamonds") { Category = new[] { "Single Card", "Card Suits" } },
        new("Change Random Card to Clubs", "rand_setHandSuit_Clubs") { Category = new[] { "Single Card", "Card Suits" } },
        new("Change Random Card to Hearts", "rand_setHandSuit_Hearts") { Category = new[] { "Single Card", "Card Suits" } },
        new("Change Random Card to Spades", "rand_setHandSuit_Spades") { Category = new[] { "Single Card", "Card Suits" } },
        new("Cycle Random Card Suit", "rand_cycleHandSuit") { Category = new[] { "Single Card", "Card Suits" } },
        new("Randomize Random Card Suit", "rand_randomizeSuit") { Category = new[] { "Single Card", "Card Suits" } },

        new("Destroy Hand", "destroyHand") { Category = new[] { "Hand", "Card Removal" } },
        new("Discard Hand", "discardHand") { Category = new[] { "Hand", "Card Removal" } },
        new("Remove Card from Deck", "destroyDeck") { Category = new[] { "Hand", "Card Removal" } },

        new("Destroy Random Card", "rand_destroyHand") { Category = new[] { "Single Card", "Card Removal" } },
        new("Discard Random Card", "rand_discardHand") { Category = new[] { "Single Card", "Card Removal" } },

        new("Flip Hand", "flipHand") { Category = "Hand" },
        new("Flip Random Card", "rand_flipHand") { Category = "Single Card" },

        new("Change Hand to Foils", "changeHandEdition_Foil") { Category = new[] { "Hand", "Card Edition" } },
        new("Change Hand to Holographic", "changeHandEdition_Holo") { Category = new[] { "Hand", "Card Edition" } },
        new("Change Hand to Polychrome", "changeHandEdition_Polychrome") { Category = new[] { "Hand", "Card Edition" } },
        new("Remove Hand Editions", "changeHandEdition_BASE") { Category = new[] { "Hand", "Card Edition" } },

        new("Change Hand Seal to Red", "changeHandSeal_Red") { Category = new[] { "Hand", "Seals" } },
        new("Change Hand Seal to Blue", "changeHandSeal_Blue") { Category = new[] { "Hand", "Seals" } },
        new("Change Hand Seal to Gold", "changeHandSeal_Gold") { Category = new[] { "Hand", "Seals" } },
        new("Change Hand Seal to Purple", "changeHandSeal_Purple") { Category = new[] { "Hand", "Seals" } },
        new("Remove Hand Seals", "changeHandSeal_BASE") { Category = new[] { "Hand", "Seals" } },

        new("Remove Hand Modifier", "changeHandCenter_c_base") { Category = new[] { "Hand", "Card Modifier" } },
        new("Change Hand Modifier to Bonus", "changeHandCenter_m_bonus") { Category = new[] { "Hand", "Card Modifier" } },
        new("Change Hand Modifier to Mult", "changeHandCenter_m_mult") { Category = new[] { "Hand", "Card Modifier" } },
        new("Change Hand Modifier to Wild", "changeHandCenter_m_wild") { Category = new[] { "Hand", "Card Modifier" } },
        new("Change Hand Modifier to Glass", "changeHandCenter_m_glass") { Category = new[] { "Hand", "Card Modifier" } },
        new("Change Hand Modifier to Steel", "changeHandCenter_m_steel") { Category = new[] { "Hand", "Card Modifier" } },
        new("Change Hand Modifier to Stone", "changeHandCenter_m_stone") { Category = new[] { "Hand", "Card Modifier" } },
        new("Change Hand Modifier to Gold", "changeHandCenter_m_gold") { Category = new[] { "Hand", "Card Modifier" } },
        new("Change Hand Modifier to Lucky", "changeHandCenter_m_lucky") { Category = new[] { "Hand", "Card Modifier" } },
        
        new("Change Random Card to Foil", "rand_changeHandEdition_Foil") { Category = new[] { "Single Card", "Card Edition" } },
        new("Change Random Card to Holographic", "rand_changeHandEdition_Holo") { Category = new[] { "Single Card", "Card Edition" } },
        new("Change Random Card to Polychrome", "rand_changeHandEdition_Polychrome") { Category = new[] { "Single Card", "Card Edition" } },
        new("Remove Random Card Edition", "rand_changeHandEdition_BASE") { Category = new[] { "Single Card", "Card Edition" } },

        new("Change Random Card Seal to Red", "rand_changeHandSeal_Red") { Category = new[] { "Single Card", "Seals" } },
        new("Change Random Card Seal to Blue", "rand_changeHandSeal_Blue") { Category = new[] { "Single Card", "Seals" } },
        new("Change Random Card Seal to Gold", "rand_changeHandSeal_Gold") { Category = new[] { "Single Card", "Seals" } },
        new("Change Random Card Seal to Purple", "rand_changeHandSeal_Purple") { Category = new[] { "Single Card", "Seals" } },
        new("Remove Random Card Seal", "rand_changeHandSeal_BASE") { Category = new[] { "Single Card", "Seals" } },

        new("Remove Random Card Modifier", "rand_changeHandCenter_c_base") { Category = new[] { "Single Card", "Card Modifier" } },
        new("Change Random Card Modifier to Bonus", "rand_changeHandCenter_m_bonus") { Category = new[] { "Single Card", "Card Modifier" } },
        new("Change Random Card Modifier to Mult", "rand_changeHandCenter_m_mult") { Category = new[] { "Single Card", "Card Modifier" } },
        new("Change Random Card Modifier to Wild", "rand_changeHandCenter_m_wild") { Category = new[] { "Single Card", "Card Modifier" } },
        new("Change Random Card Modifier to Glass", "rand_changeHandCenter_m_glass") { Category = new[] { "Single Card", "Card Modifier" } },
        new("Change Random Card Modifier to Steel", "rand_changeHandCenter_m_steel") { Category = new[] { "Single Card", "Card Modifier" } },
        new("Change Random Card Modifier to Stone", "rand_changeHandCenter_m_stone") { Category = new[] { "Single Card", "Card Modifier" } },
        new("Change Random Card Modifier to Gold", "rand_changeHandCenter_m_gold") { Category = new[] { "Single Card", "Card Modifier" } },
        new("Change Random Card Modifier to Lucky", "rand_changeHandCenter_m_lucky") { Category = new[] { "Single Card", "Card Modifier" } },

        new("Give Random Tarot", "addTarot") { Category = new[] { "Consumeables", "Tarot Cards", "Give Cards" } },
        new("Give Random Planet", "addPlanet") { Category = new[] { "Consumeables", "Planet Cards", "Give Cards" } },
        new("Give Random Spectral", "addSpectral") { Category = new[] { "Consumeables", "Spectral Cards", "Give Cards" } },
        new("Destroy Random Consumeable", "crand_destroyConsumables") { Category = new[] { "Consumeables", "Card Removal" } },
        new("Destroy Consumeables", "destroyConsumables") { Category = new[] { "Consumeables", "Card Removal" } },

        new("Give Random Joker", "addJoker") { Category = new[] { "Jokers", "Give Cards" } },
        new("Destroy Jokers", "destroyJokers") { Category = new[] { "Jokers", "Card Removal" } },
        new("Destroy Random Joker", "jrand_destroyJokers") { Category = new[] { "Jokers", "Card Removal" } },

        new("Change Random Joker to Foil", "jrand_changeJokerEdition_Foil") { Category = new[] { "Jokers", "Card Edition" } },
        new("Change Random Joker to Holographic", "jrand_changeJokerEdition_Holo") { Category = new[] { "Jokers", "Card Edition" } },
        new("Change Random Joker to Polychrome", "jrand_changeJokerEdition_Polychrome") { Category = new[] { "Jokers", "Card Edition" } },
        new("Remove Random Joker Edition", "jrand_changeJokerEdition_BASE") { Category = new[] { "Jokers", "Card Edition" } },

        new("Open Standard Pack", "openBooster_p_standard_normal_1") { Category = "Boosters" },
        new("Open Mega Standard Pack", "openBooster_p_standard_mega_1") { Category = "Boosters" },
        new("Open Arcana Pack", "openBooster_p_arcana_normal_1") { Category = "Boosters" },
        new("Open Mega Arcana Pack", "openBooster_p_arcana_mega_1") { Category = "Boosters" },
        new("Open Celestial Pack", "openBooster_p_celestial_normal_1") { Category = "Boosters" },
        new("Open Mega Celestial Pack", "openBooster_p_celestial_mega_1") { Category = "Boosters" },
        new("Open Spectral Pack", "openBooster_p_spectral_normal_1") { Category = "Boosters" },
        new("Open Mega Spectral Pack", "openBooster_p_spectral_mega_1") { Category = "Boosters" },
        new("Open Buffoon Pack", "openBooster_p_buffoon_normal_1") { Category = "Boosters" },
        new("Open Mega Buffoon Pack", "openBooster_p_buffoon_mega_1") { Category = "Boosters" },

        new("Draw a Card", "drawFromDeck_1") { Category = new[] { "Playing Cards", "Deck", "Give Cards" } },
        new("Return a Discarded Card", "drawFromDiscard_1") { Category = new[] { "Playing Cards", "Give Cards" } },
        new("Shuffle Discards into Deck", "reshuffle") { Category = new[] { "Playing Cards", "Deck", "Give Cards" } },
        new("Give Random Face Card", "addFaceCard") { Category = new[] { "Playing Cards", "Give Cards" } },
        new("Give Random Number Card", "addNumberCard") { Category = new[] { "Playing Cards", "Give Cards" } },

        new("Debuff Hand", "debuffHand_true") { Category = new[] { "Hand", "Debuffs" } },
        new("Un-Debuff Hand", "debuffHand_false") { Category = new[] { "Hand", "Debuffs" } },
        new("Debuff Random Card", "rand_debuffHand_true") { Category = new[] { "Single Card", "Debuffs" } },
        new("Un-Debuff Random Card", "rand_debuffHand_false") { Category = new[] { "Single Card", "Debuffs" } }
    };
}