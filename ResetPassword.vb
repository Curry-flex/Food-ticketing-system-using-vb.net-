Imports System.Data.SqlClient

Public Class ResetPassword
    Dim VAR As Integer
    Dim cmd As New SqlCommand

    Dim con As New SqlConnection("Data Source=CURRYFLEX;Initial Catalog=Food_ticketing;Integrated Security=True")
    Dim da As New SqlDataAdapter
    Dim dt As New DataTable
    Dim reader As SqlDataReader

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim count As Integer
        con.Open()
        Dim query As String
        query = "select *from users  where UID='" & txt1.Text & "' "
        cmd = New SqlCommand(query, con)
        reader = cmd.ExecuteReader

        While reader.Read()
            count = (reader.Item("password"))

        End While
        con.Close()

        If count <> txt3.Text Then

            MessageBox.Show("Incorrect old password")

        Else

            con.Open()

            cmd = con.CreateCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "update users set  password='" & txt4.Text & "'  where UID ='" & txt1.Text & "'"
            cmd.ExecuteNonQuery()
            con.Close()
            MessageBox.Show("updated successfully")
        End If

        txt1.Clear()
        txt3.Clear()
        txt4.Clear()


        Dim id As String = txt1.Text
        Dim old As String = txt3.Text
        Dim neu As String = txt4.Text

        'If id.Trim.Equals("") Or old.Trim.Equals("") Or neu.Trim.Equals("") Then
        'MessageBox.Show("Fill all requried field", "Required field", MessageBoxButtons.OK, MessageBoxIcon.Error)

        'ElseIf txt3.Text <> txt4.Text Then

        'MessageBox.Show("Not Matching", "Miss Match", MessageBoxButtons.OK, MessageBoxIcon.Error)

        'Else




        'End If



    End Sub

    Private Sub ResetPassword_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim ss As New Cashier
        ss.Show()
        Me.Hide()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Application.Exit()


    End Sub
End Class