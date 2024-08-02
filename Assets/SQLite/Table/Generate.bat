@echo off

rem 双引号内 替换为 表格工具.exe文件 的路径
set TableToolExePath="E:\Project\TableTool\TableTool\bin\Debug\net8.0\TableTool.exe"

rem 等于号 后面替换为 表格所在文件夹的路径(不能包含空格)
set TablePath=E:\Project\Study\Assets\SQLite\Table\Excel

rem 等于号 后面替换为 二进制文件输出的文件夹 的路径(不能包含空格)
set BinaryOutPath=E:\Project\Study\Assets\SQLite\Table\Output\Binary

rem 等于号 后面替换为 C#代码文件输出的文件夹 的路径(不能包含空格)
set CSharpOutPath=E:\Project\Study\Assets\SQLite\Table\Output

call %TableToolExePath% %TablePath% %BinaryOutPath% %CSharpOutPath%

pause