using BaseLib.Abstracts;
using BaseLib.Extensions;
using BaseLib.Utils;

namespace EmiyaMod;

[Pool(typeof(EmiyaRelicPool))]
public abstract class EmiyaRelic : CustomRelicModel
{
    // RelicImagePath() / BigRelicImagePath() are BaseLib.Extensions helpers
    public override string PackedIconPath =>
        $"{Id.Entry.RemovePrefix().ToLowerInvariant()}.png".RelicImagePath();
    protected override string PackedIconOutlinePath =>
        $"{Id.Entry.RemovePrefix().ToLowerInvariant()}_outline.png".RelicImagePath();
    protected override string BigIconPath =>
        $"{Id.Entry.RemovePrefix().ToLowerInvariant()}.png".BigRelicImagePath();
}
