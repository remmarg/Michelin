<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Admin.aspx.vb" Inherits="Michelin.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
                  <p>
          <h3><b>Current User Name:<%=User.Identity.Name%>  <asp:Label ID="Label5" runat="server" Text="Not Logged In"></asp:Label> 
         Existing users: <asp:Label ID="Label4" runat="server"  Text="Not Logged In"></asp:Label>&nbsp;</b></h3>
    </p>
<table class="nav-justified">
<tr>
<td>
    <p><h2> <asp:Label ID="Label1" runat="server" style="float:left" text="Manage Users" /> &nbsp;&nbsp;
    <asp:Label ID="Msg" runat="server" ForeColor="maroon" text="... "/></h2>
</p>
<p><asp:Button ID="Button7" runat="server" CssClass="btn btn-default" Text="Pull Names"  /> </p>   
    <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" Width ="95%"  
                RepeatDirection="Horizontal">
                <asp:ListItem Value="[AÀÁÂÃÄ]%">&nbsp;A</asp:ListItem>
                <asp:ListItem Value="B%">&nbsp;B</asp:ListItem>
                <asp:ListItem Value="[CÇ]%">&nbsp;C</asp:ListItem>
                <asp:ListItem Value="D%">&nbsp;D</asp:ListItem>
                <asp:ListItem Value="[EÈÉÊË]%">&nbsp;E</asp:ListItem>
                <asp:ListItem Value="F%">&nbsp;F</asp:ListItem>
                <asp:ListItem Value="G%">&nbsp;G</asp:ListItem>
                <asp:ListItem Value="H%">&nbsp;H</asp:ListItem>
                <asp:ListItem Value="[IÌÍÎÏ]%">&nbsp;I</asp:ListItem>
                <asp:ListItem Value="J%">&nbsp;J</asp:ListItem>
                <asp:ListItem Value="K%">&nbsp;K</asp:ListItem>
                <asp:ListItem Value="L%">&nbsp;L</asp:ListItem>
                <asp:ListItem Value="M%">&nbsp;M</asp:ListItem>
                <asp:ListItem Value="[NÑ]%">&nbsp;N</asp:ListItem>
                <asp:ListItem Value="[OÒÓÔÕÖ]%">&nbsp;O</asp:ListItem>
                <asp:ListItem Value="P%">&nbsp;P</asp:ListItem>
                <asp:ListItem Value="Q%">&nbsp;Q</asp:ListItem>
                <asp:ListItem Value="R%">&nbsp;R</asp:ListItem>
                <asp:ListItem Value="[SŠ]%">&nbsp;S</asp:ListItem>
                <asp:ListItem Value="T%">&nbsp;T</asp:ListItem>
                <asp:ListItem Value="[UÙÚÛÜ]%">&nbsp;U</asp:ListItem>
                <asp:ListItem Value="V%">&nbsp;V</asp:ListItem>
                <asp:ListItem Value="W%">&nbsp;W</asp:ListItem>
                <asp:ListItem Value="X%">&nbsp;X</asp:ListItem>
                <asp:ListItem Value="[YÝÿ]%">&nbsp;Y</asp:ListItem>
                <asp:ListItem Value="[ZÆØÅ]%">&nbsp;Z</asp:ListItem>
                <asp:ListItem Value="%">&nbsp;All</asp:ListItem>
            </asp:RadioButtonList>

                <div>
                    <asp:Button ID="Button2" runat="server" width= "150px" Text="Delete Member"  associatedcontrol="DropDownList1"  style="float:left"  CssClass="btn btn-default"/>   
                  <asp:DropDownList ID="DropDownList1" runat="server"   CssClass="form-control"   width= "33%" DataSourceID="Membership1" DataTextField="Comment" DataValueField="UserID" AutoPostBack="True"></asp:DropDownList>                  
                      
                </div>  
    <p></p>
                  <p>
                    <asp:Button ID="Button5" width= "150px" runat="server" style="float:left" Text="Update Email" CssClass="btn btn-default" />
                    <asp:TextBox ID="txtEmail" runat="server"  Width ="50%"  CssClass="form-control"></asp:TextBox>
                      <asp:Label ID="labLocked" runat="server" ForeColor="Black" Text="  " Width ="100%" CssClass="col-md-2 control-label"></asp:Label>  
                    
                  </p>
                  <p>
                   <asp:Button ID="Button6"  runat="server" Text="Unlock"  width= "75px" style="float:left" CssClass="btn btn-default"/> <span></span>
                   <asp:Button ID="Button4" runat="server" Text="Lock" visible="true" width= "75px" style="float:left" CssClass="btn btn-default"/>
                      <asp:CheckBox ID="CheckBox1" runat="server" Enabled="true"  CssClass="btn btn-default"  />  
                  </p>
                   <p>
                    
                    <asp:TextBox ID="txtUserName" runat="server" Visible = 'false' Enabled="false" CssClass="col-md-2 control-label"></asp:TextBox> 
                   </p>


    <h2>Create User  </h2>

    <p>
                  
                  <asp:Label ID ="UN" runat="server"  CssClass="col-md-2 control-label" Text="Name" />
                 <span>
                  <asp:TextBox runat="server" id="NameText" ValidationGroup="UserGroup" 
                         TabIndex="1" CssClass="form-control"/>
                 </span>
                 <span>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="NameText" ValidationGroup="UserGroup" 
                      Display="Dynamic" runat="server" style="margin: 0 auto 0 10px; color:Red" ErrorMessage="Field is Required." />
                </span>
 </p>
  <p>
               <asp:Label ID ="CID" runat="server"  CssClass="col-md-2 control-label" Text="Chorus"/>
                <span>
               <asp:TextBox runat="server" id="UserNameText" ValidationGroup="UserGroup" 
                        TabIndex="2" CssClass="form-control"/>
               </span>
               <span>
                    <asp:RequiredFieldValidator ID="UserNameReq" ControlToValidate="UserNameText" ValidationGroup="UserGroup" 
                        Display="Dynamic" runat="server" style="margin: 0 auto 0 10px; color:Red" ErrorMessage="Field is Required." />
               </span>
  </p>  
<p>
    <asp:Label ID ="pwd" runat="server"  CssClass="col-md-2 control-label" Text="Password" />
                <span>
                    <asp:TextBox runat="server" id="PassText" 
                    TextMode="Password" ValidationGroup="UserGroup"  TabIndex="3" CssClass="form-control"/>
                </span>
 
                <span>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="UserGroup" 
                        ControlToValidate="PassText" runat="server" Display="Dynamic" style="margin: 0 auto 0 10px; color:Red" ErrorMessage="Field is Required." />
                    <asp:CompareValidator ID="ComparePasswordsValidator" ValidationGroup="UserGroup" runat="server" 
                        ErrorMessage="Passwords must match!" Display="Dynamic" style="color:red;" ControlToValidate="PassText" ControlToCompare="PassConfirmText" />
                </span>
</p>
<p>
 <asp:Label ID ="CPD" runat="server"  CssClass="col-md-2 control-label" Text="Confirm" />

                <span>
                    <asp:TextBox runat="server" id="PassConfirmText" 
                   TextMode="Password" ValidationGroup="UserGroup"  TabIndex="4" CssClass="form-control" />
                </span>

                <span>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="UserGroup" ControlToValidate="PassConfirmText" Display="Dynamic" runat="server" style="margin: 0 auto 0 10px; color:Red" ErrorMessage="Field is Required." />
                    <asp:CompareValidator ID="CompareValidator1" ValidationGroup="UserGroup" runat="server" ErrorMessage="Passwords must match!" Display="Dynamic" style="color:red;" ControlToValidate="PassConfirmText" ControlToCompare="PassText" />
                </span>

   </p> 
    <p>
 <asp:Label ID ="Email" runat="server"  CssClass="col-md-2 control-label" Text="Email" />        
                <span>
                    <asp:TextBox runat="server" ValidationGroup="UserGroup" id="EmailText" 
                         TabIndex="5" CssClass="form-control" />
                </span>    
                <span>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="UserGroup" ControlToValidate="EmailText" Display="Dynamic" runat="server" style="margin: 0 auto 0 10px; color:Red" ErrorMessage="Field is Required." />
                    <asp:RegularExpressionValidator id="RegularExpressionValidator1" ValidationGroup="UserGroup" runat="server" ControlToValidate="EmailText" style="color:red;margin: 0 auto 0 10px;" Display="Dynamic" ErrorMessage="Email Not Valid" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"/>
                </span>
 </p>
    <p> 
          <asp:Button ID="Button1" runat="server" Text="Create" style="float:left" CssClass="btn btn-default" />
        <asp:CheckBox ID="ActiveUser" runat="server" Text="Active" style="margin:0 auto 0 145px" Checked="true" TabIndex="6" /> </p>

     <h2> Create or Delete Role </h2>
   <p>
    <asp:Button ID="CreateRole" width= "75px" runat="server" Text="Create" style="float:left" CssClass="btn btn-default" />
    <asp:Button ID="Delete" runat="server" width= "75px" Text="Delete" style="float:left" CssClass="btn btn-default" />
    <asp:TextBox ID="RoleTextBox" CssClass="form-control" runat="server"></asp:TextBox>
   </p>   
     </td>
     <td>&nbsp;
                    <div>
                        <br /><asp:Button ID="Button3" runat="server" Text="Apply Role Changes" CssClass="btn btn-default"/></b>
                        <div id="CheckBoxRoles" runat="server"></div>  
                    </div>
     </td>
</tr>
</table>
    <asp:TextBox ID="txtID" runat="server" Enabled="False"  CssClass="col-md-2 control-label" Visible="False"></asp:TextBox>
                        <asp:DropDownList ID="txtApp" runat="server" DataSourceID="Applications" 
                        DataTextField="ApplicationName" DataValueField="ApplicationId" 
                         AutoPostBack="True" Visible="False">
                    </asp:DropDownList>                
    <asp:SqlDataSource ID="Membership1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:AvailableHours_aspnetdb_ConnectionString %>" 
                        SelectCommand="SELECT aspnet_Users.UserName AS UserID, CAST(RIGHT (CAST(aspnet_Membership.Comment AS varchar(8000)), 80) AS nvarchar(80)) AS Comment FROM aspnet_Membership INNER JOIN aspnet_Users ON aspnet_Membership.UserId = aspnet_Users.UserId WHERE (CAST(LEFT (CAST(aspnet_Membership.Comment AS varchar(8000)), 1) AS nvarchar(1)) LIKE @lname) OR (CAST(LEFT (CAST(aspnet_Membership.Comment AS varchar(8000)), 1) AS nvarchar(1)) LIKE ' ') ORDER BY Comment">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="RadioButtonList1" DefaultValue="%" 
                                Name="lname" PropertyName="SelectedValue" />
                        </SelectParameters>
                    </asp:SqlDataSource>

                    <asp:SqlDataSource ID="Applications" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:AvailableHours_aspnetdb_ConnectionString %>" 
                        SelectCommand="SELECT [ApplicationId], [ApplicationName] FROM [vw_aspnet_Applications]">
                    </asp:SqlDataSource>
</asp:Content>
