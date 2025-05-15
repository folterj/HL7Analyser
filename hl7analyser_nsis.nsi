# define the name of the installer
Outfile "HL7Analyser.exe"
Icon "HL7Analyser\health.ico"

InstallDir $TEMP\HL7AnalyserSetup

AutoCloseWindow true

# default section
Section

HideWindow

SetOutPath $INSTDIR

File /r HL7AnalyserSetup\Release\*.*
ExecWait "$INSTDIR\Setup.exe"

RMDir /r "$INSTDIR"

SectionEnd
