using System;
using System.Collections.Generic;
using CrowdControl.Common;
using JetBrains.Annotations;
using ConnectorType = CrowdControl.Common.ConnectorType;

namespace CrowdControl.Games.Packs.Balatro
{
    [UsedImplicitly]
    public class Balatro : SimpleTCPPack
    {
        public override string Host => "127.0.0.1";

        public override ushort Port => 58430;

        public Balatro(UserRecord player, Func<CrowdControlBlock, bool> responseHandler, Action<object> statusUpdateHandler) : base(player, responseHandler, statusUpdateHandler) { }

        public override Game Game { get; } = new Game("Balatro", "Balatro", "PC", ConnectorType.SimpleTCPConnector);


        public override EffectList Effects
        {
            get
            {
                List<Effect> effects = new List<Effect>
                {

                    new Effect("Give $5", "addMoney_5") { Category = "Money" },
                    new Effect("Give $25", "addMoney_25") { Category = "Money" },
                    new Effect("Give $100", "addMoney_100") { Category = "Money" },
                    new Effect("Take $5", "addMoney_-5") { Category = "Money" },
                    new Effect("Take $25", "addMoney_-25") { Category = "Money" },
                    new Effect("Take $100", "addMoney_-100") { Category = "Money" },

                    new Effect("Take all Chips", "addChips_0") { Category = "Chips" },
                    new Effect("Take 10% of Blind", "addChips_-10") { Category = "Chips" },
                    new Effect("Take 25% of Blind", "addChips_-25") { Category = "Chips" },
                    new Effect("Give 10% of Blind", "addChips_10") { Category = "Chips" },
                    new Effect("Give 25% of Blind", "addChips_25") { Category = "Chips" },
                    new Effect("Complete Blind", "addChips_100") { Category = "Chips" },

                    new Effect("Reduce Blind by 25%", "addBlind_-25") { Category = "Blind" },
                    new Effect("Halve Blind", "addBlind_-50") { Category = "Blind" },
                    new Effect("Increase Blind by 25%", "addBlind_25") { Category = "Blind" },
                    new Effect("Double Blind", "addBlind_100") { Category = "Blind" },

                    new Effect("Give Extra Hand", "addHands_1") { Category = "Hands / Discards" },
                    new Effect("Give Extra Discard", "addDiscards_1") { Category = "Hands / Discards" },
                    new Effect("Take Hand", "addHands_-1") { Category = "Hands / Discards" },
                    new Effect("Take Discard", "addDiscards_-1") { Category = "Hands / Discards" },

                    new Effect("Randomize Hand", "randomizeHand") { Category = new string[]{ "Hand", "Card Suits", "Card Values"} },

                    new Effect("Cycle Hand Up", "cycleHand_1") { Category = new string[]{ "Hand", "Card Values"} },
                    new Effect("Cycle Hand Down", "cycleHand_-1") { Category = new string[]{ "Hand", "Card Values"} },
                    new Effect("Cycle Hand Up 4", "cycleHand_4") { Category = new string[]{ "Hand", "Card Values"} },
                    new Effect("Cycle Hand Down 4", "cycleHand_-4") { Category = new string[]{ "Hand", "Card Values"} },
                    new Effect("Boost Hand",    "boostHand_1") { Category = new string[]{ "Hand", "Card Values"} },
                    new Effect("Reduce Hand",   "boostHand_-1") { Category = new string[]{ "Hand", "Card Values"} },
                    new Effect("Boost Hand by 4",  "boostHand_4") { Category = new string[]{ "Hand", "Card Values"} },
                    new Effect("Reduce Hand by  4", "boostHand_-4") { Category = new string[]{ "Hand", "Card Values"} },
                    new Effect("Randomize Hand Values", "randomizeValue") { Category = new string[]{ "Hand", "Card Values"} },

                    new Effect("Cycle Random Card Up", "rand_cycleHand_1") { Category = new string[]{ "Single Card", "Card Values"} },
                    new Effect("Cycle Random Card Down", "rand_cycleHand_-1") { Category = new string[]{ "Single Card", "Card Values"} },
                    new Effect("Cycle Random Card Up 4", "rand_cycleHand_4") { Category = new string[]{ "Single Card", "Card Values"} },
                    new Effect("Cycle Random Card Down 4", "rand_cycleHand_-4") { Category = new string[]{ "Single Card", "Card Values"} },
                    new Effect("Boost Random Card",    "rand_boostHand_1") { Category = new string[]{ "Single Card", "Card Values"} },
                    new Effect("Reduce Random Card",   "rand_boostHand_-1") { Category = new string[]{ "Single Card", "Card Values"} },
                    new Effect("Boost Random Card by 4",  "rand_boostHand_4") { Category = new string[]{ "Single Card", "Card Values"} },
                    new Effect("Reduce Random Card by 4", "rand_boostHand_-4") { Category = new string[]{ "Single Card", "Card Values"} },
                    new Effect("Randomize Random Card Value", "rand_randomizeValue") { Category = new string[]{ "Single Card", "Card Values"} },


                    new Effect("Change Hand to Diamonds", "setHandSuit_Diamonds") { Category = new string[]{ "Hand", "Card Suits"} },
                    new Effect("Change Hand to Clubs", "setHandSuit_Clubs") { Category = new string[]{ "Hand", "Card Suits"} },
                    new Effect("Change Hand to Hearts", "setHandSuit_Hearts") { Category = new string[]{ "Hand", "Card Suits"} },
                    new Effect("Change Hand to Spades", "setHandSuit_Spades") { Category = new string[]{ "Hand", "Card Suits"} },
                    new Effect("Cycle Hand Suit", "cycleHandSuit") { Category = new string[]{ "Hand", "Card Suits"} },
                    new Effect("Randomize Hand Suits", "randomizeSuit") { Category = new string[]{ "Hand", "Card Suits" } },

                    new Effect("Change Random Card to Diamonds", "rand_setHandSuit_Diamonds") { Category = new string[]{ "Single Card", "Card Suits"} },
                    new Effect("Change Random Card to Clubs", "rand_setHandSuit_Clubs") { Category = new string[]{ "Single Card", "Card Suits"} },
                    new Effect("Change Random Card to Hearts", "rand_setHandSuit_Hearts") { Category = new string[]{ "Single Card", "Card Suits"} },
                    new Effect("Change Random Card to Spades", "rand_setHandSuit_Spades") { Category = new string[]{ "Single Card", "Card Suits"} },
                    new Effect("Cycle Random Card Suit", "rand_cycleHandSuit") { Category = new string[]{ "Single Card", "Card Suits"} },
                    new Effect("Randomize Random Card Suit", "rand_randomizeSuit") { Category = new string[]{ "Single Card", "Card Suits" } },


                    new Effect("Destroy Hand", "destroyHand") { Category = new string[]{ "Hand", "Card Removal"} },
                    new Effect("Discard Hand", "discardHand") { Category = new string[]{ "Hand", "Card Removal"} },
                    new Effect("Remove Card from Deck", "destroyDeck") { Category = new string[]{ "Hand", "Card Removal"} },

                    new Effect("Destroy Random Card", "rand_destroyHand") { Category = new string[]{ "Single Card", "Card Removal"} },
                    new Effect("Discard Random Card", "rand_discardHand") { Category = new string[]{ "Single Card", "Card Removal"} },


                    new Effect("Flip Hand", "flipHand") { Category = "Hand" },
                    new Effect("Flip Random Card", "rand_flipHand") { Category = "Single Card" },

                    new Effect("Change Hand to Foils", "changeHandEdition_Foil") { Category = new string[]{ "Hand", "Card Edition"} },
                    new Effect("Change Hand to Holographic", "changeHandEdition_Holo") { Category = new string[]{ "Hand", "Card Edition"} },
                    new Effect("Change Hand to Polychrome", "changeHandEdition_Polychrome") { Category = new string[]{ "Hand", "Card Edition"} },
                    new Effect("Remove Hand Editions", "changeHandEdition_BASE") { Category = new string[]{ "Hand", "Card Edition"} },

                    new Effect("Change Hand Seal to Red", "changeHandSeal_Red") { Category = new string[]{ "Hand", "Seals"} },
                    new Effect("Change Hand Seal to Blue", "changeHandSeal_Blue") { Category = new string[]{ "Hand", "Seals"} },
                    new Effect("Change Hand Seal to Gold", "changeHandSeal_Gold") { Category = new string[]{ "Hand", "Seals"} },
                    new Effect("Change Hand Seal to Purple", "changeHandSeal_Purple") { Category = new string[]{ "Hand", "Seals"} },
                    new Effect("Remove Hand Seals", "changeHandSeal_BASE") { Category = new string[]{ "Hand", "Seals"} },

                    new Effect("Remove Hand Modifier", "changeHandCenter_c_base") { Category = new string[]{ "Hand", "Card Modifier"} },
                    new Effect("Change Hand Modifier to Bonus", "changeHandCenter_m_bonus") { Category = new string[]{ "Hand", "Card Modifier"} },
                    new Effect("Change Hand Modifier to Mult", "changeHandCenter_m_mult") { Category = new string[]{ "Hand", "Card Modifier"} },
                    new Effect("Change Hand Modifier to Wild", "changeHandCenter_m_wild") { Category = new string[]{ "Hand", "Card Modifier"} },
                    new Effect("Change Hand Modifier to Glass", "changeHandCenter_m_glass") { Category = new string[]{ "Hand", "Card Modifier"} },
                    new Effect("Change Hand Modifier to Steel", "changeHandCenter_m_steel") { Category = new string[]{ "Hand", "Card Modifier"} },
                    new Effect("Change Hand Modifier to Stone", "changeHandCenter_m_stone") { Category = new string[]{ "Hand", "Card Modifier"} },
                    new Effect("Change Hand Modifier to Gold", "changeHandCenter_m_gold") { Category = new string[]{ "Hand", "Card Modifier"} },
                    new Effect("Change Hand Modifier to Lucky", "changeHandCenter_m_lucky") { Category = new string[]{ "Hand", "Card Modifier"} },




                    new Effect("Change Random Card to Foil", "rand_changeHandEdition_Foil") { Category = new string[]{ "Single Card", "Card Edition"} },
                    new Effect("Change Random Card to Holographic", "rand_changeHandEdition_Holo") { Category = new string[]{ "Single Card", "Card Edition"} },
                    new Effect("Change Random Card to Polychrome", "rand_changeHandEdition_Polychrome") { Category = new string[]{ "Single Card", "Card Edition"} },
                    new Effect("Remove Random Card Edition", "rand_changeHandEdition_BASE") { Category = new string[]{ "Single Card", "Card Edition"} },

                    new Effect("Change Random Card Seal to Red", "rand_changeHandSeal_Red") { Category = new string[]{ "Single Card", "Seals"} },
                    new Effect("Change Random Card Seal to Blue", "rand_changeHandSeal_Blue") { Category = new string[]{ "Single Card", "Seals"} },
                    new Effect("Change Random Card Seal to Gold", "rand_changeHandSeal_Gold") { Category = new string[]{ "Single Card", "Seals"} },
                    new Effect("Change Random Card Seal to Purple", "rand_changeHandSeal_Purple") { Category = new string[]{ "Single Card", "Seals"} },
                    new Effect("Remove Random Card Seal", "rand_changeHandSeal_BASE") { Category = new string[]{ "Single Card", "Seals"} },

                    new Effect("Remove Random Card Modifier", "rand_changeHandCenter_c_base") { Category = new string[]{ "Single Card", "Card Modifier"} },
                    new Effect("Change Random Card Modifier to Bonus", "rand_changeHandCenter_m_bonus") { Category = new string[]{ "Single Card", "Card Modifier"} },
                    new Effect("Change Random Card Modifier to Mult", "rand_changeHandCenter_m_mult") { Category = new string[]{ "Single Card", "Card Modifier"} },
                    new Effect("Change Random Card Modifier to Wild", "rand_changeHandCenter_m_wild") { Category = new string[]{ "Single Card", "Card Modifier"} },
                    new Effect("Change Random Card Modifier to Glass", "rand_changeHandCenter_m_glass") { Category = new string[]{ "Single Card", "Card Modifier"} },
                    new Effect("Change Random Card Modifier to Steel", "rand_changeHandCenter_m_steel") { Category = new string[]{ "Single Card", "Card Modifier"} },
                    new Effect("Change Random Card Modifier to Stone", "rand_changeHandCenter_m_stone") { Category = new string[]{ "Single Card", "Card Modifier"} },
                    new Effect("Change Random Card Modifier to Gold", "rand_changeHandCenter_m_gold") { Category = new string[]{ "Single Card", "Card Modifier"} },
                    new Effect("Change Random Card Modifier to Lucky", "rand_changeHandCenter_m_lucky") { Category = new string[]{ "Single Card", "Card Modifier"} },




                    new Effect("Give Random Tarot", "addTarot") { Category = new string[]{ "Consumeables", "Tarot Cards", "Give Cards"} },
                    new Effect("Give Random Planet", "addPlanet") { Category = new string[]{ "Consumeables", "Planet Cards", "Give Cards"} },
                    new Effect("Give Random Spectral", "addSpectral") { Category = new string[]{ "Consumeables", "Spectral Cards", "Give Cards"} },
                    new Effect("Destroy Random Consumeable", "crand_destroyConsumables") { Category = new string[]{ "Consumeables", "Card Removal"} },
                    new Effect("Destroy Consumeables", "destroyConsumables") { Category = new string[]{ "Consumeables", "Card Removal"} },

                    new Effect("Give Random Joker", "addJoker") { Category = new string[]{ "Jokers", "Give Cards"} },
                    new Effect("Destroy Jokers", "destroyJokers") { Category = new string[]{ "Jokers", "Card Removal"} },
                    new Effect("Destroy Random Joker", "jrand_destroyJokers") { Category = new string[]{ "Jokers", "Card Removal"} },

                    new Effect("Change Random Joker to Foil", "jrand_changeJokerEdition_Foil") { Category = new string[]{ "Jokers", "Card Edition"} },
                    new Effect("Change Random Joker to Holographic", "jrand_changeJokerEdition_Holo") { Category = new string[]{ "Jokers", "Card Edition"} },
                    new Effect("Change Random Joker to Polychrome", "jrand_changeJokerEdition_Polychrome") { Category = new string[]{ "Jokers", "Card Edition"} },
                    new Effect("Remove Random Joker Edition", "jrand_changeJokerEdition_BASE") { Category = new string[]{ "Jokers", "Card Edition"} },

                    new Effect("Open Standard Pack", "openBooster_p_standard_normal_1") { Category = "Boosters" },
                    new Effect("Open Mega Standard Pack", "openBooster_p_standard_mega_1") { Category = "Boosters" },
                    new Effect("Open Arcana Pack", "openBooster_p_arcana_normal_1") { Category = "Boosters" },
                    new Effect("Open Mega Arcana Pack", "openBooster_p_arcana_mega_1") { Category = "Boosters" },
                    new Effect("Open Celestial Pack", "openBooster_p_celestial_normal_1") { Category = "Boosters" },
                    new Effect("Open Mega Celestial Pack", "openBooster_p_celestial_mega_1") { Category = "Boosters" },
                    new Effect("Open Spectral Pack", "openBooster_p_spectral_normal_1") { Category = "Boosters" },
                    new Effect("Open Mega Spectral Pack", "openBooster_p_spectral_mega_1") { Category = "Boosters" },
                    new Effect("Open Buffoon Pack", "openBooster_p_buffoon_normal_1") { Category = "Boosters" },
                    new Effect("Open Mega Buffoon Pack", "openBooster_p_buffoon_mega_1") { Category = "Boosters" },

                    new Effect("Draw a Card", "drawFromDeck_1") { Category = new string[]{ "Playing Cards", "Deck", "Give Cards"} },
                    new Effect("Return a Discarded Card", "drawFromDiscard_1") { Category = new string[]{ "Playing Cards", "Give Cards"} },
                    new Effect("Shuffle Discards into Deck", "reshuffle") { Category = new string[]{ "Playing Cards", "Deck", "Give Cards"} },
                    new Effect("Give Random Face Card", "addFaceCard") { Category = new string[]{ "Playing Cards", "Give Cards"} },
                    new Effect("Give Random Number Card", "addNumberCard") { Category = new string[]{ "Playing Cards", "Give Cards"} },


                    new Effect("Debuff Hand", "debuffHand_true") { Category = new string[]{ "Hand", "Debuffs"} },
                    new Effect("Un-Debuff Hand", "debuffHand_false") { Category = new string[]{ "Hand", "Debuffs"} },
                    new Effect("Debuff Random Card", "rand_debuffHand_true") { Category = new string[]{ "Single Card", "Debuffs"} },
                    new Effect("Un-Debuff Random Card", "rand_debuffHand_false") { Category = new string[]{ "Single Card", "Debuffs"} },

                    /*

             
                    --addChips(100)


                    */

                };

                return effects;
            }
        }


    }
}
