Imports System
Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Validation
Imports DevExpress.ExpressApp.Security
Imports System.Text.RegularExpressions
Imports DevExpress.ExpressApp.Validation
Imports System.Runtime.InteropServices

Namespace Solution161.Module

    Public NotInheritable Partial Class Solution161Module
        Inherits ModuleBase

        Public Sub New()
            InitializeComponent()
        End Sub

        Public Overrides Sub Setup(ByVal moduleManager As ApplicationModulesManager)
            MyBase.Setup(moduleManager)
            ValidationRulesRegistrator.RegisterRule(moduleManager, GetType(PasswordStrengthCodeRule), GetType(IRuleBaseProperties))
        End Sub

        Public Overrides Sub Setup(ByVal application As XafApplication)
            AddHandler application.SetupComplete, New EventHandler(Of EventArgs)(AddressOf application_SetupComplete)
            MyBase.Setup(application)
        End Sub

        'this code is necessary to enable validation in the "Change Password On First Logon" window.
        Private Sub application_SetupComplete(ByVal sender As Object, ByVal e As EventArgs)
            Dim [module] As ValidationModule = CType(CType(sender, XafApplication).Modules.FindModule(GetType(ValidationModule)), ValidationModule)
            If [module] IsNot Nothing Then
                [module].InitializeRuleSet()
            End If
        End Sub
    End Class

    <CodeRule>
    Public Class PasswordStrengthCodeRule
        Inherits RuleBase(Of ChangePasswordOnLogonParameters)

        Public Sub New()
            MyBase.New("", "ChangePassword")
            Properties.SkipNullOrEmptyValues = False
        End Sub

        Public Sub New(ByVal properties As IRuleBaseProperties)
            MyBase.New(properties)
        End Sub

        Protected Overrides Function IsValidInternal(ByVal target As ChangePasswordOnLogonParameters, <Out> ByRef errorMessageTemplate As String) As Boolean
            If CalculatePasswordStrength(target.NewPassword) < 3 Then
                errorMessageTemplate = "password strength is insufficient"
                Return False
            End If

            errorMessageTemplate = String.Empty
            Return True
        End Function

        Private Function CalculatePasswordStrength(ByVal pwd As String) As Integer
            Dim weight As Integer = 0
            If Equals(pwd, Nothing) Then Return weight
            If pwd.Length > 1 AndAlso pwd.Length < 4 Then
                Threading.Interlocked.Increment(weight)
            Else
                If pwd.Length > 5 Then Threading.Interlocked.Increment(weight)
                Dim rxUpperCase As Regex = New Regex("[A-Z]")
                Dim rxLowerCase As Regex = New Regex("[a-z]")
                Dim rxNumerals As Regex = New Regex("[0-9]")
                Dim match As Match = rxUpperCase.Match(pwd)
                If match.Success Then Threading.Interlocked.Increment(weight)
                match = rxLowerCase.Match(pwd)
                If match.Success Then Threading.Interlocked.Increment(weight)
                match = rxNumerals.Match(pwd)
                If match.Success Then Threading.Interlocked.Increment(weight)
            End If

            If weight = 3 AndAlso pwd.Length < 6 Then Threading.Interlocked.Decrement(weight)
            If weight = 4 AndAlso pwd.Length > 10 Then Threading.Interlocked.Increment(weight)
            Return weight
        End Function
    End Class
End Namespace
