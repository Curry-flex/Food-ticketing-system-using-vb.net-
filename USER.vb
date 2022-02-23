Imports System.Data.SqlClient

Public Class USER
    Dim VAR As Integer
    Dim cmd As New SqlCommand

    Dim con As New SqlConnection("Data Source=DESKTOP-GJACM0V\CURRYSQL;Initial Catalog=Food_ticketing_System;Integrated Security=True")
    Dim da As New SqlDataAdapter
    Dim dt As New DataTable
    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Application.Exit()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim ulevel As String = combo1.Text
        Dim uname As String = txt1.Text
        Dim password As String = txt2.Text




        If ulevel.Trim.Equals("") Or uname.Trim.Equals("") Or password.Trim.Equals("") Then

            MessageBox.Show("Missing field", "Add field", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else


            con.Open()

            cmd = con.CreateCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "insert into users values('" & combo1.Text & "','" & txt1.Text & "','" & txt2.Text & "')"
            cmd.ExecuteNonQuery()
            con.Close()

            MessageBox.Show("Data inserted succesfully")
            txt1.Clear()
            txt2.Clear()
            combo1.Text = ""
            txt1.Clear()
            txt2.Clear()




        End If

    End Sub

    Private Sub USER_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Public Sub display()
        con.Open()

        cmd = con.CreateCommand()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "select uid,userlevel,username from users"
        cmd.ExecuteNonQuery()
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter(cmd)
        da.Fill(dt)
        grid.DataSource = dt

        con.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        display()

    End Sub

    Private Sub grid_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles grid.CellClick
        Try


            con.Open()
            Dim i As Integer


            i = Convert.ToInt32(grid.SelectedCells.Item(0).Value.ToString())

            cmd = con.CreateCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "select * from users where UID =" & i & ""
            cmd.ExecuteNonQuery()

            Dim dt As New DataTable
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(dt)

            Dim dr As SqlClient.SqlDataReader

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)

            While dr.Read

                txt3.Text = dr.GetInt32(0).ToString

                combo1.Text = dr.GetString(1).ToString()


                txt1.Text = dr.GetString(2).ToString







            End While


        Catch ex As Exception

        End Try


        con.Close()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        If txt3.Text = "" Then
            MessageBox.Show("Provide ID delete", "ID", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            con.Open()

            cmd = con.CreateCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "delete from users where UID= '" + txt3.Text + "'"
            cmd.ExecuteNonQuery()

            con.Close()
            MessageBox.Show("Record deleted succcessfully")
            display()
        End If



    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        txt1.Clear()
        txt2.Clear()
        txt3.Clear()
        combo1.Text = ""
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim ulevel As String = combo1.Text
        Dim uname As String = txt1.Text
        Dim password As String = txt2.Text

        If ulevel.Trim.Equals("") Or uname.Trim.Equals("") Or password.Trim.Equals("") Then

            MessageBox.Show("Enter field to delete", "Add field", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Else

            con.Open()

            cmd = con.CreateCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "update users set username='" & txt1.Text & "' , userlevel='" & combo1.Text & "', password='" & txt2.Text & "'  where UID ='" & txt3.Text & "'"
            cmd.ExecuteNonQuery()
            con.Close()
            MessageBox.Show("Record updated successfully")
            display()
        End If




    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim ss As New AdminPanel
        ss.Show()
        Me.Hide()

    End Sub

    Private Sub grid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grid.CellContentClick

    End Sub

    Private Sub txt3_TextChanged(sender As Object, e As EventArgs) Handles txt3.TextChanged

    End Sub
End Class