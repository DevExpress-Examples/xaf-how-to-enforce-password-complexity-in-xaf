Namespace Solution161.Win

    Partial Class Solution161WindowsFormsApplication

        ''' <summary> 
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary> 
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Me.components IsNot Nothing) Then
                Me.components.Dispose()
            End If

            MyBase.Dispose(disposing)
        End Sub

'#Region "Component Designer generated code"
        ''' <summary> 
        ''' Required method for Designer support - do not modify 
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.module1 = New DevExpress.ExpressApp.SystemModule.SystemModule()
            Me.module2 = New DevExpress.ExpressApp.Win.SystemModule.SystemWindowsFormsModule()
            Me.module3 = New Solution161.[Module].Solution161Module()
            Me.module4 = New Solution161.[Module].Win.Solution161WindowsFormsModule()
            Me.module5 = New DevExpress.ExpressApp.Validation.ValidationModule()
            Me.module6 = New DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule()
            Me.module7 = New DevExpress.ExpressApp.Validation.Win.ValidationWindowsFormsModule()
            Me.securityModule1 = New DevExpress.ExpressApp.Security.SecurityModule()
            Me.sqlConnection1 = New System.Data.SqlClient.SqlConnection()
            Me.securityComplex1 = New DevExpress.ExpressApp.Security.SecurityComplex()
            Me.authenticationStandard1 = New DevExpress.ExpressApp.Security.AuthenticationStandard()
            CType((Me), System.ComponentModel.ISupportInitialize).BeginInit()
            ' 
            ' module5
            ' 
            Me.module5.AllowValidationDetailsAccess = True
            ' 
            ' sqlConnection1
            ' 
            Me.sqlConnection1.ConnectionString = "Data Source=(local);Initial Catalog=Solution161;Integrated Security=SSPI;Pooling=" & "false"
            Me.sqlConnection1.FireInfoMessageEventOnUserErrors = False
            ' 
            ' securityComplex1
            ' 
            Me.securityComplex1.Authentication = Me.authenticationStandard1
            Me.securityComplex1.IsGrantedForNonExistentPermission = False
            Me.securityComplex1.RoleType = GetType(DevExpress.Persistent.BaseImpl.Role)
            Me.securityComplex1.UserType = GetType(DevExpress.Persistent.BaseImpl.User)
            ' 
            ' authenticationStandard1
            ' 
            Me.authenticationStandard1.LogonParametersType = GetType(DevExpress.ExpressApp.Security.AuthenticationStandardLogonParameters)
            ' 
            ' Solution161WindowsFormsApplication
            ' 
            Me.ApplicationName = "Solution161"
            Me.Connection = Me.sqlConnection1
            Me.Modules.Add(Me.module1)
            Me.Modules.Add(Me.module2)
            Me.Modules.Add(Me.module6)
            Me.Modules.Add(Me.module3)
            Me.Modules.Add(Me.module4)
            Me.Modules.Add(Me.module5)
            Me.Modules.Add(Me.module7)
            Me.Modules.Add(Me.securityModule1)
            Me.Security = Me.securityComplex1
            AddHandler Me.DatabaseVersionMismatch, New System.EventHandler(Of DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs)(AddressOf Me.Solution161WindowsFormsApplication_DatabaseVersionMismatch)
            CType((Me), System.ComponentModel.ISupportInitialize).EndInit()
        End Sub

'#End Region
        Private module1 As DevExpress.ExpressApp.SystemModule.SystemModule

        Private module2 As DevExpress.ExpressApp.Win.SystemModule.SystemWindowsFormsModule

        Private module3 As Solution161.[Module].Solution161Module

        Private module4 As Solution161.[Module].Win.Solution161WindowsFormsModule

        Private module5 As DevExpress.ExpressApp.Validation.ValidationModule

        Private module6 As DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule

        Private module7 As DevExpress.ExpressApp.Validation.Win.ValidationWindowsFormsModule

        Private securityModule1 As DevExpress.ExpressApp.Security.SecurityModule

        Private sqlConnection1 As System.Data.SqlClient.SqlConnection

        Private securityComplex1 As DevExpress.ExpressApp.Security.SecurityComplex

        Private authenticationStandard1 As DevExpress.ExpressApp.Security.AuthenticationStandard
    End Class
End Namespace
