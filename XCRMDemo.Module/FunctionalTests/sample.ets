;#DropDB XCRMDemoEasyTest

#Application XCRMDemoWin
#Application XCRMDemoWeb

*FillForm
 User Name = Admin
*Action Log In

#IfDef XCRMDemoWin

*Action About...
 
*Action OK

#EndIf

#IfDef XCRMDemoWeb
*Action Navigation(My Details)
#EndIf
