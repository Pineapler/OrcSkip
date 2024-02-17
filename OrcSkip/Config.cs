using BepInEx.Configuration;

namespace OrcSkip;

public class Config(ConfigFile file) {
    public ConfigEntry<bool> SkipIntro { get; } = file.Bind("General", "SkipIntro", true, "Should the intro movie be skipped (Torch logo)?");
    public ConfigEntry<bool> SkipPerfect { get; } = file.Bind("General", "SkipPerfect", true, "Should the \"Perfect!\" cutscene be skipped?");
    public ConfigEntry<bool> SkipStory { get; } = file.Bind("General", "SkipStory", false, "Should the story cutscenes be skipped? (For modders; players should probably keep this disabled)");
}
