@Echo OFF
set WORKING_DIRECTORY=%cd%

Echo "Building solution/project file using batch file"
SET PATH=C:\Windows\Microsoft.NET\Framework\v4.0.30319\
SET SolutionPath=Foodie.Data.csproj
cd %WORKING_DIRECTORY%\Foodie.Data\
Echo Start Time - %Time%
MSbuild %SolutionPath% /p:Configuration=Release  /t:Rebuild
Echo End Time - %Time%

SET SolutionPath=Foodie.Main.csproj
cd %WORKING_DIRECTORY%\FoodieApp\
Echo Start Time - %Time%
MSbuild %SolutionPath% /p:Configuration=Release  /t:Rebuild
Echo End Time - %Time%

SET SolutionPath=FoodieTest.csproj
cd %WORKING_DIRECTORY%\FoodieTest\
Echo Start Time - %Time%
MSbuild %SolutionPath% /t:Rebuild /p:Configuration=Release 
Echo End Time - %Time%


SET PATH=C:\Program Files\Microsoft Visual Studio 11.0\Common7\IDE\
mstest /testcontainer:"%WORKING_DIRECTORY%\FoodieTest\bin\release\FoodieTest.dll"
echo Build Process Completed...
Set /p Wait=Press any key to start Foodie

SET PATH=%WORKING_DIRECTORY%\FoodieApp\bin\release\
Foodie.Main

GOTO End
:Error
ECHO You did not enter a path.
:End
