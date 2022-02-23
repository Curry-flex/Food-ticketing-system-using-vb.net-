Imports System.Data.SqlClient

Public Class FOOD
    Dim VAR As Integer
    Dim cmd As New SqlCommand

    Dim con As New SqlConnection("Data Source=DESKTOP-GJACM0V\CURRYSQL;Initial Catalog=Food_ticketing_System;Integrated Security=True")
    Dim da As New SqlDataAdapter
    Dim dt As New DataTable

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Application.Exit()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Dim food As String = txt1.Text
        Dim price As String = txt2.Text
        Dim type As String = combo1.Text
        Dim cat As String = combo2.Text
        con.Open()

        If food.Trim.Equals("") Or price.Trim.Equals("") Or type.Trim.Equals("") Or cat.Trim.Equals("") Then

            MessageBox.Show("Missing field", "Add field", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else



            cmd = con.CreateCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "insert into food values('" & txt1.Text & "','" & txt2.Text & "','" & txt3.Text & "','" & combo1.Text & "','" & combo2.Text & "' ,'" + datepicker.Text + "')"
            cmd.ExecuteNonQuery()
            MessageBox.Show("Data inserted succesfully")
            txt1.Clear()
            txt2.Clear()
            txt3.Clear()

            combo1.Text = ""
            combo2.Text = ""



        End If
        con.Close()
    End Sub
    Public Sub display()
        con.Open()

        cmd = con.CreateCommand()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "select *from food"
        cmd.ExecuteNonQuery()
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter(cmd)
        da.Fill(dt)
        grid.DataSource = dt

        con.Close()
    End Sub

    Private Sub FOOD_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        display()

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim food As String = txt1.Text
        Dim price As String = txt2.Text
        Dim type As String = combo1.Text
        Dim cat As String = combo2.Text
        If txt4.Text = "" Then
            MessageBox.Show("Provide ID delete", "ID", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Else
            con.Open()

            cmd = con.CreateCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "delete from food where foodID = '" + txt4.Text + "'"
            cmd.ExecuteNonQuery()

            con.Close()
            MessageBox.Show("Record deleted succcessfully")
            display()
        End If

    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles grid.CellClick
        Try


            con.Open()
            Dim i As Integer


            i = Convert.ToInt32(grid.SelectedCells.Item(0).Value.ToString())

            cmd = con.CreateCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "select * from food where foodID =" & i & ""
            cmd.ExecuteNonQuery()

            Dim dt As New DataTable
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(dt)

            Dim dr As SqlClient.SqlDataReader

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)

            While dr.Read

                txt4.Text = dr.GetInt32(0).ToString




                txt1.Text = dr.GetString(1).ToString()
                txt2.Text = dr.GetInt32(2).ToString()

                txt3.Text = dr.GetInt32(3).ToString()

                combo1.Text = dr.GetString(4).ToString()
                combo2.Text = dr.GetString(5).ToString()



            End While


        Catch ex As Exception

        End Try


        con.Close()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim food As String = txt1.Text
        Dim price As String = txt2.Text
        Dim type As String = combo1.Text
        Dim cat As String = combo2.Text

        If FOOD.Trim.Equals("") Or price.Trim.Equals("") Or Type.Trim.Equals("") Or cat.Trim.Equals("") Then

            MessageBox.Show("Enter field to update", "Add field", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            con.Open()

            cmd = con.CreateCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "update food set food_name='" & txt1.Text & "' , price='" & txt2.Text & "', quantity='" & txt3.Text & "' , food_type ='" & combo1.Text & "',category='" & combo2.Text & "' where foodID ='" & txt4.Text & "'"
            cmd.ExecuteNonQuery()
            con.Close()
            MessageBox.Show("Record updated successfully")
            display()
        End If



    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        txt1.Clear()
        txt2.Clear()
        txt3.Clear()
        txt4.Clear()
        combo1.Text = ""
        combo2.Text = ""

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim ss As New AdminPanel
        ss.Show()
        Me.Hide()

    End Sub

    Private Sub grid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grid.CellContentClick

    End Sub
End Class