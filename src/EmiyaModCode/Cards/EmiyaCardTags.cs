using MegaCrit.Sts2.Core.Entities.Cards;

namespace EmiyaMod;

public static class EmiyaCardTags
{
    public static CardTag Traced { get; private set; }

    public static void Register()
    {
        Traced = CustomContentDictionary.AddEnum<CardTag>("EmiyaMod_Traced");
    }
}
