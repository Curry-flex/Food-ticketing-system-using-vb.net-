
Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Public Class Getreport
    Dim con As New SqlConnection("Data Source=CURRYFLEX;Initial Catalog=Food_ticketing;Integrated Security=True")
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim rptds As ReportDataSource
            ReportViewer1.RefreshReport()
            With ReportViewer1.LocalReport
                .ReportPath = Application.StartupPath & "\Report\paymentReport.rdlc"
                .DataSources.Clear()

            End With

            Dim ds As New DataSet1

            Dim da As New SqlDataAdapter
            con.Open()
            da.SelectCommand = New SqlCommand("select foodname,price,quantity,total,paydate from payment where paydate between '" & date1.Value.ToString("yyyy-MM-dd") & "' and '" & date2.Value.ToString("yyyy-MM-dd") & "' ", con)
            da.Fill(ds.Tables("payment"))

            rptds = New ReportDataSource("DataSet1", ds.Tables("payment"))
            ReportViewer1.LocalReport.DataSources.Add(rptds)
            ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
            ReportViewer1.ZoomMode = ZoomMode.Percent
            ReportViewer1.ZoomPercent = 100

            con.Close()


        Catch ex As Exception

            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub ReportViewer1_Load(sender As Object, e As EventArgs) Handles ReportViewer1.Load

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim ss As New ResetPassword
        ss.Show()
        Me.Hide()


    End Sub

    Private Sub date2_ValueChanged(sender As Object, e As EventArgs) Handles date2.ValueChanged

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub date1_ValueChanged(sender As Object, e As EventArgs) Handles date1.ValueChanged

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub Getreport_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim rptds As ReportDataSource
            ReportViewer1.RefreshReport()
            With ReportViewer1.LocalReport
                .ReportPath = Application.StartupPath & "\Report\foodreport1.rdlc"
                .DataSources.Clear()

            End With

            Dim ds As New DataSet1

            Dim da As New SqlDataAdapter
            con.Open()
            da.SelectCommand = New SqlCommand("select food_name,price,quantity,food_type,category,date_added from food where date_added between '" & date1.Value.ToString("yyyy-MM-dd") & "' and '" & date2.Value.ToString("yyyy-MM-dd") & "' ", con)
            da.Fill(ds.Tables("food"))

            rptds = New ReportDataSource("DataSet1", ds.Tables("food"))
            ReportViewer1.LocalReport.DataSources.Add(rptds)
            ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
            ReportViewer1.ZoomMode = ZoomMode.Percent
            ReportViewer1.ZoomPercent = 100

            con.Close()


        Catch ex As Exception

            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim ss As New Form1
        ss.Show()
        Me.Hide()

    End Sub
End Class