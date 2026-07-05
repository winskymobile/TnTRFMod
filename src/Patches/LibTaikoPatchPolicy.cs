namespace TnTRFMod.Patches;

internal static class LibTaikoPatchPolicy
{
    internal static bool ShouldApplyKnownPatch(uint actualCrc, uint supportedCrc, bool unsafeSkipCrcCheck)
    {
        return actualCrc == supportedCrc || unsafeSkipCrcCheck;
    }
}
