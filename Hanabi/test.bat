REM usage: test.bat solution.exe 1-1.in
del %~n2.result
%1 < %~n2.in > %~n2.result & fc %~n2.result %~n2.out