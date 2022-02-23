Imports System.Data.SqlClient

Public Class Cashier
    Dim con As SqlConnection
    Dim table As New DataTable("Table")
    Dim cmd As New SqlCommand
    Dim reader As SqlDataReader


    Private Sub Cashier_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        table.Columns.Add("Description", Type.GetType("System.String"))
        table.Columns.Add("Price", Type.GetType("System.Int32"))
        table.Columns.Add("Qunatity", Type.GetType("System.Int32"))
        table.Columns.Add("Total", Type.GetType("System.Int32"))

        grid.DataSource = table

        con = New SqlConnection

        con.ConnectionString = "Data Source=DESKTOP-GJACM0V\CURRYSQL;Initial Catalog=Food_ticketing_System;Integrated Security=True"
        Dim reader As SqlDataReader

        Try
            con.Open()
            Dim query As String
            query = "select * from food where Quantity >= 1"
            cmd = New SqlCommand(query, con)
            reader = cmd.ExecuteReader

            While reader.Read()
                ListBox1.Items.Add(reader.Item("food_name"))
                ' Dim sname = reader.GetString("category")
                'Dim xx As Integer = Integer.Parse(sname)
                ' ListBox1.Items.Add(foodname)

            End While
            con.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        con = New SqlConnection

        con.ConnectionString = "Data Source=DESKTOP-GJACM0V\CURRYSQL;Initial Catalog=Food_ticketing_System;Integrated Security=True"
        Dim reader As SqlDataReader

        Try
            con.Open()
            Dim query As String
            query = "select * from food where food_name ='" & ListBox1.Text & "'"
            cmd = New SqlCommand(query, con)
            reader = cmd.ExecuteReader

            While reader.Read()
                txt1.Text = reader.Item("food_name")
                txt2.Text = reader.Item("price")




            End While
            con.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub calculate()

        Try
            txt4.Text = txt2.Text * txt3.Text
        Catch ex As Exception

        End Try


    End Sub

    Private Sub txt2_TextChanged(sender As Object, e As EventArgs) Handles txt2.TextChanged
        calculate()
    End Sub

    Private Sub txt3_TextChanged(sender As Object, e As EventArgs) Handles txt3.TextChanged
        calculate()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Application.Exit()
    End Sub

    Private Sub combo1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim count As Integer = 0
        con.Open()
        Dim query As String
        query = "select * from food  where food_name='" & txt1.Text & "' "
        cmd = New SqlCommand(query, con)
        reader = cmd.ExecuteReader

        While reader.Read()
            count = Convert.ToInt32(reader.Item("Quantity"))

        End While
        con.Close()

        If count >= txt3.Text Then
            ' Dim food As String = txt1.Text
            '  Dim price As String = txt2.Text
            ' Dim qunt As String = txt3.Text
            ' Dim total As String = txt3.Text

            con.Open()

            ' If food.Trim.Equals("") Or price.Trim.Equals("") Or qunt.Trim.Equals("") Or total.Trim.Equals("") Then

            ' MessageBox.Show("Missing field", "Add field", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ' Else


            cmd = con.CreateCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "insert into payment values('" + txtinvoice.Text + "','" & txt1.Text & "','" & txt2.Text & "','" & txt3.Text & "','" & txt4.Text & "','" + Datepicker.Text + "')"
            cmd.ExecuteNonQuery()

            table.Rows.Add(txt1.Text, txt2.Text, txt3.Text, txt4.Text)
            grid.DataSource = table
            con.Close()

            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "update food set quantity =quantity- '" + txt3.Text + "'"
            cmd.ExecuteNonQuery()

            con.Close()

        Else
            MessageBox.Show("food not available")
        End If



        Dim colsum As Integer

        For Each R As DataGridViewRow In grid.Rows
            colsum += R.Cells(3).Value

        Next

        txtcost.Text = colsum





        ' Dim dt As New DataTable
        'Dim dr As DataRow
        'dt.Columns.Add("Description")
        'dt.Columns.Add("Price")
        'dt.Columns.Add("Quantity")
        'dt.Columns.Add("Total")
        ' dr = dt.NewRow()
        ' dr("description") = txt1.Text
        ' dr("price") = txt2.Text
        'dr("quantity") = txt3.Text
        'dr("total") = txt4.Text
        'dt.Rows.Add(dr)
        'grid.DataSource = dt

        con.Close()
        txt1.Clear()
        txt2.Clear()
        txt3.Clear()
        txt4.Clear()

        display()
    End Sub
    Public Sub display()




    End Sub

    Private Sub grid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grid.CellContentClick

    End Sub

    Private Sub grid_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles grid.CellClick
        Dim index As Integer
        index = e.RowIndex
        Dim selecteRow As DataGridViewRow
        selecteRow = grid.Rows(index)
        txt1.Text = selecteRow.Cells(0).Value.ToString()
        txt2.Text = selecteRow.Cells(1).Value.ToString()
        txt3.Text = selecteRow.Cells(2).Value.ToString()
        txt4.Text = selecteRow.Cells(3).Value.ToString()





    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim index As Integer
        index = grid.CurrentCell.RowIndex
        grid.Rows.RemoveAt(index)


    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim ss As New Form1
        ss.Show()
        Me.Hide()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim ss As New ResetPassword
        ss.Show()
        Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        With Myreport



            .loadBiiling("select foodname,price,quantity,total from payment where invoiceNO=' " + txtinvoice.Text + "'")
            .ShowDialog()


        End With
    End Sub
End Class