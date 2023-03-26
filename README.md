# MobilityWareTest
## Project video poker 

## Project view  
- Scene: we can split it into 3 part Buttons and Hud, Paytable, and CardsTable.   
## Project Script Hierarchy 
- we can split project hierarchy into Data and controllers/View and Models.
- project use DIContainer VContainer for maanging dependance and logic bettwen defferent parts. 
## EntryPoint
### these scripts will help you navigate inside project 
- GameLifeScope : is a Container initializer and dependancy binder.
- UIInitializer : initialize all ui in the project. 
- GameFlowInitializer : is responseble about managing the game flow and game loop. 
### GameLifeScope 
- bind all project partst and then Inject needed part insid **GameFlowInitializer** and **UIInitializer**.
- all controllers  *BetButtonsView, HudMoneyView, BetsTable, CardsTable* do not interact together directly they interact only in 
UIInitializer and GameFlowInitializer.
- this help seperate laogic from view.
- models also injected only in UIInitializer and GameFlowInitializer.
### Video for Helping to navigate in the project [Gameplay video](https://drive.google.com/file/d/1Vw4QQLv68wiGdUM1iAcCv4T-bSj_fL85/view?usp=share_link)



