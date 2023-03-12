using Zenject;

public class RewardsInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindRewardSystem();
        BindChestRewardGenerator();
    }

    private void BindRewardSystem()
    {
        Container.Bind<RewardSystem>().
            AsSingle();
    }

    private void BindChestRewardGenerator()
    {
        Container.Bind<ChestRewardGenerator>().
            AsSingle();
    }
}
