Imports System
Imports DevExpress.ExpressApp.Updating
Imports DevExpress.Data.Filtering
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.ExpressApp.Security
Imports DevExpress.ExpressApp

Namespace Solution161.Module

    Public Class Updater
        Inherits ModuleUpdater

        Public Sub New(ByVal objectSpace As IObjectSpace, ByVal currentDBVersion As Version)
            MyBase.New(objectSpace, currentDBVersion)
        End Sub

        Public Overrides Sub UpdateDatabaseAfterUpdateSchema()
            MyBase.UpdateDatabaseAfterUpdateSchema()
'#Region "Create Users for the Complex Security Strategy"
            ' If a user named 'Sam' doesn't exist in the database, create this user
            Dim user1 As User = ObjectSpace.FindObject(Of User)(New BinaryOperator("UserName", "Sam"))
            If user1 Is Nothing Then
                user1 = ObjectSpace.CreateObject(Of User)()
                user1.UserName = "Sam"
                user1.FirstName = "Sam"
                ' Set a password if the standard authentication type is used
                user1.SetPassword("")
            End If

            ' If a user named 'John' doesn't exist in the database, create this user
            Dim user2 As User = ObjectSpace.FindObject(Of User)(New BinaryOperator("UserName", "John"))
            If user2 Is Nothing Then
                user2 = ObjectSpace.CreateObject(Of User)()
                user2.UserName = "John"
                user2.FirstName = "John"
                ' Set a password if the standard authentication type is used
                user2.SetPassword("")
            End If

            ' If a role with the Administrators name doesn't exist in the database, create this role
            Dim adminRole As Role = ObjectSpace.FindObject(Of Role)(New BinaryOperator("Name", "Administrators"))
            If adminRole Is Nothing Then
                adminRole = ObjectSpace.CreateObject(Of Role)()
                adminRole.Name = "Administrators"
            End If

            ' If a role with the Users name doesn't exist in the database, create this role
            Dim userRole As Role = ObjectSpace.FindObject(Of Role)(New BinaryOperator("Name", "Users"))
            If userRole Is Nothing Then
                userRole = ObjectSpace.CreateObject(Of Role)()
                userRole.Name = "Users"
            End If

            ' Delete all permissions assigned to the Administrators and Users roles
            While adminRole.PersistentPermissions.Count > 0
                ObjectSpace.Delete(adminRole.PersistentPermissions(0))
            End While

            While userRole.PersistentPermissions.Count > 0
                ObjectSpace.Delete(userRole.PersistentPermissions(0))
            End While

            ' Allow full access to all objects to the Administrators role
            adminRole.AddPermission(New ObjectAccessPermission(GetType(Object), ObjectAccess.AllAccess))
            ' Deny editing access to the AuditDataItemPersistent type objects to the Administrators role
            adminRole.AddPermission(New ObjectAccessPermission(GetType(AuditDataItemPersistent), ObjectAccess.ChangeAccess, ObjectAccessModifier.Deny))
            ' Allow editing the application model to the Administrators role
            adminRole.AddPermission(New EditModelPermission(ModelAccessModifier.Allow))
            ' Save the Administrators role to the database
            adminRole.Save()
            ' Allow full access to all objects to the Users role
            userRole.AddPermission(New ObjectAccessPermission(GetType(Object), ObjectAccess.AllAccess))
            ' Deny editing access to the User type objects to the Users role
            userRole.AddPermission(New ObjectAccessPermission(GetType(User), ObjectAccess.ChangeAccess, ObjectAccessModifier.Deny))
            ' Deny full access to the Role type objects to the Users role
            userRole.AddPermission(New ObjectAccessPermission(GetType(Role), ObjectAccess.AllAccess, ObjectAccessModifier.Deny))
            ' Deny editing the application model to the Users role
            userRole.AddPermission(New EditModelPermission(ModelAccessModifier.Deny))
            ' Save the Users role to the database
            userRole.Save()
            ' Add the Administrators role to the user1
            user1.Roles.Add(adminRole)
            ' Add the Users role to the user2
            user2.Roles.Add(userRole)
            ' Save the users to the database
            user1.Save()
            user2.Save()
            ObjectSpace.CommitChanges()
'#End Region
        End Sub
    End Class
End Namespace
