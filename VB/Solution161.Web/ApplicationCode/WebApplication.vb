Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Xpo
Imports System
Imports System.ComponentModel
Imports DevExpress.ExpressApp.Web

Namespace Solution161.Web

    Public Partial Class Solution161AspNetApplication
        Inherits WebApplication

        Protected Overrides Sub CreateDefaultObjectSpaceProvider(ByVal args As CreateCustomObjectSpaceProviderEventArgs)
            args.ObjectSpaceProvider = New XPObjectSpaceProvider(args.ConnectionString, args.Connection, True)
        End Sub

        Private module1 As DevExpress.ExpressApp.SystemModule.SystemModule

        Private module2 As DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule

        Private module3 As [Module].Solution161Module

        Private module4 As [Module].Web.Solution161AspNetModule

        Private securityModule1 As DevExpress.ExpressApp.Security.SecurityModule

        Private module6 As Objects.BusinessClassLibraryCustomizationModule

        Private sqlConnection1 As Data.SqlClient.SqlConnection

        Private securityComplex1 As DevExpress.ExpressApp.Security.SecurityComplex

        Private authenticationStandard1 As DevExpress.ExpressApp.Security.AuthenticationStandard

        Private module5 As Validation.ValidationModule

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Solution161AspNetApplication_DatabaseVersionMismatch(ByVal sender As Object, ByVal e As DatabaseVersionMismatchEventArgs)
#If EASYTEST
			e.Updater.Update();
			e.Handled = true;
#Else
            If System.Diagnostics.Debugger.IsAttached Then
                e.Updater.Update()
                e.Handled = True
            Else
                Throw New InvalidOperationException("The application cannot connect to the specified database, because the latter doesn't exist or its version is older than that of the application." & Microsoft.VisualBasic.Constants.vbCrLf & "This error occurred  because the automatic database update was disabled when the application was started without debugging." & Microsoft.VisualBasic.Constants.vbCrLf & "To avoid this error, you should either start the application under Visual Studio in debug mode, or modify the " & "source code of the 'DatabaseVersionMismatch' event handler to enable automatic database update, " & "or manually create a database using the 'DBUpdater' tool." & Microsoft.VisualBasic.Constants.vbCrLf & "Anyway, refer to the 'Update Application and Database Versions' help topic at http://www.devexpress.com/Help/?document=ExpressApp/CustomDocument2795.htm " & "for more detailed information. If this doesn't help, please contact our Support Team at http://www.devexpress.com/Support/Center/")
            End If
#End If
        End Sub

        Private Sub InitializeComponent()
            module1 = New SystemModule.SystemModule()
            module2 = New SystemModule.SystemAspNetModule()
            module3 = New [Module].Solution161Module()
            module4 = New [Module].Web.Solution161AspNetModule()
            module5 = New Validation.ValidationModule()
            module6 = New Objects.BusinessClassLibraryCustomizationModule()
            securityModule1 = New Security.SecurityModule()
            sqlConnection1 = New Data.SqlClient.SqlConnection()
            securityComplex1 = New Security.SecurityComplex()
            authenticationStandard1 = New Security.AuthenticationStandard()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            ' 
            ' module5
            ' 
            module5.AllowValidationDetailsAccess = True
            ' 
            ' sqlConnection1
            ' 
            sqlConnection1.ConnectionString = "Data Source=(local);Initial Catalog=Solution161;Integrated Security=SSPI;Pooling=" & "false"
            sqlConnection1.FireInfoMessageEventOnUserErrors = False
            ' 
            ' securityComplex1
            ' 
            securityComplex1.Authentication = authenticationStandard1
            securityComplex1.IsGrantedForNonExistentPermission = False
            securityComplex1.RoleType = GetType(DevExpress.Persistent.BaseImpl.Role)
            securityComplex1.UserType = GetType(DevExpress.Persistent.BaseImpl.User)
            ' 
            ' authenticationStandard1
            ' 
            authenticationStandard1.LogonParametersType = GetType(Security.AuthenticationStandardLogonParameters)
            ' 
            ' Solution161AspNetApplication
            ' 
            ApplicationName = "Solution161"
            Connection = sqlConnection1
            Modules.Add(module1)
            Modules.Add(module2)
            Modules.Add(module6)
            Modules.Add(module3)
            Modules.Add(module4)
            Modules.Add(module5)
            Modules.Add(securityModule1)
            Security = securityComplex1
            AddHandler DatabaseVersionMismatch, New EventHandler(Of DatabaseVersionMismatchEventArgs)(AddressOf Solution161AspNetApplication_DatabaseVersionMismatch)
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        End Sub
    End Class
End Namespace
