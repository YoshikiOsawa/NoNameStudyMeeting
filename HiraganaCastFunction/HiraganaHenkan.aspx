<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HiraganaHenkan.aspx.cs" Inherits="Osawa_Jishugakushyuu.Class.HiraganaCastFunction.HiraganaHenkan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <thead>
                    <tr>
                        <th>
                            <%--<p>ローマ字を入力してください。</p>--%>
                        </th>
                        <%--<th>→</th>--%>
                        <th>
                          <%--  <p>ひらがな表記</p>--%>
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <tr><td>
                        <asp:Label ID="PathLabel" runat="server" Text=""></asp:Label></td></tr>
                    <tr>
                        <td>
                            <asp:Button ID="FileSelect" runat="server" Text="TEST1テキスト" OnClick="FileSelect_Click" /></td>
                        <td>→</td>
                        <td>
                            <asp:Label ID="HiraganaLabel" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="CastButton" runat="server" Text="TEST2テキスト" OnClick="CastButton_Click" /></td>
                        <td>
                            <asp:Label ID="ErrorLabel" runat="server" Text="" ForeColor="Red"></asp:Label></td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>
