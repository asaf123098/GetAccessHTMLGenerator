set configurationName=%2
set targetFileName=%3

set binDir=bin\%configurationName%
set htmlAgilityDllPath=%binDir%\HtmlAgilityPack.dll
set exePath=%binDir%\%targetFileName%

set targetDirPath="..\DescriptionGenerator"

if exist %targetDirPath% rmdir /s /q %targetDirPath%
mkdir %targetDirPath%

copy /y %exePath% %targetDirPath%\%targetFileName%
copy /y %htmlAgilityDllPath% %targetDirPath%\HtmlAgilityPack.dll
xcopy /y /i /e  "..\DescriptionHtmlTemplates" %targetDirPath%\DescriptionHtmlTemplates