Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Linq
Imports System.Web
Imports System.Web.Security

Namespace WSATTest
    Public Class GetAllUsers
        Public Sub New()
        End Sub

        Public Function CustomGetAllUsers() As DataSet
            Dim ds As DataSet = New DataSet()
            Dim dt As DataTable = New DataTable()
            dt = ds.Tables.Add("Users")
            Dim muc As MembershipUserCollection = Membership.GetAllUsers()

            'dt.Columns.Add("PasswordQuestion", Type.GetType("System.String"))
            'dt.Columns.Add("ProviderName", Type.GetType("System.String"))
            'dt.Columns.Add("LastActivityDate", Type.GetType("System.DateTime"))
            'dt.Columns.Add("LastPasswordChangedDate", Type.GetType("System.DateTime"))
            'dt.Columns.Add("LastLockoutDate", Type.GetType("System.DateTime"))
            'dt.Columns.Add("IsApproved", Type.GetType("System.Boolean"))
            '
            'dt.Columns.Add("IsOnline", Type.GetType("System.Boolean"))
            dt.Columns.Add("IsLockedOut", Type.GetType("System.Boolean"))
            dt.Columns.Add("Comment", Type.GetType("System.String"))
            dt.Columns.Add("UserName", Type.[GetType]("System.String"))
            'dt.Columns.Add("Email", Type.[GetType]("System.String"))
            dt.Columns.Add("CreationDate", Type.[GetType]("System.DateTime"))
            dt.Columns.Add("LastLoginDate", Type.[GetType]("System.DateTime"))

            For Each mu As MembershipUser In muc
                Dim dr As DataRow
                dr = dt.NewRow()
                dr("IsLockedOut") = mu.IsLockedOut
                dr("Comment") = mu.Comment
                dr("UserName") = mu.UserName
                'dr("Email") = mu.Email
                dr("CreationDate") = mu.CreationDate
                dr("LastLoginDate") = mu.LastLoginDate
                dt.Rows.Add(dr)
            Next

            Return ds
        End Function

        Public Function CustomGetComment() As DataSet
            Dim ds As DataSet = New DataSet()
            Dim dt As DataTable = New DataTable()
            dt = ds.Tables.Add("Users")
            Dim muc As MembershipUserCollection = Membership.GetAllUsers()


            dt.Columns.Add("Comment", Type.GetType("System.String"))


            For Each mu As MembershipUser In muc
                Dim dr As DataRow
                dr = dt.NewRow()

                dr("Comment") = mu.Comment

                dt.Rows.Add(dr)
            Next

            Return ds
        End Function
    End Class
End Namespace

