Imports System.Data.SqlClient
Imports System.Data
Public Class Admin
    Inherits System.Web.UI.Page
    Public Shared rolesArray As String()
    Public Shared gbl_ID As String
    Public Shared gbl_Application As String
    Public Shared gbl_Role As String
    Public Shared u As MembershipUser
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim User As System.Security.Principal.IPrincipal
        User = System.Web.HttpContext.Current.User
        Dim username As String

        Try
            Dim roles As List(Of String) = New List(Of String)(Web.Security.Roles.GetAllRoles())
            If HttpContext.Current.User.Identity.IsAuthenticated Then
                Me.Label5.Text = Membership.GetUser().Comment
                Me.Label4.Text = Membership.GetAllUsers().Count
            End If
            If Not IsPostBack Then username = Right(LTrim(RTrim(User.Identity.Name)), 8)
            If Not IsPostBack Then gbl_ID = username
            'If Not IsPostBack Then Call Populate()
            Call Populate()
            '        For Each role In roles
            '            Dim box As CheckBox = New CheckBox()
            '            box.ID = role
            '            box.Text = "&nbsp;" & role
            '            CheckBoxRoles.Controls.Add(box)
            '            Dim control As LiteralControl = New LiteralControl("<br />")
            '            CheckBoxRoles.Controls.Add(control)
            '        Next
            If Not IsPostBack Then gbl_Application = "38bc1c21-1817-42ca-aa93-e945ae486dc8"
            If Not IsPostBack Then Me.txtApp.SelectedValue = "38bc1c21-1817-42ca-aa93-e945ae486dc8"
        Catch ex As Exception
            Dim errFiltered As String
            errFiltered = (Replace(ex.Message, "'", ""))
            Msg.Text = errFiltered
        Finally
        End Try
    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            For Each control In CheckBoxRoles.Controls
                If TypeOf control Is CheckBox Then
                    Dim box As CheckBox = CType(control, CheckBox)
                    If box.Checked Then
                        If (System.Web.Security.Roles.IsUserInRole(Me.txtUserName.Text, box.ID)) = True Then
                            'MsgBox(txtID.Text & " already in  " & box.ID & " Role")
                        Else
                            ' MsgBox(" add  " & box.ID & " to " & txtID.Text)
                            System.Web.Security.Roles.AddUserToRole(Me.txtUserName.Text, box.ID)
                            'System.Web.Security.Roles.RemoveUserFromRole(txtID.Text, box.ID)
                        End If
                    End If
                End If
            Next
            For Each control In CheckBoxRoles.Controls

                If TypeOf control Is CheckBox Then
                    Dim box As CheckBox = CType(control, CheckBox)

                    If Not box.Checked Then
                        If (System.Web.Security.Roles.IsUserInRole(Me.txtUserName.Text, box.ID)) = True Then
                            ' MsgBox("Remove " & box.ID & " From " & txtID.Text)
                            System.Web.Security.Roles.RemoveUserFromRole(Me.txtUserName.Text, box.ID)
                        Else
                            '  MsgBox(txtID.Text & " does not have " & box.ID & " role ")
                        End If
                    End If
                End If
            Next
        Catch ex As Exception
            Dim errFiltered As String
            errFiltered = (Replace(ex.Message, "'", ""))
            Msg.Text = errFiltered
        Finally
        End Try
    End Sub
    Public Sub PullNames()
        'This pulls the first and last name info from the IDW database (BFG3 Only)
        Dim conn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sqlStr1 As String
        Dim sqlStr2 As String
        Dim sqlStr3 As String
        Dim sqlStr4 As String
        gbl_ID = Me.DropDownList1.SelectedValue
        Try
            conn.ConnectionString = ConfigurationManager.ConnectionStrings("AvailableHours_aspnetdb_ConnectionString").ConnectionString
            conn.Open()
            cmd.Connection = conn
            sqlStr1 = " UPDATE   [AvailableHours].[dbo].[aspnet_Membership]  "
            sqlStr2 = " SET              [Comment] = RTRIM(LTRIM([IDW].[dbo].[IDWEmployees].[Lname])) + ', ' + RTRIM(LTRIM([IDW].[dbo].[IDWEmployees].[Fname]))"
            sqlStr3 = " FROM         [AvailableHours].[dbo].[aspnet_Users] INNER JOIN  [AvailableHours].[dbo].[aspnet_Membership] ON [AvailableHours].[dbo].[aspnet_Users].[UserId] = [AvailableHours].[dbo].[aspnet_Membership].[UserId] INNER JOIN "
            sqlStr4 = " [IDW].[dbo].[IDWEmployees] ON [AvailableHours].[dbo].[aspnet_Users].[UserName] = [IDW].[dbo].[IDWEmployees].[Chorus_ID] "
            cmd.CommandText = (sqlStr1 & sqlStr2 & sqlStr3 & sqlStr4) ' & sqlStr5)
            cmd.CommandType = CommandType.Text
            cmd.ExecuteScalar()
        Catch ex As Exception
            Dim errFiltered As String
            errFiltered = (Replace(ex.Message, "'", ""))
            Msg.Text = errFiltered
        Finally
            If Not IsNothing(cmd) Then cmd.Dispose()
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    Protected Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Call PullNames()
    End Sub

    Protected Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            u.Email = txtEmail.Text
            System.Web.Security.Membership.UpdateUser(u)
            Msg.Text = "User e-mail updated."
        Catch ex As Exception
            Dim errFiltered As String
            errFiltered = (Replace(ex.Message, "'", ""))
            Msg.Text = errFiltered
        End Try
    End Sub

    Protected Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try

            For i As Integer = 0 To Membership.MaxInvalidPasswordAttempts - 1
                Membership.ValidateUser(gbl_ID, "thisisandummypasswordonlytolocktheuser")
            Next

        Catch ex As Exception
            Dim errFiltered As String
            errFiltered = (Replace(ex.Message, "'", ""))
            Msg.Text = errFiltered
        Finally
            Call one()
            Msg.Text = Me.DropDownList1.SelectedValue & " Locked"
        End Try

    End Sub

    Protected Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Msg.Text = Nothing
        Try

            System.Web.Security.Membership.GetUser(username:=Me.DropDownList1.SelectedValue).UnlockUser()
        Catch ex As Exception
            Dim errFiltered As String
            errFiltered = (Replace(ex.Message, "'", ""))
            Msg.Text = errFiltered
        Finally
            Call one()
            Msg.Text = Me.DropDownList1.SelectedValue & " Unlocked"
        End Try
    End Sub
    Public Sub one()
        Try
            ' Me.txtComment.Text = System.Web.Security.Membership.GetUser(Me.txtUserName.Text).Comment
            Me.txtEmail.Text = System.Web.Security.Membership.GetUser(Me.txtUserName.Text).Email
            Me.CheckBox1.Checked = System.Web.Security.Membership.GetUser(Me.txtUserName.Text).IsLockedOut
            Select Case Me.CheckBox1.Checked
                Case 1
                    Me.CheckBox1.Checked = True
                    Me.labLocked.Text = "User account is locked out!"
                Case 0
                    Me.CheckBox1.Checked = False
                    Me.labLocked.Text = "User account is not locked out!"
                Case Else

            End Select
        Catch ex As Exception
            Dim errFiltered As String
            errFiltered = (Replace(ex.Message, "'", ""))
            Msg.Text = errFiltered
        Finally
        End Try
    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged
        Try
            Msg.Text = "... "
            gbl_ID = Me.DropDownList1.SelectedValue
            Me.txtID.Text = Me.DropDownList1.SelectedValue

            Me.txtUserName.Text = Me.DropDownList1.SelectedValue
            Me.labLocked.Text = "  "
            u = Membership.GetUser(gbl_ID)
            Call one() ' Comment
        Catch ex As Exception
            Dim errFiltered As String
            errFiltered = (Replace(ex.Message, "'", ""))
            Msg.Text = errFiltered
        Finally
            'Call Populate()
            Call PopulateRoles()
        End Try
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            'MsgBox(gbl_ID)
            System.Web.Security.Membership.DeleteUser(gbl_ID, True)
        Catch ex As Exception
            Dim errFiltered As String
            errFiltered = (Replace(ex.Message, "'", ""))
            Msg.Text = errFiltered
            Me.DropDownList1.DataBind()
        Finally
            Msg.Text = "Member Deleted"
        End Try
    End Sub
    Public Sub PopulateRoles()
        Try
            For Each control In CheckBoxRoles.Controls
                If TypeOf control Is CheckBox Then
                    Dim box As CheckBox = CType(control, CheckBox)
                    box.Checked = False

                    If Not box.Checked Then
                        If (System.Web.Security.Roles.IsUserInRole(Me.txtUserName.Text, box.ID)) = True Then
                            box.Checked = True
                        Else
                            box.Checked = False
                        End If
                    End If
                End If
            Next
        Catch ex As Exception
            Dim errFiltered As String
            errFiltered = (Replace(ex.Message, "'", ""))
            Msg.Text = errFiltered
        Finally
        End Try
    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        Try
            For Each control In CheckBoxRoles.Controls
                If TypeOf control Is CheckBox Then
                    Dim box As CheckBox = CType(control, CheckBox)
                    box.Checked = False
                End If
            Next
            'Me.txtComment.Text = Nothing
            Me.txtEmail.Text = Nothing
            ' Me.txtID.Text = Nothing
        Catch ex As Exception
            Dim errFiltered As String
            errFiltered = (Replace(ex.Message, "'", ""))
            Msg.Text = errFiltered
        Finally
        End Try
    End Sub
    Public Sub PutName()
        'This gets first and last name from IDW database
        Dim conn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sqlStr1 As String
        Dim sqlStr2 As String
        Dim sqlStr3 As String
        Dim sqlStr4 As String
        Dim sqlStr5 As String
        Dim sqlStr6 As String
        Dim emp As String
        emp = Me.NameText.Text
        Dim uName As String
        uName = Me.UserNameText.Text
        Try
            conn.ConnectionString = ConfigurationManager.ConnectionStrings("AvailableHours_aspnetdb_ConnectionString").ConnectionString
            conn.Open()
            cmd.Connection = conn
            sqlStr1 = " UPDATE   [AvailableHours].[dbo].[aspnet_Membership] "
            sqlStr2 = " SET              [Comment] = N'" + emp + "'"
            sqlStr3 = " FROM         [AvailableHours].[dbo].[aspnet_Users] "
            sqlStr4 = " INNER JOIN  [AvailableHours].[dbo].[aspnet_Membership] "
            sqlStr5 = " ON [AvailableHours].[dbo].[aspnet_Users].[UserId] = [AvailableHours].[dbo].[aspnet_Membership].[UserId] "
            sqlStr6 = " Where [AvailableHours].[dbo].[aspnet_Users].[UserName] = N'" + uName + "'"
            cmd.CommandText = (sqlStr1 & sqlStr2 & sqlStr3 & sqlStr4 & sqlStr5 & sqlStr6)
            cmd.CommandType = CommandType.Text
            cmd.ExecuteScalar()
        Catch ex As Exception
        Finally
            If Not IsNothing(cmd) Then cmd.Dispose()
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    Protected Sub Delete_Click(sender As Object, e As EventArgs) Handles Delete.Click
        gbl_Role = RoleTextBox.Text
        Try
            Dim newRole As String
            newRole = Me.RoleTextBox.Text
            If Not Web.Security.Roles.RoleExists(gbl_Role) Then
                Msg.Text = "Role '" & Server.HtmlEncode(gbl_Role) & "' does not exists. Please specify a different role name."
                Return
            End If
            Web.Security.Roles.DeleteRole(newRole)
            Msg.Text = "Role '" & Server.HtmlEncode(gbl_Role) & "' deleted."

            Response.Redirect("CreateUser.aspx")
        Catch ex As Exception
            Msg.Text = "Role '" & Server.HtmlEncode(gbl_Role) & "' <u>not</u> not deleted."
        End Try
    End Sub

    Protected Sub CreateRole_Click(sender As Object, e As EventArgs) Handles CreateRole.Click
        gbl_Role = RoleTextBox.Text
        Try
            Select Case Web.Security.Roles.RoleExists(gbl_Role)
                Case 0
                    Msg.Text = "Role '" & Server.HtmlEncode(gbl_Role) & "' created."
                    Web.Security.Roles.CreateRole(gbl_Role)
                Case 1
                    Msg.Text = "Role '" & Server.HtmlEncode(gbl_Role) & "' already exists. Please specify a different role name."
                Case Else
                    Msg.Text = "Else"
            End Select

            Response.Redirect("CreateUser.aspx")
        Catch ex As Exception
            Msg.Text = "Role '" & Server.HtmlEncode(gbl_Role) & "' <u>not</u> created."
        End Try
    End Sub
    Public Sub Populate()

        Try '


            Dim roles As List(Of String) = New List(Of String)(Web.Security.Roles.GetAllRoles())
            For Each role In roles
                Dim box As CheckBox = New CheckBox()
                box.ID = role
                box.Text = "&nbsp;" & role
                CheckBoxRoles.Controls.Add(box)
                Dim control As LiteralControl = New LiteralControl("<br />")
                CheckBoxRoles.Controls.Add(control)

            Next

        Catch ex As Exception
            Dim errFiltered As String
            errFiltered = (Replace(ex.Message, "'", ""))
            Msg.Text = errFiltered
        Finally
        End Try
    End Sub
End Class