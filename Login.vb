Imports System.Data.SqlClient

Public Class Form1
    Dim VAR As Integer
    Dim cmd As New SqlCommand

    Dim con As New SqlConnection("Data Source=DESKTOP-GJACM0V\CURRYSQL;Initial Catalog=Food_ticketing_System;Integrated Security=True")
    Dim da As New SqlDataAdapter
    Dim dt As New DataTable
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Application.Exit()

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        con.Open()
        Dim sql As String = "select *from users where username='" + txt1.Text + "' and password='" + txt2.Text + "' and userlevel='" + combo1.Text + "'"
        cmd = con.CreateCommand()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
        con.Close()

        da = New SqlDataAdapter(cmd)
        dt = New DataTable()

        da.Fill(dt)

        If dt.Rows.Count() >= 1 And combo1.Text = "Admin" Then

            Dim ss As New AdminPanel




            ss.Show()
            Me.Hide()

        ElseIf dt.Rows.Count() >= 1 And combo1.Text = "Cashier" Then

            Dim ss As New Cashier
            ss.Show()
            Me.Hide()

        ElseIf dt.Rows.Count() >= 1 And combo1.Text = "Manager" Then

            Dim xx As New Getreport

            xx.Show()


            Me.Hide()


        Else
            MessageBox.Show("Incorrect")


        End If

    End Sub
End Class
