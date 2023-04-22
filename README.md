# DI
## Project video poker 
### Video for Helping to navigate in the project [Gameplay video](https://drive.google.com/file/d/1Vw4QQLv68wiGdUM1iAcCv4T-bSj_fL85/view?usp=share_link)

## Project view  
- Scene: pleas opne ***Main*** Scene in case project opened on default Scene.
- Scene: we can split it into 3 parts Buttons and Hud, Paytable, and CardsTable.  
## Project Script Hierarchy 
- We can split the project hierarchy into Data, Controllers/Views,s and Models.
- Project is useing DIContainer VContainer for managing dependencies and logic between different parts.
## EntryPoint
### Explanation of how to navigate inside the project 
- GameLifeScope : is a Container initializer and dependency binder.
- UIInitializer : initialize all ui in the project. 
- GameFlowInitializer : is responsible about managing the game flow and game loop. 
### GameLifeScope 
- Bind all project parts and then Inject needed part insid **GameFlowInitializer** or **UIInitializer**.
- All controllers  *BetButtonsView, HudMoneyView, BetsTable, CardsTable* do not interact directly with each other they interact only in 
UIInitializer and GameFlowInitializer.
- This help seperate laogic from view.
- Models also injected only in UIInitializer and GameFlowInitializer.




