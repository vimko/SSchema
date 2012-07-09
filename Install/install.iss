; �ű��� Inno Setup �ű��� ���ɣ�
; �йش��� Inno Setup �ű��ļ�����ϸ��������İ����ĵ���

#define MyAppName "�ɶ��������ݶ���"
#define MyAppVersion "1.0.0.0"
#define MyAppPublisher "�ɶ�����������ɷ����޹�˾"
#define MyAppExeName "SSChema.Controller.exe"

[Setup]
; ע: AppId��ֵΪ������ʶ��Ӧ�ó���
; ��ҪΪ������װ����ʹ����ͬ��AppIdֵ��
; (�����µ�GUID����� ����|��IDE������GUID��)
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
; ע��: ��Ҫ���κι���ϵͳ�ļ���ʹ�á�Flags: ignoreversion��
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
