@Echo OFF
#C:\Users\Evan\Documents\Visual Studio 2013\Projects
SET /P pathdir=Please enter your present working directory: 
IF "%pathdir%"=="" GOTO Error

Echo "Building solution/project file using batch file"
SET PATH=C:\Windows\Microsoft.NET\Framework\v4.0.30319\
SET SolutionPath=Foodie.Data.csproj
cd %pathdir%\FoodieApp\Foodie.Data\
Echo Start Time - %Time%
MSbuild %SolutionPath% /p:Configuration=Release  /t:Rebuild
Echo End Time - %Time%

SET SolutionPath=Foodie.Main.csproj
cd %pathdir%\FoodieApp\FoodieApp\
Echo Start Time - %Time%
MSbuild %SolutionPath% /p:Configuration=Release  /t:Rebuild
Echo End Time - %Time%

SET SolutionPath=FoodieTest.csproj
cd %pathdir%\FoodieApp\FoodieTest\
Echo Start Time - %Time%
MSbuild %SolutionPath% /t:Rebuild /p:Configuration=Release 
Echo End Time - %Time%

cd %pathdir%\FoodieApp\
SET PATH=C:\Program Files\Microsoft Visual Studio 11.0\Common7\IDE\
mstest /testcontainer:FoodieTest\bin\release\FoodieTest.dll"
echo Build Process Completed...
Set /p Wait=Press any key to start Foodie

SET PATH=%pathdir%\FoodieApp\FoodieApp\bin\release\
Foodie.Main

GOTO End
:Error
ECHO You did not enter a path.
:End
