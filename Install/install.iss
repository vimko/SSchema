; 脚本由 Inno Setup 脚本向导 生成！
; 有关创建 Inno Setup 脚本文件的详细资料请查阅帮助文档！

#define MyAppName "成都新亚数据定制"
#define MyAppVersion "1.0.0.0"
#define MyAppPublisher "成都任我行软件股份有限公司"
#define MyAppExeName "SSChema.Controller.exe"

[Setup]
; 注: AppId的值为单独标识该应用程序。
; 不要为其他安装程序使用相同的AppId值。
; (生成新的GUID，点击 工具|在IDE中生成GUID。)
AppId={{4735E2DF-ACE8-4B97-A04D-28FA2BC94AFD}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
DefaultDirName={pf}\{#MyAppName}
DefaultGroupName={#MyAppName}
AllowNoIcons=yes
OutputDir=E:\Do\SSchema\Install\Output
OutputBaseFilename=setup
Compression=lzma
SolidCompression=yes

[Languages]
Name: chinesesimp; MessagesFile: compiler:Default.isl

[Tasks]
Name: desktopicon; Description: {cm:CreateDesktopIcon}; GroupDescription: {cm:AdditionalIcons}; Flags: unchecked; OnlyBelowVersion: 0,6.1
Name: quicklaunchicon; Description: {cm:CreateQuickLaunchIcon}; GroupDescription: {cm:AdditionalIcons}; Flags: unchecked

[Files]
Source: E:\Do\SSchema\Debug\SSChema.Controller.exe; DestDir: {app}; Flags: ignoreversion
Source: E:\Do\SSchema\Debug\*; DestDir: {app}; Flags: ignoreversion recursesubdirs createallsubdirs
; 注意: 不要在任何共享系统文件上使用“Flags: ignoreversion”
Source: ..\Debug\installservices.bat; DestDir: {app}; DestName: installservices; Tasks: ; Languages: 
Source: ..\Debug\unstallservices.bat; DestDir: {app}; DestName: unstallservices.bat; Flags: uninsneveruninstall
Source: ..\Debug\SSChema.InnstoSql.exe; DestDir: {app}

[Icons]
Name: {group}\{#MyAppName}; Filename: {app}\{#MyAppExeName}
Name: {group}\{cm:UninstallProgram,{#MyAppName}}; Filename: {uninstallexe}
Name: {commondesktop}\{#MyAppName}; Filename: {app}\{#MyAppExeName}; Tasks: desktopicon
Name: {userappdata}\Microsoft\Internet Explorer\Quick Launch\{#MyAppName}; Filename: {app}\{#MyAppExeName}; Tasks: quicklaunchicon

[Run]
Filename: {app}\{#MyAppExeName}; Description: {cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}; Flags: nowait postinstall skipifsilent

Filename: {app}\installservices; Flags: shellexec hidewizard
Filename: {app}\SSChema.InnstoSql.exe; Flags: shellexec hidewizard
[UninstallRun]
Filename: {app}\unstallservices.bat; Flags: shellexec
