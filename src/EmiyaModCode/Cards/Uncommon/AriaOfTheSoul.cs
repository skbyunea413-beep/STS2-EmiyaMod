namespace EmiyaMod;

public sealed class AriaOfTheSoul : EmiyaCard
{
    public AriaOfTheSoul() : base(1, CardType.Skill, CardRarity.Uncommon, TargetType.Self) { }

    protected override IEnumerable<DynamicVar> CanonicalVars => [new CardsVar(2), new StarsVar(1)];

    protected override async Task OnPlay(PlayerChoiceContext ctx, CardPlay cardPlay)
    {
        await CardPileCmd.Draw(ctx, base.DynamicVars.Cards.BaseValue, base.Owner);
        await PlayerCmd.GainStars(base.DynamicVars.Stars.BaseValue, base.Owner);
    }

    protected override void OnUpgrade()
    {
        base.DynamicVars.Stars.UpgradeValueBy(1m);
    }
}
