using Engine;
using Engine.Input;
using Main;
using Engine.DI;
using Main.Level;

public class GameManager : CoreManager<GameManager>, IMakeStarted, IMakeFailed, IMakeCompleted, IDependency
{
    public static bool isStarted { get; internal set; }
    public static bool isCompleted { get; internal set; }
    public static bool isFailed { get; internal set; }

    public static bool isFinished { get { return isFailed || isCompleted; } }
    public static bool isPlaying { get { return !isFinished && isStarted; } }


    private IGameStatue _startStatue = new LevelStatueStarted();
    private IGameStatue _failedStatue = new LevelStatueFailed();
    private IGameStatue _completedStatue = new LevelStatueCompleted();


    public void Inject()
    {
        DIContainer.RegisterAsSingle<IMakeStarted>(this);
        DIContainer.RegisterAsSingle<IMakeFailed>(this);
        DIContainer.RegisterAsSingle<IMakeCompleted>(this);
    }

    protected override void OnInitialize()
    {
        isStarted = false;
        isCompleted = false;
        isFailed = false;

#if Support_SDK
        apps.ADSManager.DisplayBanner();
#endif
    }

    public void MakeStarted()
    {
        ILevelsData levelData = DIContainer.AsSingle<ILevelsData>();
        ILevelsGroup levelsGroup = DIContainer.AsSingle<ILevelsGroup>();

        isStarted = true;

#if Support_SDK
        apps.EventsLogger.ProgressStartEvent(
            new apps.ProgressStartInfo
            (
                levelData.playerLevel,
                "level_" + levelData.idLevel,
                levelData.playerLevel,
                "easy",
                levelData.playerLevel / levelsGroup.totalLevels,
                levelData.isRandom,
                "standard",
                "classic")
            );
#endif

        SwitchToStatue(_startStatue);
    }

    /// <param name="progress">
    /// It's can be the progress point where the player host the level or
    /// The id of the reason for the player why he lost the level. Example hit an obstacles...
    /// </param>
    public void MakeFailed(int progress, string reason)
    {
        ILevelsData levelData = DIContainer.AsSingle<ILevelsData>();
        ILevelsGroup levelsGroup = DIContainer.AsSingle<ILevelsGroup>();

        if (isFinished) return;

        isFailed = true;

        ControllerInputs.s_EnableInputs = false;

#if Support_SDK
        apps.EventsLogger.ProgressFailedEvent(new apps.ProgressFailedInfo(levelData.playerLevel,
            "level_" + levelData.idLevel, levelData.idLevel, "easy",
            levelData.playerLevel / levelsGroup.totalLevels, levelData.playerLevel != levelData.idLevel,
            "standard", "standard", Timer.LevelTime.ToString(), "killed", progress, 0));
#endif

        SwitchToStatue(_failedStatue);
    }

    public void MakeCompleted()
    {
        ILevelsData levelData = DIContainer.AsSingle<ILevelsData>();
        ILevelsGroup levelsGroup = DIContainer.AsSingle<ILevelsGroup>();

        if (isFinished) return;

        isCompleted = true;

        ControllerInputs.s_EnableInputs = false;

#if Support_SDK
        apps.EventsLogger.ProgressCompletedEvent(new apps.ProgressCompletedInfo(levelData.playerLevel,
            "level_" + levelData.idLevel, levelData.idLevel, "easy",
            levelData.playerLevel / levelsGroup.totalLevels, levelData.playerLevel != levelData.idLevel,
            "standard", "standard", Timer.LevelTime.ToString(), 100, 0));
#endif

        levelData.LevelCompleted();
        SwitchToStatue(_completedStatue);
    }
}
