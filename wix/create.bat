del installer.wixobj
"%wix%\bin\candle" installer.wxs -ext WiXNetFxExtension -ext WixDifxAppExtension -ext WixUIExtension.dll -ext WixUtilExtension -ext WixIisExtension
"%wix%\bin\light" installer.wixobj "%wix%\bin\difxapp_x86.wixlib" -sval -o MissionPlanner-1.3.68.1.msi -ext WiXNetFxExtension -ext WixDifxAppExtension -ext WixUIExtension.dll -ext WixUtilExtension -ext WixIisExtension
