namespace EmiyaMod;

public sealed class AbnormalResilience : EmiyaCard
{
    public AbnormalResilience() : base(2, CardType.Power, CardRarity.Uncommon, TargetType.Self) { }

    protected override IEnumerable<DynamicVar> CanonicalVars =>
        [new IntVar("Percent", 1)];

    protected override async Task OnPlay(PlayerChoiceContext ctx, CardPlay cardPlay)
    {
        await PowerCmd.Apply<AbnormalResiliencePower>(ctx, base.Owner.Creature,
            base.DynamicVars["Percent"].BaseValue, base.Owner.Creature, this);
    }

    protected override void OnUpgrade()
    {
        base.DynamicVars["Percent"].UpgradeValueBy(1m);
    }
}
