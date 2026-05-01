namespace EmiyaMod;

public sealed class AbnormalResiliencePower : EmiyaPower
{
    public override PowerType Type => PowerType.Buff;
    public override PowerStackType StackType => PowerStackType.Single;

    public override async Task AfterPlayerTurnStart(PlayerChoiceContext ctx, Player player)
    {
        if (base.Owner.Player != player) return;

        int missing = base.Owner.MaxHp - base.Owner.CurrentHp;
        if (missing <= 0) return;

        decimal healAmount = Math.Max(1m, Math.Floor(missing * base.Amount / 100m));
        Flash();
        await CreatureCmd.Heal(base.Owner, healAmount);
    }
}
