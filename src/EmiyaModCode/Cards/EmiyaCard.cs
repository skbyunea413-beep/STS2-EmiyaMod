using BaseLib.Abstracts;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;

namespace EmiyaMod;

[Pool(typeof(EmiyaCardPool))]
public abstract class EmiyaCard(int cost, CardType type, CardRarity rarity, TargetType target)
    : CustomCardModel(cost, type, rarity, target)
{
}
