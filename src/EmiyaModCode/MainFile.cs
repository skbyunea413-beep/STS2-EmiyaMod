using MegaCrit.Sts2.Core.Modding;

namespace EmiyaMod;

[ModInitializer(nameof(Initialize))]
public class MainFile
{
    public const string ModId = "EmiyaMod";
    public static string ResPath => $"res://{ModId}";

    public static void Initialize()
    {
    }
}
