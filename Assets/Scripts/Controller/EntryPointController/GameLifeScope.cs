using Bets;
using Models;
using BetsView;
using VContainer;
using UnityEngine;
using Models.UserModel;
using VContainer.Unity;
using Controller.UIView;

namespace Controller
{
    /// <summary>
    /// this is the entry  point of the game, this class glue all different parts
    /// togather. <DI Container>  
    /// </summary>
    public class GameLifeScope : LifetimeScope
    {
        // we provide the monobehavior that we want to inject or we want them tobe injected 
        [SerializeField] private BetButtonsView BetButtonsView;
        [SerializeField] private HudMoneyView HudMoneyView;
        [SerializeField] private BetsTable BetsTable;
        [SerializeField] private CardsTable CardsTable;
        
        //initialize the entry point of the container 
        // at the entry point we have the logic that is dependant on more than one part 
        // of the project.  
        //we can have more than one entry point, 
        protected override void Configure(IContainerBuilder builder)
        {
            builder.UseEntryPoints(Lifetime.Singleton, entryPoints =>
            { 
                entryPoints.Add<UIInitializer>();
                entryPoints.Add<GameFlowInitializer>();
            });
                
            // models
            // binding models to di container as single 
            // so we can inject them every where 
            builder.Register<UserModel>(Lifetime.Singleton);
            builder.Register<FinalCombination>(Lifetime.Singleton);
            builder.Register<BetsConst>(Lifetime.Singleton);
            
            // component
          
            //binding Component <MonoBehaviour> to the container 
            builder.RegisterComponent(BetButtonsView);
            builder.RegisterComponent(HudMoneyView);
            builder.RegisterComponent(BetsTable);
            builder.RegisterComponent(CardsTable);
        }
    }
}