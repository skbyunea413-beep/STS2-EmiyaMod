namespace EmiyaMod;

public sealed class Reinforcement : EmiyaCard
{
    public Reinforcement() : base(1, CardType.Power, CardRarity.Common, TargetType.Self) { }

    protected override IEnumerable<DynamicVar> CanonicalVars => [new PowerVar<StrengthPower>(1m)];

    protected override async Task OnPlay(PlayerChoiceContext ctx, CardPlay cardPlay)
    {
        await PowerCmd.Apply<StrengthPower>(ctx, base.Owner.Creature,
            base.DynamicVars["StrengthPower"].BaseValue, base.Owner.Creature, this);
    }

    protected override void OnUpgrade()
    {
        base.EnergyCost.UpgradeBy(-1);
    }
}
